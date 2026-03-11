Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ChangePassword
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Result As DialogResult
        Result = MessageBox.Show("Are you sure, you want to   Close this password change  Window?", "Close This !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            '  login.Show()
            Me.Close()
        Else
            Me.Show()
        End If

    End Sub

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.FID.Text = String.Empty OrElse Me.FFNAME.Text = String.Empty OrElse Me.FAUTH.Text = String.Empty OrElse Me.NPASS.Text = String.Empty OrElse Me.FCODE.Text = String.Empty Then
            MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.NPASS.Text.Length < 6 Then
            MessageBox.Show("New password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim FID As String = Me.FID.Text
            Dim FFNAME As String = Me.FFNAME.Text
            Dim FAUTH As Integer = Convert.ToInt32(Me.FAUTH.Text)
            Dim NPASS As String = Me.NPASS.Text
            Dim FCODE As Integer = Convert.ToInt32(Me.FCODE.Text)


            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT USERCODE, USERTYPE  
             FROM USERDATA 
             WHERE USERID = @FID 
               AND USERCODE = @FCODE 
               AND FIRSTNAME = @FFNAME 
               AND USERTYPE = @FAUTH"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@FID", FID)
                    cmd.Parameters.AddWithValue("@FCODE", FCODE)
                    cmd.Parameters.AddWithValue("@FFNAME", FFNAME)
                    cmd.Parameters.AddWithValue("@FAUTH", FAUTH)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show("NO USER EXIST WITH GIVEN DETAILS",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                    End Using
                End Using
                ' When all details matched change the password
                ' UPDATE PASSWORD
                Dim updateSql As String =
                "UPDATE USERDATA 
                SET PASSWORD = @NPASS 
                WHERE USERCODE = @FCODE"

                Using updateCmd As New SQLiteCommand(updateSql, conn)
                    updateCmd.Parameters.AddWithValue("@NPASS", NPASS)
                    updateCmd.Parameters.AddWithValue("@FCODE", FCODE)

                    updateCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Password changed successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
            End Using
            ' login.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Data Missing " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub


End Class