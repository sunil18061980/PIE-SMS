Public Class StartMain
    Private Sub CREATEUSERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CREATEUSERToolStripMenuItem.Click
        Dim l As New Login
        l.ShowDialog()
        If Not ActiveUserID Then
            Me.Close()
        End If
    End Sub

    Private Sub CLOSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLOSEToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub INCOMESOURCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INCOMESOURCEToolStripMenuItem.Click

    End Sub

    Private Sub StartMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Dim l As New Login
        l.ShowDialog()
        'if No active user i.e. login is not complete close the Main Window also
        If String.IsNullOrEmpty(ActiveUserID) Then
            MessageBox.Show("Login Failed. Closing Application.", "No Matching Credential Found ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Me.Close()
        End If
    End Sub

    Private Sub LOGINToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem1.Click
        'Clear all user session variables and show login form again
        ActiveUserCode = 0
        ActiveUserID = ""
        UserName = ""
        UserRole = 0
        IsLoggedIn = False

        Dim l As New Login
        l.ShowDialog()
        If String.IsNullOrEmpty(ActiveUserID) Then
            Me.Close()
        End If
    End Sub

    Private Sub EXPEMSESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXPEMSESToolStripMenuItem.Click

    End Sub

    Private Sub INCOMESOURCEToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles INCOMESOURCEToolStripMenuItem1.Click
        Dim I As New IncomeSources
        I.ShowDialog()
    End Sub

    Private Sub CATEGORYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CATEGORYToolStripMenuItem1.Click
        Dim IC As New IncomeCategory
        IC.ShowDialog()
    End Sub

    Private Sub DISPLAYSOURCEToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub INCOMEALLOCATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INCOMEALLOCATIONToolStripMenuItem.Click
        Dim IA As New IncomeAllocation
        IA.ShowDialog()

    End Sub
End Class