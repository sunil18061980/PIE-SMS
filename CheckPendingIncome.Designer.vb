<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckPendingIncome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Label2 = New Label()
        ListView1 = New ListView()
        ComboBox1 = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        GroupBox1 = New GroupBox()
        Button3 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.ForeColor = Color.Red
        Button1.Location = New Point(27, 51)
        Button1.Name = "Button1"
        Button1.Size = New Size(240, 44)
        Button1.TabIndex = 1
        Button1.Text = "CURRENT MONTH"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.ForeColor = Color.Red
        Button2.Location = New Point(273, 51)
        Button2.Name = "Button2"
        Button2.Size = New Size(303, 44)
        Button2.TabIndex = 2
        Button2.Text = "CURRENT FINANCIAL YEAR"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(56, 477)
        Label2.Name = "Label2"
        Label2.Size = New Size(1157, 28)
        Label2.TabIndex = 3
        Label2.Text = "(PAYMENT WHICH IS NOT RECEIVED TILL DATA, (NOT INCLUDNG INCOME FOR NEXT MONTHS OF THE FINANCIAL YEAR)"
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(26, 140)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1262, 334)
        ListView1.TabIndex = 4
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(56, 68)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(300, 36)
        ComboBox1.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.White
        Label3.Location = New Point(69, 109)
        Label3.Name = "Label3"
        Label3.Size = New Size(198, 28)
        Label3.TabIndex = 6
        Label3.Text = "PENDING PAYMENTS"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = Color.White
        Label4.Location = New Point(56, 24)
        Label4.Name = "Label4"
        Label4.Size = New Size(126, 28)
        Label4.TabIndex = 7
        Label4.Text = "SELECT USER"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.ForeColor = Color.White
        GroupBox1.Location = New Point(417, 24)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(587, 101)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "CHECK PENDING PAYMENT FOR"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(1094, 64)
        Button3.Name = "Button3"
        Button3.Size = New Size(147, 55)
        Button3.TabIndex = 9
        Button3.Text = "CLOSE"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' CheckPendingIncome
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DodgerBlue
        ClientSize = New Size(1326, 593)
        Controls.Add(Button3)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(ComboBox1)
        Controls.Add(ListView1)
        Controls.Add(Label2)
        Controls.Add(GroupBox1)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "CheckPendingIncome"
        StartPosition = FormStartPosition.CenterParent
        Text = "Pending Payments - Expected to Receive  Before given Period"
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button3 As Button
End Class
