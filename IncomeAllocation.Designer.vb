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
        Label1 = New Label()
        Label2 = New Label()
        ComboBox1 = New ComboBox()
        ListView1 = New ListView()
        ListBox1 = New ListBox()
        Label3 = New Label()
        ListView2 = New ListView()
        ListView3 = New ListView()
        Label4 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(62, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(155, 20)
        Label1.TabIndex = 0
        Label1.Text = "INCOME ALLOCATION"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 20)
        Label2.TabIndex = 1
        Label2.Text = "SELECT USER"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(6, 122)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(244, 28)
        ComboBox1.TabIndex = 2
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(265, 35)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1005, 135)
        ListView1.TabIndex = 3
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(8, 200)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(242, 324)
        ListBox1.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 168)
        Label3.Name = "Label3"
        Label3.Size = New Size(178, 20)
        Label3.TabIndex = 5
        Label3.Text = "LINKED INCOME SOURCE"
        ' 
        ' ListView2
        ' 
        ListView2.Location = New Point(258, 223)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(1072, 154)
        ListView2.TabIndex = 6
        ListView2.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView3
        ' 
        ListView3.Location = New Point(256, 405)
        ListView3.Name = "ListView3"
        ListView3.Size = New Size(1072, 119)
        ListView3.TabIndex = 7
        ListView3.UseCompatibleStateImageBehavior = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(278, 200)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 20)
        Label4.TabIndex = 8
        Label4.Text = "Currently Active"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(256, 382)
        Label5.Name = "Label5"
        Label5.Size = New Size(89, 20)
        Label5.TabIndex = 9
        Label5.Text = "Deactivated"
        ' 
        ' IncomeAllocation
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1340, 726)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ListView3)
        Controls.Add(ListView2)
        Controls.Add(Label3)
        Controls.Add(ListBox1)
        Controls.Add(ListView1)
        Controls.Add(ComboBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "IncomeAllocation"
        Text = "IncomeAllocation"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ListView3 As ListView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
