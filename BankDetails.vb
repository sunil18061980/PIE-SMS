Imports System.Data.SQLite
Imports System.Diagnostics.Eventing.Reader
Imports System.Reflection.Emit
Imports System.Threading

Public Class BankDetails
    Dim modify As Boolean = False
    Dim oldName As String
    Dim oldCode As String
    Dim curr_bank_code As Integer = -1
    Dim cur_bankName As String = ""
    Private Sub BankDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BankList()
    End Sub

    Private Sub BankList()
        Dim BL = ProjectUtilities.GetBankNameList()

        ListBox1.Items.Clear()   'Clear old items

        If BL IsNot Nothing AndAlso BL.Count > 0 Then
            'Add items to ListBox
            For Each item As String In BL
                ListBox1.Items.Add(item)
            Next
            ListBox1.Enabled = True

        Else
            'No data case
            ListBox1.Items.Add("No Data Found")
            ListBox1.Enabled = False
        End If
        Button3.Enabled = False
        ListBox1.Text = ""
        oldName = ""
        oldCode = 0
        modify = False
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If UserRole < 4 Then
            MessageBox.Show("You are not authorized to  Edit / Add  ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub

        End If
        If TextBox1.Text.Length < 5 Then
            Exit Sub
        End If
        If modify Then
            ModifyBankName(oldName, oldCode)
            Exit Sub
        End If
        ' check for duplicate bank name
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim Sql As String = "SELECT COUNT(*) FROM BANK_NAMES WHERE BANK_NAME=@newBank"
                Using cmd As New SQLiteCommand(Sql, conn)
                    cmd.Parameters.AddWithValue("@newBank", TextBox1.Text.Trim())
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Bank Name is already listed", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        AddBankName()
                    End If

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


    End Sub
    Private Sub AddBankName()
        Dim nextCode As Integer
        Dim NewName As String = TextBox1.Text.Trim()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT IFNULL(MAX(BANK_CODE), 10) + 1 FROM BANK_NAMES"
                Using cmd As New SQLiteCommand(sql, conn)
                    nextCode = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Dim sqlSave As String = "INSERT INTO BANK_NAMES (BANK_CODE, BANK_NAME) VALUES (@CODE, @NAME)"
                Using cmdSave As New SQLiteCommand(sqlSave, conn)
                    cmdSave.Parameters.AddWithValue("@CODE", nextCode)
                    cmdSave.Parameters.AddWithValue("@NAME", NewName)
                    Dim result As Integer = cmdSave.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("New Bank Name " & NewName & " is  Listed Successfully", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error in connection, Bank Name not listed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End Using

            End Using


        Catch ex As Exception
            MessageBox.Show("Not able to establish connection " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End Try
        BankList()
        ListBox1.SelectedItem = NewName
        Button4.PerformClick()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length < 5 Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
    End Sub


    Private Sub ModifyBankName(ByVal oldName As String, ByVal oldCode As Integer)
        ' check if oldName and new name or same or different
        Dim newName = TextBox1.Text.Trim()
        If newName = oldName Then
            MessageBox.Show("Nothing to update", "No Changes ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BankList()
            Exit Sub
        End If
        ' check if newName is already exist with different code, if not update the bank name
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM BANK_NAMES WHERE BANK_NAME=@NAME AND BANK_CODE<>@CODE", conn)
                    cmdCheck.Parameters.AddWithValue("@NAME", newName)
                    cmdCheck.Parameters.AddWithValue("@CODE", oldCode)
                    Dim result As Integer = cmdCheck.ExecuteScalar()
                    If result > 0 Then
                        'name already exist return
                        MessageBox.Show("New Name " & newName & " already exist As another bank name ", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Hand)


                    Else
                        'Update the name

                        Using cmdUpdate As New SQLiteCommand("UPDATE BANK_NAMES SET BANK_NAME =@NAME WHERE BANK_CODE=@CODE", conn)
                            cmdUpdate.Parameters.AddWithValue("@NAME", newName)
                            cmdUpdate.Parameters.AddWithValue("@CODE", oldCode)
                            Dim rows_Affected As Integer = cmdUpdate.ExecuteNonQuery()
                            If rows_Affected > 0 Then
                                MessageBox.Show("Bank name updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                MessageBox.Show("Update process is not completed ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End Using

                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch data" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        ListBox1.Text = ""
        BankList()
        ListBox1.SelectedItem = newName
        Button4.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem IsNot Nothing Then
            oldName = ListBox1.SelectedItem.ToString()
        Else
            MessageBox.Show("Please select an item")
        End If
        If oldName.Trim().Length < 5 Then
            Exit Sub
        End If
        ListView1.Items.Clear()
        TextBox1.Text = oldName
        oldCode = ProjectUtilities.GetBankCodeByBankName(oldName)
        modify = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        SetBlank()
        TextBox1.Text = ""
        Dim selectedText As String = TryCast(ListBox1.SelectedItem, String)
        If String.IsNullOrWhiteSpace(selectedText) Then
            MessageBox.Show("Select Bank Name from the List", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        cur_bankName = selectedText

        'get bank code to get bank staff details, exit is not matching name found
        Dim cur_BankCode = ProjectUtilities.GetBankCodeByBankName(cur_bankName)
        If cur_BankCode < 0 Then
            MessageBox.Show("Error in Fetching data", "Name Mismatch ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'If all set get respective bank details and fill in the listview1
        UpdateListView(cur_BankCode)
        Label3.Text = cur_bankName & "  -  " & " STAFF CONTACT DETAILS "
    End Sub


    Private Sub UpdateListView(ByVal cur_code As Integer)
        Dim dt As New DataTable
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM BANK_STAFF WHERE BANK_CODE=@CUR_CODE", conn)
                    cmd.Parameters.AddWithValue("@CUR_CODE", cur_code)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                        'show all the filed in listview1 (bank_place, b_staff_name, b_staff_desg, b_staff_mobile, b_staff_landline, b_staff_email, b_staff_remarks


                        'Clear old items
                        ListView1.Items.Clear()

                        'Optional: clear columns if you want to recreate them
                        ListView1.Columns.Clear()
                        ListView1.View = View.Details
                        ListView1.FullRowSelect = True
                        ListView1.GridLines = True

                        'Add columns
                        ListView1.Columns.Add("CODE", 40)
                        ListView1.Columns.Add("Place", 150)
                        ListView1.Columns.Add("Staff Name", 150)
                        ListView1.Columns.Add("Designation", 120)
                        ListView1.Columns.Add("Mobile", 120)
                        ListView1.Columns.Add("Landline", 120)
                        ListView1.Columns.Add("Email", 200)
                        ListView1.Columns.Add("Remarks", 200)
                        If dt.Rows.Count = 0 Then
                            Dim item As New ListViewItem("No Data Found")

                            'Optional: span across columns visually
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")

                            ListView1.Items.Add(item)

                        Else
                            'Add rows from DataTable to ListView
                            For Each row As DataRow In dt.Rows
                                Dim item As New ListViewItem(row("b_staff_code").ToString())
                                item.SubItems.Add(row("bank_place").ToString())
                                item.SubItems.Add(row("b_staff_name").ToString())
                                item.SubItems.Add(row("b_staff_desg").ToString())
                                item.SubItems.Add(row("b_staff_mobile").ToString())
                                item.SubItems.Add(row("b_staff_landline").ToString())
                                item.SubItems.Add(row("b_staff_email").ToString())
                                item.SubItems.Add(row("b_staff_remarks").ToString())
                                ListView1.Items.Add(item)
                            Next
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to fetch Data " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem Is Nothing Then Exit Sub
        'Call Button4 click event
        SetBlank()
        oldName = ListBox1.SelectedItem.ToString()
        curr_bank_code = ProjectUtilities.GetBankCodeByBankName(oldName)
        Button4.PerformClick()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Can't Update or  Add new Staff details ", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(TextBox9.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("Bank Place, Staff Name or number can't be Empty ", "input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'CHECK IF THE NEWCODE ALREADY EXIST IN THE TABLE, IT IS TI TO REPLACE, ELSE DATE
        Try
            Dim rowCount As Integer = -1
            Dim staffCode As Integer

            If Not Integer.TryParse(TextBox2.Text, staffCode) Then
                MessageBox.Show("Invalid staff code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT COUNT(*) FROM BANK_STAFF WHERE B_STAFF_CODE=@CODE", conn)
                    cmd.Parameters.AddWithValue("@CODE", staffCode)
                    rowCount = Convert.ToInt32(cmd.ExecuteScalar())

                    If rowCount = 0 Then
                        AddStaff()
                    ElseIf rowCount = 1 Then
                        UpdateStaff()
                    Else
                        MessageBox.Show("Error in Data, Cant Proceed Further", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Not able to Fetch Staff details," & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub AddStaff()

        Dim newCode As Integer
        If Not Integer.TryParse(TextBox2.Text, newCode) Then
            MessageBox.Show("Please enter a valid numeric staff code", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim b_code As Integer
        Dim b_place = TextBox9.Text.Trim()
        Dim staff_name = TextBox3.Text.Trim()
        Dim staff_design = TextBox6.Text.Trim()
        Dim staff_mobile = TextBox4.Text.Trim()
        Dim staff_landline = TextBox7.Text.Trim()
        Dim staff_email = TextBox5.Text.Trim()
        Dim staff_remarks = TextBox8.Text.Trim()

        ' Check if the bank codes exist
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT COUNT(*) FROM BANK_NAMES WHERE BANK_CODE=@CODE", conn)
                    cmd.Parameters.AddWithValue("@CODE", curr_bank_code)
                    Dim count As Integer = cmd.ExecuteScalar()
                    If count = 1 Then
                        b_code = curr_bank_code
                    Else
                        b_code = -1

                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Not able to Fetch Bank Name " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

        ' exit if bank code does not exist
        If b_code < 0 Then
            MessageBox.Show("Error while Fetching Data, Some Logical Issue in Getting Bank Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)

            Exit Sub
        End If


        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "INSERT INTO BANK_STAFF (B_STAFF_CODE, BANK_CODE,BANK_PLACE, B_STAFF_NAME, B_STAFF_DESG,B_STAFF_MOBILE,     B_STAFF_LANDLINE, B_STAFF_EMAIL, B_STAFF_REMARKS ) VALUES (@code, @bank, @place, @name, @desg, @mobile, @land, @email, @remark)"
                Using cmdSave As New SQLiteCommand(sql, conn)
                    cmdSave.Parameters.AddWithValue("@code", newCode)
                    cmdSave.Parameters.AddWithValue("@bank", b_code)
                    cmdSave.Parameters.AddWithValue("@place", b_place)
                    cmdSave.Parameters.AddWithValue("@name", staff_name)
                    cmdSave.Parameters.AddWithValue("@desg", staff_design)
                    cmdSave.Parameters.AddWithValue("@mobile", staff_mobile)
                    cmdSave.Parameters.AddWithValue("@land", staff_landline)
                    cmdSave.Parameters.AddWithValue("@email", staff_email)
                    cmdSave.Parameters.AddWithValue("@remark", staff_remarks)
                    cmdSave.ExecuteNonQuery()
                End Using
                MessageBox.Show("Correct Message Staff Details are successfully recorded", "Recoded", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SetBlank()
                BankList()
                cur_bankName = ProjectUtilities.GetBankNameByBankCode(b_code)
                ListBox1.SelectedItem = cur_bankName
                Button4.PerformClick()

            End Using

        Catch ex As Exception
            MessageBox.Show("Not Able to Save bank Staff Details" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Private Sub UpdateStaff()
        Dim b_code As Integer
        Dim oldCode As Integer = Convert.ToInt32(TextBox2.Text)
        Dim newCode As Integer = Convert.ToInt32(TextBox2.Text)

        Dim b_place As String = TextBox9.Text.Trim()
        Dim staff_name As String = TextBox3.Text.Trim()
        Dim staff_design As String = TextBox6.Text.Trim()
        Dim staff_mobile As String = TextBox4.Text.Trim()
        Dim staff_landline As String = TextBox7.Text.Trim()
        Dim staff_email As String = TextBox5.Text.Trim()
        Dim staff_remarks As String = TextBox8.Text.Trim()

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' Check bank code
                Using cmdBank As New SQLiteCommand("SELECT COUNT(*) FROM BANK_NAMES WHERE BANK_CODE=@CODE", conn)
                    cmdBank.Parameters.AddWithValue("@CODE", curr_bank_code)

                    Dim bankCount As Integer = Convert.ToInt32(cmdBank.ExecuteScalar())

                    If bankCount = 1 Then
                        b_code = curr_bank_code
                    Else
                        MessageBox.Show("Invalid bank code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                ' Check staff exists
                Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM BANK_STAFF WHERE B_STAFF_CODE=@CODE", conn)
                    cmdCheck.Parameters.AddWithValue("@CODE", oldCode)

                    Dim rowCount As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                    If rowCount = 0 Then
                        MessageBox.Show("Staff record not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End Using

                ' Update record
                Dim sql As String = "UPDATE BANK_STAFF SET " &
                                        "B_STAFF_CODE=@newcode, " &
                                        "BANK_CODE=@bank, " &
                                        "BANK_PLACE=@place, " &
                                        "B_STAFF_NAME=@name, " &
                                        "B_STAFF_DESG=@desg, " &
                                        "B_STAFF_MOBILE=@mobile, " &
                                        "B_STAFF_LANDLINE=@land, " &
                                        "B_STAFF_EMAIL=@email, " &
                                        "B_STAFF_REMARKS=@remark " &
                                        "WHERE B_STAFF_CODE=@oldcode"

                Using cmdUpdate As New SQLiteCommand(sql, conn)
                    cmdUpdate.Parameters.AddWithValue("@newcode", newCode)
                    cmdUpdate.Parameters.AddWithValue("@bank", b_code)
                    cmdUpdate.Parameters.AddWithValue("@place", b_place)
                    cmdUpdate.Parameters.AddWithValue("@name", staff_name)
                    cmdUpdate.Parameters.AddWithValue("@desg", staff_design)
                    cmdUpdate.Parameters.AddWithValue("@mobile", staff_mobile)
                    cmdUpdate.Parameters.AddWithValue("@land", staff_landline)
                    cmdUpdate.Parameters.AddWithValue("@email", staff_email)
                    cmdUpdate.Parameters.AddWithValue("@remark", staff_remarks)
                    cmdUpdate.Parameters.AddWithValue("@oldcode", oldCode)

                    Dim rowsAffected As Integer = cmdUpdate.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Staff details updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SetBlank()
                        BankList()
                        cur_bankName = ProjectUtilities.GetBankNameByBankCode(b_code)
                        ListBox1.SelectedItem = cur_bankName
                        Button4.PerformClick()

                    Else
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Not able to update bank staff details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        If ListView1.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListView1.SelectedItems(0)

            ' First column
            Dim code As String = item.Text

            ' Other columns
            Dim place As String = item.SubItems(1).Text
            Dim name As String = item.SubItems(2).Text
            Dim design As String = item.SubItems(3).Text
            Dim mobile As String = item.SubItems(4).Text
            Dim landline As String = item.SubItems(5).Text
            Dim email As String = item.SubItems(6).Text
            Dim remarks As String = item.SubItems(7).Text

            TextBox2.Text = code
            TextBox3.Text = name
            TextBox4.Text = mobile
            TextBox5.Text = email
            TextBox6.Text = design
            TextBox7.Text = landline
            TextBox8.Text = remarks
            TextBox9.Text = place
        End If
    End Sub

    Private Sub SetBlank()
        TextBox2.Text = -1
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim nextCode As Integer
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            Using cmd As New SQLiteCommand("SELECT IFNULL(MAX(B_STAFF_CODE), 1000) + 1 FROM BANK_STAFF", conn)
                nextCode = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        'check if bank not selected, Return

        If curr_bank_code < 11 Then
            MessageBox.Show("Bank is not selected , Select from the Bank Name List", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetBlank()
        TextBox2.Text = nextCode.ToString()
    End Sub


End Class