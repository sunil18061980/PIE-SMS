Imports System.Data.SQLite

Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim db As New CreateTables()
            db.createTable()
            db.DefaultData()

        Catch ex As Exception
            Print(ex.Message)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim USERID As String = USER_ID.Text.Trim()
        Dim USERPASS As String = USER_PASSWORD.Text.Trim()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql1 As String = "SELECT * FROM USERDATA WHERE USERID=usid and PASSWORD=uspass"
                Dim cmd As New SQLiteCommand(sql1, conn)
                cmd.Parameters.AddWithValue("@usid", USERID)
                cmd.Parameters.AddWithValue("@uspass", USERPASS)
                Dim result = cmd.ExecuteScalar()
                If (result) Then
                    UserCode = result("USERCODE")
                    USERID = result("USERID")
                    UserName = result("USERNAME")
                    UserRole = result("USERTYPE")
                    IsLoggedIn = True
                End If


            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class