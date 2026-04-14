<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncomeAllocation
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Label2 = New Label()
        ComboBox1 = New ComboBox()
        ListBox1 = New ListBox()
        Label3 = New Label()
        ListView2 = New ListView()
        ListView3 = New ListView()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label11 = New Label()
        ComboBox2 = New ComboBox()
        Button1 = New Button()
        DateTimePicker1 = New DateTimePicker()
        TextBox1 = New TextBox()
        ComboBox3 = New ComboBox()
        DateTimePicker2 = New DateTimePicker()
        Button2 = New Button()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        TextBox3 = New TextBox()
        Label12 = New Label()
        Button3 = New Button()
        TextBox2 = New TextBox()
        Button4 = New Button()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        Label10 = New Label()
        Button5 = New Button()
        Button6 = New Button()
        GroupBox3 = New GroupBox()
        ContextMenuStrip1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        Label1.Location = New Point(398, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(536, 31)
        Label1.TabIndex = 0
        Label1.Text = "INCOME ALLOCATION - ASSIGN A NEW INCOME "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.MenuHighlight
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(62, 54)
        Label2.Name = "Label2"
        Label2.Size = New Size(126, 28)
        Label2.TabIndex = 1
        Label2.Text = "SELECT USER"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 12F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(24, 90)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(329, 36)
        ComboBox1.TabIndex = 1
        ' 
        ' ListBox1
        ' 
        ListBox1.Font = New Font("Segoe UI", 12F)
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(24, 162)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(328, 228)
        ListBox1.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.MenuHighlight
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = SystemColors.ButtonHighlight
        Label3.Location = New Point(62, 129)
        Label3.Name = "Label3"
        Label3.Size = New Size(235, 28)
        Label3.TabIndex = 5
        Label3.Text = "LINKED INCOME SOURCE"
        ' 
        ' ListView2
        ' 
        ListView2.Location = New Point(12, 438)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(1316, 137)
        ListView2.TabIndex = 6
        ListView2.TabStop = False
        ListView2.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView3
        ' 
        ListView3.Location = New Point(12, 606)
        ListView3.Name = "ListView3"
        ListView3.Size = New Size(1316, 119)
        ListView3.TabIndex = 7
        ListView3.TabStop = False
        ListView3.UseCompatibleStateImageBehavior = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(26, 412)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 20)
        Label4.TabIndex = 8
        Label4.Text = "Currently Active"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(26, 583)
        Label5.Name = "Label5"
        Label5.Size = New Size(89, 20)
        Label5.TabIndex = 9
        Label5.Text = "Deactivated"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = SystemColors.MenuHighlight
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = SystemColors.ButtonHighlight
        Label6.Location = New Point(34, 23)
        Label6.Name = "Label6"
        Label6.Size = New Size(187, 28)
        Label6.TabIndex = 10
        Label6.Text = "INCOME CATEGORY"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = SystemColors.MenuHighlight
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.ForeColor = SystemColors.ButtonHighlight
        Label7.Location = New Point(265, 107)
        Label7.Name = "Label7"
        Label7.Size = New Size(117, 28)
        Label7.TabIndex = 11
        Label7.Text = "START DATE"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = SystemColors.MenuHighlight
        Label8.Font = New Font("Segoe UI", 12F)
        Label8.ForeColor = SystemColors.ButtonHighlight
        Label8.Location = New Point(272, 23)
        Label8.Name = "Label8"
        Label8.Size = New Size(97, 28)
        Label8.TabIndex = 12
        Label8.Text = "AMOUNT"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = SystemColors.MenuHighlight
        Label9.Font = New Font("Segoe UI", 12F)
        Label9.ForeColor = SystemColors.ButtonHighlight
        Label9.Location = New Point(21, 107)
        Label9.Name = "Label9"
        Label9.Size = New Size(212, 28)
        Label9.TabIndex = 13
        Label9.Text = "PAYMNENT SCHEDULE"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = SystemColors.MenuHighlight
        Label11.Font = New Font("Segoe UI", 12F)
        Label11.ForeColor = SystemColors.ButtonHighlight
        Label11.Location = New Point(611, 183)
        Label11.Name = "Label11"
        Label11.Size = New Size(79, 28)
        Label11.TabIndex = 15
        Label11.Text = "STATUS"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Segoe UI", 12F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(21, 52)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(217, 36)
        ComboBox2.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.Location = New Point(33, 267)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 51)
        Button1.TabIndex = 3
        Button1.Text = "&NEW"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Font = New Font("Segoe UI", 12F)
        DateTimePicker1.Location = New Point(248, 142)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(225, 34)
        DateTimePicker1.TabIndex = 10
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.Location = New Point(265, 53)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(125, 34)
        TextBox1.TabIndex = 8
        ' 
        ' ComboBox3
        ' 
        ComboBox3.Font = New Font("Segoe UI", 12F)
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New Point(21, 143)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(217, 36)
        ComboBox3.TabIndex = 9
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Font = New Font("Segoe UI", 12F)
        DateTimePicker2.Location = New Point(486, 138)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(250, 34)
        DateTimePicker2.TabIndex = 11
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.Location = New Point(138, 267)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 51)
        Button2.TabIndex = 4
        Button2.Text = "&SAVE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, ToolStripMenuItem2})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(162, 52)
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(161, 24)
        ToolStripMenuItem1.Text = "EDIT"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(161, 24)
        ToolStripMenuItem2.Text = "DEACTIVATE"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 12F)
        TextBox3.Location = New Point(20, 216)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(575, 34)
        TextBox3.TabIndex = 12
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = SystemColors.MenuHighlight
        Label12.Font = New Font("Segoe UI", 12F)
        Label12.ForeColor = SystemColors.ButtonHighlight
        Label12.Location = New Point(23, 182)
        Label12.Name = "Label12"
        Label12.Size = New Size(100, 28)
        Label12.TabIndex = 25
        Label12.Text = "REMARKS"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 12F)
        Button3.Location = New Point(243, 267)
        Button3.Name = "Button3"
        Button3.Size = New Size(94, 51)
        Button3.TabIndex = 5
        Button3.Text = "&CANCEL"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 12F)
        TextBox2.Location = New Point(611, 216)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(125, 34)
        TextBox2.TabIndex = 13
        TextBox2.TabStop = False
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Segoe UI", 12F)
        Button4.Location = New Point(352, 267)
        Button4.Name = "Button4"
        Button4.Size = New Size(94, 51)
        Button4.TabIndex = 6
        Button4.Text = "E&XIT"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.Highlight
        GroupBox1.Location = New Point(18, 43)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(340, 355)
        GroupBox1.TabIndex = 29
        GroupBox1.TabStop = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = SystemColors.Highlight
        GroupBox2.Controls.Add(TextBox3)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Controls.Add(TextBox2)
        GroupBox2.Controls.Add(Button4)
        GroupBox2.Controls.Add(DateTimePicker2)
        GroupBox2.Controls.Add(Label12)
        GroupBox2.Controls.Add(Button1)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Controls.Add(DateTimePicker1)
        GroupBox2.Controls.Add(ComboBox3)
        GroupBox2.Controls.Add(Button3)
        GroupBox2.Controls.Add(TextBox1)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(ComboBox2)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Location = New Point(364, 43)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(752, 360)
        GroupBox2.TabIndex = 30
        GroupBox2.TabStop = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = SystemColors.MenuHighlight
        Label10.Font = New Font("Segoe UI", 12F)
        Label10.ForeColor = SystemColors.ButtonHighlight
        Label10.Location = New Point(495, 107)
        Label10.Name = "Label10"
        Label10.Size = New Size(201, 28)
        Label10.TabIndex = 14
        Label10.Text = "NEXT PAYMENT DATE"
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Segoe UI", 12F)
        Button5.ForeColor = SystemColors.ActiveCaptionText
        Button5.Location = New Point(14, 39)
        Button5.Name = "Button5"
        Button5.Size = New Size(147, 80)
        Button5.TabIndex = 31
        Button5.Text = "INCOME SOURCE"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Font = New Font("Segoe UI", 12F)
        Button6.ForeColor = SystemColors.ActiveCaptionText
        Button6.Location = New Point(14, 125)
        Button6.Name = "Button6"
        Button6.Size = New Size(147, 86)
        Button6.TabIndex = 32
        Button6.Text = "INCOME CATEGORY"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = SystemColors.MenuHighlight
        GroupBox3.Controls.Add(Button6)
        GroupBox3.Controls.Add(Button5)
        GroupBox3.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GroupBox3.ForeColor = SystemColors.ButtonHighlight
        GroupBox3.Location = New Point(1140, 41)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(176, 360)
        GroupBox3.TabIndex = 33
        GroupBox3.TabStop = False
        GroupBox3.Text = "ADD NEW"
        ' 
        ' IncomeAllocation
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1373, 792)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ListView3)
        Controls.Add(ListView2)
        Controls.Add(Label3)
        Controls.Add(ListBox1)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox3)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MinimizeBox = False
        Name = "IncomeAllocation"
        StartPosition = FormStartPosition.CenterParent
        Text = "IncomeAllocation"
        ContextMenuStrip1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ListView3 As ListView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents GroupBox3 As GroupBox
End Class
