<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncomeForecasting
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
        ComboBox1 = New ComboBox()
        Button1 = New Button()
        Button2 = New Button()
        DateTimePicker1 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        Button3 = New Button()
        ListView1 = New ListView()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(47, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(126, 28)
        Label1.TabIndex = 0
        Label1.Text = "SELECT USER"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"ALL"})
        ComboBox1.Location = New Point(47, 79)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(256, 36)
        ComboBox1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.IndianRed
        Button1.ForeColor = Color.White
        Button1.Location = New Point(332, 61)
        Button1.Name = "Button1"
        Button1.Size = New Size(185, 59)
        Button1.TabIndex = 2
        Button1.Text = "MONTH"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.IndianRed
        Button2.Location = New Point(523, 61)
        Button2.Name = "Button2"
        Button2.Size = New Size(208, 59)
        Button2.TabIndex = 3
        Button2.Text = "FINANCIAL YEAR"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(848, 59)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(250, 34)
        DateTimePicker1.TabIndex = 4
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Location = New Point(848, 99)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(250, 34)
        DateTimePicker2.TabIndex = 5
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.IndianRed
        Button3.Location = New Point(1104, 59)
        Button3.Name = "Button3"
        Button3.Size = New Size(152, 74)
        Button3.TabIndex = 6
        Button3.Text = "SHOW"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(25, 152)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1342, 361)
        ListView1.TabIndex = 7
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(47, 534)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 28)
        Label2.TabIndex = 8
        Label2.Text = "Total Income"
        ' 
        ' IncomeForecasting
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DeepSkyBlue
        ClientSize = New Size(1379, 673)
        Controls.Add(Label2)
        Controls.Add(ListView1)
        Controls.Add(Button3)
        Controls.Add(DateTimePicker2)
        Controls.Add(DateTimePicker1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(ComboBox1)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.White
        Margin = New Padding(4)
        Name = "IncomeForecasting"
        Text = "EXPECTED INCOMES"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button3 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label2 As Label
End Class
