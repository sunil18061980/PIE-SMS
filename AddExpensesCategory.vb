Imports System.ComponentModel.Design.Serialization
Imports System.Data.SQLite
Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports SHDocVw

Public Class AddExpensesCategory
    Dim modify As Boolean = False
    Dim oldCode As Integer
    Private Sub AddExpensesCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateExpensesList()

    End Sub
    Private Sub UpdateExpensesList()
        Dim ExpDetails As DataTable = ProjectUtilities.GetExpensesCategoryDetails()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Items.Clear()

        If ListView1.Columns.Count = 0 Then
            ListView1.Columns.Add("EXPENSES CATEGORY", 150)
            ListView1.Columns.Add("EXPENSES HEAD", 120)
            ListView1.Columns.Add("REMARKS", 200)
        End If
        For Each row As DataRow In ExpDetails.Rows
            Dim Item As New ListViewItem(row("EXP_CAT_NAME").ToString)
            Item.SubItems.Add(row("EXP_CAT_HEAD").ToString)
            Item.SubItems.Add(row("EXP_CAT_REMARKS").ToString)
            ListView1.Items.Add(Item)
        Next
        TextBox1.Text = ""
        TextBox2.Text = ""
        modify = False
        ComboBox1.Text = ""
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then

            Dim item As ListViewItem = ListView1.SelectedItems(0)

            Dim e_name = item.Text
            Dim e_cat = item.SubItems(1).Text
            Dim e_remarks = item.SubItems(2).Text

            ComboBox1.Text = e_cat
            TextBox1.Text = e_name
            TextBox2.Text = e_remarks
            modify = True
            oldCode = ProjectUtilities.GetExpensesCategoryCodeByName(e_name)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MessageBox.Show("Expenses Category Name or Head Can't be empty", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If modify Then
            ModifyCategory()
        Else
            SaveCategory()
        End If
        UpdateExpensesList()
    End Sub
    Private Sub SaveCategory()
        'Check for duplicate records, if not save new expenses category
        Try
            Dim maxCode As Integer
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT * FROM EXPENSES_CATEGORY WHERE EXP_CAT_NAME=@NAME", conn)
                    cmd.Parameters.AddWithValue("@NAME", TextBox2.Text.Trim())
                    Using reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            MessageBox.Show("Name already exists.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End Using
                End Using

                'save Expenses name
                'GET Max code
                Using cmdMaxCode As New SQLiteCommand("SELECT MAX(EXP_CAT_CODE) FROM EXPENSES_CATEGORY", conn)
                    Dim result = cmdMaxCode.ExecuteScalar()

                    If result IsNot DBNull.Value Then
                        maxCode = Convert.ToInt32(result) + 1
                    Else
                        maxCode = 11
                    End If
                End Using

                If String.IsNullOrWhiteSpace(TextBox2.Text) Then
                    TextBox2.Text = "NA"
                End If

                Using cmdSave As New SQLiteCommand("INSERT INTO EXPENSES_CATEGORY (EXP_CAT_CODE, EXP_CAT_HEAD, EXP_CAT_NAME, EXP_CAT_REMARKS) VALUES (@CODE, @HEAD, @NAME, @REMARKS)", conn)
                    cmdSave.Parameters.AddWithValue("@CODE", maxCode)
                    cmdSave.Parameters.AddWithValue("@HEAD", ComboBox1.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@NAME", TextBox1.Text.Trim())
                    cmdSave.Parameters.AddWithValue("@REMARKS", TextBox2.Text.Trim())

                    cmdSave.ExecuteNonQuery()

                    MessageBox.Show("New Expenses Category is recorded", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Using
            End Using
            TextBox1.Text = ""
            TextBox2.Text = ""
        Catch ex As Exception
            MessageBox.Show("Issue while fetching data - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub ModifyCategory()
        If oldCode = -1 Then
            MessageBox.Show("No Record Exist to Modify", "No Record exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                'check for duplicate name with other code
                Using cmd As New SQLiteCommand("SELECT * FROM EXPENSES_CATEGORY WHERE EXP_CAT_NAME=@NAME AND EXP_CAT_CODE!=@ECODE", conn)

                    cmd.Parameters.AddWithValue("@NAME", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@ECODE", oldCode)

                    Using reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            MessageBox.Show("Name already exists.with other code", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End Using

                End Using

                Using cmd As New SQLiteCommand("UPDATE EXPENSES_CATEGORY " &
                              "SET EXP_CAT_HEAD=@HEAD, EXP_CAT_NAME=@NAME, EXP_CAT_REMARKS=@REMARK " &
                              "WHERE EXP_CAT_CODE=@OLDCODE", conn)

                    cmd.Parameters.AddWithValue("@HEAD", ComboBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@NAME", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@REMARK", TextBox2.Text.Trim())
                    cmd.Parameters.AddWithValue("@OLDCODE", oldCode)

                    Dim rows As Integer = cmd.ExecuteNonQuery()

                    If rows > 0 Then
                        MessageBox.Show("Expenses Name updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No record found to update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End Using




            End Using
        Catch ex As Exception
            MessageBox.Show("Problem while fetching" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        modify = False
    End Sub


End Class