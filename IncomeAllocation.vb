Imports System.ComponentModel.DataAnnotations
Imports System.Data.SQLite
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class IncomeAllocation

    Private Sub SetReadonlyOff()
        ListBox1.Enabled = False
        ComboBox1.Enabled = False
        Button2.Enabled = True
        Button1.Enabled = False
        ComboBox2.Enabled = True

        ComboBox3.Enabled = True
        TextBox1.Enabled = True
        TextBox3.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
    End Sub
    Private Sub SetReadonlyOn()
        ListBox1.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = True
    End Sub


    Private Sub IncomeAllocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetReadonlyOn()
        ListView2.ContextMenuStrip = ContextMenuStrip1
        ' Populate the ComboBox with user IDs from the database
        'get id by calling the function in ProjectUtilities
        ComboBox1.DataSource = ProjectUtilities.GetUserIDList()
        ' Dim dt As DataTable = ProjectUtilities.GetAllUsersData()
        ' ListView1.View = View.Details
        'ListView1.FullRowSelect = True
        'ListView1.Items.Clear()

        '        If ListView1.Columns.Count = 0 Then
        '       ListView1.Columns.Add("User ID", 100)
        '      ListView1.Columns.Add("First Name", 120)
        '     ListView1.Columns.Add("Last Name", 120)
        '    ListView1.Columns.Add("User Type", 100)
        '   End If
        '
        'For Each row As DataRow In dt.Rows
        'Dim item As New ListViewItem(row("USERID").ToString())
        'item.SubItems.Add(row("FIRSTNAME").ToString())
        'item.SubItems.Add(row("LASTNAME").ToString())
        'item.SubItems.Add(row("USERTYPE").ToString())
        'ListView1.Items.Add(item)
        'Next
        'ListView1.ContextMenuStrip = ContextMenuStrip1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim SelectedUserId As String = ComboBox1.Text.Trim()
            Dim SelectedUserCode As Integer = ProjectUtilities.GetUserCodeByUserID(SelectedUserId)
            Dim S_List As List(Of String) = ProjectUtilities.GetAssociatedSourceByUserCode(SelectedUserCode)

            ListBox1.DataSource = Nothing
            ListBox1.Items.Clear()

            If S_List IsNot Nothing AndAlso S_List.Count > 0 Then
                ListBox1.DataSource = S_List
            Else
                ListBox1.Items.Add("No Associated Source")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim SelectedUserId As String = ComboBox1.Text.Trim()
        Dim SelectedUserCode As Integer = ProjectUtilities.GetUserCodeByUserID(SelectedUserId)
        Dim SourceName As String = ListBox1.Text.Trim()
        Dim SelectedSourceCode As Integer = ProjectUtilities.GetSourceCodeBySourceName(SourceName)
        Dim dt As DataTable = ProjectUtilities.GetUserIncomeHistoryFromSource(SelectedUserCode, SelectedSourceCode)

        '---------------- LISTVIEW 2 ----------------
        ListView2.View = View.Details
        ListView2.FullRowSelect = True
        ListView2.Items.Clear()

        If ListView2.Columns.Count = 0 Then
            ListView2.Columns.Add("USER NAME", 100)
            ListView2.Columns.Add("SOURCE NAME", 120)
            ListView2.Columns.Add("INCOME TYPE", 120)
            ListView2.Columns.Add("START DATE", 120)
            ListView2.Columns.Add("END DATE", 100)
            ListView2.Columns.Add("PAYMENT SCHEDULE", 120)
            ListView2.Columns.Add("FIX AMOUNT", 120)
            ListView2.Columns.Add("NEXT PAYMENT DATE", 100)
            ListView2.Columns.Add("STATUS", 100)

        End If

        '---------------- LISTVIEW 3 ----------------
        ListView3.View = View.Details
        ListView3.FullRowSelect = True
        ListView3.Items.Clear()

        If ListView3.Columns.Count = 0 Then
            ListView3.Columns.Add("USER NAME", 100)
            ListView3.Columns.Add("SOURCE NAME", 120)
            ListView3.Columns.Add("START DATE", 120)
            ListView3.Columns.Add("START DATE", 120)
            ListView3.Columns.Add("END DATE", 100)
            ListView3.Columns.Add("PAYMENT SCHEDULE", 120)
            ListView3.Columns.Add("FIX AMOUNT", 120)
            ListView3.Columns.Add("NEXT PAYMENT DATE", 100)
            ListView3.Columns.Add("STATUS", 100)
        End If

        '---------------- COUNTING ----------------
        Dim totalCount As Integer = dt.Rows.Count
        Dim trueCount As Integer = dt.Select("STATUS = True").Length
        Dim falseCount As Integer = dt.Select("STATUS = False").Length

        Label4.Text = "Active (" & trueCount.ToString() & " out of " & totalCount.ToString() & ")"
        Label5.Text = "De-activated (" & falseCount.ToString() & " out of " & totalCount.ToString() & ")"

        '---------------- FILL LISTVIEWS ----------------
        For Each row As DataRow In dt.Rows
            Dim incomeName = ProjectUtilities.GetIncomeCategoryNameByCode(row("INC_S_C_CODE"))
            Dim item As New ListViewItem(SelectedUserId)
            item.SubItems.Add(SourceName)
            item.SubItems.Add(incomeName)
            item.SubItems.Add(row("START_DATE").ToString())
            item.SubItems.Add(row("END_DATE").ToString())
            item.SubItems.Add(row("PAYMENT_SCHEDULE").ToString())
            item.SubItems.Add(row("FIXED_AMOUNT").ToString())
            item.SubItems.Add(row("NEXT_PAYMENT_DATE").ToString())

            Dim statusValue As Boolean = False
            If Not IsDBNull(row("STATUS")) Then
                statusValue = Convert.ToBoolean(row("STATUS"))
            End If

            If statusValue Then
                item.SubItems.Add("Active")
                ListView2.Items.Add(item)
            Else
                item.SubItems.Add("De-activated")
                ListView3.Items.Add(item)
            End If

        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetReadonlyOff()

        ComboBox2.DataSource = ProjectUtilities.GetIncomeCategoryList()
        ComboBox3.DataSource = ProjectUtilities.GetPaymentScheduleNameList()


    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        DateTimePicker2.Value = ProjectUtilities.UpdatePaymentScheduleDate(ComboBox3.Text.Trim(), DateTimePicker1.Value)
    End Sub

    'Make sure Entered value is a number only
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Contains(".") Then
            Dim parts() As String = TextBox1.Text.Split("."c)
            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                Dim cursorPos As Integer = TextBox1.SelectionStart
                TextBox1.Text = parts(0) & "." & parts(1).Substring(0, 2)
                TextBox1.SelectionStart = Math.Min(cursorPos, TextBox1.Text.Length)
            End If
        End If
    End Sub
    'Before creating new income source make sure all required field have valid data
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'check As all have values 
        Dim u_name = ComboBox1.Text.Trim()
        Dim s_name = ListBox1.Text.Trim()
        Dim p_schedule = ComboBox3.Text.Trim()
        Dim i_type = ComboBox2.Text.Trim()
        Dim st_Date As DateTime = DateTimePicker1.Value
        Dim next_date As DateTime = DateTimePicker2.Value
        Dim s_amount = TextBox1.Text.Trim()
        Dim st_status As Boolean = 1
        Dim remarks As String = TextBox3.Text.Trim()


        If String.IsNullOrWhiteSpace(u_name) Then
            MessageBox.Show("Please select User Name")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(s_name) Then
            MessageBox.Show("Please select Source")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(p_schedule) Then
            MessageBox.Show("Please select Payment Schedule")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(i_type) Then
            MessageBox.Show("Please select Income Type")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(s_amount) Then
            MessageBox.Show("Please enter Amount")
            Exit Sub
        End If

        ' Check numeric amount
        If Not IsNumeric(s_amount) Then
            MessageBox.Show("Amount must be numeric")
            Exit Sub
        End If

        ' Check date logic
        If next_date < st_Date Then
            MessageBox.Show("Next Date cannot be earlier than Start Date")
            Exit Sub
        End If
        Dim u_code = ProjectUtilities.GetUserCodeByUserID(u_name)
        Dim s_code = ProjectUtilities.GetSourceCodeBySourceName(s_name)
        Dim i_code = ProjectUtilities.GetIncomeCategoryCodeByName(i_type)
        AssignNewIncome(u_code, s_code, p_schedule, s_amount, st_Date, next_date, i_code, st_status, remarks)
    End Sub


    Private Sub AssignNewIncome(u_code, s_code, p_schedule, s_amount, st_Date, next_date, i_code, st_status, remarks)
        'check if any record exist in the CURRENT_INCOME_SOURCE WHERE SOURCE CODE, USER CODE AND SAME INCOME TYPE WITH TRUE STATUS, SET THAT TO FALSE  AND THEN CREATE NEW IF NOT CREATE NEW
        'check if to modifying the existing income source

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("UPDATE CURRENT_INCOME_SOURCE SET STATUS = @STATUSFALSE WHERE USERCODE = @UCODE AND INC_S_CODE = @SCODE AND INC_S_C_CODE = @ICODE AND STATUS = @STATUSTRUE AND END_DATE=@EDATE", conn)
                    cmd.Parameters.AddWithValue("@STATUSFALSE", 0)
                    cmd.Parameters.AddWithValue("@UCODE", u_code)
                    cmd.Parameters.AddWithValue("@SCODE", s_code)
                    cmd.Parameters.AddWithValue("@ICODE", i_code)
                    cmd.Parameters.AddWithValue("@STATUSTRUE", 1)
                    cmd.Parameters.AddWithValue("@EDATE", Today)
                    cmd.ExecuteNonQuery()
                End Using
                'Set If any record with same combination of User, Incomesource and Income type exist. 
                Using cmd As New SQLiteCommand("UPDATE CURRENT_INCOME_SOURCE SET STATUS = FALSE WHERE USERCODE = @UCODE AND INC_S_CODE = @SCODE AND INC_S_C_CODE = @ICODE AND STATUS = TRUE", conn)
                    cmd.Parameters.AddWithValue("@UCODE", u_code)
                    cmd.Parameters.AddWithValue("@SCODE", s_code)
                    cmd.Parameters.AddWithValue("@ICODE", i_code)
                    cmd.ExecuteNonQuery()
                End Using

                Dim sql As String = "INSERT INTO CURRENT_INCOME_SOURCE " &
                                    "(USERCODE, INC_S_CODE, PAYMENT_SCHEDULE, FIXED_AMOUNT, NEXT_PAYMENT_DATE, START_DATE, STATUS, INC_S_C_CODE, REMARKS) " &
                                    "VALUES " &
                                    "(@USERCODE, @SOURCECODE, @PAYMENT_SCHEDULE, @FIX_AMOUNT, @NEXT_PAYMENT_DATE, @START_DATE, @STATUS, @INCS, @REMARK)"

                Using cmdCurrent As New SQLiteCommand(sql, conn)

                    cmdCurrent.Parameters.AddWithValue("@USERCODE", CInt(u_code))
                    cmdCurrent.Parameters.AddWithValue("@SOURCECODE", CInt(s_code))
                    cmdCurrent.Parameters.AddWithValue("@PAYMENT_SCHEDULE", p_schedule)

                    cmdCurrent.Parameters.AddWithValue("@FIX_AMOUNT", CDbl(s_amount))

                    cmdCurrent.Parameters.Add("@NEXT_PAYMENT_DATE", DbType.Date).Value = next_date
                    cmdCurrent.Parameters.Add("@START_DATE", DbType.Date).Value = st_Date

                    cmdCurrent.Parameters.AddWithValue("@STATUS", If(st_status, 1, 0))
                    cmdCurrent.Parameters.AddWithValue("@INCS", CInt(i_code))
                    cmdCurrent.Parameters.AddWithValue("@REMARK", remarks)

                    cmdCurrent.ExecuteNonQuery()
                End Using

                MessageBox.Show("New Income Is Assigned Successfully", "Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SetReadonlyOn()
            End Using

        Catch ex As Exception
            MessageBox.Show("Not in fetching data, " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        SetReadonlyOff()
        ShowSelectedSource()
        ComboBox2.Enabled = False
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        ShowSelectedSource()

    End Sub

    Private Sub ShowSelectedSource()
        If ListView2.SelectedItems.Count > 0 Then

            Dim item As ListViewItem = ListView2.SelectedItems(0)

            Dim u_name = item.Text
            Dim s_name = item.SubItems(1).Text
            Dim c_name = item.SubItems(2).Text
            Dim st_date = item.SubItems(3).Text
            Dim end_date = item.SubItems(4).Text
            Dim p_schedule = item.SubItems(5).Text
            Dim f_amount = item.SubItems(6).Text
            Dim next_date = item.SubItems(7).Text
            Dim st_status = item.SubItems(8).Text
            Dim st_remarks As String = ""
            Dim u_code = ProjectUtilities.GetUserCodeByUserID(u_name)
            Dim s_code = ProjectUtilities.GetSourceCodeBySourceName(s_name)
            Dim c_code = ProjectUtilities.GetIncomeCategoryCodeByName(c_name)
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Using cmd As New SQLiteCommand("SELECT REMARKS FROM CURRENT_INCOME_SOURCE WHERE USERCODE=@UCODE AND INC_S_CODE=@SCODE AND INC_S_C_CODE=@CCODE AND STATUS=1", conn)
                        cmd.Parameters.AddWithValue("@UCODE", u_code)
                        cmd.Parameters.AddWithValue("@SCODE", s_code)
                        cmd.Parameters.AddWithValue("@CCODE", c_code)
                        Dim result = cmd.ExecuteScalar()
                        If result IsNot Nothing Then
                            st_remarks = result
                        End If
                    End Using
                End Using
            Catch ex As Exception

            End Try

            ComboBox1.Text = u_name
            ListBox1.Text = s_name
            ComboBox2.Text = c_name
            ComboBox3.Text = p_schedule
            TextBox1.Text = f_amount
            TextBox2.Text = st_status
            TextBox3.Text = st_remarks
            Dim dt1 As DateTime
            Dim dt2 As DateTime

            If DateTime.TryParse(st_date.Trim(), dt1) Then
                DateTimePicker1.Value = dt1
            End If

            If DateTime.TryParse(end_date.Trim(), dt2) Then
                DateTimePicker2.Value = dt2
            End If

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetReadonlyOn()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim INSN As New IncomeSources
        INSN.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ICN As New IncomeCategory
        ICN.ShowDialog()
    End Sub
End Class