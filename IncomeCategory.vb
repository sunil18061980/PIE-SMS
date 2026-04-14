Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class IncomeCategory
    Dim modify As Boolean = False
    Dim catOldName As String = ""
    Private Sub IncomeCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateCategoryListByName()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Make sure user has the permission to add or modify categories. Only Admin and Manager can add or modify categories
        If UserRole < 4 Then
            MessageBox.Show("You do not have permission to add or modify categories.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If TextBox1.Text = "" OrElse TextBox2.Text = "" Then
            MessageBox.Show("Please enter both Category Name and Remarks.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If modify Then
            ModifyCategory()
            modify = False
        Else
            SaveCategory()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        UpdateCategoryListByName()
        modify = False
    End Sub
    Private Sub SaveCategory()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_NAME = @CategoryName", conn)
                    cmdCheck.Parameters.AddWithValue("@CategoryName", TextBox1.Text.Trim())
                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show(" Category Name already exists. Please choose a different name.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using
                Using cmd2 As New SQLiteCommand("SELECT MAX(Inc_S_Cat_Code) FROM INCOME_SOURCE_CATEGORY", conn)
                    Dim maxCode As Object = cmd2.ExecuteScalar()
                    Dim newCode As Integer = If(maxCode Is DBNull.Value, 101, Convert.ToInt32(maxCode) + 1)
                    Using cmdInsert As New SQLiteCommand("INSERT INTO INCOME_SOURCE_CATEGORY (INC_S_CAT_CODE, INC_S_CAT_NAME, INC_S_CAT_Remarks) VALUES (@Code, @CategoryName, @Remarks)", conn)
                        cmdInsert.Parameters.AddWithValue("@Code", newCode)
                        cmdInsert.Parameters.AddWithValue("@CategoryName", TextBox1.Text.Trim())
                        cmdInsert.Parameters.AddWithValue("@Remarks", TextBox2.Text.Trim())
                        cmdInsert.ExecuteNonQuery()
                        MessageBox.Show("Income Source Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateCategoryListByName()
        ListBox1.Items.Clear()
        Dim sl As Integer = 1
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_NAME,INC_S_CAT_REMARKS FROM INCOME_SOURCE_CATEGORY", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim msg = sl.ToString & ". " & reader("INC_S_CAT_NAME").ToString() & "  -  " & reader("INC_S_CAT_REMARKS").ToString()
                            ListBox1.Items.Add(msg)
                            sl += 1
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ModifyCategory()
        'To modify we need to get the category code first using the name and then update the record
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim categoryCode As Integer = getCategoryCodeByName(catOldName)
                If categoryCode = -1 Then
                    MessageBox.Show("Unable to find the category to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Check if the new category name already exists for a different category code
                Using cmdCheck As New SQLiteCommand("SELECT COUNT(*) FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_NAME = @CategoryName AND INC_S_CAT_CODE != @CategoryCode", conn)
                    cmdCheck.Parameters.AddWithValue("@CategoryName", catOldName)
                    cmdCheck.Parameters.AddWithValue("@CategoryCode", categoryCode)
                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                    Label5.Text = categoryCode.ToString()
                    If count > 0 Then
                        MessageBox.Show("eRROR NOT FROM HEREAnother category with the same name already exists. Please choose a different name.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using
                ' Save the modified category details
                Using cmd As New SQLiteCommand("UPDATE INCOME_SOURCE_CATEGORY SET INC_S_CAT_NAME = @CategoryName, INC_S_CAT_REMARKS = @Remarks WHERE INC_S_CAT_CODE = @CategoryCode", conn)
                    cmd.Parameters.AddWithValue("@CategoryName", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@Remarks", TextBox2.Text.Trim())
                    cmd.Parameters.AddWithValue("@CategoryCode", categoryCode)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Income Source Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    modify = False
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetCategoryCodeByName(categoryName As String) As Integer
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_CODE FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_NAME = @CategoryName", conn)
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    Else
                        Throw New Exception("Category not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving category code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1 ' Return -1 to indicate an error
        End Try
    End Function

    Public Function GetAllCategories() As List(Of String)
        Dim categories As New List(Of String)()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_NAME FROM INCOME_SOURCE_CATEGORY", conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            categories.Add(reader("INC_S_CAT_NAME").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return categories
    End Function

    Public Function GetCategoryNameByCode(ByRef categoryCode As Integer) As String
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT INC_S_CAT_NAME FROM INCOME_SOURCE_CATEGORY WHERE INC_S_CAT_CODE = @CategoryCode", conn)
                    cmd.Parameters.AddWithValue("@CategoryCode", categoryCode)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    Else
                        Throw New Exception("Category not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving category name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty ' Return empty string to indicate an error
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Dim curr_cat, curr_cat_remark As String
        If ListBox1.SelectedIndex >= 0 Then
            Dim selectedItem As String = ListBox1.SelectedItem.ToString()

            ' Step 1: Split by "-"
            Dim mainParts As String() = selectedItem.Split("-"c)

            If mainParts.Length >= 2 Then

                ' Step 2: Split first part by "."
                Dim subParts As String() = mainParts(0).Split("."c)

                If subParts.Length >= 2 Then
                    'TextBox1.Text = subParts(0).Trim() ' Part 1
                    TextBox1.Text = subParts(1).Trim() ' Part 2
                    TextBox2.Text = mainParts(1).Trim() ' Part 3
                    modify = True
                    catOldName = TextBox1.Text.Trim()
                End If
            Else
                MessageBox.Show("Selected item format is incorrect. Unable to parse category details.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = "NA"
        modify = False
    End Sub
End Class