Imports System.Data.SQLite

Public Class AddIncomeSource
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub AddIncomeSource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaskedTextBox1.Mask = "00/00/0000"
        MaskedTextBox1.ValidatingType = GetType(Date)
        If UserSession.IsLoggedIn Then
            Me.Text += $"              Welcome, {UserSession.UserName} [{UserSession.UserID}] !"

        Else
            MessageBox.Show("No user is currently logged in. Please log in to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If
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
            Dim textBoxes As String() = {
    "TextBox2", "TextBox3", "TextBox4", "TextBox5",
    "TextBox6", "TextBox7", "TextBox8", "TextBox9", "TextBox10", "TextBox12"}

            For Each name As String In textBoxes
                Dim tb As TextBox = TryCast(Me.Controls(name), TextBox)
                If tb IsNot Nothing Then
                    tb.ReadOnly = False
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


        ' After all validations, save the source
        SaveSource()
        MessageBox.Show("Income source added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Clear form for next entry
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox12.Clear()
        MaskedTextBox1.Clear()
        Button2.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel2.Visible = False
        Panel1.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel2.Visible = True
        Panel1.Visible = False
    End Sub
End Class