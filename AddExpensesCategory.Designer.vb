<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddExpensesCategory
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
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        ComboBox1 = New ComboBox()
        Label4 = New Label()
        ListView1 = New ListView()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        GroupBox1 = New GroupBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(362, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(363, 41)
        Label1.TabIndex = 0
        Label1.Text = "EXPENSES CATEGORIES"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(15, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 28)
        Label2.TabIndex = 1
        Label2.Text = "CATEGORY NAME"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(21, 237)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 28)
        Label3.TabIndex = 2
        Label3.Text = "REMARKS"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 10.8F)
        TextBox1.Location = New Point(17, 170)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "EXPENSE NAME"
        TextBox1.Size = New Size(269, 31)
        TextBox1.TabIndex = 3
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 10.8F)
        TextBox2.Location = New Point(15, 280)
        TextBox2.Name = "TextBox2"
        TextBox2.PlaceholderText = "About Expenses"
        TextBox2.Size = New Size(392, 31)
        TextBox2.TabIndex = 3
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 10.8F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"DIRECT EXPENSES", "INDIRECT EXPENSES", "LONG TERM SAVING"})
        ComboBox1.Location = New Point(15, 58)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(270, 33)
        ComboBox1.TabIndex = 1
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(21, 27)
        Label4.Name = "Label4"
        Label4.Size = New Size(158, 28)
        Label4.TabIndex = 7
        Label4.Text = "EXPENSES HEAD"
        ' 
        ' ListView1
        ' 
        ListView1.BackColor = SystemColors.HotTrack
        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.ForeColor = SystemColors.HighlightText
        ListView1.GridLines = True
        ListView1.Location = New Point(490, 62)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(641, 480)
        ListView1.Sorting = SortOrder.Ascending
        ListView1.TabIndex = 6
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(22, 369)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 50)
        Button1.TabIndex = 4
        Button1.Text = "&NEW"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.HotTrack
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.Location = New Point(156, 369)
        Button2.Name = "Button2"
        Button2.Size = New Size(105, 50)
        Button2.TabIndex = 5
        Button2.Text = "&SAVE"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.HotTrack
        Button3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(287, 369)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 50)
        Button3.TabIndex = 11
        Button3.Text = "E&XIT"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.HotTrack
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(33, 61)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(433, 481)
        GroupBox1.TabIndex = 12
        GroupBox1.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(21, 314)
        Label7.Name = "Label7"
        Label7.Size = New Size(260, 20)
        Label7.TabIndex = 12
        Label7.Text = "(Any Ref or some Point to Remember)"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(21, 204)
        Label6.Name = "Label6"
        Label6.Size = New Size(370, 20)
        Label6.TabIndex = 2
        Label6.Text = "(Like Room Rent Paid, Fees, Veg Purchase,  Movies etc.)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(19, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(187, 20)
        Label5.TabIndex = 7
        Label5.Text = "(Direct / Indirect Expenses)"
        ' 
        ' AddExpensesCategory
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Highlight
        ClientSize = New Size(1181, 586)
        Controls.Add(ListView1)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        ForeColor = SystemColors.ButtonHighlight
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddExpensesCategory"
        StartPosition = FormStartPosition.CenterParent
        Text = "AddExpensesCategory"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
