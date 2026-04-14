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
        Label1 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Label2 = New Label()
        ListView1 = New ListView()
        ComboBox1 = New ComboBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(375, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(240, 28)
        Label1.TabIndex = 0
        Label1.Text = "CHEK PENDING PAYMENT"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(632, 32)
        Button1.Name = "Button1"
        Button1.Size = New Size(196, 54)
        Button1.TabIndex = 1
        Button1.Text = "CURRENT MONTH"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(871, 29)
        Button2.Name = "Button2"
        Button2.Size = New Size(303, 49)
        Button2.TabIndex = 2
        Button2.Text = "CURRENT FINANCIAL YEAR"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(63, 537)
        Label2.Name = "Label2"
        Label2.Size = New Size(1067, 28)
        Label2.TabIndex = 3
        Label2.Text = "(PAYMENT WHICH IS NOT RECIVED TILL DATA, (NOT INCLUDNG INCOME FOR NEXT MONTHS FOR THE FINANCIAL YEAR)"
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(41, 102)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1262, 239)
        ListView1.TabIndex = 4
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(41, 42)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(300, 36)
        ComboBox1.TabIndex = 5
        ' 
        ' CheckPendingIncome
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1326, 661)
        Controls.Add(ComboBox1)
        Controls.Add(ListView1)
        Controls.Add(Label2)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(4)
        Name = "CheckPendingIncome"
        Text = "CheckPendingIncome"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ComboBox1 As ComboBox
End Class
