Imports System.Data.SQLite
Imports System.Data.SqlTypes
Imports System.Drawing.Imaging
Imports System.[Private].Windows

Public Class login
    Dim NewAuthority As Integer
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim db As New CreateTables()
            db.createTable()
            db.DefaultData()

        Catch ex As Exception
            Print(ex.Message)
        End Try



        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "SELECT MAX(USERCODE) FROM USERDATA"

                Using cmd As New SQLiteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim NCODE As Integer

                    If IsDBNull(result) OrElse result Is Nothing Then
                        NCODE = 11

                    Else
                        NCODE = Convert.ToInt32(result) + 1
                    End If
                    CreateNewUser(NCODE)

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting continent code: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SaveUser()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT USERCODE, USERID FROM USERDATA WHERE USERID=@uid"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("uid", UserId)
                    Dim Result As Object = cmd.ExecuteScalar()
                    If IsDBNull(Result) OrElse Result Is Nothing Then
                        'Save User details in USER TABLE
                        Dim sqlsave As String =
                     "INSERT INTO USERDATA (USERCODE, USERID, FIRSTNAME, LASTNAME, USERTYPE, PASSWORD) VALUES 
                    (@ucode, @uid, @ufname, @ulname, @utype, @upass)"
                        Dim cmd1 As New SQLiteCommand(sqlsave, conn)
                        cmd1.Parameters.AddWithValue("@ucode", NewCode.Text)
                        cmd1.Parameters.AddWithValue("@uid", UserId.Text)
                        cmd1.Parameters.AddWithValue("@ufname", FirstName.Text)
                        cmd1.Parameters.AddWithValue("@ulname", LastName.Text)
                        cmd1.Parameters.AddWithValue("@utype", Authority.Text)
                        cmd1.Parameters.AddWithValue("@upass", Password.Text)
                        cmd1.ExecuteNonQuery()
                        MessageBox.Show("User Details save successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.None)
                    Else
                        MessageBox.Show("User Id Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Details Missing" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NotFirstUser()
        GroupBox1.Text = "New User"
        Label4.Text = "No User Exist, Register New Admin "
        Label3.Text = "ADMIN REGISTRATION"

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        Button1.Visible = False
        Panel1.Visible = False
        Panel2.Visible = True
        Label11.Visible = True
        Dim items() As String = {
            "Label3", "Label4", "Label5", "Label6", "Label7", "Label8",
            "Label9", "Label10", "NewCode", "UserId", "Password",
            "FirstName", "LastName", "Authority", "Button3"
        }

        For Each item As String In items
            If GroupBox1.Controls.ContainsKey(item) Then
                GroupBox1.Controls(item).Visible = True
            End If
        Next

    End Sub
    Private Sub FirstUser()
        GroupBox1.Text = "LOGIN"
        Label4.Text = "ENTER USER CREDENTIALS "
        Label3.Text = ""
        Panel1.Visible = True
        Panel2.Visible = False
        Label11.Visible = False

        Label1.Visible = True
        Label2.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        Button1.Visible = True
        Button2.Visible = True

        Dim items() As String = {
        "Label3", "Label5", "Label6", "Label7", "Label8",
        "Label9", "Label10", "NewCode", "UserId", "Password",
        "FirstName", "LastName", "Authority", "Button3"
    }

        For Each item As String In items
            If GroupBox1.Controls.ContainsKey(item) Then
                GroupBox1.Controls(item).Visible = False
            End If
        Next

    End Sub
    Public Sub CreateNewUser(ByVal Code As Integer)

        If Code = 11 Then
            NewCode.Text = Code.ToString()
            NotFirstUser()
        End If

        If Code <> 11 Then
            NewCode.Text = Code.ToString()
            FirstUser()
        End If

    End Sub


    Private Sub Authority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Authority.SelectedIndexChanged
        NewAuthority = Convert.ToInt32(Authority.Text)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If NewCode.Text = String.Empty OrElse Password.Text = String.Empty OrElse Authority.Text = String.Empty OrElse FirstName.Text = String.Empty Then
            MessageBox.Show("All Fields are Mandatory ", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        Else
            SaveUser()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'When calling User Name and Authority is passed, will collect the usercode from the table and proceed
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT *  FROM USERDATA WHERE USERID = @U_id AND PASSWORD=@U_pass"
                Dim cmd As New SQLiteCommand(Sql, conn)
                cmd.Parameters.AddWithValue("@U_id", TextBox1.Text)
                cmd.Parameters.AddWithValue("@U_pass", TextBox2.Text)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    If Not reader.Read() Then
                        MessageBox.Show("User Name or Password is incorrect",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    ' Read values correctly
                    Dim User_Code As Integer = Convert.ToInt32(reader("USERCODE"))
                    Dim User_Role As String = reader("USERTYPE").ToString()
                    Dim User_Name As String = reader("FIRSTNAME").ToString() & " " & reader("LASTNAME").ToString()
                    Dim User_Id As String = reader("USERID").ToString()
                    ' Set global session variables
                    UserSession.UserCode = User_Code
                    UserSession.UserRole = User_Role
                    UserSession.UserName = User_Name
                    UserSession.UserID = User_Id
                    UserSession.IsLoggedIn = True

                    Dim f As New AddIncomeSource()
                    'f.UserRole = Convert.ToInt32(User_Role)
                    'f.UserName = TextBox1.Text.ToString
                    'f.UserCode = Convert.ToInt32(User_Code)
                    f.Show()
                    'Hide is this is startup form else close (have to do this as later it will not be startup page
                    If Application.OpenForms(0) Is Me Then
                        Me.Hide()
                    Else
                        Me.Close()
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Data Missing " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function AddNewUser() As Boolean
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "SELECT MAX(USERCODE) FROM USERDATA"

                Using cmd As New SQLiteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim NCODE As Integer

                    If IsDBNull(result) OrElse result Is Nothing Then
                        NCODE = 11
                        CreateNewUser(NCODE)
                        Return True
                        Exit Function
                    Else
                        NCODE = Convert.ToInt32(result) + 1
                        NotFirstUser()
                        Label3.Text = "CREATE MEW USER"
                        Label5.Visible = True
                        Label4.Visible = False
                    End If


                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting continent code: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return True

    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AddNewUser()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        login_Load(sender, e)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ChangePassword.Show()
        Me.Hide()
    End Sub



End Class
