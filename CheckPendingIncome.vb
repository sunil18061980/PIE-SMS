Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles

Public Class CheckPendingIncome
    Dim curr_Month As String = "Current Month"
    Dim FinancialYear As String
    Dim fy As String
    Private Sub CheckPendingIncome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim All_User = ProjectUtilities.GetUserIDList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("ALL")
        For Each item As String In All_User
            ComboBox1.Items.Add(item)
        Next

        Dim month = Now.Month()
        Dim year = Now.Year()
        If month > 3 Then
            FinancialYear = year & " - " & year + 1
        Else
            FinancialYear = year - 1 & " - " & year
        End If
        Button1.Text = Now.ToString("MMMM yyyy")
        Button2.Text = "FY " & FinancialYear
        fy = FinancialYear

        ' Split the financial year string
        Dim parts() As String = fy.Split("-"c)

        ' Get starting year (first part)
        Dim startYear As Integer = Convert.ToInt32(parts(0))

        ' Create start date (1 April of starting year)
        Dim startDate As DateTime = New DateTime(startYear, 4, 1)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedIndex >= 0 Then
            ListView1.Items.Clear()
            If ComboBox1.Text = "ALL" Then
                ListView1.Items.Add("All selected")
            Else
                ListView1.Items.Add("One selected")
            End If


        End If
    End Sub
    ' GET PENDING INCOME FOR CURRENT MONTH
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MessageBox.Show("User is not select from User List ", "User Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim This_Month As Integer = Now.Month()
        Dim This_year As Integer = Now.Year()
        Dim uid As String = ComboBox1.Text.Trim()
        Dim dt As New DataTable
        Try
            Dim sql As String
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                If uid = "ALL" Then
                    sql = "SELECT * FROM CURRENT_INCOME_SOURCE " &
                    "WHERE STATUS = @status " &
                    "AND strftime('%m', NEXT_PAYMENT_DATE) = @t_month " &
                    "AND strftime('%Y', NEXT_PAYMENT_DATE) = @t_year"

                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@t_month", This_Month.ToString("00"))
                        cmd.Parameters.AddWithValue("@t_year", This_year.ToString())

                        Using da As New SQLiteDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using

                Else
                    Dim u_code = ProjectUtilities.GetUserCodeByUserID(uid)

                    sql = "SELECT * FROM CURRENT_INCOME_SOURCE " &
                    "WHERE STATUS = @status " &
                    "AND strftime('%m', NEXT_PAYMENT_DATE) = @t_month " &
                    "AND strftime('%Y', NEXT_PAYMENT_DATE) = @t_year " &
                    "AND USERCODE = @ucode"

                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@t_month", This_Month.ToString("00"))
                        cmd.Parameters.AddWithValue("@t_year", This_year.ToString())
                        cmd.Parameters.AddWithValue("@ucode", u_code)

                        Using da As New SQLiteDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End If

            End Using
            Dim msg As String = "Pending Income for " & Button1.Text
            UpdatePendingIncomeReceiptView(dt, msg)
        Catch ex As Exception

            MessageBox.Show("Not able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub
    'DISPLAY PENDING INCOME FOR FINANCIAL YEAR / MONTH (UPDATING THE LISTVIEW)


    Private Sub UpdatePendingIncomeReceiptView(ByVal dt As DataTable, ByVal msg As String)
        Try
            ListView1.Items.Clear()
            ListView1.Columns.Clear()

            ListView1.View = View.Details
            ListView1.FullRowSelect = True
            ListView1.GridLines = True

            ' Add columns
            ListView1.Columns.Add("User ", 100)
            ListView1.Columns.Add("Income Source", 250)
            ListView1.Columns.Add("Income Category", 250)
            ListView1.Columns.Add("Amount ", 150)
            ListView1.Columns.Add("Payment Due Date", 200)

            If dt.Rows.Count = 0 Then
                Dim item As New ListViewItem("No Pending Payment")

                For i As Integer = 1 To ListView1.Columns.Count - 1
                    item.SubItems.Add("")
                Next
                ListView1.Items.Add(item)
                ListView1.Enabled = False
            Else
                ListView1.Enabled = True

                For Each row As DataRow In dt.Rows
                    Dim u_code = row("USERCODE")
                    Dim i_code = row("INC_S_CODE")
                    Dim c_code = row("INC_S_C_CODE")
                    Dim u_id = ProjectUtilities.GetUserIDByUserCode(u_code)
                    Dim inc_source = ProjectUtilities.GetSourceNameBySourceCode(i_code)
                    Dim i_category = ProjectUtilities.GetIncomeCategoryNameByCode(c_code)


                    Dim item As New ListViewItem(u_id.ToString())
                    item.SubItems.Add(inc_source.ToString())
                    item.SubItems.Add(i_category)
                    item.SubItems.Add(row("FIXED_AMOUNT").ToString())
                    item.SubItems.Add(row("NEXT_PAYMENT_DATE".ToString()))
                    ListView1.Items.Add(item)
                Next
            End If
            Label3.Text = msg

        Catch ex As Exception
            MessageBox.Show("Not able to fetch data while updating Account details " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try



    End Sub
    ' GET PENDING INCOME FOR FINANCIAL YEAR
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MessageBox.Show("User is not select from User List ", "User Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim This_Month As Integer = Now.Month()
        Dim This_year As Integer = Now.Year()
        Dim uid As String = ComboBox1.Text.Trim()
        Dim dt As New DataTable
        Try
            Dim sql As String
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim startYear As Integer = Convert.ToInt32(fy.Split("-"c)(0))
                Dim fyStartDate As DateTime = New DateTime(startYear, 4, 1)
                Dim currentDate As DateTime = Now.Date

                If uid = "ALL" Then
                    sql = "SELECT * FROM CURRENT_INCOME_SOURCE " &
                          "WHERE STATUS = @status " &
                          "AND DATE(NEXT_PAYMENT_DATE) BETWEEN DATE(@start_date) AND DATE(@end_date)"

                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@start_date", fyStartDate.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@end_date", currentDate.ToString("yyyy-MM-dd"))

                        Using da As New SQLiteDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using

                Else
                    Dim u_code = ProjectUtilities.GetUserCodeByUserID(uid)

                    sql = "SELECT * FROM CURRENT_INCOME_SOURCE " &
                          "WHERE STATUS = @status " &
                          "AND USERCODE = @ucode " &
                          "AND DATE(NEXT_PAYMENT_DATE) BETWEEN DATE(@start_date) AND DATE(@end_date)"

                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@ucode", u_code)
                        cmd.Parameters.AddWithValue("@start_date", fyStartDate.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@end_date", currentDate.ToString("yyyy-MM-dd"))

                        Using da As New SQLiteDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End If




            End Using
            Dim msg As String = "Pending Income for " & Button2.Text
            UpdatePendingIncomeReceiptView(dt, msg)
        Catch ex As Exception

            MessageBox.Show("Not able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class