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
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label11 = New Label()
        Button6 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        GroupBox1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(16, 240)
        Button1.Margin = New Padding(4)
        Button1.Name = "Button1"
        Button1.Size = New Size(96, 49)
        Button1.TabIndex = 0
        Button1.Text = "&LOGIN"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(390, 384)
        Button2.Margin = New Padding(4)
        Button2.Name = "Button2"
        Button2.Size = New Size(128, 60)
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
        Label1.Location = New Point(16, 17)
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
        Label2.Location = New Point(16, 127)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 28)
        Label2.TabIndex = 3
        Label2.Text = "PASSWORD"
        ' 
        ' TextBox1
        ' 
        TextBox1.ForeColor = SystemColors.MenuHighlight
        TextBox1.Location = New Point(16, 62)
        TextBox1.Margin = New Padding(4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(214, 34)
        TextBox1.TabIndex = 4
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = SystemColors.ButtonHighlight
        TextBox2.ForeColor = Color.Black
        TextBox2.Location = New Point(16, 172)
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
        Label3.Location = New Point(257, 29)
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
        Label4.Location = New Point(64, 26)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(132, 37)
        Label4.TabIndex = 7
        Label4.Text = "NO USER"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(18, 324)
        Button3.Margin = New Padding(4)
        Button3.Name = "Button3"
        Button3.Size = New Size(121, 46)
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
        Label5.Location = New Point(19, 7)
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
        Label6.Location = New Point(19, 47)
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
        Label7.Location = New Point(20, 93)
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
        Label8.Location = New Point(19, 141)
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
        Label9.Location = New Point(21, 200)
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
        Label10.Location = New Point(18, 248)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(121, 28)
        Label10.TabIndex = 14
        Label10.Text = "AUTHORITY"
        ' 
        ' NewCode
        ' 
        NewCode.Location = New Point(172, 4)
        NewCode.Margin = New Padding(4)
        NewCode.Name = "NewCode"
        NewCode.ReadOnly = True
        NewCode.Size = New Size(127, 34)
        NewCode.TabIndex = 15
        ' 
        ' UserId
        ' 
        UserId.CharacterCasing = CharacterCasing.Upper
        UserId.Location = New Point(172, 47)
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
        FirstName.Location = New Point(172, 93)
        FirstName.Margin = New Padding(4)
        FirstName.Name = "FirstName"
        FirstName.PlaceholderText = "FirstName"
        FirstName.Size = New Size(198, 34)
        FirstName.TabIndex = 17
        ' 
        ' LastName
        ' 
        LastName.CharacterCasing = CharacterCasing.Upper
        LastName.Location = New Point(172, 141)
        LastName.Margin = New Padding(4)
        LastName.Name = "LastName"
        LastName.PlaceholderText = "LastName"
        LastName.Size = New Size(198, 34)
        LastName.TabIndex = 18
        ' 
        ' Password
        ' 
        Password.Location = New Point(171, 200)
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
        Authority.Location = New Point(172, 248)
        Authority.Margin = New Padding(4)
        Authority.Name = "Authority"
        Authority.Size = New Size(154, 36)
        Authority.TabIndex = 20
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.BackgroundImageLayout = ImageLayout.Stretch
        GroupBox1.Controls.Add(Panel1)
        GroupBox1.Location = New Point(64, 82)
        GroupBox1.Margin = New Padding(4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4)
        GroupBox1.Size = New Size(295, 397)
        GroupBox1.TabIndex = 21
        GroupBox1.TabStop = False
        GroupBox1.Text = "New User"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Location = New Point(7, 81)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(250, 319)
        Panel1.TabIndex = 24
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(NewCode)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(Authority)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(UserId)
        Panel2.Controls.Add(FirstName)
        Panel2.Controls.Add(Password)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(LastName)
        Panel2.Controls.Add(Label8)
        Panel2.Location = New Point(4, 82)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(381, 397)
        Panel2.TabIndex = 24
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.White
        Label11.Font = New Font("Bell MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.Sienna
        Label11.Location = New Point(12, 485)
        Label11.Name = "Label11"
        Label11.Size = New Size(437, 252)
        Label11.TabIndex = 21
        Label11.Text = resources.GetString("Label11.Text")
        Label11.Visible = False
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(389, 196)
        Button6.Name = "Button6"
        Button6.Size = New Size(126, 62)
        Button6.TabIndex = 23
        Button6.Text = "&CANCEL"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Cursor = Cursors.No
        Button4.Location = New Point(389, 115)
        Button4.Name = "Button4"
        Button4.Size = New Size(128, 64)
        Button4.TabIndex = 22
        Button4.Text = "SINGUP"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(390, 280)
        Button5.Name = "Button5"
        Button5.Size = New Size(128, 81)
        Button5.TabIndex = 22
        Button5.Text = "FORGET PASSWORD"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.DarkSeaGreen
        CancelButton = Button6
        ClientSize = New Size(605, 777)
        Controls.Add(Panel2)
        Controls.Add(Label4)
        Controls.Add(Label11)
        Controls.Add(Label3)
        Controls.Add(Button6)
        Controls.Add(Button4)
        Controls.Add(Button5)
        Controls.Add(GroupBox1)
        Controls.Add(Button2)
        Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(4)
        MaximizeBox = False
        Name = "login"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "USER AUTHENTICATION"
        GroupBox1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
