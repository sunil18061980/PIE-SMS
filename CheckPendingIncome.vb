Public Class CheckPendingIncome
    Dim curr_Month As String = "Current Month"
    Dim FinancialYear As String
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
End Class