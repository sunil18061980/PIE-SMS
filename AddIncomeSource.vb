Imports System.Data.Common
Imports System.Data.SQLite
Imports System.Data.SqlTypes
Imports System.Security.Cryptography.X509Certificates

Public Class AddIncomeSource
    Public EditRecord As Boolean = False
    Private Sub AddIncomeSource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Mask = "00/00/0000"
        MaskedTextBox1.ValidatingType = GetType(Date)
        If UserSession.IsLoggedIn Then
            Me.Text += $"                                      Welcome, {UserSession.UserName} [{UserSession.UserID}] !"

        Else
            MessageBox.Show("No user is currently logged in. Please log in to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If
        SourceListShow()
    End Sub

    ' Function to show Source Name in the list box
    Sub SourceListShow()
        Try
            Dim SelectSource As String = TextBox11.Text.Trim()

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String

                If String.IsNullOrWhiteSpace(SelectSource) Then
                    ' If textbox is empty → load all
                    sql = "SELECT INC_S_NAME 
               FROM INCOME_SOURCE 
               WHERE INC_S_STATUS = 'True'
               ORDER BY INC_S_NAME"
                Else
                    ' If textbox has text → load matching names
                    sql = "SELECT INC_S_NAME 
               FROM INCOME_SOURCE 
               WHERE INC_S_STATUS = 'True'
                 AND INC_S_NAME LIKE @name
               ORDER BY INC_S_NAME"
                End If

                Using cmd As New SQLiteCommand(sql, conn)

                    If Not String.IsNullOrWhiteSpace(SelectSource) Then
                        cmd.Parameters.AddWithValue("@name", "%" & SelectSource & "%")
                    End If

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        ListBox1.Items.Clear()

                        If Boolean.Parse(reader.HasRows.ToString()) = False Then
                            ListBox1.Items.Add("No Matching Source Found")
                        End If

                        While reader.Read()
                            ListBox1.Items.Add(reader("INC_S_NAME").ToString())
                        End While
                    End Using

                End Using
            End Using


        Catch ex As Exception
            MessageBox.Show("Error loading income sources: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        login.Show()
    End Sub
    '  Function to restrict access to certain features based on user role, 
    ' Add new source code with allowed user roles and make textboxes readonly for unauthorized users
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim role As Integer = UserSession.UserRole
        If role = 4 Or role = 5 Then

            ListBox1.Enabled = False
            Button8.Enabled = False
            Dim textBoxes As String() = {
             "TextBox2", "TextBox3", "TextBox4", "TextBox5",
             "TextBox6", "TextBox7", "TextBox8", "TextBox9", "TextBox10", "TextBox12"}

            For Each ctrl As Control In Panel1.Controls
                If TypeOf ctrl Is TextBox Then
                    Dim tb As TextBox = DirectCast(ctrl, TextBox)
                    tb.ReadOnly = False
                    tb.Clear()
                End If
            Next



            ' enable date and save button
            Button2.Enabled = True
            MaskedTextBox1.ReadOnly = False

            'set new source code for textbox1  
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT IFNULL(MAX(INC_S_CODE), 100) + 1 FROM INCOME_SOURCE"
                Using cmd As New SQLiteCommand(sql, conn)
                    Dim newSourceCode As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    TextBox1.Text = newSourceCode.ToString()
                End Using
            End Using

        Else
            MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Sub SaveSource()
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Dim sql As String = "INSERT INTO INCOME_SOURCE 
            (INC_S_CODE, INC_S_NAME, INC_S_ADDRESS, INC_S_PERSON, INC_S_DESIGNATION,
            INC_S_CONTACT, INC_S_MOBILE, INC_S_REF, INC_S_REMARKS, INC_S_ST_DATE,
            INC_S_EMAIL, INC_S_WEBSITE, INC_S_STATUS) VALUES 
            (@code, @name, @address, @person, @design, @contact, @mobile, @ref, @remarks, @start_date,
            @email, @website, @status)"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim d As Date = Date.ParseExact(
                MaskedTextBox1.Text, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)

                cmd.Parameters.AddWithValue("@code", TextBox1.Text)
                cmd.Parameters.AddWithValue("@name", TextBox2.Text)
                cmd.Parameters.AddWithValue("@address", TextBox3.Text)
                cmd.Parameters.AddWithValue("@person", TextBox4.Text)
                cmd.Parameters.AddWithValue("@design", TextBox5.Text)
                cmd.Parameters.AddWithValue("@contact", TextBox7.Text)
                cmd.Parameters.AddWithValue("@mobile", TextBox6.Text)
                cmd.Parameters.AddWithValue("@ref", TextBox10.Text)
                cmd.Parameters.AddWithValue("@remarks", TextBox12.Text)
                cmd.Parameters.AddWithValue("@start_date", d.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@email", TextBox8.Text)
                cmd.Parameters.AddWithValue("@website", TextBox9.Text)
                cmd.Parameters.AddWithValue("@status", "True")
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'check all required fields are filled
        If String.IsNullOrWhiteSpace(TextBox1.Text) Or String.IsNullOrWhiteSpace(TextBox2.Text) Or String.IsNullOrWhiteSpace(MaskedTextBox1.Text) Then
            MessageBox.Show("Please fill in all required fields (Source Code, Source Name, Start Date).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'check if start date is valid
        Dim startDate As Date
        If Not Date.TryParseExact(MaskedTextBox1.Text, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, startDate) Then
            MessageBox.Show("Please enter a valid start date in the format dd/MM/yyyy.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If EditRecord = False Then
            'check if source code already exists

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT COUNT(*) FROM INCOME_SOURCE WHERE INC_S_CODE = @code"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@code", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Source code already exists. Please use a different code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using



            'check if source name already exists
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT COUNT(*) FROM INCOME_SOURCE WHERE INC_S_NAME = @name"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", TextBox2.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Source name already exists. Please use a different name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

        End If
        If EditRecord = True Then
            modifyRecord()
            Return
        End If
        ' After all validations, save the source
        SaveSource()
        MessageBox.Show("Income source added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Clear form for next entry

        ResetAll()
    End Sub


    ' to modify the record of selected source, update the record in database and refresh the listbox
    Public Sub modifyRecord()
        ' check if source name is changed and if it already exists in database
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = ("SELECT COUNT(*) FROM INCOME_SOURCE WHERE INC_S_NAME = @name AND INC_S_CODE != @code")
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@code", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Source name already exists. Please use a different name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            ' Update the record in database
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "UPDATE INCOME_SOURCE SET 
                INC_S_NAME = @name, 
                INC_S_ADDRESS = @address, 
                INC_S_PERSON = @person, 
                INC_S_DESIGNATION = @design, 
                INC_S_CONTACT = @contact, 
                INC_S_MOBILE = @mobile, 
                INC_S_REF = @ref, 
                INC_S_REMARKS = @remarks, 
                INC_S_ST_DATE = @start_date,
                INC_S_EMAIL = @email,
                INC_S_WEBSITE = @website
                WHERE INC_S_CODE = @code"
                Using cmd As New SQLiteCommand(sql, conn)
                    Dim d As Date = Date.ParseExact(
                    MaskedTextBox1.Text, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    cmd.Parameters.AddWithValue("@code", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@name", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@address", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@person", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@design", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@contact", TextBox7.Text)
                    cmd.Parameters.AddWithValue("@mobile", TextBox6.Text)
                    cmd.Parameters.AddWithValue("@ref", TextBox10.Text)
                    cmd.Parameters.AddWithValue("@remarks", TextBox12.Text)
                    cmd.Parameters.AddWithValue("@start_date", d.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@email", TextBox8.Text)
                    cmd.Parameters.AddWithValue("@website", TextBox9.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Income source updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error updating source: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel2.Visible = False
        Panel1.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = True
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT INC_S_CODE, INC_S_NAME FROM INCOME_SOURCE"
                Using cmd As New SQLiteCommand(sql, conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        ComboBox1.Items.Clear()
                        While reader.Read()
                            ComboBox1.Items.Add(reader("INC_S_NAME").ToString())
                        End While
                    End Using
                End Using
                Dim sql2 As String = "SELECT USERID FROM USERDATA"
                Using cmd2 As New SQLiteCommand(sql2, conn)
                    Using reader2 As SQLiteDataReader = cmd2.ExecuteReader()
                        ComboBox2.Items.Clear()
                        While reader2.Read()
                            ComboBox2.Items.Add(reader2("USERID").ToString())
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Panel2.Visible = True
        Panel1.Visible = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Load selected source details into textboxes for viewing or editing
        If ListBox1.SelectedItem Is Nothing Then
            Return
        End If
        Dim selectedName As String = ListBox1.SelectedItem.ToString()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT * FROM INCOME_SOURCE WHERE INC_S_NAME = @name"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", selectedName)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox1.Text = reader("INC_S_CODE").ToString()
                            TextBox2.Text = reader("INC_S_NAME").ToString()
                            TextBox3.Text = reader("INC_S_ADDRESS").ToString()
                            TextBox4.Text = reader("INC_S_PERSON").ToString()
                            TextBox5.Text = reader("INC_S_DESIGNATION").ToString()
                            TextBox6.Text = reader("INC_S_MOBILE").ToString()
                            TextBox7.Text = reader("INC_S_CONTACT").ToString()
                            TextBox8.Text = reader("INC_S_EMAIL").ToString()
                            TextBox9.Text = reader("INC_S_WEBSITE").ToString()
                            TextBox10.Text = reader("INC_S_REF").ToString()
                            TextBox12.Text = reader("INC_S_REMARKS").ToString()
                            Dim startDate As Date
                            If Date.TryParse(reader("INC_S_ST_DATE").ToString(), startDate) Then
                                MaskedTextBox1.Text = startDate.ToString("dd-MM-yyyy")
                            End If
                        End If
                        Button8.Enabled = True
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading source details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ResetAll()
    End Sub

    Private Sub ResetAll()
        Panel1.Visible = False
        Panel2.Visible = False
        Panel4.Visible = False
        Panel3.Visible = True

        Dim textBoxes As String() = {
             "TextBox1", "TextBox2", "TextBox3", "TextBox4", "TextBox5",
             "TextBox6", "TextBox7", "TextBox8", "TextBox9", "TextBox10", "TextBox12"}

        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = DirectCast(ctrl, TextBox)
                tb.ReadOnly = True
                tb.Clear()
            End If
        Next

        TextBox11.Enabled = True
        TextBox11.ReadOnly = False
        MaskedTextBox1.Clear()
        SourceListShow()
        Button2.Enabled = False
        ListBox1.Enabled = True
        Button8.Enabled = False
        MaskedTextBox1.ReadOnly = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Text box text is not empty or white space 
        If String.IsNullOrWhiteSpace(TextBox11.Text) Then
            MessageBox.Show("No Name Entered, showing All.", "No Input ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        SourceListShow()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("No source selected to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If UserSession.UserRole = 4 Or UserSession.UserRole = 5 Then
            ListBox1.Enabled = False
            Button8.Enabled = False
            Dim textBoxes As String() = {
             "TextBox2", "TextBox3", "TextBox4", "TextBox5",
             "TextBox6", "TextBox7", "TextBox8", "TextBox9", "TextBox10", "TextBox12"}

            For Each ctrl As Control In Panel1.Controls
                If TypeOf ctrl Is TextBox Then
                    Dim tb As TextBox = DirectCast(ctrl, TextBox)
                    tb.ReadOnly = False
                End If
            Next
            EditRecord = True
            Button2.Enabled = True
        Else
            MessageBox.Show("You do not have permission to edit this record.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Please select both source and user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If STARTDATE.Value = Nothing OrElse SCHEDULEDATE.Value = Nothing Then
            MessageBox.Show("Please select a valid start date and Payment Schedule Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If STARTDATE.Value > SCHEDULEDATE.Value Then
            MessageBox.Show("Start date cannot be after Payment Schedule Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            ' GET USERCODE AND SOURCE CODE FOR SELECTED USER AND SOURCE NAME
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql3 As String = "SELECT USERCODE FROM USERDATA WHERE USERID = @user"
                Dim sql4 As String = "SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @source"
                Dim userCode As String = ""
                Dim sourceCode As String = ""
                Using cmd3 As New SQLiteCommand(sql3, conn)
                    cmd3.Parameters.AddWithValue("@user", ComboBox2.Text)
                    userCode = Convert.ToString(cmd3.ExecuteScalar())
                End Using
                Using cmd4 As New SQLiteCommand(sql4, conn)
                    cmd4.Parameters.AddWithValue("@source", ComboBox1.Text)
                    sourceCode = Convert.ToString(cmd4.ExecuteScalar())
                End Using

                ' Return if either user code or source code is not found (should not happen if dropdowns are populated correctly)
                If userCode = "" Or sourceCode = "" Then
                    MessageBox.Show("Invalid user or source selection.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                'check if same user access already exists for the source
                Dim sql1 As String = "SELECT COUNT(*) FROM USER_INCOME_SOURCE WHERE INC_S_CODE = @source AND USERCODE = @user"
                Using cmd1 As New SQLiteCommand(sql1, conn)
                    cmd1.Parameters.AddWithValue("@source", sourceCode)
                    cmd1.Parameters.AddWithValue("@user", userCode)
                    Dim count As Integer = Convert.ToInt32(cmd1.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This user already has access to the selected source.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Make sure no field is empty before inserting
                If STARTDATE.Value = Nothing Then
                    MessageBox.Show("Please select a valid start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                If FIXAMOUNT.Text = Nothing Then
                    MessageBox.Show("Please enter a valid fixed amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                If SCHEDULE.Text = Nothing Then
                    MessageBox.Show("Please enter a valid schedule.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                If SCHEDULEDATE.Value = Nothing Or SCHEDULEDATE.Value < STARTDATE.Value Then
                    MessageBox.Show("Please select a valid schedule date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                'If all is okay insert the access record
                Dim sql2 As String = "INSERT INTO USER_INCOME_SOURCE (USERCODE, INC_S_CODE, START_DATE, FIXED_AMOUNT, PAYMENT_SCHEDULE, NEXT_PAYMENT_DATE, STATUS) VALUES (@user, @source, @start_date, @fixed_amount, @schedule, @schedule_date, @status)"
                Using cmd2 As New SQLiteCommand(sql2, conn)
                    cmd2.Parameters.AddWithValue("@user", userCode)
                    cmd2.Parameters.AddWithValue("@source", sourceCode)
                    cmd2.Parameters.AddWithValue("@start_date", STARTDATE.Value.ToString("yyyy-MM-dd"))
                    cmd2.Parameters.AddWithValue("@fixed_amount", Convert.ToInt32(FIXAMOUNT.Text))
                    cmd2.Parameters.AddWithValue("@schedule", SCHEDULE.Text)
                    cmd2.Parameters.AddWithValue("@schedule_date", SCHEDULEDATE.Value.ToString("yyyy-MM-dd"))
                    cmd2.Parameters.AddWithValue("@status", True)
                    cmd2.ExecuteNonQuery()
                End Using



            End Using

            MessageBox.Show("Access granted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetAll()
        Catch ex As Exception
            MessageBox.Show("Error granting access: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Panel1.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT USERID FROM USERDATA"
                Dim sql2 As String = "SELECT INC_S_NAME FROM INCOME_SOURCE"
                Using cmd As New SQLiteCommand(sql, conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        USERNAME.Items.Clear()
                        While reader.Read()
                            USERNAME.Items.Add(reader("USERID").ToString())
                        End While
                    End Using
                End Using
                Using cmd1 As New SQLiteCommand(sql2, conn)
                    Using reader1 As SQLiteDataReader = cmd1.ExecuteReader()
                        SOURCENAME.Items.Clear()
                        While reader1.Read()
                            SOURCENAME.Items.Add(reader1("INC_S_NAME").ToString())
                        End While
                    End Using
                End Using

            End Using

            Button10.Enabled = True
            Panel4.Visible = True
            Label30.Visible = False
            DateTimePicker3.Visible = False
            USERNAME.Enabled = True
            SOURCENAME.Enabled = True


            Button11.Visible = False
            Button12.Visible = False

            Label25.Visible = False
            Label26.Visible = False
            Label27.Visible = False
            Label28.Visible = False
            Label29.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            TextBox13.Visible = False
            TextBox14.Visible = False
            TextBox15.Visible = False
            Button12.Visible = False


        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If USERNAME.Text = "" OrElse SOURCENAME.Text = "" Then
            MessageBox.Show("Please select both user and source.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT USERCODE FROM USERDATA WHERE USERID = @user"
                Dim sql2 As String = "SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @source"
                Dim userCode As String = ""
                Dim sourceCode As String = ""
                Dim accessCount As Integer = 0
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@user", USERNAME.Text)
                    userCode = Convert.ToString(cmd.ExecuteScalar())
                End Using
                Using cmd As New SQLiteCommand(sql2, conn)
                    cmd.Parameters.AddWithValue("@source", SOURCENAME.Text)
                    sourceCode = Convert.ToString(cmd.ExecuteScalar())
                End Using
                Dim sql3 As String = "SELECT COUNT(*) FROM USER_INCOME_SOURCE WHERE USERCODE = @user AND INC_S_CODE = @source"
                Using cmd As New SQLiteCommand(sql3, conn)
                    cmd.Parameters.AddWithValue("@user", userCode)
                    cmd.Parameters.AddWithValue("@source", sourceCode)
                    accessCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                If accessCount = 0 Then
                    MessageBox.Show("This user does not have access to the selected source.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim sql4 As String = "SELECT * FROM USER_INCOME_SOURCE WHERE USERCODE = @user AND INC_S_CODE = @source"
                Using cmd As New SQLiteCommand(sql4, conn)
                    cmd.Parameters.AddWithValue("@user", userCode)
                    cmd.Parameters.AddWithValue("@source", sourceCode)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then

                            DateTimePicker1.Value = Convert.ToDateTime(reader("START_DATE"))
                            DateTimePicker2.Value = Convert.ToDateTime(reader("NEXT_PAYMENT_DATE"))
                            DateTimePicker3.Value = Convert.ToDateTime(reader("NEXT_PAYMENT_DATE"))
                            TextBox13.Text = reader("FIXED_AMOUNT").ToString()
                            TextBox15.Text = reader("PAYMENT_SCHEDULE").ToString()
                            If reader("STATUS").ToString() = "True" Then
                                TextBox14.Text = "True"

                            Else
                                TextBox14.Text = "False"
                                MessageBox.Show("This user has De-activate access to the selected source. Reactivate Source using RE-ACTIVATE Button ", "Access Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return

                            End If
                        End If
                    End Using
                End Using

            End Using
            USERNAME.Enabled = False
            SOURCENAME.Enabled = False
            Button10.Enabled = False
            Button11.Visible = True
            Button12.Visible = True

            Label25.Visible = True
            Label26.Visible = True
            Label27.Visible = True
            Label28.Visible = True
            Label29.Visible = True
            DateTimePicker1.Visible = True
            DateTimePicker2.Visible = True
            TextBox13.Visible = True
            TextBox14.Visible = True
            TextBox15.Visible = True
            Button12.Visible = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        DateTimePicker3.Visible = True
        Label30.Visible = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If DateTimePicker3.Visible = True AndAlso DateTimePicker3.Value <= DateTimePicker1.Value Then
            MessageBox.Show("Please select a valid Exit date, It Can't be before start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            MessageBox.Show("Next payment date can't be before start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "UPDATE USER_INCOME_SOURCE SET 
                START_DATE = @start_date, 
                FIXED_AMOUNT = @fixed_amount, 
                PAYMENT_SCHEDULE = @schedule, 
                NEXT_PAYMENT_DATE = @next_payment_date, 
                STATUS = @status,
                END_DATE = @exit_date
                WHERE USERCODE = (SELECT USERCODE FROM USERDATA WHERE USERID = @user) AND INC_S_CODE = (SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @source)"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@start_date", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@fixed_amount", Convert.ToInt32(TextBox13.Text))
                    cmd.Parameters.AddWithValue("@schedule", TextBox15.Text)
                    cmd.Parameters.AddWithValue("@next_payment_date", DateTimePicker2.Value.ToString("yyyy-MM-dd"))

                    If Button11.Visible = True Then
                        cmd.Parameters.AddWithValue("@exit_date", DateTimePicker3.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@status", False)
                    Else
                        cmd.Parameters.AddWithValue("@exit_date", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@user", USERNAME.Text)
                    cmd.Parameters.AddWithValue("@source", SOURCENAME.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating access: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Panel4.Visible = False
    End Sub
End Class