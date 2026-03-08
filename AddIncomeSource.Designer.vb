Imports System.Security.Cryptography.X509Certificates

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddIncomeSource
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Label10 = New Label()
        Label11 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        TextBox5 = New TextBox()
        TextBox6 = New TextBox()
        TextBox7 = New TextBox()
        TextBox8 = New TextBox()
        TextBox9 = New TextBox()
        Label12 = New Label()
        TextBox10 = New TextBox()
        Button3 = New Button()
        Label13 = New Label()
        TextBox12 = New TextBox()
        MaskedTextBox1 = New MaskedTextBox()
        Panel1 = New Panel()
        Button8 = New Button()
        Button7 = New Button()
        TextBox11 = New TextBox()
        ListBox1 = New ListBox()
        Label16 = New Label()
        ListBox2 = New ListBox()
        Panel4 = New Panel()
        Button15 = New Button()
        DateTimePicker3 = New DateTimePicker()
        DateTimePicker2 = New DateTimePicker()
        DateTimePicker1 = New DateTimePicker()
        TextBox15 = New TextBox()
        TextBox14 = New TextBox()
        TextBox13 = New TextBox()
        Label30 = New Label()
        Button12 = New Button()
        Label29 = New Label()
        Button11 = New Button()
        Button10 = New Button()
        Label28 = New Label()
        Label27 = New Label()
        Label26 = New Label()
        Label25 = New Label()
        SOURCENAME = New ComboBox()
        USERNAME = New ComboBox()
        Label24 = New Label()
        Label23 = New Label()
        Label19 = New Label()
        Panel2 = New Panel()
        Label34 = New Label()
        STARTDATE = New DateTimePicker()
        FIXAMOUNT = New TextBox()
        SCHEDULEDATE = New DateTimePicker()
        SCHEDULE = New ComboBox()
        Label22 = New Label()
        Label21 = New Label()
        Label20 = New Label()
        Label18 = New Label()
        Button9 = New Button()
        ComboBox2 = New ComboBox()
        ComboBox1 = New ComboBox()
        Label14 = New Label()
        Label15 = New Label()
        Button5 = New Button()
        Panel5 = New Panel()
        Label33 = New Label()
        Button17 = New Button()
        ComboBox3 = New ComboBox()
        ComboBox4 = New ComboBox()
        Label31 = New Label()
        Label17 = New Label()
        Label32 = New Label()
        Button6 = New Button()
        Button4 = New Button()
        Panel3 = New Panel()
        Button18 = New Button()
        Button16 = New Button()
        Button14 = New Button()
        Button13 = New Button()
        DBConnectionBindingSource = New BindingSource(components)
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        Panel5.SuspendLayout()
        Panel3.SuspendLayout()
        CType(DBConnectionBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Tahoma", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(296, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(241, 34)
        Label1.TabIndex = 0
        Label1.Text = "INCOME SOURCE "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Segoe UI", 13.8F)
        Label2.Location = New Point(42, 117)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 31)
        Label2.TabIndex = 1
        Label2.Text = "CODE"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F)
        Label3.Location = New Point(255, 107)
        Label3.Name = "Label3"
        Label3.Size = New Size(176, 31)
        Label3.TabIndex = 2
        Label3.Text = " SOURCE NAME"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13.8F)
        Label4.Location = New Point(34, 170)
        Label4.Name = "Label4"
        Label4.Size = New Size(111, 31)
        Label4.TabIndex = 3
        Label4.Text = "ADDRESS"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13.8F)
        Label5.Location = New Point(30, 233)
        Label5.Name = "Label5"
        Label5.Size = New Size(203, 31)
        Label5.TabIndex = 4
        Label5.Text = "CONTACT PERSON"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 13.8F)
        Label6.Location = New Point(30, 332)
        Label6.Name = "Label6"
        Label6.Size = New Size(211, 31)
        Label6.TabIndex = 5
        Label6.Text = "CONTACT NUMBER"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 13.8F)
        Label7.Location = New Point(645, 233)
        Label7.Name = "Label7"
        Label7.Size = New Size(94, 31)
        Label7.TabIndex = 6
        Label7.Text = "MOBILE"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 13.8F)
        Label8.Location = New Point(30, 432)
        Label8.Name = "Label8"
        Label8.Size = New Size(132, 31)
        Label8.TabIndex = 7
        Label8.Text = "REFERENCE"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 13.8F)
        Label9.Location = New Point(645, 432)
        Label9.Name = "Label9"
        Label9.Size = New Size(134, 31)
        Label9.TabIndex = 8
        Label9.Text = "START DATE"
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(30, 639)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(203, 63)
        Button1.TabIndex = 9
        Button1.Text = "ADD NEW SOURCE"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Enabled = False
        Button2.Font = New Font("Segoe UI", 13.8F)
        Button2.Location = New Point(255, 641)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(202, 60)
        Button2.TabIndex = 10
        Button2.Text = "SAVE SOURCE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 13.8F)
        Label10.Location = New Point(286, 332)
        Label10.Name = "Label10"
        Label10.Size = New Size(79, 31)
        Label10.TabIndex = 11
        Label10.Text = "EMAIL"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 13.8F)
        Label11.Location = New Point(640, 332)
        Label11.Name = "Label11"
        Label11.Size = New Size(108, 31)
        Label11.TabIndex = 12
        Label11.Text = "WEB SITE"
        ' 
        ' TextBox1
        ' 
        TextBox1.Enabled = False
        TextBox1.Font = New Font("Segoe UI", 13.8F)
        TextBox1.Location = New Point(153, 107)
        TextBox1.Margin = New Padding(3, 2, 3, 2)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(80, 38)
        TextBox1.TabIndex = 13
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.ForeColor = SystemColors.MenuHighlight
        TextBox2.Location = New Point(451, 107)
        TextBox2.Margin = New Padding(3, 2, 3, 2)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(423, 30)
        TextBox2.TabIndex = 14
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox3.ForeColor = SystemColors.MenuHighlight
        TextBox3.Location = New Point(157, 175)
        TextBox3.Margin = New Padding(3, 2, 3, 2)
        TextBox3.Name = "TextBox3"
        TextBox3.ReadOnly = True
        TextBox3.Size = New Size(717, 27)
        TextBox3.TabIndex = 15
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.ForeColor = SystemColors.MenuHighlight
        TextBox4.Location = New Point(24, 271)
        TextBox4.Margin = New Padding(3, 2, 3, 2)
        TextBox4.Name = "TextBox4"
        TextBox4.ReadOnly = True
        TextBox4.Size = New Size(253, 27)
        TextBox4.TabIndex = 16
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox5.ForeColor = SystemColors.MenuHighlight
        TextBox5.Location = New Point(286, 271)
        TextBox5.Margin = New Padding(3, 2, 3, 2)
        TextBox5.Name = "TextBox5"
        TextBox5.ReadOnly = True
        TextBox5.Size = New Size(292, 27)
        TextBox5.TabIndex = 17
        ' 
        ' TextBox6
        ' 
        TextBox6.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox6.ForeColor = SystemColors.MenuHighlight
        TextBox6.Location = New Point(584, 271)
        TextBox6.Margin = New Padding(3, 2, 3, 2)
        TextBox6.Name = "TextBox6"
        TextBox6.ReadOnly = True
        TextBox6.Size = New Size(290, 27)
        TextBox6.TabIndex = 18
        ' 
        ' TextBox7
        ' 
        TextBox7.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox7.ForeColor = SystemColors.MenuHighlight
        TextBox7.Location = New Point(24, 369)
        TextBox7.Margin = New Padding(3, 2, 3, 2)
        TextBox7.Name = "TextBox7"
        TextBox7.ReadOnly = True
        TextBox7.Size = New Size(251, 27)
        TextBox7.TabIndex = 19
        ' 
        ' TextBox8
        ' 
        TextBox8.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox8.ForeColor = SystemColors.MenuHighlight
        TextBox8.Location = New Point(281, 369)
        TextBox8.Margin = New Padding(3, 2, 3, 2)
        TextBox8.Name = "TextBox8"
        TextBox8.ReadOnly = True
        TextBox8.Size = New Size(297, 27)
        TextBox8.TabIndex = 20
        ' 
        ' TextBox9
        ' 
        TextBox9.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox9.ForeColor = SystemColors.MenuHighlight
        TextBox9.Location = New Point(584, 369)
        TextBox9.Margin = New Padding(3, 2, 3, 2)
        TextBox9.Name = "TextBox9"
        TextBox9.ReadOnly = True
        TextBox9.Size = New Size(290, 27)
        TextBox9.TabIndex = 21
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 13.8F)
        Label12.Location = New Point(296, 233)
        Label12.Name = "Label12"
        Label12.Size = New Size(158, 31)
        Label12.TabIndex = 22
        Label12.Text = "DESIGNATION"
        ' 
        ' TextBox10
        ' 
        TextBox10.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox10.ForeColor = SystemColors.MenuHighlight
        TextBox10.Location = New Point(24, 488)
        TextBox10.Margin = New Padding(3, 2, 3, 2)
        TextBox10.Name = "TextBox10"
        TextBox10.ReadOnly = True
        TextBox10.Size = New Size(496, 27)
        TextBox10.TabIndex = 23
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(928, 598)
        Button3.Margin = New Padding(3, 2, 3, 2)
        Button3.Name = "Button3"
        Button3.Size = New Size(250, 68)
        Button3.TabIndex = 25
        Button3.Text = "EXIT"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 13.8F)
        Label13.Location = New Point(30, 535)
        Label13.Name = "Label13"
        Label13.Size = New Size(115, 31)
        Label13.TabIndex = 26
        Label13.Text = "REMARKS"
        ' 
        ' TextBox12
        ' 
        TextBox12.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox12.ForeColor = SystemColors.MenuHighlight
        TextBox12.Location = New Point(24, 575)
        TextBox12.Margin = New Padding(3, 2, 3, 2)
        TextBox12.Name = "TextBox12"
        TextBox12.ReadOnly = True
        TextBox12.Size = New Size(850, 27)
        TextBox12.TabIndex = 27
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MaskedTextBox1.Location = New Point(645, 488)
        MaskedTextBox1.Margin = New Padding(3, 2, 3, 2)
        MaskedTextBox1.Mask = "--/--/----"
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.ReadOnly = True
        MaskedTextBox1.Size = New Size(229, 38)
        MaskedTextBox1.TabIndex = 28
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gainsboro
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Button8)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Button7)
        Panel1.Controls.Add(TextBox11)
        Panel1.Controls.Add(ListBox1)
        Panel1.Controls.Add(Label16)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(MaskedTextBox1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(TextBox12)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(TextBox10)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(TextBox9)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(TextBox8)
        Panel1.Controls.Add(TextBox7)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(TextBox6)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(TextBox5)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(TextBox4)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(TextBox3)
        Panel1.Controls.Add(TextBox2)
        Panel1.Font = New Font("MS Reference Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Panel1.Location = New Point(12, 31)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1290, 767)
        Panel1.TabIndex = 29
        Panel1.Visible = False
        ' 
        ' Button8
        ' 
        Button8.Enabled = False
        Button8.Location = New Point(485, 644)
        Button8.Margin = New Padding(3, 2, 3, 2)
        Button8.Name = "Button8"
        Button8.Size = New Size(202, 60)
        Button8.TabIndex = 35
        Button8.Text = "SAVE CHANGES"
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(1155, 63)
        Button7.Margin = New Padding(3, 2, 3, 2)
        Button7.Name = "Button7"
        Button7.Size = New Size(100, 42)
        Button7.TabIndex = 34
        Button7.Text = "search 07"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' TextBox11
        ' 
        TextBox11.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox11.Location = New Point(894, 67)
        TextBox11.Margin = New Padding(3, 2, 3, 2)
        TextBox11.Name = "TextBox11"
        TextBox11.Size = New Size(251, 34)
        TextBox11.TabIndex = 32
        ' 
        ' ListBox1
        ' 
        ListBox1.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(894, 124)
        ListBox1.Margin = New Padding(3, 2, 3, 2)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(381, 510)
        ListBox1.TabIndex = 31
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = SystemColors.MenuHighlight
        Label16.Location = New Point(940, 3)
        Label16.Name = "Label16"
        Label16.Size = New Size(195, 41)
        Label16.TabIndex = 30
        Label16.Text = "SOURCE LIST"
        ' 
        ' ListBox2
        ' 
        ListBox2.Font = New Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListBox2.ForeColor = SystemColors.HotTrack
        ListBox2.FormattingEnabled = True
        ListBox2.Location = New Point(90, 12)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(760, 704)
        ListBox2.TabIndex = 37
        ' 
        ' Panel4
        ' 
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(Button15)
        Panel4.Controls.Add(DateTimePicker3)
        Panel4.Controls.Add(DateTimePicker2)
        Panel4.Controls.Add(DateTimePicker1)
        Panel4.Controls.Add(TextBox15)
        Panel4.Controls.Add(TextBox14)
        Panel4.Controls.Add(TextBox13)
        Panel4.Controls.Add(Label30)
        Panel4.Controls.Add(Button12)
        Panel4.Controls.Add(Label29)
        Panel4.Controls.Add(Button11)
        Panel4.Controls.Add(Button10)
        Panel4.Controls.Add(Label28)
        Panel4.Controls.Add(Label27)
        Panel4.Controls.Add(Label26)
        Panel4.Controls.Add(Label25)
        Panel4.Controls.Add(SOURCENAME)
        Panel4.Controls.Add(USERNAME)
        Panel4.Controls.Add(Label24)
        Panel4.Controls.Add(Label23)
        Panel4.Controls.Add(Label19)
        Panel4.Location = New Point(354, 5)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(726, 692)
        Panel4.TabIndex = 35
        Panel4.Visible = False
        ' 
        ' Button15
        ' 
        Button15.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button15.Location = New Point(608, 114)
        Button15.Name = "Button15"
        Button15.Size = New Size(94, 33)
        Button15.TabIndex = 21
        Button15.Text = "CLOSE 15"
        Button15.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker3
        ' 
        DateTimePicker3.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        DateTimePicker3.Location = New Point(224, 435)
        DateTimePicker3.Name = "DateTimePicker3"
        DateTimePicker3.Size = New Size(250, 27)
        DateTimePicker3.TabIndex = 20
        DateTimePicker3.Visible = False
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        DateTimePicker2.Location = New Point(319, 369)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(250, 27)
        DateTimePicker2.TabIndex = 19
        DateTimePicker2.Visible = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        DateTimePicker1.Location = New Point(47, 237)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(250, 27)
        DateTimePicker1.TabIndex = 18
        DateTimePicker1.Visible = False
        ' 
        ' TextBox15
        ' 
        TextBox15.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        TextBox15.Location = New Point(277, 308)
        TextBox15.Name = "TextBox15"
        TextBox15.Size = New Size(125, 27)
        TextBox15.TabIndex = 17
        TextBox15.Visible = False
        ' 
        ' TextBox14
        ' 
        TextBox14.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        TextBox14.Location = New Point(495, 241)
        TextBox14.Name = "TextBox14"
        TextBox14.ReadOnly = True
        TextBox14.Size = New Size(125, 27)
        TextBox14.TabIndex = 16
        TextBox14.Visible = False
        ' 
        ' TextBox13
        ' 
        TextBox13.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        TextBox13.Location = New Point(333, 241)
        TextBox13.Name = "TextBox13"
        TextBox13.Size = New Size(125, 27)
        TextBox13.TabIndex = 15
        TextBox13.Visible = False
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.Font = New Font("Times New Roman", 12F)
        Label30.Location = New Point(43, 441)
        Label30.Name = "Label30"
        Label30.Size = New Size(148, 22)
        Label30.TabIndex = 14
        Label30.Text = "CLOSING DATE"
        Label30.Visible = False
        ' 
        ' Button12
        ' 
        Button12.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button12.Location = New Point(355, 513)
        Button12.Name = "Button12"
        Button12.Size = New Size(94, 33)
        Button12.TabIndex = 13
        Button12.Text = "SAVE CHANGES 12"
        Button12.UseVisualStyleBackColor = True
        Button12.Visible = False
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Font = New Font("Times New Roman", 12F)
        Label29.Location = New Point(495, 192)
        Label29.Name = "Label29"
        Label29.Size = New Size(79, 22)
        Label29.TabIndex = 12
        Label29.Text = "STATUS"
        Label29.Visible = False
        ' 
        ' Button11
        ' 
        Button11.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button11.Location = New Point(57, 513)
        Button11.Name = "Button11"
        Button11.Size = New Size(226, 33)
        Button11.TabIndex = 10
        Button11.Text = "DEACTIVATE"
        Button11.UseVisualStyleBackColor = True
        Button11.Visible = False
        ' 
        ' Button10
        ' 
        Button10.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button10.Location = New Point(508, 111)
        Button10.Name = "Button10"
        Button10.Size = New Size(94, 39)
        Button10.TabIndex = 9
        Button10.Text = "SHOW 10"
        Button10.UseVisualStyleBackColor = True
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Font = New Font("Times New Roman", 12F)
        Label28.Location = New Point(43, 364)
        Label28.Name = "Label28"
        Label28.Size = New Size(260, 22)
        Label28.TabIndex = 8
        Label28.Text = "PAYMENT SCHEDULE DATE"
        Label28.Visible = False
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Times New Roman", 12F)
        Label27.Location = New Point(43, 306)
        Label27.Name = "Label27"
        Label27.Size = New Size(205, 22)
        Label27.TabIndex = 7
        Label27.Text = "PAYMENT SCHEDULE"
        Label27.TextAlign = ContentAlignment.MiddleCenter
        Label27.Visible = False
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Times New Roman", 12F)
        Label26.Location = New Point(341, 194)
        Label26.Name = "Label26"
        Label26.Size = New Size(94, 22)
        Label26.TabIndex = 6
        Label26.Text = "AMOUNT"
        Label26.Visible = False
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Font = New Font("Times New Roman", 12F)
        Label25.Location = New Point(39, 202)
        Label25.Name = "Label25"
        Label25.Size = New Size(124, 22)
        Label25.TabIndex = 5
        Label25.Text = "START DATE"
        Label25.Visible = False
        ' 
        ' SOURCENAME
        ' 
        SOURCENAME.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        SOURCENAME.FormattingEnabled = True
        SOURCENAME.Location = New Point(268, 121)
        SOURCENAME.Name = "SOURCENAME"
        SOURCENAME.Size = New Size(223, 28)
        SOURCENAME.TabIndex = 4
        ' 
        ' USERNAME
        ' 
        USERNAME.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        USERNAME.FormattingEnabled = True
        USERNAME.Location = New Point(33, 119)
        USERNAME.Name = "USERNAME"
        USERNAME.Size = New Size(197, 28)
        USERNAME.TabIndex = 3
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Times New Roman", 12F)
        Label24.Location = New Point(268, 87)
        Label24.Name = "Label24"
        Label24.Size = New Size(167, 22)
        Label24.TabIndex = 2
        Label24.Text = "INCOME SOURCE"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Times New Roman", 12F)
        Label23.Location = New Point(39, 87)
        Label23.Name = "Label23"
        Label23.Size = New Size(135, 22)
        Label23.TabIndex = 1
        Label23.Text = "SELECT USER"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(22, 15)
        Label19.Name = "Label19"
        Label19.Size = New Size(661, 33)
        Label19.TabIndex = 0
        Label19.Text = "INCOME SOURCE -USER MAPPING MODIFICATION"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Label34)
        Panel2.Controls.Add(STARTDATE)
        Panel2.Controls.Add(FIXAMOUNT)
        Panel2.Controls.Add(SCHEDULEDATE)
        Panel2.Controls.Add(SCHEDULE)
        Panel2.Controls.Add(Label22)
        Panel2.Controls.Add(Label21)
        Panel2.Controls.Add(Label20)
        Panel2.Controls.Add(Label18)
        Panel2.Controls.Add(Button9)
        Panel2.Controls.Add(ComboBox2)
        Panel2.Controls.Add(ComboBox1)
        Panel2.Controls.Add(Label14)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(Button5)
        Panel2.Location = New Point(309, 9)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(819, 638)
        Panel2.TabIndex = 30
        Panel2.Visible = False
        ' 
        ' Label34
        ' 
        Label34.AutoSize = True
        Label34.Font = New Font("Times New Roman", 12F)
        Label34.Location = New Point(40, 94)
        Label34.Name = "Label34"
        Label34.Size = New Size(243, 22)
        Label34.TabIndex = 43
        Label34.Text = "SELECT INCOME SOURCE"
        ' 
        ' STARTDATE
        ' 
        STARTDATE.Font = New Font("Tahoma", 12F)
        STARTDATE.Location = New Point(373, 190)
        STARTDATE.Name = "STARTDATE"
        STARTDATE.Size = New Size(250, 32)
        STARTDATE.TabIndex = 42
        ' 
        ' FIXAMOUNT
        ' 
        FIXAMOUNT.Font = New Font("Tahoma", 12F)
        FIXAMOUNT.Location = New Point(373, 245)
        FIXAMOUNT.Name = "FIXAMOUNT"
        FIXAMOUNT.Size = New Size(250, 32)
        FIXAMOUNT.TabIndex = 41
        ' 
        ' SCHEDULEDATE
        ' 
        SCHEDULEDATE.Font = New Font("Tahoma", 12F)
        SCHEDULEDATE.Location = New Point(373, 391)
        SCHEDULEDATE.Name = "SCHEDULEDATE"
        SCHEDULEDATE.Size = New Size(250, 32)
        SCHEDULEDATE.TabIndex = 40
        ' 
        ' SCHEDULE
        ' 
        SCHEDULE.Font = New Font("Tahoma", 12F)
        SCHEDULE.FormattingEnabled = True
        SCHEDULE.Items.AddRange(New Object() {"YEARLY", "QUARTELY", "MONTHLY", "WEEKLY"})
        SCHEDULE.Location = New Point(373, 313)
        SCHEDULE.Name = "SCHEDULE"
        SCHEDULE.Size = New Size(151, 32)
        SCHEDULE.TabIndex = 39
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Times New Roman", 12F)
        Label22.Location = New Point(37, 401)
        Label22.Name = "Label22"
        Label22.Size = New Size(260, 22)
        Label22.TabIndex = 38
        Label22.Text = "PAYMENT SCHEDULE DATE"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Times New Roman", 12F)
        Label21.Location = New Point(37, 325)
        Label21.Name = "Label21"
        Label21.Size = New Size(205, 22)
        Label21.TabIndex = 37
        Label21.Text = "PAYMENT SCHEDULE"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Times New Roman", 12F)
        Label20.Location = New Point(40, 252)
        Label20.Name = "Label20"
        Label20.Size = New Size(94, 22)
        Label20.TabIndex = 36
        Label20.Text = "AMOUNT"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Times New Roman", 12F)
        Label18.Location = New Point(37, 192)
        Label18.Name = "Label18"
        Label18.Size = New Size(124, 22)
        Label18.TabIndex = 34
        Label18.Text = "START DATE"
        ' 
        ' Button9
        ' 
        Button9.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(161))
        Button9.Location = New Point(40, 458)
        Button9.Name = "Button9"
        Button9.Size = New Size(145, 56)
        Button9.TabIndex = 33
        Button9.Text = "ALLOW"
        Button9.UseVisualStyleBackColor = True
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Tahoma", 12F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(373, 121)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(284, 32)
        ComboBox2.TabIndex = 32
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Tahoma", 12F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(37, 128)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(311, 32)
        ComboBox1.TabIndex = 31
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Times New Roman", 12F)
        Label14.Location = New Point(378, 90)
        Label14.Name = "Label14"
        Label14.Size = New Size(135, 22)
        Label14.TabIndex = 29
        Label14.Text = "SELECT USER"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Tahoma", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(98, 20)
        Label15.Name = "Label15"
        Label15.Size = New Size(516, 34)
        Label15.TabIndex = 28
        Label15.Text = "INCOME SOURCE   AND USER MAPPING"
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Segoe Fluent Icons", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button5.Location = New Point(242, 458)
        Button5.Margin = New Padding(3, 2, 3, 2)
        Button5.Name = "Button5"
        Button5.Size = New Size(144, 56)
        Button5.TabIndex = 26
        Button5.Text = "CANCEL"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Panel5
        ' 
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Controls.Add(Label33)
        Panel5.Controls.Add(Button17)
        Panel5.Controls.Add(ComboBox3)
        Panel5.Controls.Add(ComboBox4)
        Panel5.Controls.Add(Label31)
        Panel5.Controls.Add(Label17)
        Panel5.Controls.Add(Label32)
        Panel5.Location = New Point(229, 5)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(763, 313)
        Panel5.TabIndex = 36
        Panel5.Visible = False
        ' 
        ' Label33
        ' 
        Label33.AutoSize = True
        Label33.Font = New Font("Times New Roman", 12F)
        Label33.Location = New Point(62, 101)
        Label33.Name = "Label33"
        Label33.Size = New Size(135, 22)
        Label33.TabIndex = 15
        Label33.Text = "SELECT USER"
        ' 
        ' Button17
        ' 
        Button17.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button17.Location = New Point(367, 222)
        Button17.Name = "Button17"
        Button17.Size = New Size(164, 39)
        Button17.TabIndex = 14
        Button17.Text = "ALLOW"
        Button17.UseVisualStyleBackColor = True
        ' 
        ' ComboBox3
        ' 
        ComboBox3.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New Point(62, 230)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(223, 28)
        ComboBox3.TabIndex = 13
        ' 
        ' ComboBox4
        ' 
        ComboBox4.Font = New Font("Segoe MDL2 Assets", 12F, FontStyle.Bold)
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New Point(62, 134)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New Size(197, 28)
        ComboBox4.TabIndex = 12
        ' 
        ' Label31
        ' 
        Label31.AutoSize = True
        Label31.Font = New Font("Times New Roman", 12F)
        Label31.Location = New Point(64, 194)
        Label31.Name = "Label31"
        Label31.Size = New Size(167, 22)
        Label31.TabIndex = 11
        Label31.Text = "INCOME SOURCE"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Copperplate Gothic Bold", 16.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(79, 24)
        Label17.Name = "Label17"
        Label17.Size = New Size(627, 31)
        Label17.TabIndex = 30
        Label17.Text = "RE-ACTIVATE USER - SOURCE MAPPING"
        ' 
        ' Label32
        ' 
        Label32.AutoSize = True
        Label32.Font = New Font("Times New Roman", 12F)
        Label32.Location = New Point(-155, 192)
        Label32.Name = "Label32"
        Label32.Size = New Size(135, 22)
        Label32.TabIndex = 10
        Label32.Text = "SELECT USER"
        ' 
        ' Button6
        ' 
        Button6.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button6.Location = New Point(928, 500)
        Button6.Margin = New Padding(3, 2, 3, 2)
        Button6.Name = "Button6"
        Button6.Size = New Size(250, 68)
        Button6.TabIndex = 33
        Button6.Text = "RESET ALL"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(928, 122)
        Button4.Margin = New Padding(3, 2, 3, 2)
        Button4.Name = "Button4"
        Button4.Size = New Size(250, 68)
        Button4.TabIndex = 29
        Button4.Text = "MAP INCOME SOURCE  "
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Button18)
        Panel3.Controls.Add(ListBox2)
        Panel3.Controls.Add(Button16)
        Panel3.Controls.Add(Button14)
        Panel3.Controls.Add(Button13)
        Panel3.Controls.Add(Button4)
        Panel3.Controls.Add(Button6)
        Panel3.Controls.Add(Button3)
        Panel3.Location = New Point(398, 41)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1328, 757)
        Panel3.TabIndex = 34
        ' 
        ' Button18
        ' 
        Button18.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button18.Location = New Point(928, 396)
        Button18.Name = "Button18"
        Button18.Size = New Size(250, 68)
        Button18.TabIndex = 38
        Button18.Text = "SHOW MAPPED SOURCES"
        Button18.UseVisualStyleBackColor = True
        ' 
        ' Button16
        ' 
        Button16.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button16.Location = New Point(928, 308)
        Button16.Name = "Button16"
        Button16.Size = New Size(250, 68)
        Button16.TabIndex = 36
        Button16.Text = "RE-ACTIVATE MAPPING"
        Button16.UseVisualStyleBackColor = True
        ' 
        ' Button14
        ' 
        Button14.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button14.Location = New Point(928, 29)
        Button14.Name = "Button14"
        Button14.Size = New Size(250, 68)
        Button14.TabIndex = 35
        Button14.Text = "INCOME SOURCE"
        Button14.UseVisualStyleBackColor = True
        ' 
        ' Button13
        ' 
        Button13.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button13.Location = New Point(928, 211)
        Button13.Name = "Button13"
        Button13.Size = New Size(250, 68)
        Button13.TabIndex = 34
        Button13.Text = "CHANGE MAPPING"
        Button13.UseVisualStyleBackColor = True
        ' 
        ' DBConnectionBindingSource
        ' 
        DBConnectionBindingSource.DataSource = GetType(DBConnection)
        ' 
        ' AddIncomeSource
        ' 
        AutoScaleDimensions = New SizeF(8F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1399, 801)
        ControlBox = False
        Controls.Add(Panel5)
        Controls.Add(Panel2)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Font = New Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(3, 2, 3, 2)
        Name = "AddIncomeSource"
        SizeGripStyle = SizeGripStyle.Show
        StartPosition = FormStartPosition.CenterScreen
        Text = "INCOME SOURCE"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(DBConnectionBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DBConnectionBindingSource As BindingSource
    Friend WithEvents Button9 As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents SCHEDULE As ComboBox
    Friend WithEvents STARTDATE As DateTimePicker
    Friend WithEvents FIXAMOUNT As TextBox
    Friend WithEvents SCHEDULEDATE As DateTimePicker
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents SOURCENAME As ComboBox
    Friend WithEvents USERNAME As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button16 As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents Button17 As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Button18 As Button
End Class
