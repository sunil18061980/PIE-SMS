<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankDetails
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
        ListBox1 = New ListBox()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        ListView1 = New ListView()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        TextBox5 = New TextBox()
        TextBox6 = New TextBox()
        TextBox7 = New TextBox()
        TextBox8 = New TextBox()
        GroupBox1 = New GroupBox()
        Label10 = New Label()
        TextBox9 = New TextBox()
        Button6 = New Button()
        Button5 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(24, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(219, 25)
        Label1.TabIndex = 0
        Label1.Text = "LISTED BANK NAMES"
        ' 
        ' ListBox1
        ' 
        ListBox1.BackColor = Color.White
        ListBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListBox1.ForeColor = Color.Black
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(12, 68)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(258, 340)
        ListBox1.TabIndex = 1
        ' 
        ' TextBox1
        ' 
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(14, 414)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "New Bank Name"
        TextBox1.Size = New Size(255, 34)
        TextBox1.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Black
        Button1.FlatStyle = FlatStyle.System
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.ForeColor = Color.Transparent
        Button1.Location = New Point(14, 564)
        Button1.Name = "Button1"
        Button1.Size = New Size(257, 40)
        Button1.TabIndex = 3
        Button1.Text = "UPDATE BANK NAME"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Black
        Button2.FlatStyle = FlatStyle.System
        Button2.Font = New Font("Segoe UI", 12F)
        Button2.ForeColor = Color.Transparent
        Button2.Location = New Point(1122, 10)
        Button2.Name = "Button2"
        Button2.Size = New Size(123, 49)
        Button2.TabIndex = 6
        Button2.Text = "&CLOSE"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Black
        Button3.Enabled = False
        Button3.FlatStyle = FlatStyle.System
        Button3.Font = New Font("Segoe UI", 12F)
        Button3.ForeColor = Color.Transparent
        Button3.Location = New Point(12, 454)
        Button3.Name = "Button3"
        Button3.Size = New Size(257, 40)
        Button3.TabIndex = 4
        Button3.Text = "SAVE CHANGES"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Black
        Button4.FlatStyle = FlatStyle.System
        Button4.Font = New Font("Segoe UI", 12F)
        Button4.ForeColor = Color.Transparent
        Button4.Location = New Point(907, 11)
        Button4.Name = "Button4"
        Button4.Size = New Size(210, 46)
        Button4.TabIndex = 5
        Button4.Text = "SH0W STAFF DETAILS"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(297, 68)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(949, 264)
        ListView1.TabIndex = 7
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(12, 49)
        Label2.Name = "Label2"
        Label2.Size = New Size(71, 28)
        Label2.TabIndex = 8
        Label2.Text = "PLACE"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(309, 34)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 25)
        Label3.TabIndex = 9
        Label3.Text = "Bank - Staff Details"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(6, 101)
        Label4.Name = "Label4"
        Label4.Size = New Size(72, 28)
        Label4.TabIndex = 10
        Label4.Text = "NAME"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(534, 104)
        Label5.Name = "Label5"
        Label5.Size = New Size(147, 28)
        Label5.TabIndex = 11
        Label5.Text = "DESIGNATION"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(6, 159)
        Label6.Name = "Label6"
        Label6.Size = New Size(86, 28)
        Label6.TabIndex = 12
        Label6.Text = "MOBILE"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(534, 156)
        Label7.Name = "Label7"
        Label7.Size = New Size(110, 28)
        Label7.TabIndex = 13
        Label7.Text = "LANDLINE"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(6, 216)
        Label8.Name = "Label8"
        Label8.Size = New Size(72, 28)
        Label8.TabIndex = 14
        Label8.Text = "EMAIL"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label9.ForeColor = Color.White
        Label9.Location = New Point(422, 216)
        Label9.Name = "Label9"
        Label9.Size = New Size(106, 28)
        Label9.TabIndex = 15
        Label9.Text = "REMARKS"
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 12F)
        TextBox2.Location = New Point(786, 43)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(137, 34)
        TextBox2.TabIndex = 17
        TextBox2.TabStop = False
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 12F)
        TextBox3.Location = New Point(139, 101)
        TextBox3.Name = "TextBox3"
        TextBox3.PlaceholderText = "Employee name"
        TextBox3.Size = New Size(277, 34)
        TextBox3.TabIndex = 9
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 12F)
        TextBox4.Location = New Point(139, 156)
        TextBox4.Name = "TextBox4"
        TextBox4.PlaceholderText = "Mobile"
        TextBox4.Size = New Size(277, 34)
        TextBox4.TabIndex = 11
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 12F)
        TextBox5.Location = New Point(139, 216)
        TextBox5.Name = "TextBox5"
        TextBox5.PlaceholderText = "Email ID"
        TextBox5.Size = New Size(277, 34)
        TextBox5.TabIndex = 13
        ' 
        ' TextBox6
        ' 
        TextBox6.Font = New Font("Segoe UI", 12F)
        TextBox6.Location = New Point(706, 97)
        TextBox6.Name = "TextBox6"
        TextBox6.PlaceholderText = "Designation"
        TextBox6.Size = New Size(217, 34)
        TextBox6.TabIndex = 10
        ' 
        ' TextBox7
        ' 
        TextBox7.Font = New Font("Segoe UI", 12F)
        TextBox7.Location = New Point(710, 153)
        TextBox7.Name = "TextBox7"
        TextBox7.PlaceholderText = "LandLine Number"
        TextBox7.Size = New Size(213, 34)
        TextBox7.TabIndex = 12
        ' 
        ' TextBox8
        ' 
        TextBox8.Font = New Font("Segoe UI", 12F)
        TextBox8.Location = New Point(547, 216)
        TextBox8.Name = "TextBox8"
        TextBox8.PlaceholderText = "Any Remarks "
        TextBox8.Size = New Size(376, 34)
        TextBox8.TabIndex = 14
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(TextBox9)
        GroupBox1.Controls.Add(Button6)
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(TextBox5)
        GroupBox1.Controls.Add(TextBox8)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBox7)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox6)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox4)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.FlatStyle = FlatStyle.System
        GroupBox1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = Color.IndianRed
        GroupBox1.Location = New Point(297, 338)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(949, 344)
        GroupBox1.TabIndex = 23
        GroupBox1.TabStop = False
        GroupBox1.Text = "ADD/ MODIFY STAFF DETAILS"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label10.ForeColor = Color.White
        Label10.Location = New Point(695, 49)
        Label10.Name = "Label10"
        Label10.Size = New Size(54, 28)
        Label10.TabIndex = 24
        Label10.Text = "EMP"
        ' 
        ' TextBox9
        ' 
        TextBox9.Location = New Point(139, 44)
        TextBox9.Name = "TextBox9"
        TextBox9.PlaceholderText = "short address"
        TextBox9.Size = New Size(378, 38)
        TextBox9.TabIndex = 8
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.Black
        Button6.Location = New Point(494, 270)
        Button6.Name = "Button6"
        Button6.Size = New Size(221, 60)
        Button6.TabIndex = 16
        Button6.Text = "SAVE/ UPDATE "
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.Black
        Button5.Location = New Point(183, 270)
        Button5.Name = "Button5"
        Button5.Size = New Size(271, 60)
        Button5.TabIndex = 15
        Button5.Text = "NEW BANK STAFF"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' BankDetails
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.MenuHighlight
        ClientSize = New Size(1283, 692)
        Controls.Add(Label3)
        Controls.Add(ListView1)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(ListBox1)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "BankDetails"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add / Update Bank Details "
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label10 As Label
End Class
