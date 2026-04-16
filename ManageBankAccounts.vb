Imports System.Data.SQLite
Imports AxSHDocVw

Public Class ManageBankAccounts
    Private Sub ManageBankAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim userIDs = ProjectUtilities.GetUserIDList()
        ComboBox1.DataSource = userIDs

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim uid = ComboBox1.Text
        Dim user_details = ProjectUtilities.GetUserNameByUserID(uid)
        Label2.Text = user_details
        Dim U_id = ProjectUtilities.GetUserCodeByUserID(uid)
        Dim bank_details = ProjectUtilities.GetAssociatedBankAccountDetailsByUserID(U_id)
        UpdateAssociatedAccountList(bank_details)
        ResetAllBlank()

    End Sub
    Private Sub UpdateAssociatedAccountList(ByVal dt As DataTable)
        Try

            ListView1.Items.Clear()
            ListView1.Columns.Clear()

            ListView1.View = View.Details
            ListView1.FullRowSelect = True
            ListView1.GridLines = True

            ' Add columns
            ListView1.Columns.Add("Code", 50)
            ListView1.Columns.Add("Bank Name", 180)
            ListView1.Columns.Add("Branch", 180)
            ListView1.Columns.Add("User Name", 150)
            ListView1.Columns.Add("Account Type", 60)
            ListView1.Columns.Add("Account Number", 150)
            ListView1.Columns.Add("IFSC Code", 100)
            ListView1.Columns.Add("SWIFT CODE", 100)
            ListView1.Columns.Add("OPENING DATE", 100)
            ListView1.Columns.Add("STATUS", 80)
            ListView1.Columns.Add("CLOSING DATE", 100)
            ListView1.Columns.Add("REMARKS", 100)

            If dt.Rows.Count = 0 Then
                Dim item As New ListViewItem("No Data Found")

                For i As Integer = 1 To ListView1.Columns.Count - 1
                    item.SubItems.Add("")
                Next

                ListView1.Items.Add(item)
                ListView1.Enabled = False
            Else
                ListView1.Enabled = True

                For Each row As DataRow In dt.Rows
                    Dim curr_status As String = ""
                    Dim close_date As String = ""
                    Dim a_status As Integer = 0

                    If Not IsDBNull(row("ACCOUNT_STATUS")) Then
                        a_status = Convert.ToInt32(row("ACCOUNT_STATUS"))
                    End If

                    If a_status = 1 Then
                        curr_status = "Active"
                        close_date = "N A"
                    Else
                        curr_status = "Closed"

                        If Not IsDBNull(row("ACCOUNT_END_DATE")) Then
                            close_date = Convert.ToDateTime(row("ACCOUNT_END_DATE")).ToShortDateString()
                        Else
                            close_date = ""
                        End If
                    End If

                    Dim u_code As Integer = 0
                    If Not IsDBNull(row("USER_CODE")) Then
                        u_code = Convert.ToInt32(row("USER_CODE"))
                    End If
                    Dim u_name As String = ProjectUtilities.GetUserNameByUserCode(u_code)

                    Dim b_code As Integer = 0
                    If Not IsDBNull(row("BANKNAME_CODE")) Then
                        b_code = Convert.ToInt32(row("BANKNAME_CODE"))
                    End If
                    Dim b_name As String = ProjectUtilities.GetBankNameByBankCode(b_code)

                    Dim item As New ListViewItem(row("BANK_ACCOUNT_CODE").ToString())
                    item.SubItems.Add(b_name)
                    item.SubItems.Add(row("BRANCH_OFFICE").ToString())
                    item.SubItems.Add(u_name)
                    item.SubItems.Add(row("ACCOUNT_TYPE").ToString())
                    item.SubItems.Add(row("ACCOUNT_NUMBER").ToString())
                    item.SubItems.Add(row("IFSC_CODE").ToString())
                    item.SubItems.Add(row("SWIFT_CODE").ToString())

                    If Not IsDBNull(row("ACCOUNT_START_DATE")) Then
                        item.SubItems.Add(Convert.ToDateTime(row("ACCOUNT_START_DATE")).ToShortDateString())
                    Else
                        item.SubItems.Add("")
                    End If

                    item.SubItems.Add(curr_status)
                    item.SubItems.Add(close_date)
                    item.SubItems.Add(row("ACCOUNT_REMARKS").ToString())

                    ListView1.Items.Add(item)
                Next
            End If


        Catch ex As Exception
            MessageBox.Show("Not able to fetch data while updating Account details " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub ResetAllBlank()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        Label15.Visible = False
        Label13.Visible = True
        TextBox6.Visible = True
        DateTimePicker2.Visible = False

    End Sub
    Private Sub ResetForNew()
        ' check if user is selected, it not exit

        If String.IsNullOrWhiteSpace(ComboBox1.Text.Trim()) Then
            MessageBox.Show("NO User Is selected", "Select User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ' get User code from the user ID
        Dim uid As String = ComboBox1.Text.Trim()

        'Set new Account Id, get max and increase by 1, if first account start with 101
        Dim acc_id As String = -1
        Dim bankList As List(Of String) = ProjectUtilities.GetBankNameList()
        ComboBox2.DataSource = bankList

        'set Account types in combo box
        '(make sure its empty before adding item to handle duplicate)
        ComboBox3.Items.Clear()
        Dim AccountTypes() As String = {"SAVING", "CURRENT", "SALARY"}
        ComboBox3.Items.AddRange(AccountTypes)

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT  IFNULL(MAX(BANK_ACCOUNT_CODE), 100)+1 FROM BANK_ACCOUNT ", conn)

                    Dim result As Integer = cmd.ExecuteScalar()
                    If result > 0 Then
                        acc_id = result
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to Fetch Account Number's " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        TextBox2.Text = acc_id
        TextBox1.Text = uid
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = "NA"

        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("ACTIVE")

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ResetForNew()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim acc_id As String = -1
        Dim bankList As List(Of String) = ProjectUtilities.GetBankNameList()
        ComboBox2.DataSource = bankList

        'set Account types in combo box
        '(make sure its empty before adding item to handle duplicate)
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()

        Dim AccountTypes() As String = {"SAVING", "CURRENT", "SALARY"}
        ComboBox3.Items.AddRange(AccountTypes)
        Dim Status_List() As String = {"ACTIVE", "INACTIVE"}
        ComboBox4.Items.AddRange(Status_List)

        If ListView1.SelectedItems.Count > 0 Then

            Dim item As ListViewItem = ListView1.SelectedItems(0)
            Dim accCode As String = item.Text                      'Column 0
            Dim bankName As String = item.SubItems(1).Text         'Column 1
            Dim bankCode As Integer = ProjectUtilities.GetBankCodeByBankName(bankName)
            Dim branch As String = item.SubItems(2).Text           'Column 2
            Dim userName As String = item.SubItems(3).Text         'Column 3
            Dim accType As String = item.SubItems(4).Text          'Column 4
            Dim accNumber As String = item.SubItems(5).Text        'Column 5
            Dim ifsc As String = item.SubItems(6).Text             'Column 6
            Dim swift As String = item.SubItems(7).Text            'Column 7
            Dim openDate As String = item.SubItems(8).Text         'Column 8
            Dim status As String = item.SubItems(9).Text           'Column 9
            Dim closeDate As String = item.SubItems(10).Text       'Column 10
            Dim remarks As String = item.SubItems(11).Text         'Column 11
            ' Get  user code bank_account_code from the selected item and fetch the complete details of the account and fill in the form for modification
            Dim u_code As Integer = ProjectUtilities.GetUserCodeByFullName(userName)
            If u_code > 10 Then
                Dim userID As String = ProjectUtilities.GetUserIDByUserCode(u_code)
                TextBox1.Text = userID
            End If
            TextBox2.Text = accCode
            ComboBox2.SelectedItem = bankName
            TextBox7.Text = branch
            ComboBox3.SelectedItem = accType
            TextBox3.Text = accNumber
            TextBox4.Text = ifsc
            TextBox5.Text = swift
            TextBox8.Text = remarks
            DateTimePicker1.Value = Convert.ToDateTime(openDate)
            ComboBox4.SelectedItem = status.ToUpper()
            TextBox6.Text = "NA"
            If status.ToUpper() = "CLOSED" Then
                DateTimePicker2.Visible = True
                DateTimePicker2.Value = Convert.ToDateTime(closeDate)
                DateTimePicker2.Enabled = True
                Label15.Visible = True
                TextBox6.Visible = False
                Label13.Visible = False
            Else
                ' DateTimePicker2.Value = DateTime.Now.Date
                ' DateTimePicker2.Enabled = False
                TextBox6.Visible = True
                Label13.Visible = True
                DateTimePicker2.Visible = False
                Label15.Visible = False
            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'check user role
        Try
            If UserRole < 4 Then
                MessageBox.Show("You Do not have Rights to Add/ Modify New Account Details", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            Dim curr_acc_code As Integer
            Integer.TryParse(TextBox2.Text, curr_acc_code)
            If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Account Code/ User Can't  be Null ", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                curr_acc_code = Convert.ToInt32(TextBox3.Text)
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                MessageBox.Show("Account number/ userID can't be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

            If String.IsNullOrWhiteSpace(TextBox7.Text) Then
                MessageBox.Show("Branch/Location can't be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


            'Check if the current account ID exist in the record or not
            Try
                Using conn As SQLiteConnection = DBConnection.GetConnection()
                    conn.Open()
                    Using cmd As New SQLiteCommand("SELECT COUNT(*) FROM BANK_ACCOUNT WHERE BANK_ACCOUNT_CODE=@ACODE", conn)
                        cmd.Parameters.AddWithValue("@ACODE", curr_acc_code)
                        Dim result As Integer = cmd.ExecuteScalar()
                        If result > 0 Then
                            UpdateExistingAccount()
                        Else
                            AddNewAccount()
                        End If

                    End Using
                End Using

            Catch ex As Exception

                MessageBox.Show("Not able to fetch bank account details ," & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try


        Catch ex As Exception
            MessageBox.Show("Input is not valid details ," & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub
    Private Sub AddNewAccount()
        ' to store the new bank account
        Dim AccStatus As Boolean = False
        Dim U_ID As String = TextBox1.Text.Trim()
        Dim u_code = ProjectUtilities.GetUserCodeByUserID(U_ID)
        'If user code is not fetched close the  process to create new account
        If u_code < 10 Then
            MessageBox.Show("Not able to fetch User Details Details is not in proper details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim acc_id As Integer = Convert.ToInt32(TextBox2.Text)


        Dim bankName As String = ComboBox2.Text.Trim()
        Dim branchName As String = TextBox7.Text.Trim()
        Dim accountType As String = ComboBox3.Text.Trim()


        Dim acc_number As String = TextBox3.Text.Trim()
        Dim bankCode As Integer = ProjectUtilities.GetBankCodeByBankName(bankName)
        If bankCode < 11 Then
            MessageBox.Show("Not able to fetch bank Code, Can't Create New Account Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        Dim acc_status = ComboBox4.Text.Trim()
        If acc_status = "ACTIVE" Then
            AccStatus = True
        Else
            MessageBox.Show("Account Status is not set to Active can't Add New Account Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim StartDate As DateTime

        If DateTimePicker1.Checked = False Then
            StartDate = DateTime.Now.Date   'Current date
        Else
            StartDate = DateTimePicker1.Value.Date
        End If
        ' if all set store account details

        Dim IFSC_Code As String = TextBox4.Text.Trim()
        Dim swift_code As String = TextBox5.Text.Trim()
        Dim acc_remarks As String = TextBox8.Text.Trim()


        'All set now store the account Details in Table BANK_ACCOUNT
        Try

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "INSERT INTO BANK_ACCOUNT (BANK_ACCOUNT_CODE, USER_CODE, BANKNAME_CODE, BRANCH_OFFICE, ACCOUNT_TYPE, ACCOUNT_NUMBER, IFSC_CODE, SWIFT_CODE, ACCOUNT_START_DATE, ACCOUNT_STATUS, ACCOUNT_REMARKS) " &
                            "VALUES (@ACODE, @UCODE, @BCODE, @BRANCH, @ATYPE, @ANUMBER, @IFSC, @SWIFT, @STARTDATE, @ASTATUS, @REMARKS)"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ACODE", acc_id)
                    cmd.Parameters.AddWithValue("@UCODE", u_code)
                    cmd.Parameters.AddWithValue("@BCODE", bankCode)
                    cmd.Parameters.AddWithValue("@BRANCH", branchName)
                    cmd.Parameters.AddWithValue("@ATYPE", accountType)
                    cmd.Parameters.AddWithValue("@ANUMBER", acc_number)
                    cmd.Parameters.AddWithValue("@IFSC", IFSC_Code)
                    cmd.Parameters.AddWithValue("@SWIFT", swift_code)
                    cmd.Parameters.AddWithValue("@STARTDATE", StartDate)
                    cmd.Parameters.AddWithValue("@ASTATUS", If(AccStatus, 1, 0)) ' Store as 1 for active and 0 for inactive
                    cmd.Parameters.AddWithValue("@REMARKS", acc_remarks)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("New Bank Account Details Recorded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Refresh the account list to show the new entry
                        Dim bank_details = ProjectUtilities.GetAssociatedBankAccountDetailsByUserID(u_code)
                        UpdateAssociatedAccountList(bank_details)
                    Else
                        MessageBox.Show("Failed to Record New Bank Account Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using


            End Using

        Catch ex As Exception
            MessageBox.Show("Not able to record new Bank Account Details,  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        ComboBox1.SelectedItem = U_ID
        ResetAllBlank()
    End Sub
    Private Sub UpdateExistingAccount()
        'MessageBox.Show("YES YOU ARE EHRE", "INPUT")
        ' To update existing bank account
        Dim AccStatus As Boolean = False

        Dim U_ID As String = TextBox1.Text.Trim()
        Dim u_code = ProjectUtilities.GetUserCodeByUserID(U_ID)

        ' If user code is not fetched, stop update
        If u_code < 10 Then
            MessageBox.Show("Not able to fetch User Details. Details are not proper.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim acc_id As Integer
        If Not Integer.TryParse(TextBox2.Text.Trim(), acc_id) Then
            MessageBox.Show("Invalid Bank Account Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim bankName As String = ComboBox2.Text.Trim()
        Dim branchName As String = TextBox7.Text.Trim()
        Dim accountType As String = ComboBox3.Text.Trim()

        Dim acc_number As String = TextBox3.Text.Trim()
        Dim IFSC_Code As String = TextBox4.Text.Trim()
        Dim swift_code As String = TextBox5.Text.Trim()
        Dim acc_remarks As String = TextBox8.Text.Trim()

        Dim bankCode As Integer = ProjectUtilities.GetBankCodeByBankName(bankName)
        If bankCode < 11 Then
            MessageBox.Show("Not able to fetch Bank Code. Can't update account details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        Dim acc_status As String = ComboBox4.Text.Trim().ToUpper()
        If acc_status = "ACTIVE" Then
            AccStatus = True
        ElseIf acc_status = "INACTIVE" Then
            AccStatus = False
        Else
            MessageBox.Show("Account Status is invalid. Please select ACTIVE or INACTIVE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim StartDate As DateTime
        If DateTimePicker1.Checked = False Then
            StartDate = DateTime.Now.Date
        Else
            StartDate = DateTimePicker1.Value.Date
        End If

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' Optional: check whether record exists first
                Dim checkSql As String = "SELECT COUNT(*) FROM BANK_ACCOUNT WHERE BANK_ACCOUNT_CODE = @ACODE"
                Using checkCmd As New SQLiteCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@ACODE", acc_id)
                    Dim recordCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If recordCount = 0 Then
                        MessageBox.Show("No bank account record found for the given Account Code.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using

                Dim sql As String = "UPDATE BANK_ACCOUNT SET " &
                                    "USER_CODE = @UCODE, " &
                                    "BANKNAME_CODE = @BCODE, " &
                                    "BRANCH_OFFICE = @BRANCH, " &
                                    "ACCOUNT_TYPE = @ATYPE, " &
                                    "ACCOUNT_NUMBER = @ANUMBER, " &
                                    "IFSC_CODE = @IFSC, " &
                                    "SWIFT_CODE = @SWIFT, " &
                                    "ACCOUNT_START_DATE = @STARTDATE, " &
                                    "ACCOUNT_STATUS = @ASTATUS, " &
                                    "ACCOUNT_REMARKS = @REMARKS " &
                                    "WHERE BANK_ACCOUNT_CODE = @ACODE"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UCODE", u_code)
                    cmd.Parameters.AddWithValue("@BCODE", bankCode)
                    cmd.Parameters.AddWithValue("@BRANCH", branchName)
                    cmd.Parameters.AddWithValue("@ATYPE", accountType)
                    cmd.Parameters.AddWithValue("@ANUMBER", acc_number)
                    cmd.Parameters.AddWithValue("@IFSC", IFSC_Code)
                    cmd.Parameters.AddWithValue("@SWIFT", swift_code)
                    cmd.Parameters.AddWithValue("@STARTDATE", StartDate)
                    cmd.Parameters.AddWithValue("@ASTATUS", If(AccStatus, 1, 0))
                    cmd.Parameters.AddWithValue("@REMARKS", acc_remarks)
                    cmd.Parameters.AddWithValue("@ACODE", acc_id)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If AccStatus = False Then
                        ' If account is set to inactive, also update the ACCOUNT_END_DATE to current date
                        Dim endDateSql As String = "UPDATE BANK_ACCOUNT SET ACCOUNT_END_DATE = @ENDDATE WHERE BANK_ACCOUNT_CODE = @ACODE"
                        Using endDateCmd As New SQLiteCommand(endDateSql, conn)
                            endDateCmd.Parameters.AddWithValue("@ENDDATE", DateTime.Now.Date)
                            endDateCmd.Parameters.AddWithValue("@ACODE", acc_id)
                            endDateCmd.ExecuteNonQuery()
                        End Using
                    End If


                    If rowsAffected > 0 Then
                        MessageBox.Show("Bank Account Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh account list
                        Dim bank_details = ProjectUtilities.GetAssociatedBankAccountDetailsByUserID(u_code)
                        UpdateAssociatedAccountList(bank_details)
                    Else
                        MessageBox.Show("No changes were made to the bank account record.", "Update Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error while updating bank account details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ResetAllBlank()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If String.IsNullOrWhiteSpace(TextBox3.Text) OrElse TextBox3.Text.Length < 6 Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim NB As New BankDetails()
        NB.ShowDialog()

    End Sub
End Class