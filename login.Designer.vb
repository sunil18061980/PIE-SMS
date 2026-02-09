<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        Button3 = New Button()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        NewCode = New TextBox()
        UserId = New TextBox()
        FirstName = New TextBox()
        LastName = New TextBox()
        Password = New TextBox()
        Authority = New ComboBox()
        GroupBox1 = New GroupBox()
        Label11 = New Label()
        Button6 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(304, 232)
        Button1.Margin = New Padding(4)
        Button1.Name = "Button1"
        Button1.Size = New Size(96, 49)
        Button1.TabIndex = 0
        Button1.Text = "&LOGIN"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(131, 607)
        Button2.Margin = New Padding(4)
        Button2.Name = "Button2"
        Button2.Size = New Size(96, 60)
        Button2.TabIndex = 1
        Button2.Text = "&QUIT"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.DarkSeaGreen
        Label1.FlatStyle = FlatStyle.System
        Label1.ForeColor = Color.Blue
        Label1.Location = New Point(62, 117)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 28)
        Label1.TabIndex = 2
        Label1.Text = "USER  ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.DarkSeaGreen
        Label2.FlatStyle = FlatStyle.System
        Label2.ForeColor = Color.Blue
        Label2.Location = New Point(65, 201)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 28)
        Label2.TabIndex = 3
        Label2.Text = "PASSWORD"
        ' 
        ' TextBox1
        ' 
        TextBox1.ForeColor = SystemColors.MenuHighlight
        TextBox1.Location = New Point(62, 149)
        TextBox1.Margin = New Padding(4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(214, 34)
        TextBox1.TabIndex = 4
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = SystemColors.ButtonHighlight
        TextBox2.ForeColor = Color.Black
        TextBox2.Location = New Point(65, 246)
        TextBox2.Margin = New Padding(4)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "-"c
        TextBox2.Size = New Size(214, 34)
        TextBox2.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.DarkSeaGreen
        Label3.FlatStyle = FlatStyle.System
        Label3.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Blue
        Label3.Location = New Point(546, 31)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(242, 32)
        Label3.TabIndex = 6
        Label3.Text = "REGISTER NEW USER"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.DarkSeaGreen
        Label4.FlatStyle = FlatStyle.System
        Label4.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Blue
        Label4.Location = New Point(19, 58)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(132, 37)
        Label4.TabIndex = 7
        Label4.Text = "NO USER"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(661, 448)
        Button3.Margin = New Padding(4)
        Button3.Name = "Button3"
        Button3.Size = New Size(104, 62)
        Button3.TabIndex = 8
        Button3.Text = "&SAVE"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.DarkSeaGreen
        Label5.FlatStyle = FlatStyle.System
        Label5.ForeColor = Color.Blue
        Label5.Location = New Point(516, 120)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(63, 28)
        Label5.TabIndex = 9
        Label5.Text = "CODE"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.DarkSeaGreen
        Label6.FlatStyle = FlatStyle.System
        Label6.ForeColor = Color.Blue
        Label6.Location = New Point(516, 168)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(85, 28)
        Label6.TabIndex = 10
        Label6.Text = "USER ID"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.DarkSeaGreen
        Label7.FlatStyle = FlatStyle.System
        Label7.ForeColor = Color.Blue
        Label7.Location = New Point(516, 221)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(124, 28)
        Label7.TabIndex = 11
        Label7.Text = "FIRST NAME"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.DarkSeaGreen
        Label8.FlatStyle = FlatStyle.System
        Label8.ForeColor = Color.Blue
        Label8.Location = New Point(516, 275)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(120, 28)
        Label8.TabIndex = 12
        Label8.Text = "LAST NAME"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.DarkSeaGreen
        Label9.FlatStyle = FlatStyle.System
        Label9.ForeColor = Color.Blue
        Label9.Location = New Point(516, 330)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(118, 28)
        Label9.TabIndex = 13
        Label9.Text = "PASSWORD"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.DarkSeaGreen
        Label10.FlatStyle = FlatStyle.System
        Label10.ForeColor = Color.Blue
        Label10.Location = New Point(516, 386)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(121, 28)
        Label10.TabIndex = 14
        Label10.Text = "AUTHORITY"
        ' 
        ' NewCode
        ' 
        NewCode.Location = New Point(661, 117)
        NewCode.Margin = New Padding(4)
        NewCode.Name = "NewCode"
        NewCode.ReadOnly = True
        NewCode.Size = New Size(127, 34)
        NewCode.TabIndex = 15
        ' 
        ' UserId
        ' 
        UserId.CharacterCasing = CharacterCasing.Upper
        UserId.Location = New Point(662, 164)
        UserId.Margin = New Padding(4)
        UserId.MaxLength = 10
        UserId.Name = "UserId"
        UserId.PlaceholderText = "UserId"
        UserId.Size = New Size(199, 34)
        UserId.TabIndex = 16
        ' 
        ' FirstName
        ' 
        FirstName.CharacterCasing = CharacterCasing.Upper
        FirstName.Location = New Point(663, 221)
        FirstName.Margin = New Padding(4)
        FirstName.Name = "FirstName"
        FirstName.PlaceholderText = "FirstName"
        FirstName.Size = New Size(198, 34)
        FirstName.TabIndex = 17
        ' 
        ' LastName
        ' 
        LastName.CharacterCasing = CharacterCasing.Upper
        LastName.Location = New Point(662, 269)
        LastName.Margin = New Padding(4)
        LastName.Name = "LastName"
        LastName.PlaceholderText = "LastName"
        LastName.Size = New Size(198, 34)
        LastName.TabIndex = 18
        ' 
        ' Password
        ' 
        Password.Location = New Point(661, 326)
        Password.Margin = New Padding(4)
        Password.MaxLength = 10
        Password.Name = "Password"
        Password.PasswordChar = "*"c
        Password.PlaceholderText = "Password"
        Password.Size = New Size(199, 34)
        Password.TabIndex = 19
        Password.UseSystemPasswordChar = True
        ' 
        ' Authority
        ' 
        Authority.FormattingEnabled = True
        Authority.Items.AddRange(New Object() {"5", "4", "3", "2"})
        Authority.Location = New Point(663, 380)
        Authority.Margin = New Padding(4)
        Authority.Name = "Authority"
        Authority.Size = New Size(154, 36)
        Authority.TabIndex = 20
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.BackgroundImageLayout = ImageLayout.Stretch
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Authority)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Password)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(LastName)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(FirstName)
        GroupBox1.Controls.Add(NewCode)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(UserId)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Location = New Point(44, 17)
        GroupBox1.Margin = New Padding(4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4)
        GroupBox1.Size = New Size(960, 568)
        GroupBox1.TabIndex = 21
        GroupBox1.TabStop = False
        GroupBox1.Text = "New User"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.White
        Label11.Font = New Font("Bell MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Sienna
        Label11.Location = New Point(13, 302)
        Label11.Name = "Label11"
        Label11.Size = New Size(437, 252)
        Label11.TabIndex = 21
        Label11.Text = resources.GetString("Label11.Text")
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(829, 607)
        Button6.Name = "Button6"
        Button6.Size = New Size(105, 62)
        Button6.TabIndex = 23
        Button6.Text = "&CANCEL"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Cursor = Cursors.No
        Button4.Enabled = False
        Button4.Location = New Point(606, 607)
        Button4.Name = "Button4"
        Button4.Size = New Size(191, 62)
        Button4.TabIndex = 22
        Button4.Text = "SINGUP"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(297, 605)
        Button5.Name = "Button5"
        Button5.Size = New Size(260, 62)
        Button5.TabIndex = 22
        Button5.Text = "FORGET PASSWORD"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.DarkSeaGreen
        CancelButton = Button6
        ClientSize = New Size(1073, 680)
        Controls.Add(Button6)
        Controls.Add(Button4)
        Controls.Add(Button5)
        Controls.Add(GroupBox1)
        Controls.Add(Button2)
        Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(4)
        MaximizeBox = False
        Name = "login"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "USER AUTHENTICATION"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NewCode As TextBox
    Friend WithEvents UserId As TextBox
    Friend WithEvents Password As TextBox
    Friend WithEvents FirstName As TextBox
    Friend WithEvents LastName As TextBox
    Friend WithEvents Authority As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Button6 As Button
End Class
