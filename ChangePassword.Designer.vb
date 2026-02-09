<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Label4 = New Label()
        FID = New TextBox()
        FFNAME = New TextBox()
        FAUTH = New TextBox()
        NPASS = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Label6 = New Label()
        FCODE = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sylfaen", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(202, 28)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(312, 39)
        Label1.TabIndex = 0
        Label1.Text = "PASSWORD FORGET "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(213, 192)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 28)
        Label2.TabIndex = 1
        Label2.Text = "USER ID"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(175, 280)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(121, 28)
        Label3.TabIndex = 2
        Label3.Text = "FIRST NAME"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(180, 360)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 28)
        Label4.TabIndex = 3
        Label4.Text = "AUTHORITY"
        ' 
        ' FID
        ' 
        FID.Location = New Point(327, 186)
        FID.Margin = New Padding(4)
        FID.Name = "FID"
        FID.Size = New Size(279, 34)
        FID.TabIndex = 4
        ' 
        ' FFNAME
        ' 
        FFNAME.Location = New Point(327, 274)
        FFNAME.Margin = New Padding(4)
        FFNAME.Name = "FFNAME"
        FFNAME.Size = New Size(279, 34)
        FFNAME.TabIndex = 5
        ' 
        ' FAUTH
        ' 
        FAUTH.Location = New Point(327, 354)
        FAUTH.Margin = New Padding(4)
        FAUTH.Name = "FAUTH"
        FAUTH.Size = New Size(279, 34)
        FAUTH.TabIndex = 6
        ' 
        ' NPASS
        ' 
        NPASS.Location = New Point(327, 442)
        NPASS.Margin = New Padding(4)
        NPASS.Name = "NPASS"
        NPASS.PasswordChar = "*"c
        NPASS.Size = New Size(271, 34)
        NPASS.TabIndex = 7
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(130, 448)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(166, 28)
        Label5.TabIndex = 8
        Label5.Text = "NEW PASSWORD"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(447, 506)
        Button1.Margin = New Padding(4)
        Button1.Name = "Button1"
        Button1.Size = New Size(140, 92)
        Button1.TabIndex = 9
        Button1.Text = "CANCEL"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(273, 506)
        Button2.Margin = New Padding(4)
        Button2.Name = "Button2"
        Button2.Size = New Size(137, 92)
        Button2.TabIndex = 10
        Button2.Text = "CHANGE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(46, 122)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(250, 28)
        Label6.TabIndex = 11
        Label6.Text = "SYSTEM GENERATED CODE"
        ' 
        ' FCODE
        ' 
        FCODE.Location = New Point(327, 116)
        FCODE.Margin = New Padding(4)
        FCODE.Name = "FCODE"
        FCODE.Size = New Size(279, 34)
        FCODE.TabIndex = 12
        ' 
        ' ChangePassword
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Button1
        ClientSize = New Size(741, 647)
        Controls.Add(FCODE)
        Controls.Add(Label6)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(NPASS)
        Controls.Add(FAUTH)
        Controls.Add(FFNAME)
        Controls.Add(FID)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(4)
        Name = "ChangePassword"
        StartPosition = FormStartPosition.CenterParent
        Text = "Change Password"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents FID As TextBox
    Friend WithEvents FFNAME As TextBox
    Friend WithEvents FAUTH As TextBox
    Friend WithEvents NPASS As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents FCODE As TextBox
End Class
