Imports System.Data.SQLite
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Drawing.Drawing2D

Public Class IncomeSources
    Dim NCode As Integer
    Dim Modify As Boolean = False
    Dim NewList As String
    Private Sub IncomeSources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'if No logged in user then show the login form  
        If IsLoggedIn = False Then
            MessageBox.Show("Please login to access this feature.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Login.Show()
        Else
            ' MsgBox("Welcome " & UserID & "(" & UserName & ")" & " (" & UserRole & ")")
            Me.Text = "Income Sources - " & ActiveUserID & " : ( " & UserName & " )" & " [ " & UserRole & " ]"

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsLoggedIn = False Then
            MessageBox.Show("Please login to access this feature.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Login.Show()
            Exit Sub
        End If
        If UserRole < 4 Then
            MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Panel1.Visible = True
        Panel1.BringToFront()

        ShowSourceList("")
        Try
            'Get the income sources from the database and display them in the listbox

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ResetAll()
        Panel1.Visible = False


    End Sub

    'Function to show the income sources in the listbox and also show the next code in the textbox
    Public Sub ShowSourceList(ByVal SNAME As String)
        Dim SL As Integer = 1

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                ListBox1.Items.Clear()
                ListBox1.Items.Add("All Sources") ' Add an option to show all sources
                If SNAME = "" Then   'If no search term is provided, show all sources
                    Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE ORDER BY INC_S_NAME", conn)
                        Using reader As SQLiteDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                NewList = Convert.ToString(SL) & ". " & reader("INC_S_NAME").ToString()
                                ListBox1.Items.Add(NewList)
                                SL += 1
                            End While
                        End Using
                    End Using

                Else 'if search term is provided, show only matching sources
                    Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE  WHERE INC_S_NAME LIKE @SNAME ORDER BY INC_S_NAME", conn)
                        cmd.Parameters.AddWithValue("@SNAME", "%" & SNAME & "%")
                        Using reader As SQLiteDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                NewList = Convert.ToString(SL) & ". " & reader("INC_S_NAME").ToString()
                                ListBox1.Items.Add(NewList)
                                SL += 1
                            End While
                        End Using
                    End Using
                End If

                'Generate new source code by getting the maximum code from the database and adding 1 to it
                Dim sql As String = "SELECT MAX(INC_S_CODE) FROM INCOME_SOURCE"
                Using cmd1 As New SQLiteCommand(sql, conn)
                    Dim maxID As Object = cmd1.ExecuteScalar()
                    If maxID IsNot Nothing AndAlso Not IsDBNull(maxID) Then
                        NCode = Convert.ToInt32(maxID) + 1
                    Else
                        NCode = 1001 ' Start from 1001 if there are no records
                    End If
                    TextBox1.Text = NCode.ToString()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error fetching income sources: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    ' To show the source details in the textboxes when a source is selected from the listbox
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        ShowSourceList(TextBox12.Text)
    End Sub

    'To clear all textboxes when the clear button is clicked
    Public Sub ClearAll()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        DateTimePicker1.Value = DateTime.Now

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'to check permission
        If UserRole < 4 Then
            MessageBox.Show("You do not have permission to perform this action.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'check all field should be filled
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or
            TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Then
            MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'If Not the modify flag is set then check for duplicate source name in the database
        If Modify = False Then
            SaveSource()
        Else
            ModifySource()
        End If

    End Sub

    Private Sub SaveSource()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT COUNT(*) FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME", conn)
                    cmd.Parameters.AddWithValue("@SNAME", TextBox2.Text)
                    'execute the query and get the count of records with the same source name
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Source name already exists. Please choose a different name.", "Duplicate Source Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using
                Dim sql As String = "INSERT INTO INCOME_SOURCE 
                (INC_S_CODE, INC_S_NAME, INC_S_ADDRESS, INC_S_PERSON, INC_S_DESIGNATION, 
                INC_S_CONTACT, INC_S_MOBILE, INC_S_EMAIL,INC_S_WEBSITE, INC_S_ST_DATE, INC_S_REF, INC_S_REMARKS, INC_S_STATUS)
                VALUES (@CODE, @NAME, @ADDRESS, @PERSON, @DESG, @CONTACT, @MOBILE, @EMAIL, @WEBSITE, @STDATE, @REF, @REMARKS, @STATUS)"
                Using cmd1 As New SQLiteCommand(sql, conn)
                    cmd1.Parameters.AddWithValue("@CODE", TextBox1.Text)
                    cmd1.Parameters.AddWithValue("@NAME", TextBox2.Text)
                    cmd1.Parameters.AddWithValue("@ADDRESS", TextBox4.Text)
                    cmd1.Parameters.AddWithValue("@PERSON", TextBox5.Text)
                    cmd1.Parameters.AddWithValue("@DESG", TextBox6.Text)
                    cmd1.Parameters.AddWithValue("@CONTACT", TextBox3.Text)
                    cmd1.Parameters.AddWithValue("@MOBILE", TextBox7.Text)
                    cmd1.Parameters.AddWithValue("@EMAIL", TextBox11.Text)
                    cmd1.Parameters.AddWithValue("@WEBSITE", TextBox8.Text)
                    cmd1.Parameters.AddWithValue("@STDATE", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cmd1.Parameters.AddWithValue("@REF", TextBox9.Text)
                    cmd1.Parameters.AddWithValue("@REMARKS", TextBox10.Text)
                    cmd1.Parameters.AddWithValue("@STATUS", True)
                    'execute the query to insert the new income source record
                    cmd1.ExecuteNonQuery()
                    MessageBox.Show(TextBox2.Text & " has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
            ClearAll()
            ShowSourceList("")
            Modify = False

        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate source name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Private Sub ModifySource()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                'Check if the source name is being changed and if the new name already exists in the database
                Dim sqlCheck As String = "SELECT COUNT(*) FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME AND INC_S_CODE <> @CODE"
                Using cmd2 As New SQLiteCommand(sqlCheck, conn)
                    cmd2.Parameters.AddWithValue("@SNAME", TextBox2.Text)
                    cmd2.Parameters.AddWithValue("@CODE", TextBox1.Text)
                    Dim count As Integer = Convert.ToInt32(cmd2.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Source name already exists. Please choose a different name.", "Duplicate Source Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using


                Dim sql As String = "UPDATE INCOME_SOURCE SET 
                INC_S_NAME = @NAME, INC_S_ADDRESS = @ADDRESS, INC_S_PERSON = @PERSON, INC_S_DESIGNATION = @DESG, 
                INC_S_CONTACT = @CONTACT, INC_S_MOBILE = @MOBILE, INC_S_EMAIL = @EMAIL,INC_S_WEBSITE = @WEBSITE, 
                INC_S_ST_DATE = @STDATE, INC_S_REF = @REF, INC_S_REMARKS = @REMARKS
                WHERE INC_S_CODE = @CODE"
                Using cmd1 As New SQLiteCommand(sql, conn)
                    cmd1.Parameters.AddWithValue("@CODE", TextBox1.Text)
                    cmd1.Parameters.AddWithValue("@NAME", TextBox2.Text)
                    cmd1.Parameters.AddWithValue("@ADDRESS", TextBox4.Text)
                    cmd1.Parameters.AddWithValue("@PERSON", TextBox5.Text)
                    cmd1.Parameters.AddWithValue("@DESG", TextBox6.Text)
                    cmd1.Parameters.AddWithValue("@CONTACT", TextBox3.Text)
                    cmd1.Parameters.AddWithValue("@MOBILE", TextBox7.Text)
                    cmd1.Parameters.AddWithValue("@EMAIL", TextBox11.Text)
                    cmd1.Parameters.AddWithValue("@WEBSITE", TextBox8.Text)
                    cmd1.Parameters.AddWithValue("@STDATE", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cmd1.Parameters.AddWithValue("@REF", TextBox9.Text)
                    cmd1.Parameters.AddWithValue("@REMARKS", TextBox10.Text)
                    'execute the query to update the income source record
                    cmd1.ExecuteNonQuery()
                    MessageBox.Show(TextBox2.Text & " has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
            ClearAll()
            ShowSourceList("")
            Modify = False
        Catch ex As Exception
            MessageBox.Show("Error updating source details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearAll()
        ShowSourceList("")
        Modify = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        Panel1.Visible = False

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim selectedName As String = ListBox1.SelectedItem.ToString()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME", conn)
                    'remove the numbering from the source name before using it in the query
                    cmd.Parameters.AddWithValue("@SNAME", selectedName.Substring(3)) ' Remove the numbering from the source name
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextBox1.Text = reader("INC_S_CODE").ToString()
                            TextBox2.Text = reader("INC_S_NAME").ToString()
                            TextBox4.Text = reader("INC_S_ADDRESS").ToString()
                            TextBox5.Text = reader("INC_S_PERSON").ToString()
                            TextBox6.Text = reader("INC_S_DESIGNATION").ToString()
                            TextBox3.Text = reader("INC_S_CONTACT").ToString()
                            TextBox7.Text = reader("INC_S_MOBILE").ToString()
                            TextBox11.Text = reader("INC_S_EMAIL").ToString()
                            TextBox8.Text = reader("INC_S_WEBSITE").ToString()
                            DateTimePicker1.Value = Convert.ToDateTime(reader("INC_S_ST_DATE"))
                            TextBox9.Text = reader("INC_S_REF").ToString()
                            TextBox10.Text = reader("INC_S_REMARKS").ToString()
                            Modify = True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching source details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If IsLoggedIn = False Then
            MessageBox.Show("Please login to access this feature.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Login.Show()
            Exit Sub
        End If
        If UserRole < 4 Then
            MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Panel1.Visible = False
        Panel2.Visible = True
        Panel2.BackColor = Color.FromArgb(200, Color.LightGray) ' Set the background color with transparency
        Panel2.BringToFront()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        'fill the combobox with the source names from the database Income_source table and order by source name
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE ORDER BY INC_S_NAME", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ComboBox2.Items.Add(reader("INC_S_NAME").ToString())
                        End While
                    End Using
                End Using

                'Fill combobox with user names from the database USERDATA table order by USERID
                Using cmd1 As New SQLiteCommand("SELECT USERID FROM USERDATA ORDER BY USERID", conn)
                    Using reader As SQLiteDataReader = cmd1.ExecuteReader()
                        While reader.Read()
                            ComboBox1.Items.Add(reader("USERID").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching source names: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please select both user and income source.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim newUserName = ComboBox1.SelectedItem.ToString().Trim()
        Dim newSourceName = ComboBox2.SelectedItem.ToString().Trim()
        Dim sourceCode As Integer
        Dim userCode As Integer

        'Get the user code for the selected user name from the database USERDATA table
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Using cmd As New SQLiteCommand("SELECT USERCODE FROM USERDATA WHERE USERID = @USERID", conn)
                    cmd.Parameters.AddWithValue("@USERID", newUserName)
                    userCode = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                'Get the source code for the selected source name from the database INCOME_SOURCE table
                Using cmd1 As New SQLiteCommand("SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME", conn)
                    cmd1.Parameters.AddWithValue("@SNAME", newSourceName)
                    sourceCode = Convert.ToInt32(cmd1.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user or source code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '
        'Check if any combination of user code and source code already exists in the database USER_INCOME_SOURCE table
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Using cmd As New SQLiteCommand("SELECT COUNT(*) FROM SOURCEMAPPING WHERE USERCODE = @USERCODE AND SOURCECODE = @S_CODE", conn)
                    cmd.Parameters.AddWithValue("@USERCODE", userCode)
                    cmd.Parameters.AddWithValue("@S_CODE", sourceCode)

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        ' Existing mapping found
                        Using cmd1 As New SQLiteCommand("SELECT * FROM SOURCEMAPPING WHERE USERCODE = @USERCODE AND SOURCECODE = @S_CODE ORDER BY LAST_MODIFIED_DATE DESC LIMIT 1", conn)
                            cmd1.Parameters.AddWithValue("@USERCODE", userCode)
                            cmd1.Parameters.AddWithValue("@S_CODE", sourceCode)

                            Using reader As SQLiteDataReader = cmd1.ExecuteReader()
                                If reader.Read() Then
                                    TextBox13.Text = "Mapping already exists for " & newUserName & " and " & newSourceName &
                                        ". You can modify the existing mapping if you want to change the details."

                                    TextBox15.Text = reader("FIX_AMOUNT").ToString()
                                    TextBox14.Text = reader("REMARKS").ToString()
                                    DateTimePicker2.Value = Convert.ToDateTime(reader("START_DATE"))
                                    DateTimePicker3.Value = Convert.ToDateTime(reader("PAYMENT_NEXT_DATE"))
                                    ComboBox4.SelectedItem = reader("PAYMENT_SCHEDULE").ToString()

                                    Dim statusValue As Boolean = Convert.ToBoolean(reader("ISACTIVE"))
                                    If statusValue Then
                                        ComboBox3.SelectedItem = "ACTIVE"
                                    Else
                                        ComboBox3.SelectedItem = "CLOSED"
                                    End If
                                End If
                            End Using
                        End Using

                    Else
                        ' No mapping found, create new mapping defaults
                        Dim sql3 As String = "SELECT USERCODE FROM USERDATA WHERE USERID = @USERID"
                        Using cmd2 As New SQLiteCommand(sql3, conn)
                            cmd2.Parameters.AddWithValue("@USERID", newUserName)

                            Dim resultUser As Object = cmd2.ExecuteScalar()
                            If resultUser Is Nothing OrElse IsDBNull(resultUser) Then
                                MessageBox.Show("User not found: " & newUserName, "Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If

                            userCode = Convert.ToInt32(resultUser)
                        End Using

                        If userCode < 11 Then
                            MessageBox.Show("User not found: " & newUserName & " " & userCode, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            Dim sql4 As String = "SELECT * FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME"
                            Using cmd3 As New SQLiteCommand(sql4, conn)
                                cmd3.Parameters.AddWithValue("@SNAME", newSourceName)

                                Using reader As SQLiteDataReader = cmd3.ExecuteReader()
                                    If reader.Read() Then
                                        TextBox13.Text = "No existing mapping found for " & newUserName & " and " & newSourceName &
                                            ". You can create a new mapping with the details below."

                                        sourceCode = Convert.ToInt32(reader("INC_S_CODE"))
                                        DateTimePicker2.Value = Convert.ToDateTime(reader("INC_S_ST_DATE"))
                                        ComboBox3.SelectedItem = "ACTIVE"
                                        ComboBox4.SelectedItem = "MONTHLY"
                                    Else
                                        MessageBox.Show("Income source not found: " & newSourceName, "Error",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If
                                End Using
                            End Using
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error associating user with income source: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Panel3.Visible = True
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False
        Button7.Enabled = False


    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        If DateTimePicker2.Value > DateTimePicker3.Value Then
            MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            DateTimePicker3.Value = DateTimePicker2.Value.AddYears(1) ' Set end date to a default value after the start date
        End If
    End Sub

    ' Allow only numbers and one decimal point
    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        ' Allow digits, control keys (Backspace), and decimal point
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." And TextBox15.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' Limit to 2 decimal places
    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text.Contains(".") Then
            Dim parts() As String = TextBox15.Text.Split("."c)

            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                Dim cursorPos As Integer = TextBox15.SelectionStart
                TextBox15.Text = parts(0) & "." & parts(1).Substring(0, 2)
                TextBox15.SelectionStart = Math.Min(cursorPos, TextBox15.Text.Length)
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel3.Visible = False
        ComboBox2.Enabled = True
        ComboBox1.Enabled = True
        Button7.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If UserRole < 4 Then
            MessageBox.Show("You do not have permission to perform this action.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        'Make sure all fields are filled
        'Check if the payment schedule is selected and the next payment date is greater than the start date
        If ComboBox4.SelectedIndex = -1 Or ComboBox4.SelectedIndex = -1 Then
            MessageBox.Show("Please select payment schedule and status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Check if the payment schedule is selected and the next payment date is greater than the start date
        If DateTimePicker2.Value >= DateTimePicker3.Value Then
            MessageBox.Show("Next payment date must be greater than start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim duration = ComboBox4.SelectedItem.ToString().Trim()
        Dim starting = DateTimePicker2.Value
        If DateTimePicker4.Value <> UpdatePaymentScheduleDate(duration, starting) Then
            MessageBox.Show("Next payment date does not match the selected payment schedule. Please update the next payment date.", "Invalid Payment Schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DateTimePicker4.Value = UpdatePaymentScheduleDate(duration, starting)
            Exit Sub
        End If
        If TextBox15.Text = "" Then
            MessageBox.Show("Please enter the fixed amount for this mapping.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If ComboBox3.SelectedIndex = -1 Then
            MessageBox.Show("Please select the status for this mapping.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If ComboBox3.SelectedItem.ToString().Trim() = "ACTIVE" Then
            If MessageBox.Show("Are you sure you want to set this mapping as ACTIVE?", "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        ElseIf ComboBox3.SelectedItem.ToString().Trim() = "CLOSED" Then
            If MessageBox.Show("Are you sure you want to set this mapping as CLOSED?", "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If
        'Save the mapping details to the database USER_INCOME_SOURCE table and also update the next payment date based on the payment schedule selected by the user in the combobox4 and the last payment date in the datetimepicker3
        SaveMappingDetails()
    End Sub
    Private Sub SaveMappingDetails()
        Dim status As Boolean
        Dim newUserName As String = ComboBox1.SelectedItem.ToString().Trim()
        Dim newSourceName As String = ComboBox2.SelectedItem.ToString().Trim()
        Dim sourceCode As Integer = 0
        Dim userCode As Integer = 0
        Dim fixAmount As Decimal = If(String.IsNullOrWhiteSpace(TextBox15.Text), 0D, Convert.ToDecimal(TextBox15.Text))
        Dim remarks As String = TextBox14.Text.Trim()
        Dim startDate As DateTime = DateTimePicker2.Value.Date
        Dim endDate As DateTime = DateTimePicker3.Value.Date
        Dim nextPaymentDate As DateTime = DateTimePicker4.Value.Date
        Dim paymentSchedule As String = ComboBox4.SelectedItem.ToString().Trim()
        If ComboBox3.SelectedItem.ToString().ToUpper = "ACTIVE" Then
            status = True
        Else
            status = False
        End If
        Dim lastModified As DateTime = DateTime.Now

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Using pragmaCmd As New SQLiteCommand("PRAGMA busy_timeout = 5000;", conn)
                    pragmaCmd.ExecuteNonQuery()
                End Using

                Using trans As SQLiteTransaction = conn.BeginTransaction()

                    If Not status Then
                        Using cmdUpdate As New SQLiteCommand("UPDATE INCOME_SOURCE SET INC_S_STATUS = 0, INC_S_END_DATE=@end WHERE INC_S_CODE = @S_CODE", conn)
                            cmdUpdate.Parameters.AddWithValue("@S_CODE", sourceCode)
                            cmdUpdate.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"))
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                    End If

                    Using cmdUser As New SQLiteCommand("SELECT USERCODE FROM USERDATA WHERE USERID = @USERID", conn, trans)
                        cmdUser.Parameters.AddWithValue("@USERID", newUserName)
                        Dim result = cmdUser.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            userCode = Convert.ToInt32(result)
                        End If
                    End Using


                    Using cmdSource As New SQLiteCommand("SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @SNAME", conn, trans)
                        cmdSource.Parameters.AddWithValue("@SNAME", newSourceName)
                        Dim result = cmdSource.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            sourceCode = Convert.ToInt32(result)
                        End If
                    End Using

                    If userCode = 0 Then Throw New Exception("User not found: " & newUserName)
                    If sourceCode = 0 Then Throw New Exception("Income source not found: " & newSourceName)

                    Dim count As Integer = 0
                    Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM SOURCEMAPPING WHERE USERCODE = @USERCODE AND SOURCECODE = @SOURCECODE", conn, trans)
                        cmdCheck.Parameters.AddWithValue("@USERCODE", userCode)
                        cmdCheck.Parameters.AddWithValue("@SOURCECODE", sourceCode)
                        Dim result = cmdCheck.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            count = Convert.ToInt32(result)
                        End If
                    End Using

                    If count > 0 Then
                        Using cmdUpdateOld As New SQLiteCommand("UPDATE SOURCEMAPPING SET ISACTIVE = 0,END_DATE=@EDATE, LAST_MODIFIED_DATE = @MODDATE WHERE USERCODE = @USERCODE AND SOURCECODE = @SOURCECODE", conn, trans)
                            cmdUpdateOld.Parameters.AddWithValue("@MODDATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            cmdUpdateOld.Parameters.AddWithValue("@USERCODE", userCode)
                            cmdUpdateOld.Parameters.AddWithValue("@SOURCECODE", sourceCode)
                            cmdUpdateOld.Parameters.AddWithValue("@EDATE", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmdUpdateOld.ExecuteNonQuery()
                        End Using
                    End If

                    Using cmdInsert As New SQLiteCommand("
                    INSERT INTO SOURCEMAPPING
                    (USERCODE, SOURCECODE, FIX_AMOUNT, REMARKS, START_DATE, PAYMENT_NEXT_DATE, PAYMENT_SCHEDULE, ISACTIVE, LAST_MODIFIED_DATE)
                    VALUES
                    (@USERCODE, @SOURCECODE, @FIX_AMOUNT, @REMARKS, @START_DATE, @PAYMENT_NEXT_DATE, @PAYMENT_SCHEDULE, @STATUS, @LDATE)", conn, trans)

                        cmdInsert.Parameters.AddWithValue("@USERCODE", userCode)
                        cmdInsert.Parameters.AddWithValue("@SOURCECODE", sourceCode)
                        cmdInsert.Parameters.AddWithValue("@FIX_AMOUNT", fixAmount)
                        cmdInsert.Parameters.AddWithValue("@REMARKS", remarks)
                        cmdInsert.Parameters.AddWithValue("@START_DATE", startDate.ToString("yyyy-MM-dd"))
                        cmdInsert.Parameters.AddWithValue("@PAYMENT_NEXT_DATE", nextPaymentDate.ToString("yyyy-MM-dd"))
                        cmdInsert.Parameters.AddWithValue("@PAYMENT_SCHEDULE", paymentSchedule)
                        cmdInsert.Parameters.AddWithValue("@STATUS", status)
                        cmdInsert.Parameters.AddWithValue("@LDATE", lastModified.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmdInsert.ExecuteNonQuery()
                    End Using

                    'Using cmdCurrent As New SQLiteCommand("
                    'INSERT INTO CURRENT_INCOME_SOURCE
                    '(USERCODE, INC_S_CODE, PAYMENT_SCHEDULE, FIXED_AMOUNT, NEXT_PAYMENT_DATE, START_DATE, STATUS)
                    'VALUES
                    '(@USERCODE, @SOURCECODE, @PAYMENT_SCHEDULE, @FIX_AMOUNT, @NEXT_PAYMENT_DATE, @START_DATE, @STATUS)
                    'ON CONFLICT(USERCODE, INC_S_CODE)
                    'DO UPDATE SET
                    '    PAYMENT_SCHEDULE = @PAYMENT_SCHEDULE,
                    '    FIXED_AMOUNT = @FIX_AMOUNT,
                    '    NEXT_PAYMENT_DATE = @NEXT_PAYMENT_DATE,
                    '    START_DATE = @START_DATE,
                    '    STATUS = @STATUS", conn, trans)

                    '    cmdCurrent.Parameters.AddWithValue("@USERCODE", userCode)
                    '    cmdCurrent.Parameters.AddWithValue("@SOURCECODE", sourceCode)
                    '    cmdCurrent.Parameters.AddWithValue("@PAYMENT_SCHEDULE", paymentSchedule)
                    '    cmdCurrent.Parameters.AddWithValue("@FIX_AMOUNT", fixAmount)
                    '    cmdCurrent.Parameters.AddWithValue("@NEXT_PAYMENT_DATE", nextPaymentDate.ToString("yyyy-MM-dd"))
                    '    cmdCurrent.Parameters.AddWithValue("@START_DATE", startDate.ToString("yyyy-MM-dd"))
                    '    cmdCurrent.Parameters.AddWithValue("@STATUS", status)
                    '    cmdCurrent.ExecuteNonQuery()
                    'End Using

                    trans.Commit()
                End Using
            End Using

            MessageBox.Show("Mapping details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error saving mapping details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub


    'To update the next payment date based on the payment schedule selected by the user in the combobox4
    'and the last payment date in the date time picker , can use this function which other part of this form
    Private Function UpdatePaymentScheduleDate(ByVal duration As String, ByVal lastDate As DateTime) As DateTime
        Select Case duration.Trim().ToUpper()
            Case "MONTHLY"
                Return lastDate.AddMonths(1)
            Case "YEARLY"
                Return lastDate.AddYears(1)
            Case "HALF YEARLY"
                Return lastDate.AddMonths(6)
            Case "QUARTERLY"
                Return lastDate.AddMonths(3)
            Case "WEEKLY"
                Return lastDate.AddDays(7)
            Case "DAILY"
                Return lastDate.AddDays(1)
            Case "ONE TIME"
                Return lastDate
            Case Else
                Return lastDate
        End Select

    End Function
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim duration = ComboBox4.SelectedItem.ToString().Trim()
        Dim lastDate = DateTimePicker2.Value

        DateTimePicker4.Value = UpdatePaymentScheduleDate(duration, lastDate)

    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim pen As New Pen(Color.Purple, 3)

        Dim rect As New Rectangle(0, 0, Panel1.Width - 1, Panel1.Height - 1)
        Dim path As New GraphicsPath()

        Dim radius As Integer = 20

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)

        path.CloseFigure()

        g.DrawPath(pen, path)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = True
        Panel4.BringToFront()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE ORDER BY INC_S_NAME", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        ComboBox6.Items.Clear()
                        While reader.Read()
                            ComboBox6.Items.Add(reader("INC_S_NAME").ToString())
                        End While
                    End Using
                End Using

                Using cmdUser As New SQLiteCommand("SELECT USERID FROM USERDATA ORDER BY USERID", conn)
                    Using reader As SQLiteDataReader = cmdUser.ExecuteReader()
                        ComboBox5.Items.Clear()
                        While reader.Read()
                            ComboBox5.Items.Add(reader("USERID").ToString())
                        End While
                    End Using

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching data for dropdowns: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Function GetUserCode(userName As String) As Integer
        Dim userCode As Integer = 0
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT USERCODE FROM USERDATA WHERE USERID = @USERID", conn)
                    cmd.Parameters.AddWithValue("@USERID", userName)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        userCode = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return userCode
    End Function

    Private Function GetUserName(userCode As Integer) As String
        Dim userFullName As String = ""

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Using cmd As New SQLiteCommand("SELECT FIRSTNAME, LASTNAME FROM USERDATA WHERE USERCODE = @USERID", conn)
                    cmd.Parameters.AddWithValue("@USERID", userCode)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            userFullName = reader("FIRSTNAME").ToString() & " " & reader("LASTNAME").ToString()
                        End If
                    End Using

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error fetching user name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return userFullName
    End Function

    Private Function GetSourceCode(userName As String) As Integer
        Dim sourceCode As Integer = 0
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CODE FROM INCOME_SOURCE WHERE INC_S_NAME = @NAME", conn)
                    cmd.Parameters.AddWithValue("@NAME", userName)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        sourceCode = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return sourceCode
    End Function

    Private Function GetSourceName(userCode As Integer) As String
        Dim sourceName As Integer = " "
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE WHERE INC_S_CODE = @NAME", conn)
                    cmd.Parameters.AddWithValue("@NAME", userCode)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        sourceName = (result).ToString
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return sourceName
    End Function

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim userCode = GetUserCode(ComboBox5.SelectedItem.ToString())
        Dim userFullName = GetUserName(userCode)
        Dim sn As Integer = 1
        Try
            ListBox2.Items.Clear()
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM INCOME_SOURCE", conn)
                    Using sourcelist As Object = cmd.ExecuteReader()
                        While sourcelist.Read()
                            Dim scode = Convert.ToInt32(sourcelist("INC_S_CODE"))
                            Dim sname = sourcelist("INC_S_NAME").ToString()
                            Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM SOURCEMAPPING WHERE USERCODE = @USERCODE AND SOURCECODE = @SOURCECODE", conn)
                                cmdCheck.Parameters.AddWithValue("@USERCODE", userCode)
                                cmdCheck.Parameters.AddWithValue("@SOURCECODE", scode)
                                Dim result = cmdCheck.ExecuteScalar()
                                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                                    Dim count = Convert.ToInt32(result)
                                    If count > 0 Then
                                        Dim text = sn & ". " & ComboBox5.Text.ToString() & " ( " & userFullName & " )" & " is associated with " & sname
                                        ListBox2.Items.Add(text)
                                        sn += 1
                                    End If
                                End If
                            End Using
                        End While
                    End Using
                End Using
            End Using
            If sn = 1 Then
                ListBox2.Items.Clear()
                ListBox2.Items.Add("No income sources associated with " & ComboBox5.Text.ToString() & " ( " & userFullName & " )")
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching associated income sources: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        Dim sourceCode = GetSourceCode(ComboBox6.SelectedItem.ToString())
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM USERDATA", conn)
                    Using userlist As Object = cmd.ExecuteReader()
                        ListBox2.Items.Clear()
                        Dim sn As Integer = 1
                        While userlist.Read()
                            Dim ucode = Convert.ToInt32(userlist("USERCODE"))
                            Dim uname = userlist("USERID").ToString()
                            Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM SOURCEMAPPING WHERE USERCODE = @USERCODE AND SOURCECODE = @SOURCECODE", conn)
                                cmdCheck.Parameters.AddWithValue("@USERCODE", ucode)
                                cmdCheck.Parameters.AddWithValue("@SOURCECODE", sourceCode)
                                Dim result = cmdCheck.ExecuteScalar()
                                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                                    Dim count = Convert.ToInt32(result)
                                    If count > 0 Then
                                        Dim text = sn & ". " & uname & " ( " & GetUserName(ucode) & " )" & " is associated with " & ComboBox6.Text.ToString()
                                        ListBox2.Items.Add(text)
                                        sn += 1
                                    End If
                                End If
                            End Using
                        End While
                        If sn = 1 Then
                            ListBox2.Items.Clear()
                            ListBox2.Items.Add("No users associated with " & ComboBox6.Text.ToString())
                        End If
                    End Using
                End Using
            End Using



        Catch ex As Exception
            MessageBox.Show("Error fetching associated users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub



#Const debug = True
End Class