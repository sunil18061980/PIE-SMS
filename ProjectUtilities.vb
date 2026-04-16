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
    ' Get UserCode by User Full Name (First Name + Last Name)
    Public Shared Function GetUserCodeByFullName(fullName As String) As Integer
        Dim userCode As Integer = -1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT UserCode FROM USERDATA WHERE (FIRSTNAME || ' ' || LASTNAME) = @FullName", conn)
                    cmd.Parameters.AddWithValue("@FullName", fullName)
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
    'Get UserID from User Code
    Public Shared Function GetUserIDByUserCode(ByVal u_code As Integer) As String
        Dim u_id As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT USERID FROM USERDATA WHERE USERCODE=@UCODE", conn)
                    cmd.Parameters.AddWithValue("@UCODE", u_code)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(result.ToString()) Then
                        u_id = result.ToString()
                    End If
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch user details while fetching user Id from user Code  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return u_id
    End Function

    ' Function to return userName for a given userID
    Public Shared Function GetUserNameByUserID(userID As String) As String
        Dim userName As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT FIRSTNAME, LASTNAME FROM USERDATA WHERE UserID = @UserID", conn)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read Then
                            userName = reader("FIRSTNAME") & " " & reader("LASTNAME")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user name: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userName
    End Function
    ' to get user full name using user Code
    Public Shared Function GetUserNameByUserCode(u_code As Integer) As String
        Dim userName As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT FIRSTNAME, LASTNAME FROM USERDATA WHERE UserCode = @U_code", conn)
                    cmd.Parameters.AddWithValue("@U_code", u_code)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read Then
                            userName = reader("FIRSTNAME") & " " & reader("LASTNAME")
                        End If
                    End Using
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
        Dim sourceName As String = "Not Found"
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_NAME FROM INCOME_SOURCE WHERE INC_S_CODE = @INCNAME", conn)
                    cmd.Parameters.AddWithValue("@INCNAME", sourceCode)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        sourceName = result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching source Name: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return sourceName
    End Function

    Public Shared Function GetPaymentInterval(schedule As String) As Integer
        Select Case schedule.ToUpper()
            Case "MONTHLY"
                Return 30
            Case "QUARTERLY"
                Return 91
            Case "HALF YEARLY"
                Return 183
            Case "YEARLY"
                Return 365
            Case "DAILY"
                Return 1
            Case "WEEKLY"
                Return 7
            Case "ONE TIME"
                Return 365
            Case "HALF MONTHLY"
                Return 15
            Case Else
                Return 0 ' Default or unknown schedule
        End Select
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

    Public Shared Function GetPaymentScheduleNameList() As List(Of String)
        Return New List(Of String) From {
        "DAILY", "MONTHLY", "YEARLY", "WEEKLY",
        "QUARTERLY", "HALF YEARLY", "ONE TIME", "HALF MONTHLY"
    }
    End Function

    Public Shared Function GetIncomeCategoryList() As List(Of String)
        Dim Inc_cat_list As New List(Of String)
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_NAME FROM INCOME_SOURCE_CATEGORY", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Inc_cat_list.Add(reader("INC_S_CAT_NAME").ToString())
                        End While
                    End Using

                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch data" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Return Inc_cat_list
    End Function

    Public Shared Function UpdatePaymentScheduleDate(ByVal duration As String, ByVal lastDate As DateTime) As DateTime
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
            Case "HALF MONTHLY"
                Return lastDate.AddDays(15)
            Case Else
                Return lastDate
        End Select

    End Function

    Public Shared Function GetIncomeCategoryCodeByName(ByVal i_type As String) As Integer
        Dim i_code As Integer
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_CODE FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_NAME = @itype", conn)
                    cmd.Parameters.AddWithValue("@itype", i_type)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        i_code = Convert.ToInt32(result)
                    End If
                End Using


            End Using
        Catch ex As Exception
            MessageBox.Show("Not Able to Fetch Income Category Code" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return i_code
    End Function

    Public Shared Function GetIncomeCategoryNameByCode(ByVal i_type As Integer) As String
        Dim i_Name As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_NAME FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_CODE = @i_type", conn)
                    cmd.Parameters.AddWithValue("@i_type", i_type)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        i_Name = result
                    End If
                End Using


            End Using
        Catch ex As Exception
            MessageBox.Show("Not Able to Fetch Income Category Code" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return i_Name
    End Function

    Public Shared Function GetExpensesCategoryDetails() As DataTable
        Dim ExpDetails As New DataTable
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmdExp As New SQLiteCommand("SELECT * FROM EXPENSES_CATEGORY", conn)
                    Using Adapter As New SQLiteDataAdapter(cmdExp)
                        Adapter.Fill(ExpDetails)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to Fetch Data" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Return ExpDetails
    End Function


    Public Shared Function GetExpensesCategoryCodeByName(ByVal e_name As String) As Integer
        Dim e_code As Integer = -1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT EXP_CAT_CODE FROM EXPENSES_CATEGORY WHERE EXP_CAT_NAME=@E_NAME", conn)
                    cmd.Parameters.AddWithValue("@E_NAME", e_name)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        e_code = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return e_code

    End Function



    Public Shared Function GetAssociatedBankAccountDetailsByUserID(ByVal uid As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM BANK_ACCOUNT WHERE USER_CODE=@UID", conn)
                    cmd.Parameters.AddWithValue("@UID", uid)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Can't fetch  Bank account details by Id" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return dt
    End Function

    Public Shared Function GetBankNameList() As List(Of String)
        Dim bank_names As New List(Of String)
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT BANK_NAME FROM BANK_NAMES ORDER BY BANK_NAME", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read
                            bank_names.Add(reader("BANK_NAME").ToString)
                        End While
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("No able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return bank_names
    End Function

    Public Shared Function GetBankCodeByBankName(ByVal b_Name As String) As Integer
        Dim bCode As Integer = -1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT BANK_CODE FROM BANK_NAMES WHERE UPPER(BANK_NAME)=UPPER(@NAME)", conn)
                    cmd.Parameters.AddWithValue("@NAME", b_Name)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        bCode = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to Fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return bCode
    End Function
    Public Shared Function GetBankNameByBankCode(ByVal b_code As String) As String
        Dim b_name As String = ""
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT BANK_NAME FROM BANK_NAMES WHERE BANK_CODE=@CODE ORDER BY BANK_CODE", conn)
                    cmd.Parameters.AddWithValue("@CODE", b_code)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        b_name = result
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to Fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Return b_name
    End Function
End Class
