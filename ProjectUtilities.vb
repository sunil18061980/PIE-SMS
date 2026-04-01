Imports System.Data.SQLite
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ProjectUtilities
    'Function to fetch all user IDs from the USERDATA table and return as a list
    Public Shared Function GetUserIDList() As List(Of String)
        Dim userList As New List(Of String)
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT USERID FROM USERDATA", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            userList.Add(reader("UserID").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user IDs: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userList
    End Function
    'function to fetch all users Data and return as a DataTable
    Public Shared Function GetAllUsersData() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM USERDATA", conn)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function


    'Function to return userCode for a given userID
    Public Shared Function GetUserCodeByUserID(userID As String) As Integer
        Dim userCode As Integer = -1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT UserCode FROM USERDATA WHERE UserID = @UserID", conn)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        userCode = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user code: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userCode
    End Function


    ' Function to return userName for a given userID
    Public Shared Function GetUserNameByUserID(userID As String) As String
        Dim userName As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT UserName FROM USERDATA WHERE UserID = @UserID", conn)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        userName = result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user name: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userName
    End Function

    'function to get sourceCode(inc_s_code) from sourceName(inc_s_name) from table income_sources
    Public Shared Function GetSourceCodeBySourceName(sourceName As String) As Integer
        Dim sourceCode As Integer = -1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT inc_s_code FROM INCOME_SOURCE WHERE inc_s_name = @SourceName", conn)
                    cmd.Parameters.AddWithValue("@SourceName", sourceName)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        sourceCode = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching source code: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return sourceCode
    End Function

    'Get SourceName by SourceCode
    Public Shared Function GetSourceNameBySourceCode(sourceCode As Integer) As String
        Dim sourceName As String = " "
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE WHERE INC_S_CODE = @INCNAME", conn)
                    cmd.Parameters.AddWithValue("@INCNAME", sourceCode)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        sourceName = result
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching source Name: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return sourceName
    End Function

    'Get all sourceName (Inc_s_name) from the table Income_source
    Public Shared Function GetIncomeSourceList() As List(Of String)
        Dim incomeSourceList As New List(Of String)
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            incomeSourceList.Add(reader("INC_S_NAME").ToString)
                        End While
                    End Using
                End Using


            End Using
        Catch ex As Exception

        End Try


        Return incomeSourceList
    End Function


    Public Shared Function GetAssociatedSourceByUserCode(userCode As Integer) As List(Of String)
        Dim sourceList As New List(Of String)

        Try
            Using Conn As SQLiteConnection = DBConnection.GetConnection()
                Conn.Open()
                Dim query As String = "
                SELECT I.INC_S_NAME
                FROM INCOME_SOURCE I
                INNER JOIN SOURCEMAPPING S 
                ON I.INC_S_CODE = S.SOURCECODE
                WHERE S.USERCODE = @USERCODE"

                Using cmd As New SQLiteCommand(query, Conn)
                    cmd.Parameters.AddWithValue("@USERCODE", userCode)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            sourceList.Add(reader("INC_S_NAME").ToString())
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error in fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return sourceList
    End Function



    Public Shared Function GetUserIncomeHistoryFromSource(userCode As Integer, SourceCode As Integer) As DataTable
        Dim IncomeHistory As New DataTable
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM CURRENT_INCOME_SOURCE WHERE USERCODE=@UCODE AND INC_S_CODE=@SCODE", conn)
                    cmd.Parameters.AddWithValue("@UCODE", userCode)
                    cmd.Parameters.AddWithValue("@SCODE", SourceCode)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(IncomeHistory)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error in fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return IncomeHistory
    End Function




End Class

