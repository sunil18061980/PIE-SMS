Imports System.Data.SQLite
Imports System.Data.SqlTypes
Imports System.Drawing.Imaging

Partial Public Class Places
    Public UserName As String
    Public UserRole As Integer
    Public UserCode As Integer
    Private Sub Places_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UserSession.IsLoggedIn Then
            UserName = UserSession.UserName
            UserRole = UserSession.UserRole
            UserCode = UserSession.UserCode
            UserID = UserSession.UserID
            MessageBox.Show("Welcome you are logged user .",
                        "Authentication Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("User not logged in. Please log in to continue.",
                        "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If
        LoadContinent()
        LoadLocationTree(TreeView1)
        ApplyDefaultTheme(Me)
        Timer1.Interval = 1000
        Timer1.Start()
        Label19.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy")
        Dim userInfo As String = UserName + " ( " + UserCode.ToString + " ) " + " / " + UserRole.ToString
        Label20.Text = userInfo
        Me.Text = "Add / update Country/ State / City Details -  " + userInfo


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label18.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub ApplyDefaultTheme(ctrl As Control)
        For Each c As Control In ctrl.Controls

            ' TEXTBOX
            If TypeOf c Is TextBox Then
                With DirectCast(c, TextBox)
                    .Font = New Font("Segoe UI", 10)
                    .ForeColor = Color.Black
                    .BackColor = Color.White
                    .PlaceholderText = String.Empty
                End With
            End If

            ' BUTTON
            If TypeOf c Is Button Then
                With DirectCast(c, Button)
                    .Font = New Font("Segoe UI", 12, FontStyle.Bold)
                    .BackColor = Color.SteelBlue
                    .ForeColor = Color.White
                    .FlatStyle = FlatStyle.Standard
                    .FlatAppearance.BorderSize = 2
                    .Size = New Size(100, 40)
                    .TextAlign = ContentAlignment.MiddleCenter
                End With
            End If

            ' LABEL
            If TypeOf c Is Label Then
                With DirectCast(c, Label)
                    If Label19 Is c Or Label18 Is c Then
                        .Font = New Font("Segoe UI", 18, FontStyle.Italic)
                    Else
                        .Font = New Font("Segoe UI", 10, FontStyle.Regular)
                    End If
                    .ForeColor = Color.Black
                End With
            End If

            ' COMBOBOX
            If TypeOf c Is ComboBox Then
                With DirectCast(c, ComboBox)
                    .Font = New Font("Segoe UI", 10)
                    .DropDownStyle = ComboBoxStyle.DropDownList
                End With
            End If

            ' LISTBOX
            If TypeOf c Is ListBox Then
                With DirectCast(c, ListBox)
                    .Font = New Font("Segoe UI", 12)
                End With
            End If

            ' DATAGRIDVIEW
            If TypeOf c Is DataGridView Then
                With DirectCast(c, DataGridView)
                    .Font = New Font("Segoe UI", 9)
                    .ColumnHeadersDefaultCellStyle.Font =
                    New Font("Segoe UI", 10, FontStyle.Bold)
                    .RowHeadersVisible = False
                    .AllowUserToAddRows = False
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
                    .DefaultCellStyle.SelectionForeColor = Color.Black
                End With
            End If

            ' HANDLE NESTED CONTROLS
            If c.HasChildren Then
                ApplyDefaultTheme(c)
            End If

        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ListBox1.SelectedIndexChanged

        If ListBox1.SelectedItem Is Nothing Then Exit Sub

        Dim continentName As String = ListBox1.SelectedItem.ToString()

        Dim continentCode As Integer = GetContinentCode(continentName)

        If continentCode <> -1 Then
            TextBox3.Text = continentCode.ToString()
            LoadCountryGrid(continentCode, DataGridView2)
            '  LoadCountries(conn, TreeView2)
            AddNewCountry()
        End If

    End Sub

    ' Method to evoke the loading of data when tab is changed
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedTab Is TabPage1 Then
            LoadContinent()
        End If
        If TabControl1.SelectedTab Is TabPage2 Then
            FillContinentList(ListBox1)
        End If
        If TabControl1.SelectedTab Is TabPage3 Then
            FillContinentList(ListBox2)
        End If
        If TabControl1.SelectedTab Is TabPage4 Then
            FillContinentList(ListBox3)
        End If


    End Sub
    ' To make sure save button active ony when continent name is more than of 3 characters and replace button is disabled
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ListBox2.SelectedIndexChanged

        If ListBox2.SelectedItem Is Nothing Then Exit Sub

        Dim continentName As String = ListBox2.SelectedItem.ToString()

        Dim continentCode As Integer = GetContinentCode(continentName)

        If continentCode <> -1 Then
            LoadCountryGrid(continentCode, DataGridView3)
            TextBox6.Text = continentCode.ToString()

        End If

    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) _
    Handles ListBox3.SelectedIndexChanged

        If ListBox3.SelectedItem Is Nothing Then Exit Sub

        Dim continentName As String = ListBox3.SelectedItem.ToString()

        Dim continentCode As Integer = GetContinentCode(continentName)

        If continentCode <> -1 Then
            TextBox10.Text = continentCode.ToString()
            LoadCountryGrid(continentCode, DataGridView4)
        End If
        DataGridView7.DataSource = Nothing
        DataGridView7.Rows.Clear()

    End Sub
    ' Function to find the continent code from continent name when selected from list box
    Public Function GetContinentCode(continentName As String) As Integer

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String =
                "SELECT CONTINENTCODE 
                 FROM CONTINENT 
                 WHERE CONTINENTNAME = @name"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", continentName)

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error getting continent code: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return -1   ' Invalid code
    End Function
    ' Default function to load country grid for the selected continent in all tables
    Public Function LoadCountryGrid(continentCode As Integer,
                                dgv As DataGridView) As Boolean
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String =
                "SELECT COUNTRYCODE AS [Country Code],
                        COUNTRYNAME AS [Country Name]
                 FROM COUNTRY
                 WHERE CONTINENTCODE = @code
                 ORDER BY COUNTRYNAME"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@code", continentCode)

                    Using da As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ' Add SL No column
                        dt.Columns.Add("SL No", GetType(Integer))

                        ' Fill SL No
                        Dim i As Integer = 1
                        For Each row As DataRow In dt.Rows
                            row("SL No") = i
                            i += 1
                        Next

                        ' Move SL No to first column
                        dt.Columns("SL No").SetOrdinal(0)

                        ' Bind to DataGridView
                        dgv.DataSource = dt

                        ' Set column widths and alignment
                        dgv.Columns("SL No").Width = 50
                        dgv.Columns("SL No").ReadOnly = True
                        dgv.Columns("SL No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        dgv.Columns("Country Code").Width = 80
                        dgv.Columns("Country Name").Width = 220

                        ' Prevent resizing if needed
                        dgv.Columns("SL No").Resizable = DataGridViewTriState.False
                        dgv.Columns("Country Code").Resizable = DataGridViewTriState.False
                        dgv.Columns("Country Name").Resizable = DataGridViewTriState.False
                    End Using
                End Using
            End Using
            TextBox11.Text = String.Empty
            TextBox7.Text = String.Empty
            TextBox12.Text = String.Empty

            TextBox9.Enabled = False
            DataGridView5.DataSource = Nothing
            DataGridView6.DataSource = Nothing
            DataGridView7.DataSource = Nothing
            DataGridView5.Rows.Clear()
            DataGridView6.Rows.Clear()
            DataGridView7.Rows.Clear()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error loading countries: " & ex.Message,
                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Funtion to load state grid for the selected country in all tabs
    Public Function LoadStateGrid(continentCode As Integer, countryCode As Integer,
                                dgv As DataGridView) As Boolean
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String =
                "SELECT STATECODE AS [State Code],
                        STATENAME AS [State Name]

                 FROM STATE
                 WHERE COUNTRYCODE = @code AND  CONTINENTCODE = @code1"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@code", countryCode)
                    cmd.Parameters.AddWithValue("@code1", continentCode)

                    Using da As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ' Add SL No column
                        dt.Columns.Add("SL No", GetType(Integer))

                        ' Fill SL No
                        Dim i As Integer = 1
                        For Each row As DataRow In dt.Rows
                            row("SL No") = i
                            i += 1
                        Next

                        ' Move SL No to first column
                        dt.Columns("SL No").SetOrdinal(0)

                        ' Bind to DataGridView
                        dgv.DataSource = dt

                        ' Set column widths and alignment
                        dgv.Columns("SL No").Width = 50
                        dgv.Columns("SL No").ReadOnly = True
                        dgv.Columns("SL No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        dgv.Columns("State Code").Width = 80
                        dgv.Columns("State Name").Width = 220

                        ' Prevent resizing if needed
                        dgv.Columns("SL No").Resizable = DataGridViewTriState.False
                        dgv.Columns("State Code").Resizable = DataGridViewTriState.False
                        dgv.Columns("State Name").Resizable = DataGridViewTriState.False
                    End Using
                End Using
            End Using


            Return True

        Catch ex As Exception
            MessageBox.Show("Error loading countries: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    ' Close Button at the top of the form to close the form



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    ' Load continent List in all Table when they are clicked and called from respective tab selection


    Private Sub Load_continentList()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim query As String = "SELECT * FROM continent"

                Using cmd As New SQLiteCommand(query, conn)
                    Using da As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ' Add SL column
                        dt.Columns.Add("SL", GetType(Integer))
                        For i As Integer = 0 To dt.Rows.Count - 1
                            dt.Rows(i)("SL") = i + 1
                        Next

                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Columns("Column1").DataPropertyName = "ContinentCode"
                        DataGridView1.Columns("Column2").DataPropertyName = "ContinentName"
                        DataGridView1.Columns("Column3").DataPropertyName = "SL"

                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading continent: " & ex.Message)
        End Try
        Button4.Enabled = False

    End Sub
    ' Function to prepare for new continent entry
    Private Sub NewContinent()
        'Code to file Continent code and name in textbox1 and textbox2

        Try
            Using Newconn As SQLiteConnection = DBConnection.GetConnection()
                If Newconn.State <> ConnectionState.Open Then
                    Newconn.Open()
                End If

                ' Get the maximum of ContinentCode 
                Dim query As String = "SELECT MAX(ContinentCode) FROM continent"
                Using cmd As New SQLiteCommand(query, Newconn)
                    Dim result = cmd.ExecuteScalar()

                    If IsDBNull(result) OrElse result Is Nothing Then
                        ' No records found
                        TextBox1.Text = "11"
                        TextBox2.Text = "ASIA"
                    Else
                        ' Records exist → max + 1
                        TextBox1.Text = (Convert.ToInt32(result) + 1).ToString()
                        TextBox2.Text = String.Empty
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error determining continent code: " & ex.Message)


        End Try


        Button4.Enabled = False
    End Sub
    ' Load to prepare for new continent entry
    Private Sub LoadContinent()
        'update the continent list if any list exist
        Load_continentList()
        NewContinent()

    End Sub
    ' Fucntion to make sure no more than 7 continents are added
    Function CheckcontinentCount() As Boolean
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim checkQuery As String =
                    "SELECT COUNT(*) FROM CONTINENT"
                Using checkCmd As New SQLiteCommand(checkQuery, conn)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count >= 7 Then
                        MessageBox.Show("All 7 Continent Name Exist", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error checking continent count: " & ex.Message)
        End Try
        Return True
    End Function
    ' Call new continent function on button click for new continent entry
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (CheckcontinentCount()) Then
            NewContinent()
        End If
    End Sub
    ' Function to save new continent entry after checking for duplicate continent name
    Private Sub SaveContinent()
        If (TextBox2.Text.Trim() = String.Empty) Then
            MessageBox.Show("Continent Name Can't be Empty", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            'To check if the continent name already exists
            Dim CheckName As String = "SELECT COUNT(*) FROM continent 
                                    WHERE ContinentName = @name"
            Using checkcmd As New SQLiteCommand(CheckName, conn)
                checkcmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim())
                Dim exists As Integer = Convert.ToInt32(checkcmd.ExecuteScalar())
                If exists > 0 Then
                    MessageBox.Show("Continent Name already exists!", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using
            Dim insertQuery As String =
                "INSERT INTO continent (ContinentCode, ContinentName) 
             VALUES (@code, @name)"
            Using cmd As New SQLiteCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@code", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Continent saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
        Load_continentList()
        NewContinent()
        Button2.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (CheckcontinentCount()) Then
            SaveContinent()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        ' Get values safely
        TextBox1.Text = row.Cells("Column1").Value.ToString()
        TextBox2.Text = row.Cells("Column2").Value.ToString()
        Button4.Enabled = True
    End Sub
    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

        ' Get values safely
        TextBox4.Text = row.Cells("Country Code").Value.ToString()
        TextBox5.Text = row.Cells("Country Name").Value.ToString()
        Button8.Enabled = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (TextBox2.Text.Trim() = String.Empty) Then
            MessageBox.Show("Continent Name Can't be Empty", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Using conn As SQLiteConnection = DBConnection.GetConnection()
            conn.Open()
            'To check if the continent name already exists
            Dim CheckName As String = "SELECT COUNT(*) FROM continent 
                                    WHERE ContinentName = @name 
                                    AND ContinentCode <> @code"
            Using checkcmd As New SQLiteCommand(CheckName, conn)
                checkcmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim())
                checkcmd.Parameters.AddWithValue("@code", TextBox1.Text.Trim())
                Dim exists As Integer = Convert.ToInt32(checkcmd.ExecuteScalar())
                If exists > 0 Then
                    MessageBox.Show("Continent Name already exists!", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using

            Dim updateQuery As String =
                "UPDATE continent 
             SET ContinentName = @name 
             WHERE ContinentCode = @code"
            Using cmd As New SQLiteCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@code", TextBox1.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Continent updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
        Load_continentList()
        NewContinent()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) _
    Handles TextBox2.TextChanged

        ' Enable button only if 3 characters are entered
        If TextBox2.TextLength >= 3 Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If

    End Sub
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBox12.TextChanged
        ' Disable Save Button if Continent Code is changed
        DataGridView7.DataSource = Nothing
        Button14.Enabled = False
        Button16.Enabled = False
        DataGridView7.Rows.Clear()

    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBox5.TextChanged
        'Enabled Save Button Button6 if 3 Characters are entered
        If TextBox5.TextLength >= 3 AndAlso Button8.Enabled = False Then
            Button6.Enabled = True
        Else
            Button6.Enabled = False

        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBox9.TextChanged
        'Enable Save Button Button10 if 3 Characters are entered and replace button is disabled
        If TextBox9.TextLength >= 3 AndAlso Button9.Enabled = False Then
            Button11.Enabled = True
        Else
            Button11.Enabled = False
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) _
    Handles TextBox14.TextChanged

        ' Enable button only if 3 characters are entered
        If TextBox14.TextLength >= 3 AndAlso Button16.Enabled = False Then
            Button14.Enabled = True
        Else
            Button14.Enabled = False
        End If

    End Sub

    ' FUNCTION TO FILL CONTINENT LIST IN THE GIVEN LISTBOX
    Public Sub FillContinentList(lst As ListBox)

        lst.Items.Clear()

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sql As String = "SELECT CONTINENTNAME FROM CONTINENT ORDER BY CONTINENTNAME"

                Using cmd As New SQLiteCommand(sql, conn)
                    Using dr As SQLiteDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lst.Items.Add(dr("CONTINENTNAME").ToString())
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading continents: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub



    'Functions to load add new country  (get ready to insert new country
    Private Sub AddNewCountry()
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim checkCode As String = "SELECT MAX(COUNTRYCODE) FROM COUNTRY"
                Using checkcmd As New SQLiteCommand(checkCode, conn)

                    Dim result As Object = checkcmd.ExecuteScalar()
                    Dim maxCode As Integer = 0

                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        maxCode = Convert.ToInt32(result)
                    Else
                        maxCode = 100
                    End If
                    TextBox4.Text = (maxCode + 1).ToString()
                    TextBox5.Text = String.Empty
                    TextBox5.Enabled = True
                    Button5.Enabled = True
                    Button6.Enabled = False
                    Button7.Enabled = True
                    Button8.Enabled = False

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Function to save new country
        If TextBox4.Text.Trim() = String.Empty Or
           TextBox5.Text.Trim() = String.Empty Or
           TextBox3.Text.Trim() = String.Empty Then
            MessageBox.Show("Continent Code, Country Code and Country Name can't be empty",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                ' to check duplicate country name
                Dim checkDuplicate As String = "SELECT COUNT(*) FROM COUNTRY WHERE COUNTRYCODE=@ID OR COUNTRYNAME=@NAME"
                Using checkcmd As New SQLiteCommand(checkDuplicate, conn)
                    checkcmd.Parameters.AddWithValue("@ID", TextBox4.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@NAME", TextBox5.Text.Trim())
                    Dim IfAny As Integer = Convert.ToInt32(checkcmd.ExecuteScalar())
                    If IfAny > 0 Then
                        MessageBox.Show("Duplicate Record, Country Name " & TextBox5.Text.Trim() & "Already Exist",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End Using

                'Insert Record is no duplicate found
                Dim InsertQuery As String = "INSERT INTO COUNTRY (COUNTRYCODE, COUNTRYNAME, CONTINENTCODE) 
                VALUES (@CODE, @CNAME, @CNTCODE)"
                Using insertcmd As New SQLiteCommand(InsertQuery, conn)
                    insertcmd.Parameters.AddWithValue("@CODE", TextBox4.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@CNAME", TextBox5.Text.Trim())
                    insertcmd.Parameters.AddWithValue("CNTCODE", TextBox3.Text.Trim())
                    insertcmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Country details saved successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '
            Dim continentCode As Integer = Convert.ToInt32(TextBox3.Text.Trim())
            LoadCountryGrid(continentCode, DataGridView2)
            AddNewCountry()

        Catch ex As Exception
            MessageBox.Show("Error in Saving Country Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox3.Text.Trim() = String.Empty Then
            MessageBox.Show("Please select a continent first.",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim continentCode As Integer = Convert.ToInt32(TextBox3.Text.Trim())
        TextBox3.Text = continentCode.ToString()
        LoadCountryGrid(continentCode, DataGridView2)
        AddNewCountry()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Function to update existing country details
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim checkSql As String =
            "SELECT COUNT(*) FROM COUNTRY
            WHERE COUNTRYNAME = @CNAME
            AND NOT (COUNTRYCODE = @CODE AND CONTINENTCODE = @CNT)"

                Using checkCmd As New SQLiteCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@CNAME", TextBox5.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CODE", TextBox4.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CNT", TextBox3.Text.Trim())

                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Country name already exists.",
                                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using
                Dim sql As String =
                "UPDATE COUNTRY
                 SET COUNTRYNAME = @CNAME
                 WHERE COUNTRYCODE = @CODE
                 AND CONTINENTCODE = @CNT"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@CNAME", TextBox5.Text.Trim())
                    cmd.Parameters.AddWithValue("@CODE", TextBox4.Text.Trim())
                    cmd.Parameters.AddWithValue("@CNT", TextBox3.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Country replaced successfully.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim continentCode As Integer = Convert.ToInt32(TextBox3.Text.Trim())
            LoadCountryGrid(continentCode, DataGridView2)
            AddNewCountry()
        Catch ex As Exception
            MessageBox.Show("Error updating country: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Function to clear all fields and reload Continent list for new Country entry
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox3.Text.Trim() = String.Empty Then
            MessageBox.Show("Please select a continent first.",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'clear country list and reset fields so that button/text box do not cause confusion and use by mistake fill wrong data

            DataGridView2.Rows.Clear()
            Button6.Enabled = False
            Button8.Enabled = False
            TextBox4.Text = String.Empty
            TextBox5.Text = String.Empty
            FillContinentList(ListBox1)
            Exit Sub
        End If
        Dim continentCode As Integer = Convert.ToInt32(TextBox3.Text.Trim())
        LoadCountryGrid(continentCode, DataGridView2)
        AddNewCountry()
    End Sub

    'Function to show state name in State Tab  when country name is clicked
    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DataGridView3.CellClick

        ' Ignore header click
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)

        TextBox7.Text = row.Cells("Country Code").Value.ToString()
        Dim CountryName As String = row.Cells("Country Name").Value.ToString()
        Dim countryCode As Integer = Convert.ToInt32(row.Cells("Country Code").Value)
        Dim continentCode As Integer = Convert.ToInt32(TextBox6.Text.Trim())
        TextBox9.Text = String.Empty
        TextBox8.Text = String.Empty
        LoadStateGrid(continentCode, countryCode, DataGridView5)

    End Sub


    'Function to show state name in CityTab name when country is clicked

    Private Sub DataGridView4_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DataGridView4.CellClick

        ' Ignore header click
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)

        TextBox11.Text = row.Cells("Country Code").Value.ToString()
        Dim CountryName As String = row.Cells("Country Name").Value.ToString()
        Dim countryCode As Integer = Convert.ToInt32(row.Cells("Country Code").Value)
        Dim continentCode As Integer = Convert.ToInt32(TextBox10.Text.Trim())
        TextBox12.Text = String.Empty
        TextBox13.Text = String.Empty
        TextBox14.Text = String.Empty
        LoadStateGrid(continentCode, countryCode, DataGridView6)

    End Sub

    'Function to start to add new state for the selected country
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox6.Text.Trim() = String.Empty Or TextBox7.Text.Trim() = String.Empty Then

            MessageBox.Show("Please select a continent and country first.",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim continentCode As Integer = Convert.ToInt32(TextBox6.Text.Trim())
        Dim countryCode As Integer = Convert.ToInt32(TextBox7.Text.Trim())
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim checkCode As String = "SELECT MAX(STATECODE) FROM STATE"
                Using checkcmd As New SQLiteCommand(checkCode, conn)
                    Dim result As Object = checkcmd.ExecuteScalar()
                    Dim maxCode As Integer = 0
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        maxCode = Convert.ToInt32(result)
                    Else
                        maxCode = 1000
                    End If
                    TextBox8.Text = (maxCode + 1).ToString()
                    TextBox9.Text = String.Empty
                    TextBox9.Enabled = True
                    TextBox12.Enabled = True
                    Button11.Enabled = False
                    Button10.Enabled = True
                    Button9.Enabled = False
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(String.Format("Error loading: {0}", ex.Message),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Function to save new state in selected country as well as continent
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If TextBox6.Text.Trim() = String.Empty Or
           TextBox7.Text.Trim() = String.Empty Or
           TextBox8.Text.Trim() = String.Empty Or
           TextBox9.Text.Trim() = String.Empty Then
            MessageBox.Show("Continent Code, Country Code, State Code and State Name can't be empty",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' Check duplicate state name within same country
                Dim checkDuplicate As String =
                    "SELECT COUNT(*) FROM STATE
               WHERE STATENAME = @NAME
               AND COUNTRYCODE = @CCODE
               AND CONTINENTCODE = @CNTCODE"

                Using checkcmd As New SQLiteCommand(checkDuplicate, conn)
                    checkcmd.Parameters.AddWithValue("@NAME", TextBox9.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@CCODE", TextBox7.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@CNTCODE", TextBox6.Text.Trim())

                    Dim IfAny As Integer = Convert.ToInt32(checkcmd.ExecuteScalar())
                    If IfAny > 0 Then
                        MessageBox.Show("State '" & TextBox9.Text.Trim() &
                                        "' already exists for this country.",
                                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' Insert record if no duplicate found
                Dim InsertQuery As String =
                    "INSERT INTO STATE (STATECODE, STATENAME, COUNTRYCODE, CONTINENTCODE)
             VALUES (@SCODE, @SNAME, @CCODE, @CNTCODE)"

                Using insertcmd As New SQLiteCommand(InsertQuery, conn)
                    insertcmd.Parameters.AddWithValue("@SCODE", TextBox8.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@SNAME", TextBox9.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@CCODE", TextBox7.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@CNTCODE", TextBox6.Text.Trim())

                    insertcmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("State saved successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim countryCode As Integer = Convert.ToInt32(TextBox7.Text.Trim())
            Dim continentCode As Integer = Convert.ToInt32(TextBox6.Text.Trim())
            TextBox9.Text = String.Empty
            TextBox8.Text = String.Empty
            TextBox9.Enabled = False
            LoadStateGrid(continentCode, countryCode, DataGridView5)
        Catch ex As Exception
            MessageBox.Show("Error saving state: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'clear all list in state Tab    
        DataGridView5.DataSource = Nothing
        DataGridView3.DataSource = Nothing
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox9.Enabled = False
        DataGridView5.Rows.Clear()
        DataGridView3.Rows.Clear()

    End Sub

    'Function when StateGrid is state Tab is clicked  (make it ready to update existing state name)
    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView5.CellClick
        ' Ignore header click
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView5.Rows(e.RowIndex)
        TextBox8.Text = row.Cells("State Code").Value.ToString()
        TextBox9.Text = row.Cells("State Name").Value.ToString()
        TextBox9.Enabled = True
        Button9.Enabled = True
        Button11.Enabled = False


    End Sub
    'Function to replace the State name with existing state code but should not be same in the same country
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox9.Text.Trim() = String.Empty Or
           TextBox8.Text.Trim() = String.Empty Or
           TextBox7.Text.Trim() = String.Empty Or
           TextBox6.Text.Trim() = String.Empty Then
            MessageBox.Show("State Name, State Code, Country Code and Continent Code can't be empty",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                ' Check for duplicate state name within same country
                Dim checkSql As String =
                    "SELECT COUNT(*) FROM STATE
             WHERE STATENAME = @SNAME
             AND COUNTRYCODE = @CCODE
             AND CONTINENTCODE = @CNTCODE
             AND NOT STATECODE = @SCODE"
                Using checkCmd As New SQLiteCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@SNAME", TextBox9.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CCODE", TextBox7.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CNTCODE", TextBox6.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@SCODE", TextBox8.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("State name already exists for this country.",
                                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using
                ' Update state name
                Dim updateSql As String =
                    "UPDATE STATE
             SET STATENAME = @SNAME
             WHERE STATECODE = @SCODE
             AND COUNTRYCODE = @CCODE
             AND CONTINENTCODE = @CNTCODE"
                Using cmd As New SQLiteCommand(updateSql, conn)
                    cmd.Parameters.AddWithValue("@SNAME", TextBox9.Text.Trim())
                    cmd.Parameters.AddWithValue("@SCODE", TextBox8.Text.Trim())
                    cmd.Parameters.AddWithValue("@CCODE", TextBox7.Text.Trim())
                    cmd.Parameters.AddWithValue("@CNTCODE", TextBox6.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("State updated successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Update State Grid with Updated data
            Dim countryCode As Integer = Convert.ToInt32(TextBox7.Text.Trim())
            Dim continentCode As Integer = Convert.ToInt32(TextBox6.Text.Trim())
            TextBox9.Text = String.Empty
            TextBox8.Text = String.Empty
            TextBox9.Enabled = False
            LoadStateGrid(continentCode, countryCode, DataGridView5)


        Catch ex As Exception
            MessageBox.Show("Error updating state: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' function to upload city details when state name is clicked in city tab
    Private Sub DataGridView6_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DataGridView6.CellClick
        ' Ignore header click

        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView6.Rows(e.RowIndex)
        TextBox12.Text = row.Cells("State Code").Value.ToString()
        Dim StateName As String = row.Cells("State Name").Value.ToString()
        Dim stateCode As Integer = Convert.ToInt32(row.Cells("State Code").Value)
        Dim countryCode As Integer = Convert.ToInt32(TextBox11.Text.Trim())
        Dim continentCode As Integer = Convert.ToInt32(TextBox10.Text.Trim())
        TextBox14.Text = String.Empty
        TextBox13.Text = String.Empty
        DataGridView7.DataSource = Nothing
        DataGridView7.Rows.Clear()

        LoadCityGrid(continentCode, countryCode, stateCode, DataGridView7)
    End Sub
    'Load City Grid for the selected state
    Public Function LoadCityGrid(continentCode As Integer,
                        countryCode As Integer,
                        stateCode As Integer,
                        dgv As DataGridView) As Boolean

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim query As String =
                "SELECT CITYCODE AS [City Code], CITYNAME AS [City Name]
                 FROM CITY
                 WHERE CONTINENTCODE = @CNTCODE
                 AND COUNTRYCODE = @CCODE
                 AND STATECODE = @SCODE
                 ORDER BY CITYNAME"

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CNTCODE", continentCode)
                    cmd.Parameters.AddWithValue("@CCODE", countryCode)
                    cmd.Parameters.AddWithValue("@SCODE", stateCode)

                    Using da As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        ' Add SL column and values
                        dt.Columns.Add("SL No", GetType(Integer))
                        Dim i As Integer = 1
                        For Each Row As DataRow In dt.Rows
                            Row("SL No") = i
                            i += 1
                        Next

                        'Place Sl NO as first Column
                        dt.Columns("SL No").SetOrdinal(0)
                        dgv.DataSource = dt

                        'set Column Width and Alignments
                        dgv.Columns("SL No").Width = 50
                        dgv.Columns("City Code").Width = 100
                        dgv.Columns("City Name").Width = 200
                        dgv.Columns("SL No").ReadOnly = True
                        dgv.Columns("City Code").ReadOnly = True
                        dgv.Columns("City Name").ReadOnly = True
                        dgv.Columns("City Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        dgv.Columns("City Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns("SL No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End Using
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Error loading cities: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False

    End Function

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If TextBox10.Text.Trim() = String.Empty Or
           TextBox11.Text.Trim() = String.Empty Or
           TextBox12.Text.Trim() = String.Empty Or
           TextBox14.Text.Trim() = String.Empty Then
            MessageBox.Show("Continent Code, Country Code, State Code and City Name can't be empty",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                ' Check for duplicate city name within same state
                Dim checkDuplicate As String =
                    "SELECT COUNT(*) FROM CITY
               WHERE CITYNAME = @NAME
               AND STATECODE = @SCODE
               AND COUNTRYCODE = @CCODE
               AND CONTINENTCODE = @CNTCODE"
                Using checkcmd As New SQLiteCommand(checkDuplicate, conn)
                    checkcmd.Parameters.AddWithValue("@NAME", TextBox14.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@SCODE", TextBox12.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@CCODE", TextBox11.Text.Trim())
                    checkcmd.Parameters.AddWithValue("@CNTCODE", TextBox10.Text.Trim())
                    Dim IfAny As Integer = Convert.ToInt32(checkcmd.ExecuteScalar())
                    If IfAny > 0 Then
                        MessageBox.Show("City '" & TextBox14.Text.Trim() &
                                        "' already exists for this state.",
                                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using
                ' Insert record if no duplicate found
                Dim InsertQuery As String =
                    "INSERT INTO CITY (CITYNAME, STATECODE, COUNTRYCODE, CONTINENTCODE)
             VALUES (@CNAME, @SCODE, @CCODE, @CNTCODE)"
                Using insertcmd As New SQLiteCommand(InsertQuery, conn)
                    insertcmd.Parameters.AddWithValue("@CNAME", TextBox14.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@SCODE", TextBox12.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@CCODE", TextBox11.Text.Trim())
                    insertcmd.Parameters.AddWithValue("@CNTCODE", TextBox10.Text.Trim())
                    insertcmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("City saved successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim continentCode As Integer = Convert.ToInt32(TextBox10.Text.Trim())
            Dim countryCode As Integer = Convert.ToInt32(TextBox11.Text.Trim())
            Dim stateCode As Integer = Convert.ToInt32(TextBox12.Text.Trim())
            TextBox14.Text = String.Empty
            TextBox14.Enabled = False
            LoadCityGrid(continentCode, countryCode, stateCode, DataGridView7)

        Catch ex As Exception
            MessageBox.Show("Error saving city: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If TextBox10.Text.Trim() = String.Empty Or
           TextBox11.Text.Trim() = String.Empty Or
           TextBox12.Text.Trim() = String.Empty Then
            MessageBox.Show("Please select a continent, country and state first.",
                            "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'clear city list and reset fields so that button/text box do not cause confusion and use by mistake fill wrong data
            DataGridView7.Rows.Clear()
            Button14.Enabled = False
            TextBox14.Text = String.Empty
            TextBox14.Enabled = True
            Exit Sub
        End If
        Try

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                'function to get maximum  of city code
                Dim checkCode As String = "SELECT MAX(CITYCODE) FROM CITY"
                Using checkcmd As New SQLiteCommand(checkCode, conn)

                    Dim result As Object = checkcmd.ExecuteScalar()
                    Dim maxCode As Integer

                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        maxCode = Convert.ToInt32(result)
                    Else
                        maxCode = 11000
                    End If

                    TextBox13.Text = (maxCode + 1).ToString()
                    TextBox14.Text = String.Empty
                    TextBox14.Enabled = True


                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox10.Text = String.Empty
        TextBox11.Text = String.Empty
        TextBox12.Text = String.Empty
        TextBox13.Text = String.Empty
        TextBox14.Text = String.Empty
        TextBox14.Enabled = False
        Button14.Enabled = False
        DataGridView4.DataSource = Nothing
        DataGridView7.DataSource = Nothing
        DataGridView6.DataSource = Nothing
        DataGridView7.Rows.Clear()
        DataGridView4.Rows.Clear()
        DataGridView6.Rows.Clear()
        ListBox3.Items.Clear()
        FillContinentList(ListBox3)

    End Sub



    ' To modify the city name when clicked on the city grid
    Private Sub DataGridView7_CellClick(sender As Object,
                                   e As DataGridViewCellEventArgs) _
                                   Handles DataGridView7.CellClick

        ' Ignore header click
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView7.Rows(e.RowIndex)

        ' Safety check
        If row Is Nothing OrElse row.Cells("City Code").Value Is Nothing Then Exit Sub

        ' Load selected city details
        TextBox13.Text = row.Cells("City Code").Value.ToString()   ' City Code
        TextBox14.Text = row.Cells("City Name").Value.ToString()   ' City Name

        ' Enable editing
        TextBox14.Enabled = True

        ' Button control
        Button14.Enabled = False   ' Save (New)
        Button13.Enabled = False   ' New
        Button16.Enabled = True    ' Update
    End Sub



    ' Function to load tree view for continent, country, state and city
    Public Sub LoadLocationTree(tv As TreeView)

        tv.Nodes.Clear()
        tv.BeginUpdate()

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' ===== CONTINENTS =====
                Dim contCmd As New SQLiteCommand(
                "SELECT CONTINENTCODE, CONTINENTNAME FROM CONTINENT ORDER BY CONTINENTNAME", conn)

                Using contReader = contCmd.ExecuteReader()
                    While contReader.Read()

                        Dim contNode As New TreeNode(contReader("CONTINENTNAME").ToString())
                        contNode.Tag = contReader("CONTINENTCODE")
                        tv.Nodes.Add(contNode)

                        LoadCountries(conn, contNode)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading tree: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tv.EndUpdate()
        End Try

    End Sub

    Private Sub LoadCountries(conn As SQLiteConnection, contNode As TreeNode)

        Dim sql As String =
        "SELECT COUNTRYCODE, COUNTRYNAME
         FROM COUNTRY
         WHERE CONTINENTCODE = @CNT
         ORDER BY COUNTRYNAME"

        Using cmd As New SQLiteCommand(sql, conn)
            cmd.Parameters.AddWithValue("@CNT", contNode.Tag)

            Using rdr = cmd.ExecuteReader()
                While rdr.Read()

                    Dim countryNode As New TreeNode(rdr("COUNTRYNAME").ToString())
                    countryNode.Tag = rdr("COUNTRYCODE")
                    contNode.Nodes.Add(countryNode)

                    LoadStates(conn, countryNode, contNode.Tag)
                End While
            End Using
        End Using

    End Sub

    Private Sub LoadStates(conn As SQLiteConnection,
                       countryNode As TreeNode,
                       continentCode As Integer)

        Dim sql As String =
        "SELECT STATECODE, STATENAME
         FROM STATE
         WHERE COUNTRYCODE = @CCODE
         AND CONTINENTCODE = @CNT
         ORDER BY STATENAME"

        Using cmd As New SQLiteCommand(sql, conn)
            cmd.Parameters.AddWithValue("@CCODE", countryNode.Tag)
            cmd.Parameters.AddWithValue("@CNT", continentCode)

            Using rdr = cmd.ExecuteReader()
                While rdr.Read()

                    Dim stateNode As New TreeNode(rdr("STATENAME").ToString())
                    stateNode.Tag = rdr("STATECODE")
                    countryNode.Nodes.Add(stateNode)

                    LoadCities(conn, stateNode, countryNode.Tag, continentCode)
                End While
            End Using
        End Using

    End Sub


    Private Sub LoadCities(conn As SQLiteConnection,
                       stateNode As TreeNode,
                       countryCode As Integer,
                       continentCode As Integer)

        Dim sql As String =
        "SELECT CITYCODE, CITYNAME
         FROM CITY
         WHERE STATECODE = @SCODE
         AND COUNTRYCODE = @CCODE
         AND CONTINENTCODE = @CNT
         ORDER BY CITYNAME"

        Using cmd As New SQLiteCommand(sql, conn)
            cmd.Parameters.AddWithValue("@SCODE", stateNode.Tag)
            cmd.Parameters.AddWithValue("@CCODE", countryCode)
            cmd.Parameters.AddWithValue("@CNT", continentCode)

            Using rdr = cmd.ExecuteReader()
                While rdr.Read()
                    Dim cityNode As New TreeNode(rdr("CITYNAME").ToString())
                    cityNode.Tag = rdr("CITYCODE")
                    stateNode.Nodes.Add(cityNode)
                End While
            End Using
        End Using

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

        ' Validation
        If TextBox13.Text.Trim() = String.Empty OrElse
       TextBox14.Text.Trim() = String.Empty Then

            MessageBox.Show("Please select a city and enter city name.",
                        "Input Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim cityCode As Integer
        If Not Integer.TryParse(TextBox13.Text.Trim(), cityCode) Then
            MessageBox.Show("Invalid city code.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cityName As String = TextBox14.Text.Trim()
        Dim countryCode As Integer = Convert.ToInt32(TextBox11.Text)
        Dim stateCode As Integer = Convert.ToInt32(TextBox12.Text)

        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                ' Optional: Prevent duplicate city names in same state
                Dim chkSql As String =
                "SELECT COUNT(*) FROM CITY
                 WHERE CITYNAME = @CITYNAME AND STATECODE = @STATECODE
                 AND CITYCODE <> @CITYCODE"

                Using chkCmd As New SQLiteCommand(chkSql, conn)
                    chkCmd.Parameters.AddWithValue("@CITYNAME", cityName)
                    chkCmd.Parameters.AddWithValue("@CITYCODE", cityCode)
                    chkCmd.Parameters.AddWithValue("@STATECODE", stateCode)

                    If Convert.ToInt32(chkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("City name already exists.",
                                    "Duplicate Entry",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' Update city
                Dim sql As String =
                "UPDATE CITY
                 SET CITYNAME = @CITYNAME
                 WHERE CITYCODE = @CITYCODE"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@CITYNAME", cityName)
                    cmd.Parameters.AddWithValue("@CITYCODE", cityCode)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("City updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

            ' Reset UI
            TextBox13.Clear()
            TextBox14.Clear()
            TextBox14.Enabled = False

            Button16.Enabled = False
            Button13.Enabled = True     ' New
            Button14.Enabled = False    ' Save

            ' Refresh grid
            LoadCityGrid(
            Convert.ToInt32(TextBox10.Text),
            Convert.ToInt32(TextBox11.Text),
            Convert.ToInt32(TextBox12.Text),
            DataGridView7)

        Catch ex As Exception
            MessageBox.Show("Error updating city: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label20_Click_1(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub
End Class
