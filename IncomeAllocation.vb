Imports System.ComponentModel.DataAnnotations

Public Class IncomeAllocation


    Private Sub IncomeAllocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Populate the ComboBox with user IDs from the database
        'get id by calling the function in ProjectUtilities
        ComboBox1.DataSource = ProjectUtilities.GetUserIDList()
        Dim dt As DataTable = ProjectUtilities.GetAllUsersData()
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.Items.Clear()

        If ListView1.Columns.Count = 0 Then
            ListView1.Columns.Add("User ID", 100)
            ListView1.Columns.Add("First Name", 120)
            ListView1.Columns.Add("Last Name", 120)
            ListView1.Columns.Add("User Type", 100)
        End If

        For Each row As DataRow In dt.Rows
            Dim item As New ListViewItem(row("USERID").ToString())
            item.SubItems.Add(row("FIRSTNAME").ToString())
            item.SubItems.Add(row("LASTNAME").ToString())
            item.SubItems.Add(row("USERTYPE").ToString())
            ListView1.Items.Add(item)
        Next

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

            Dim item As New ListViewItem(SelectedUserId)
            item.SubItems.Add(SourceName)
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
End Class