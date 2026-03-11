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
        Label1 = New Label()
        USER_ID = New TextBox()
        USER_PASSWORD = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(84, 110)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 28)
        Label1.TabIndex = 0
        Label1.Text = "USER ID"
        ' 
        ' USER_ID
        ' 
        USER_ID.Location = New Point(221, 111)
        USER_ID.Name = "USER_ID"
        USER_ID.Size = New Size(212, 27)
        USER_ID.TabIndex = 1
        ' 
        ' USER_PASSWORD
        ' 
        USER_PASSWORD.Location = New Point(221, 178)
        USER_PASSWORD.Name = "USER_PASSWORD"
        USER_PASSWORD.PasswordChar = "+"c
        USER_PASSWORD.Size = New Size(212, 27)
        USER_PASSWORD.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(84, 178)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 28)
        Label2.TabIndex = 3
        Label2.Text = "PASSWORD"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(84, 47)
        Label3.Name = "Label3"
        Label3.Size = New Size(315, 38)
        Label3.TabIndex = 4
        Label3.Text = "USER AUTHENTICATION"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(221, 244)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 5
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(USER_PASSWORD)
        Controls.Add(USER_ID)
        Controls.Add(Label1)
        Name = "Login"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents USER_PASSWORD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents USER_ID As TextBox
    Friend WithEvents Button1 As Button
End Class
