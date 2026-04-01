Imports System.ComponentModel.Design.Serialization
Imports System.Data.SQLite
Imports System.Transactions
Imports AxSHDocVw

Public Class Login
    Dim maxCode, maxCodeResult As Integer
    Dim resetPassword As Boolean = False


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim db As New CreateTables()
            db.CreateTable()
            db.DefaultData()
            'MessageBox.Show("Necessary databases are created ", "done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Server / Connection Not established " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        If IsFirstUser() = 11 Then
            Panel1.Visible = False
            Panel2.Visible = True
            Panel2.BringToFront()
            NEWCODE.Text = Convert.ToString(maxCode)
        Else
            Panel1.Visible = True
            Panel2.Visible = False
            Panel1.BringToFront()
        End If

    End Sub

    Public Function IsFirstUser() As Integer
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql1 As String = "SELECT MAX(USERCODE) FROM USERDATA"
                Dim cmd As New SQLiteCommand(sql1, conn)
                Dim result As Object = cmd.ExecuteScalar()

                If result Is Nothing OrElse IsDBNull(result) Then
                    maxCode = 11
                Else
                    maxCode = Convert.ToInt32(result) + 1
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch Data" & ex.Message, "Connectivity Issue", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Return maxCode

    End Function
    'function to CHECK LOGIN AND SHARE USER DETAILS GLOBALLY
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim USERID As String = USER_ID.Text.Trim()
        Dim USERPASS As String = USER_PASSWORD.Text.Trim()
        IsLoggedIn = False

        If USERID = "" Or USERPASS = "" Then Exit Sub

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql1 As String = "SELECT USERCODE, USERID, FIRSTNAME, LASTNAME, USERTYPE 
                                  FROM USERDATA 
                                  WHERE USERID=@usid AND PASSWORD=@uspass"

                Using cmd As New SQLiteCommand(sql1, conn)

                    cmd.Parameters.AddWithValue("@usid", USERID)
                    cmd.Parameters.AddWithValue("@uspass", USERPASS)

                    Using result As SQLiteDataReader = cmd.ExecuteReader()

                        If result.Read() Then
                            'User Found

                            ActiveUserCode = result("USERCODE").ToString()
                            ActiveUserID = result("USERID").ToString()
                            UserName = result("FIRSTNAME").ToString() & " " & result("LASTNAME").ToString
                            UserRole = result("USERTYPE").ToString()

                            IsLoggedIn = True

                        Else
                            'User Not Found
                            IsLoggedIn = False
                            '      MessageBox.Show("User ID or Password Mismatch ", "Invalid Input",
                            '     MessageBoxButtons.OK, MessageBoxIcon.Hand)

                        End If

                    End Using

                End Using

                If IsLoggedIn Then
                    StartMain.Show()
                    Me.Close()
                Else
                    MessageBox.Show("Invalid User ID or Password",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Can't Fetch Records: " & ex.Message,
                        "Connectivity Issue",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        End Try

    End Sub

    'Function to exit the project
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SM As New StartMain
        Me.Close()
        SM.Close()
    End Sub
    ' To set form to LOGIN USER
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Visible = True
        Panel2.Visible = False

    End Sub
    ' TO SET FORM TO CREATE NEW USER
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Visible = False
        Panel2.Visible = True
        SetDefaultValues()
    End Sub
    'Check if all the inputs are valid REQUIRED TO ADD NEW USER
    Public Function CheckInputValues() As Boolean
        Dim result As Boolean = True
        Dim validRoles As String() = {"5", "4", "3", "2"}

        'Make Sure All fields have Value  & have  minimum length fields
        If NEWCODE.Text.Length < 2 Then
            MessageBox.Show("User Code must be at least 3 characters.", "INPUT MISSING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            result = False
        ElseIf NEWID.Text.Length < 3 Then
            MessageBox.Show("User ID must be at least 3 characters.", "INPUT MISSING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            result = False
        ElseIf NEWFIRSTNAME.Text.Length < 3 Then
            MessageBox.Show("First Name must be at least 3 characters.", "INPUT MISSING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            result = False
        ElseIf NEWPASSWORD.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "INPUT MISSING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            result = False
        ElseIf Not validRoles.Contains(NEWROLE.Text) Then
            MessageBox.Show("Role must be one of 5, 4, 3, or 2.", "INVALID ROLE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            result = False
        End If
        Return result
    End Function
    ' If all inputs are as required , Check if the new userID and code are not duplicate
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If CheckInputValues() Then
            'MessageBox.Show("we ARE HRE", "DD")
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Dim sql1 As String
                    If resetPassword = False Then
                        sql1 = "SELECT * FROM USERDATA WHERE USERID=@user_id or USERCODE=@user_code"
                    Else
                        sql1 = "SELECT * FROM USERDATA WHERE USERID=@user_id AND USERCODE=@user_code"
                    End If

                    Dim cmd As New SQLiteCommand(sql1, conn)

                    cmd.Parameters.AddWithValue("@user_id", NEWID.Text)
                    cmd.Parameters.AddWithValue("@user_code", NEWCODE.Text)
                    Dim result As SQLiteDataReader = cmd.ExecuteReader()

                    If result.HasRows Then
                        If resetPassword Then
                            result.Close()   'release database to jump to reset password
                            Reset_Password()
                            Return
                        End If
                        MessageBox.Show("User Already Exist with CODE - " & NEWCODE.Text & " or WITH USER ID - " & NEWID.Text, "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Return
                    Else
                        AddNewUser()
                    End If


                End Using
            Catch ex As Exception
                MessageBox.Show("Error in Data Fetching" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

            'If All fields are not complete exist from the function
        Else
            MessageBox.Show("RETRUN IS " & CheckInputValues(), "Duplicate")
            Return
        End If

    End Sub
    ' Function to reset all  default values, 
    Private Sub SetDefaultValues()
        NEWCODE.Text = Convert.ToString(IsFirstUser())
        NEWID.Text = ""
        NEWFIRSTNAME.Text = ""
        NEWLASTNAME.Text = ""
        NEWPASSWORD.Text = ""
        USER_ID.Text = ""
        USER_PASSWORD.Text = ""
        resetPassword = False
        NEWCODE.ReadOnly = True
        Label4.Text = "NEW USER REGISTRATION"

    End Sub
    ' If all set , create new user
    Public Function AddNewUser() As Boolean
        If resetPassword = False Then
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Dim Sql As String = "INSERT INTO USERDATA (USERCODE, USERID, FIRSTNAME, LASTNAME, USERTYPE, PASSWORD) VALUES (@us_code, @us_id, @f_name, @l_name, @us_type, @us_pass) "
                    Dim cmd As New SQLiteCommand(Sql, conn)
                    cmd.Parameters.AddWithValue("@us_code", NEWCODE.Text)
                    cmd.Parameters.AddWithValue("@us_id", NEWID.Text)
                    cmd.Parameters.AddWithValue("@f_name", NEWFIRSTNAME.Text)
                    cmd.Parameters.AddWithValue("@l_name", NEWLASTNAME.Text)
                    cmd.Parameters.AddWithValue("@us_type", NEWROLE.Text)
                    cmd.Parameters.AddWithValue("@us_pass", NEWPASSWORD.Text)
                    cmd.ExecuteNonQuery()
                    Dim msg1 = NEWCODE.Text & " " & NEWID.Text & " " & NEWFIRSTNAME.Text & " " & NEWLASTNAME.Text & " " & NEWROLE.Text
                    MessageBox.Show("NEW USER ADDED AS " & msg1, "USER ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetDefaultValues()

                End Using

            Catch ex As Exception
                MessageBox.Show("Error in Data Fetching (TO Add New User )" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            Reset_Password()
        End If

        Return True

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetDefaultValues()
    End Sub
    ' Function to  create password/ if forgotten (not to change password)
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SetDefaultValues()
        NEWCODE.Text = ""
        NEWCODE.Enabled = True
        resetPassword = True
        Panel1.Visible = False
        Panel2.Visible = True
        Panel2.BringToFront()
        NEWCODE.ReadOnly = False
        Label4.Text = "CHANGE EXISTING USER PASSWORD"
    End Sub
    ' function to RESET NEW PASSWORD FOR USER 
    Public Sub Reset_Password()

        If Not CheckInputValues() Then Exit Sub

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "UPDATE USERDATA 
                                 SET PASSWORD = @u_pass
                                 WHERE USERCODE = @u_code 
                                 AND USERID = @u_id 
                                 AND USERTYPE = @u_type"

                Using cmd As New SQLiteCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@u_pass", NEWPASSWORD.Text)
                    cmd.Parameters.AddWithValue("@u_code", NEWCODE.Text)
                    cmd.Parameters.AddWithValue("@u_id", NEWID.Text)
                    cmd.Parameters.AddWithValue("@u_type", NEWROLE.Text)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Password changed successfully for " & NEWID.Text,
                                        "Password Updated",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        SetDefaultValues()

                    Else
                        MessageBox.Show("No matching User Code, ID, or Role found.",
                                        "Password Reset Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning)
                    End If

                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message,
                            "Connection Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub USER_PASSWORD_KeyDown(sender As Object, e As KeyEventArgs) Handles USER_PASSWORD.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)
        Dim g = e.Graphics

        ' Smooth edges
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim centerX = 150
        Dim centerY = 150

        Dim petalWidth = 40
        Dim petalHeight = 100

        ' Draw petals
        For i = 0 To 360 Step 30
            g.TranslateTransform(centerX, centerY)
            g.RotateTransform(i)

            g.FillEllipse(Brushes.Pink, -petalWidth \ 2, -petalHeight, petalWidth, petalHeight)

            g.ResetTransform()
        Next

        ' Draw center of lotus
        g.FillEllipse(Brushes.Yellow, centerX - 20, centerY - 20, 40, 40)


    End Sub

#Const debug = True
End Class