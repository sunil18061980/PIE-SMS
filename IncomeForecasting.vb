
Imports System.Data.SQLite
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class IncomeForecasting
    Dim fy As String
    Dim c_month As String
    Private Sub IncomeForecasting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim users = ProjectUtilities.GetAllUsersData()
        If users IsNot Nothing AndAlso users.Rows.Count > 0 Then
            ComboBox1.DataSource = users
            ComboBox1.DisplayMember = "UserID"
            ComboBox1.ValueMember = "UserCode"
        End If
        c_month = DateTime.Now.ToString("MMMM yyyy")
        Dim n_month = DateTime.Now.Month
        If n_month >= 4 Then
            fy = DateTime.Now.Year.ToString() & "-" & (DateTime.Now.Year + 1).ToString()
        Else
            fy = (DateTime.Now.Year - 1).ToString() & "-" & DateTime.Now.Year.ToString()
        End If

        Button2.Text = "FY : " & fy
        Button1.Text = c_month

    End Sub
    ' Get Expected income for current month
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MessageBox.Show("User is not select from User List ", "User Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim This_Month As Integer = Now.Month()
        Dim This_year As Integer = Now.Year()
        Dim uid As String = ComboBox1.Text.Trim()
        Dim dt As New DataTable
        Dim startDate As DateTime = New DateTime(This_year, This_Month, 1)
        Dim lastDate As DateTime = New DateTime(This_year, This_Month, DateTime.DaysInMonth(This_year, This_Month))
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
            Dim msg As String = "Expected Income for  " & Button1.Text
            UpdateIncomeForecastingView(dt, msg, startDate, lastDate)
        Catch ex As Exception

            MessageBox.Show("Not able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub


    'Get expected income for current financial year (from current date to 31st March of the next year)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MessageBox.Show("User is not select from User List ", "User Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim This_Month As Integer = Now.Month()
        Dim This_year As Integer = Now.Year()
        Dim uid As String = ComboBox1.Text.Trim()
        Dim dt As New DataTable
        Dim startDate As DateTime = New DateTime(This_year, This_Month, 1)
        Dim lastDate As DateTime = New DateTime(This_year + 1, 3, 31)
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
            Dim msg As String = "Expected Income (from " & startDate.ToString("dd MMM yyyy") & " to " & lastDate.ToString("dd MMM yyyy") & ") : " & Button2.Text
            UpdateIncomeForecastingView(dt, msg, startDate, lastDate)
        Catch ex As Exception

            MessageBox.Show("Not able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a valid user.", "User Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim startDate As DateTime = DateTimePicker1.Value.Date
        Dim endDate As DateTime = DateTimePicker2.Value.Date

        If startDate > endDate Then
            MessageBox.Show("Start date cannot be greater than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim startFY As String = If(startDate.Month >= 4, startDate.Year.ToString() & "-" & (startDate.Year + 1).ToString(), (startDate.Year - 1).ToString() & "-" & startDate.Year.ToString())
        Dim endFY As String = If(endDate.Month >= 4, endDate.Year.ToString() & "-" & (endDate.Year + 1).ToString(), (endDate.Year - 1).ToString() & "-" & endDate.Year.ToString())

        If startFY <> endFY Then
            MessageBox.Show("Start date and end date must be in the same financial year.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim u_id As String = ComboBox1.Text.ToString()
        Dim u_code = ProjectUtilities.GetUserCodeByUserID(u_id)
        Dim dt As New DataTable

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "SELECT * FROM CURRENT_INCOME_SOURCE " &
                                    "WHERE STATUS = @status " &
                                    "AND USERCODE = @ucode " &
                                    "AND DATE(NEXT_PAYMENT_DATE) BETWEEN DATE(@start_date) AND DATE(@end_date)"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@status", 1)
                    cmd.Parameters.AddWithValue("@ucode", u_code)
                    cmd.Parameters.AddWithValue("@start_date", startDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@end_date", endDate.ToString("yyyy-MM-dd"))


                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using

                Dim msg As String = "Expected Income from " & startDate.ToString("dd MMM yyyy") & " to " & endDate.ToString("dd MMM yyyy") & " : "


                'Change startDate to first date of that month and endDate to last date of that month to calculate the income for the whole month considering the payment schedule
                startDate = New DateTime(startDate.Year, startDate.Month, 1)
                endDate = New DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month))

                UpdateIncomeForecastingView(dt, msg, startDate, endDate)
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred while fetching income forecasting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
    ' dIPSLAY INCOME FORECASTING DATA IN LISTVIEW1
    Private Sub UpdateIncomeForecastingView(ByVal dt As DataTable, ByVal msg As String, startDate As DateTime, lastDate As DateTime)
        Try
            ListView1.View = View.Details
            ListView1.View = View.Details
            ListView1.FullRowSelect = True
            ListView1.Items.Clear()
            Dim total_Income As Decimal = 0
            If ListView1.Columns.Count = 0 Then
                ListView1.Columns.Add("USER NAME", 150)
                ListView1.Columns.Add("SOURCE NAME", 200)
                ListView1.Columns.Add("INCOME CATEGORY", 200)
                ListView1.Columns.Add("PAYMENT SCHEDULE", 200)
                ListView1.Columns.Add("FIX AMOUNT", 150)
                ListView1.Columns.Add("NEXT PAYMENT DATE", 200)
                ListView1.Columns.Add("STATUS", 100)

            End If
            ' fill the date
            If dt.Rows.Count = 0 Then
                Dim item As New ListViewItem("No Data Found")
                Label2.Text = "No income forecasting found for " & c_month
                ListView1.Items.Add(item)
            Else
                '---------------- FILL LISTVIEWS ----------------
                For Each row As DataRow In dt.Rows

                    Dim rowStatus As String = If(Not IsDBNull(row("STATUS")) AndAlso Convert.ToBoolean(row("STATUS")), "Active", "De-activated")
                    Dim SourceName = ProjectUtilities.GetSourceNameBySourceCode(row("INC_S_CODE"))
                    Dim incomeName = ProjectUtilities.GetIncomeCategoryNameByCode(row("INC_S_C_CODE"))
                    Dim userName = ProjectUtilities.GetUserNameByUserCode(row("USERCODE"))
                    Dim item As New ListViewItem(userName)
                    item.SubItems.Add(SourceName)
                    item.SubItems.Add(incomeName)
                    item.SubItems.Add(row("PAYMENT_SCHEDULE").ToString())
                    item.SubItems.Add(row("FIXED_AMOUNT").ToString())
                    item.SubItems.Add(row("NEXT_PAYMENT_DATE").ToString())
                    item.SubItems.Add(rowStatus)
                    Dim pyt_schedule = row("PAYMENT_SCHEDULE").ToString().ToUpper()

                    ' TO COUNT  THE INCOME FOR THE SELECTED PERIOD (FROM START DATE TO END DATE) - CONSIDERING THE PAYMENT SCHEDULE 

                    Dim total_duration_period As Integer = (lastDate - startDate).Days + 1
                    Dim payment_interval = ProjectUtilities.GetPaymentInterval(pyt_schedule)
                    total_Income += (Convert.ToDecimal(row("FIXED_AMOUNT")) * (total_duration_period \ payment_interval))

                    '---------------- FILL LISTVIEWS ----------------
                    ListView1.Items.Add(item)

                Next

            End If
            Label2.Text = msg & "  " & total_Income.ToString("C2")

        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the income forecasting view: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




End Class