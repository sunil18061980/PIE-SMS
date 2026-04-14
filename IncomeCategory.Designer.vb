<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncomeCategory
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
        Label2 = New Label()
        Label3 = New Label()
        Label5 = New Label()
        Button1 = New Button()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        ListBox1 = New ListBox()
        Button2 = New Button()
        GroupBox1 = New GroupBox()
        Button3 = New Button()
        GroupBox2 = New GroupBox()
        Label1 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Historic", 13.8F)
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(81, 94)
        Label2.Name = "Label2"
        Label2.Size = New Size(198, 31)
        Label2.TabIndex = 1
        Label2.Text = "CATEGORY NAME"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Historic", 13.8F)
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(67, 222)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 31)
        Label3.TabIndex = 2
        Label3.Text = "REMAKRS"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.ButtonHighlight
        Label5.Location = New Point(67, 178)
        Label5.Name = "Label5"
        Label5.Size = New Size(417, 20)
        Label5.TabIndex = 4
        Label5.Text = "(Hints - Shop Rent, House Rent, Salary, Insurance Maturity etc)"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 13.8F)
        Button1.ForeColor = SystemColors.ActiveCaptionText
        Button1.Location = New Point(178, 296)
        Button1.Name = "Button1"
        Button1.Size = New Size(115, 42)
        Button1.TabIndex = 5
        Button1.Text = "&SAVE"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox1.Font = New Font("Segoe UI", 13.8F)
        TextBox1.Location = New Point(67, 128)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "SALARY, PROFIT, RENT"
        TextBox1.Size = New Size(417, 38)
        TextBox1.TabIndex = 6
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 13.8F)
        TextBox2.Location = New Point(67, 256)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(417, 38)
        TextBox2.TabIndex = 7
        TextBox2.Text = "NA"
        ' 
        ' ListBox1
        ' 
        ListBox1.Font = New Font("Segoe UI Emoji", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(13, 37)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(445, 345)
        ListBox1.TabIndex = 8
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 13.8F)
        Button2.ForeColor = SystemColors.ActiveCaptionText
        Button2.Location = New Point(319, 296)
        Button2.Name = "Button2"
        Button2.Size = New Size(105, 42)
        Button2.TabIndex = 9
        Button2.Text = "&CLOSE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = SystemColors.ButtonHighlight
        GroupBox1.Location = New Point(25, 41)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(514, 407)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "INCOME SOURCE CATEGORY"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = SystemColors.ActiveCaptionText
        Button3.Location = New Point(41, 296)
        Button3.Name = "Button3"
        Button3.Size = New Size(115, 42)
        Button3.TabIndex = 10
        Button3.Text = "&NEW"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(ListBox1)
        GroupBox2.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox2.ForeColor = SystemColors.ButtonHighlight
        GroupBox2.Location = New Point(560, 42)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(474, 407)
        GroupBox2.TabIndex = 11
        GroupBox2.TabStop = False
        GroupBox2.Text = "LISTED SOURCE CATEGORIES"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Transparent
        Label1.Location = New Point(67, 488)
        Label1.Name = "Label1"
        Label1.Size = New Size(916, 28)
        Label1.TabIndex = 12
        Label1.Text = "This will be useful to check type of income we are getting and will be associated with any income source "
        ' 
        ' IncomeCategory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.MenuHighlight
        ClientSize = New Size(1093, 570)
        Controls.Add(Label1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "IncomeCategory"
        SizeGripStyle = SizeGripStyle.Show
        StartPosition = FormStartPosition.CenterParent
        Text = "INCOME CATEGORY - TYPES OF INCOME "
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
End Class
