Imports System.Data.SQLite

Public Class ShowListedIncomeSource
    Dim msg As String = "View Income Details based on the selected user and income source."
    Private Sub ShowListedIncomeSource_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim All_User = ProjectUtilities.GetUserIDList()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("ALL")
        For Each item As String In All_User
            ComboBox1.Items.Add(item)
        Next

        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        Dim list_Item As New ListViewItem("SELECT USER AND INCOME SOURCE")
        ListView1.Items.Add(list_Item)
        For Each column As ColumnHeader In ListView1.Columns
            column.Width = -2 ' Auto-size columns
        Next


        Dim All_Income_Source = ProjectUtilities.GetIncomeSourceList()
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("ALL")
        For Each item As String In All_Income_Source
            ComboBox2.Items.Add(item)
        Next


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            Return
        End If
        If String.IsNullOrWhiteSpace(ComboBox2.Text) Then
            Return
        End If
        Dim UserID As String = ComboBox1.Text

        Dim IncomeSource As String = ComboBox2.Text

        Dim dt As DataTable = GetListedIncomeSource(UserID, IncomeSource)

        Dim totalRecord As Integer = dt.Rows.Count
        Label3.Text = msg + " ::  ( " & totalRecord.ToString() & " )"
        DisplayIncomeList(dt)


    End Sub

    Private Function GetListedIncomeSource(UserID As String, IncomeSource As String) As DataTable

        Dim dt As New DataTable
        If UCase(UserID) = "ALL" And UCase(IncomeSource) = "ALL" Then
            Try

                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Dim query As String = "SELECT * FROM CURRENT_INCOME_SOURCE WHERE STATUS=@status"

                    Using cmd As New SQLiteCommand(query, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        Using adapter As New SQLiteDataAdapter(cmd)
                            adapter.Fill(dt)
                        End Using
                    End Using

                End Using

            Catch ex As Exception
                MessageBox.Show("Not able to Fetch Data for All User and All Income Source" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            msg = "Showing all active income for all users."

        End If

        ' For all users but specific income source
        If UCase(UserID) = "ALL" And UCase(IncomeSource) <> "ALL" Then
            Dim u_id = ProjectUtilities.GetUserIDList()
            Dim inc_code = ProjectUtilities.GetSourceCodeBySourceName(IncomeSource)

            For Each item As String In u_id
                Dim user_code = ProjectUtilities.GetUserCodeByUserID(item)

                Try
                    Using conn As SQLiteConnection = DBConnection.GetConnection()
                        conn.Open()
                        Dim query As String = "SELECT * FROM CURRENT_INCOME_SOURCE WHERE STATUS = @status AND INC_S_CODE = @inc_code AND USERCODE = @user_code"

                        Using cmd As New SQLiteCommand(query, conn)
                            cmd.Parameters.AddWithValue("@status", 1)
                            cmd.Parameters.AddWithValue("@inc_code", inc_code)
                            cmd.Parameters.AddWithValue("@user_code", user_code)

                            Using adapter As New SQLiteDataAdapter(cmd)
                                adapter.Fill(dt)
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Not able to fetch data for user: " & item & ". " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
            Dim sourceName As String = ProjectUtilities.GetSourceNameBySourceCode(inc_code)
            msg = "Showing all users Active Income From " & sourceName & " ."

        End If


        ' if user select specific user and all income source
        If UserID <> "ALL" And IncomeSource = "ALL" Then
            Dim u_id = ProjectUtilities.GetUserCodeByUserID(UserID)
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Dim query As String = "SELECT * FROM CURRENT_INCOME_SOURCE WHERE STATUS=@status AND USERCODE=@user_code"
                    Using cmd As New SQLiteCommand(query, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@user_code", u_id)
                        Using adapter As New SQLiteDataAdapter(cmd)
                            adapter.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Not able to Fetch Data for " & UserID & " User" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Dim userName As String = ProjectUtilities.GetUserNameByUserCode(u_id)
            msg = "Showing all active income for " & userName & " user."

        End If

        ' if user select specific user and specific income source
        If UserID <> "ALL" And IncomeSource <> "ALL" Then
            Dim u_id = ProjectUtilities.GetUserCodeByUserID(UserID)
            Dim inc_code = ProjectUtilities.GetSourceCodeBySourceName(IncomeSource)
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Dim query As String = "SELECT * FROM CURRENT_INCOME_SOURCE WHERE STATUS=@status AND USERCODE=@user_code AND INC_S_CODE=@inc_code"
                    Using cmd As New SQLiteCommand(query, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@user_code", u_id)
                        cmd.Parameters.AddWithValue("@inc_code", inc_code)
                        Using adapter As New SQLiteDataAdapter(cmd)
                            adapter.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Not able to Fetch Data for " & UserID & " User and " & IncomeSource & " Income Source" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            Dim userName As String = ProjectUtilities.GetUserNameByUserCode(u_id)
            Dim sourceName As String = ProjectUtilities.GetSourceNameBySourceCode(inc_code)
            msg = "Showing active income for " & userName & " user and " & sourceName & " income source."
        End If



        Return dt
    End Function


    Private Sub DisplayIncomeList(dt As DataTable)
        ListView1.Items.Clear()
        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        If dt.Rows.Count = 0 Then
            Dim listItem As New ListViewItem("No Data Found")
            ListView1.Items.Add(listItem)
        End If

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim UserName As String = ProjectUtilities.GetUserNameByUserCode(row("USERCODE")).ToString()
                Dim listItem As New ListViewItem(UserName)
                Dim sourceName As String = ProjectUtilities.GetSourceNameBySourceCode(row("INC_S_CODE")).ToString()
                listItem.SubItems.Add(sourceName)
                Dim categoryName As String = ProjectUtilities.GetIncomeCategoryNameByCode(row("INC_S_C_CODE")).ToString()
                listItem.SubItems.Add(categoryName)
                listItem.SubItems.Add(row("PAYMENT_SCHEDULE").ToString())
                listItem.SubItems.Add(row("FIXED_AMOUNT").ToString())
                listItem.SubItems.Add(row("REMARKS").ToString())
                listItem.SubItems.Add(row("START_DATE").ToString())
                listItem.SubItems.Add(row("NEXT_PAYMENT_DATE").ToString())

                ListView1.Items.Add(listItem)
            Next

            For Each column As ColumnHeader In ListView1.Columns
                column.Width = -2 ' Auto-size columns
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class