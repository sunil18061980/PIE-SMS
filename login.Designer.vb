<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Label1 = New Label()
        USER_ID = New TextBox()
        USER_PASSWORD = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Button1 = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Button5 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        NEWPASSWORD = New TextBox()
        NEWROLE = New ComboBox()
        NEWLASTNAME = New TextBox()
        NEWFIRSTNAME = New TextBox()
        NEWID = New TextBox()
        NEWCODE = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Button6 = New Button()
        Button4 = New Button()
        Button7 = New Button()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Transparent
        Label1.Location = New Point(41, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 28)
        Label1.TabIndex = 0
        Label1.Text = "USER ID"
        ' 
        ' USER_ID
        ' 
        USER_ID.Font = New Font("Segoe UI", 12F)
        USER_ID.Location = New Point(41, 101)
        USER_ID.Name = "USER_ID"
        USER_ID.PlaceholderText = "User ID"
        USER_ID.Size = New Size(212, 34)
        USER_ID.TabIndex = 9
        ' 
        ' USER_PASSWORD
        ' 
        USER_PASSWORD.Font = New Font("Segoe UI", 12F)
        USER_PASSWORD.Location = New Point(283, 101)
        USER_PASSWORD.Name = "USER_PASSWORD"
        USER_PASSWORD.PasswordChar = "+"c
        USER_PASSWORD.PlaceholderText = "Your Password"
        USER_PASSWORD.Size = New Size(212, 34)
        USER_PASSWORD.TabIndex = 10
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Transparent
        Label2.Location = New Point(283, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 28)
        Label2.TabIndex = 3
        Label2.Text = "PASSWORD"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Transparent
        Label3.Location = New Point(41, 15)
        Label3.Name = "Label3"
        Label3.Size = New Size(315, 38)
        Label3.TabIndex = 4
        Label3.Text = "USER AUTHENTICATION"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(501, 96)
        Button1.Name = "Button1"
        Button1.Size = New Size(106, 43)
        Button1.TabIndex = 11
        Button1.Text = "LOGIN"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(USER_ID)
        Panel1.Controls.Add(USER_PASSWORD)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(342, 175)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(622, 183)
        Panel1.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Button5)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(NEWPASSWORD)
        Panel2.Controls.Add(NEWROLE)
        Panel2.Controls.Add(NEWLASTNAME)
        Panel2.Controls.Add(NEWFIRSTNAME)
        Panel2.Controls.Add(NEWID)
        Panel2.Controls.Add(NEWCODE)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(Label4)
        Panel2.Location = New Point(360, 45)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(541, 399)
        Panel2.TabIndex = 7
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(369, 260)
        Button5.Name = "Button5"
        Button5.Size = New Size(140, 62)
        Button5.TabIndex = 12
        Button5.Text = "GOTO &LOGIN"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(369, 195)
        Button3.Name = "Button3"
        Button3.Size = New Size(140, 58)
        Button3.TabIndex = 8
        Button3.Text = "&CANCEL"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(369, 139)
        Button2.Name = "Button2"
        Button2.Size = New Size(140, 55)
        Button2.TabIndex = 7
        Button2.Text = "&SAVE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' NEWPASSWORD
        ' 
        NEWPASSWORD.Font = New Font("Segoe UI", 12F)
        NEWPASSWORD.Location = New Point(187, 268)
        NEWPASSWORD.Name = "NEWPASSWORD"
        NEWPASSWORD.PasswordChar = "+"c
        NEWPASSWORD.PlaceholderText = "Password"
        NEWPASSWORD.Size = New Size(151, 34)
        NEWPASSWORD.TabIndex = 5
        NEWPASSWORD.UseSystemPasswordChar = True
        ' 
        ' NEWROLE
        ' 
        NEWROLE.DropDownStyle = ComboBoxStyle.DropDownList
        NEWROLE.Font = New Font("Segoe UI", 12F)
        NEWROLE.FormattingEnabled = True
        NEWROLE.Items.AddRange(New Object() {"5", "4", "3", "2"})
        NEWROLE.Location = New Point(187, 322)
        NEWROLE.Name = "NEWROLE"
        NEWROLE.Size = New Size(151, 36)
        NEWROLE.TabIndex = 6
        ' 
        ' NEWLASTNAME
        ' 
        NEWLASTNAME.Font = New Font("Segoe UI", 12F)
        NEWLASTNAME.Location = New Point(187, 214)
        NEWLASTNAME.Name = "NEWLASTNAME"
        NEWLASTNAME.PlaceholderText = "Last Name"
        NEWLASTNAME.Size = New Size(151, 34)
        NEWLASTNAME.TabIndex = 4
        ' 
        ' NEWFIRSTNAME
        ' 
        NEWFIRSTNAME.Font = New Font("Segoe UI", 12F)
        NEWFIRSTNAME.Location = New Point(187, 166)
        NEWFIRSTNAME.Name = "NEWFIRSTNAME"
        NEWFIRSTNAME.PlaceholderText = "First Name"
        NEWFIRSTNAME.Size = New Size(151, 34)
        NEWFIRSTNAME.TabIndex = 3
        ' 
        ' NEWID
        ' 
        NEWID.Font = New Font("Segoe UI", 12F)
        NEWID.Location = New Point(187, 114)
        NEWID.Name = "NEWID"
        NEWID.PlaceholderText = "userID"
        NEWID.Size = New Size(151, 34)
        NEWID.TabIndex = 2
        ' 
        ' NEWCODE
        ' 
        NEWCODE.Font = New Font("Segoe UI", 12F)
        NEWCODE.Location = New Point(187, 68)
        NEWCODE.Name = "NEWCODE"
        NEWCODE.PlaceholderText = "Auto Generated Code"
        NEWCODE.ReadOnly = True
        NEWCODE.Size = New Size(151, 34)
        NEWCODE.TabIndex = 1
        NEWCODE.TabStop = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F)
        Label10.ForeColor = Color.WhiteSmoke
        Label10.Location = New Point(44, 330)
        Label10.Name = "Label10"
        Label10.Size = New Size(116, 28)
        Label10.TabIndex = 6
        Label10.Text = "AUTHORITY"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F)
        Label9.ForeColor = Color.WhiteSmoke
        Label9.Location = New Point(44, 275)
        Label9.Name = "Label9"
        Label9.Size = New Size(117, 28)
        Label9.TabIndex = 5
        Label9.Text = "PASSWORD"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F)
        Label8.ForeColor = Color.WhiteSmoke
        Label8.Location = New Point(44, 214)
        Label8.Name = "Label8"
        Label8.Size = New Size(117, 28)
        Label8.TabIndex = 4
        Label8.Text = "LAST NAME"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.ForeColor = Color.WhiteSmoke
        Label7.Location = New Point(40, 166)
        Label7.Name = "Label7"
        Label7.Size = New Size(121, 28)
        Label7.TabIndex = 3
        Label7.Text = "FIRST NAME"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.WhiteSmoke
        Label6.Location = New Point(44, 121)
        Label6.Name = "Label6"
        Label6.Size = New Size(83, 28)
        Label6.TabIndex = 2
        Label6.Text = "USER ID"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.WhiteSmoke
        Label5.Location = New Point(41, 75)
        Label5.Name = "Label5"
        Label5.Size = New Size(114, 28)
        Label5.TabIndex = 1
        Label5.Text = "USER CODE"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.IndianRed
        Label4.Location = New Point(16, 6)
        Label4.Name = "Label4"
        Label4.Size = New Size(326, 41)
        Label4.TabIndex = 0
        Label4.Text = "USER REGISTRATION"
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(979, 235)
        Button6.Name = "Button6"
        Button6.Size = New Size(140, 58)
        Button6.TabIndex = 13
        Button6.Text = "ADD &NEW USER"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(979, 296)
        Button4.Name = "Button4"
        Button4.Size = New Size(140, 66)
        Button4.TabIndex = 15
        Button4.Text = "E&XIT"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(979, 179)
        Button7.Name = "Button7"
        Button7.Size = New Size(140, 53)
        Button7.TabIndex = 16
        Button7.Text = "FORGET PASSWORD"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.Logo
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(23, 114)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(298, 248)
        PictureBox1.TabIndex = 17
        PictureBox1.TabStop = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.HotTrack
        ClientSize = New Size(1200, 473)
        Controls.Add(PictureBox1)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Button4)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        FormScreenCaptureMode = ScreenCaptureMode.HideWindow
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "USER LOGIN / ADD NEW USERS"
        TopMost = True
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NEWCODE As TextBox
    Friend WithEvents USER_PASSWORD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents USER_ID As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents NEWPASSWORD As TextBox
    Friend WithEvents NEWROLE As ComboBox
    Friend WithEvents NEWLASTNAME As TextBox
    Friend WithEvents NEWFIRSTNAME As TextBox
    Friend WithEvents NEWID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
