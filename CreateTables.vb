Imports System.Data.SQLite
Imports System.Data.SqlTypes
Imports System.Drawing.Imaging
Imports System.[Private].Windows
Imports System.Security.Cryptography
Imports AxSHDocVw
Public Class CreateTables


    Public Sub CreateTable()
        ' Table to store user data
        Try


            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                ' Create table to add Expenses Category
                Dim ExpCat As String = "CREATE TABLE IF NOT EXISTS EXPENSES_CATEGORY (
                    EXP_CAT_CODE  INTEGER PRIMARY KEY,
                    EXP_CAT_NAME TEXT,
                    EXP_CAT_HEAD TEXT,
                    EXP_CAT_REMARKS TEXT
                    )"
                Using cmdExp As New SQLiteCommand(ExpCat, conn)
                    cmdExp.ExecuteNonQuery()
                End Using

                ' Create table to STORE USER DETAILS

                Dim sql As String = "CREATE TABLE IF NOT EXISTS USERDATA (
                    USERCODE INTEGER PRIMARY KEY,
                    USERID TEXT NOT NULL UNIQUE,
                    FIRSTNAME TEXT NOT NULL,
                    LASTNAME TEXT NOT NULL,
                    USERTYPE TEXT NOT NULL,
                    PASSWORD TEXT NOT NULL
                )"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using


                ' Table to store transaction modes (cash, bank, etc.)
                Dim sql1 As String = "CREATE TABLE IF NOT EXISTS TRANSACTION_MODE (
                    TR_MODE_CODE INTEGER PRIMARY KEY,
                    TR_MODE_NAME TEXT NOT NULL UNIQUE,
                    TR_MODE_REMARKS TEXT )"
                Using cmd As New SQLiteCommand(sql1, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'table to store cash wallet and bank wallet details for each user
                Dim sql2 As String = "CREATE TABLE IF NOT EXISTS CASH_WALLET (
                    USERCODE INTEGER,
                    CW_CODE INTEGER PRIMARY KEY,
                    CW_ST_DATE DATE NOT NULL,
                    CW_END_DATE DATE,
                    CW_STAUS BOOLEAN NOT NULL,
                    CW_REMARKS TEXT,
                    CW_BALANCE INTEGER,
                    FOREIGN KEY (USERCODE) REFERENCES USERDATA(USERCODE)
                    )"
                Using cmd As New SQLiteCommand(sql2, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'Create table for income source category
                Dim sql11 As String = "CREATE TABLE IF NOT EXISTS INCOME_SOURCE_CATEGORY (
                    INC_S_CAT_CODE INTEGER PRIMARY KEY,
                    INC_S_CAT_NAME TEXT NOT NULL UNIQUE,
                    INC_S_CAT_REMARKS TEXT
                )"
                Using cmd As New SQLiteCommand(sql11, conn)
                    cmd.ExecuteNonQuery()
                End Using


                Dim sql3 As String = "CREATE TABLE IF NOT EXISTS BANK_WALLET (
                    USERCODE INTEGER, 
                    BW_CODE INTEGER PRIMARY KEY,
                    BW_ST_DATE DATE NOT NULL,
                    BW_END_DATE DATE,
                    BW_STAUS BOOLEAN NOT NULL,
                    BW_REMARKS TEXT,
                    BW_BALANCE INTEGER,
                    FOREIGN KEY (USERCODE) REFERENCES USERDATA(USERCODE)
                    )"
                Using cmd As New SQLiteCommand(sql3, conn)
                    cmd.ExecuteNonQuery()
                End Using


                ' table to store income source details for each user
                Dim sql4 As String = "CREATE TABLE IF NOT EXISTS INCOME_SOURCE (
                INC_S_CODE INTEGER PRIMARY KEY,
                INC_S_NAME TEXT NOT NULL UNIQUE,
                INC_S_ADDRESS TEXT,
                INC_S_PERSON TEXT,
                INC_S_DESIGNATION TEXT,
                INC_S_CONTACT TEXT,
                INC_S_MOBILE TEXT,
                INC_S_EMAIL TEXT,
                INC_S_WEBSITE TEXT,
                INC_S_ST_DATE DATE NOT NULL,
                INC_S_END_DATE DATE,
                INC_S_STATUS BOOLEAN NOT NULL,
                INC_S_REF TEXT,
                INC_S_REMARKS TEXT
                )"
                Using cmd As New SQLiteCommand(sql4, conn)
                    cmd.ExecuteNonQuery()
                End Using

                ' CREATE TABLE TO SHOW CURRENT INCOME SOURCE MAPPING FOR EACH USER USEFUL FOR REMINDERS AND PAYMENT SCHEDULES, RECEIPTS
                Dim sql5 As String = "CREATE TABLE IF NOT EXISTS CURRENT_INCOME_SOURCE (
                  USERCODE INTEGER,
                  INC_S_CODE INTEGER,
                  START_DATE DATE NOT NULL,
                  END_DATE DATE,
                  FIXED_AMOUNT REAL,
                  PAYMENT_SCHEDULE TEXT,
                  STATUS BOOLEAN NOT NULL,
                  INC_S_C_CODE INTEGER,
                  NEXT_PAYMENT_DATE DATE NOT NULL,   
                  REMARKS TEXT,
                  FOREIGN KEY (USERCODE) REFERENCES USERDATA(USERCODE),
                  FOREIGN KEY (INC_S_CODE) REFERENCES INCOME_SOURCE(INC_S_CODE),
                  FOREIGN KEY (INC_S_C_CODE) REFERENCES INCOME_SOURCE_CATEGORY(INC_S_CAT_CODE)
               )"
                Using cmd9 As New SQLiteCommand(sql5, conn)
                    cmd9.ExecuteNonQuery()
                End Using


                'CREATE TABLE TO RECORD ALL USER INCOME SOURCE MAPPING CHANGES

                Dim sql6 As String = "CREATE TABLE IF NOT EXISTS SOURCEMAPPING (
                    USERCODE INTEGER,
                    SOURCECODE INTEGER,
                    LAST_MODIFIED_DATE DATE,
                    START_DATE  DATE,
                    END_DATE  DATE,
                    FIX_AMOUNT  REAL,
                    PAYMENT_SCHEDULE  TEXT,
                    PAYMENT_NEXT_DATE  DATE,
                    ISACTIVE  BOOLEAN,
                    REMARKS TEXT) "
                Using cmd As New SQLiteCommand(sql6, conn)
                    cmd.ExecuteNonQuery()
                End Using


                'CREATE TABLE FOR CONTINENETS
                Dim sql7 As String = "CREATE TABLE IF NOT EXISTS CONTINENT (
                   CONTINENTCODE INTEGER,
                   CONTINENTNAME TEXT NOT NULL UNIQUE,
                   PRIMARY KEY (CONTINENTCODE)
                    
                )"
                Using cmd As New SQLiteCommand(sql7, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'CREATE TABLE FOR COUNTRIIES
                Dim sql8 As String = "CREATE TABLE IF NOT EXISTS COUNTRY (
                    COUNTRYCODE INTEGER,
                    COUNTRYNAME TEXT NOT NULL UNIQUE,
                    CONTINENTCODE INTEGER,
                    PRIMARY KEY (COUNTRYCODE)
                    )"
                Using cmd As New SQLiteCommand(sql8, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'CREATE TABLE FOR STATES
                Dim sql9 As String = "CREATE TABLE IF NOT EXISTS STATE (
                    STATECODE INTEGER,
                    STATENAME TEXT NOT NULL UNIQUE,
                    CONTINENTCODE INTEGER,
                    COUNTRYCODE  INTEGER,
                    PRIMARY KEY (STATECODE)
                    
                )"
                Using cmd As New SQLiteCommand(sql9, conn)
                    cmd.ExecuteNonQuery()
                End Using


                'CREATE TABLE FOR CITIES
                Dim sql10 As String = "CREATE TABLE IF NOT EXISTS CITY (
                    CITYCODE INTEGER,
                    CITYNAME TEXT NOT NULL UNIQUE,
                    STATECODE  INTEGER,
                    CONTINENTCODE  INTEGER,
                    COUNTRYCODE  INTEGER,
                    PRIMARY KEY (CITYCODE)
                    
                )"
                Using cmd As New SQLiteCommand(sql10, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'Create table to map income source and category
                Dim sql12 As String = "CREATE TABLE IF NOT EXISTS SOURCE_CATEGORY_MAPPING (
                    INC_S_CODE INTEGER,
                    INC_USERCODE INTEGER,
                    INC_S_CAT_CODE INTEGER,
                    FOREIGN KEY (INC_S_CODE) REFERENCES INCOME_SOURCE(INC_S_CODE),
                    FOREIGN KEY (INC_S_CAT_CODE) REFERENCES INCOME_SOURCE_CATEGORY(INC_S_CAT_CODE),
                    FOREIGN KEY (INC_USERCODE) REFERENCES USERDATA(USERCODE)
                )"
                Using cmd As New SQLiteCommand(sql12, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'create table to store bank name only
                Using cmdBank As New SQLiteCommand("CREATE TABLE IF NOT EXISTS BANK_NAMES (BANK_NAME TEXT UNIQUE, 
                  BANK_CODE INTEGER UNIQUE
                    )", conn)
                    cmdBank.ExecuteNonQuery()
                End Using

                'create table to store bank contact details
                Dim sqlBankStaff As String = "CREATE TABLE IF NOT EXISTS BANK_STAFF (
                B_STAFF_CODE INTEGER,
                BANK_CODE INTEGER,
                BANK_PLACE TEXT,
                B_STAFF_NAME TEXT,
                B_STAFF_DESG TEXT,
                B_STAFF_MOBILE TEXT UNIQUE,
                B_STAFF_LANDLINE TEXT,
                B_STAFF_EMAIL TEXT,
                B_STAFF_REMARKS TEXT,
                PRIMARY KEY (B_STAFF_CODE),
                FOREIGN KEY (BANK_CODE) REFERENCES BANK_NAMES (BANK_CODE)
                )"

                Using cmdBankstaff As New SQLiteCommand(sqlBankStaff, conn)
                    cmdBankstaff.ExecuteNonQuery()
                End Using


                'Create Table to store bank account details
                Dim sql13 As String = "CREATE TABLE IF NOT EXISTS BANK_ACCOUNT 
                    (
                        BANK_ACCOUNT_CODE  INTEGER,
                        BANKNAME_CODE INTEGER NOT NULL,
                        USER_CODE INTEGER,
                        ACCOUNT_TYPE TEXT,
                        ACCOUNT_NUMBER TEXT UNIQUE,
                        IFSC_CODE TEXT,
                        SWIFT_CODE TEXT,
                        BRANCH_OFFICE TEXT,
                        ACCOUNT_REMARKS TEXT, 
                        ACCOUNT_STATUS BOOLEAN,
                        ACCOUNT_START_DATE DATE,
                        ACCOUNT_END_DATE DATE,
                        PRIMARY KEY (BANK_ACCOUNT_CODE),
                        FOREIGN KEY (USER_CODE) REFERENCES USERDATA(USERCODE),
                        FOREIGN KEY (BANKNAME_CODE) REFERENCES BANK_NAMES(BANK_CODE)
                    )"

                Using addBankAccount As New SQLiteCommand(sql13, conn)
                    addBankAccount.ExecuteNonQuery()
                End Using


                ' add CASH BOOK

                Dim sql14 As String = "CREATE TABLE IF NOT EXISTS CASH_BOOK (
                    TRANS_CODE  INTEGER,
                    TRANS_USERCODE  INTEGER,
                    TRANS_DATE  DATE,
                    TRANS_MODE TEXT,
                    TRANS_TDS REAL,
                    OTHER_DEDUCTION REAL,
                    TRANS_AMOUNT REAL,
                    TRANS_TYPE TEXT,
                    FOREIGN KEY (TRANS_USERCODE) REFERENCES USERDATA(USERCODE)
                )"
                Using cmd As New SQLiteCommand(sql14, conn)
                    cmd.ExecuteNonQuery()
                End Using


                ' add BANK BOOK
                Dim sql15 As String = "CREATE TABLE IF NOT EXISTS BANK_BOOK (
                    TRANS_CODE  INTEGER,
                    TRANS_BANKCODE INTEGER,
                    TRANS_USERCODE  INTEGER,
                    TRANS_DATE  DATE,
                    TRANS_MODE TEXT,
                    TRANS_TDS REAL,
                    OTHER_DEDUCTION REAL,
                    TRANS_AMOUNT REAL,
                    TRANS_TYPE TEXT,
                    FOREIGN KEY (TRANS_USERCODE) REFERENCES USERDATA(USERCODE),
                    FOREIGN KEY (TRANS_BANKCODE) REFERENCES BANK_ACCOUNT(BANK_CODE)
                )"
                Using cmd As New SQLiteCommand(sql15, conn)
                    cmd.ExecuteNonQuery()
                End Using




            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating tables: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DefaultData()
        ' Insert default transaction modes cash and bank 
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "INSERT OR IGNORE INTO TRANSACTION_MODE (TR_MODE_CODE, TR_MODE_NAME, TR_MODE_REMARKS) VALUES 
                    (11, 'CASH', 'Cash Transaction Mode'),
                    (22, 'BANK', 'Bank Transaction Mode')"
                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting default data: " & ex.Message, "Error", buttons:=MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

        'create cash wallet for all users
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql4 As String = "SELECT USERCODE FROM USERDATA"
                Using cmd As New SQLiteCommand(sql4, conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim userCode As Integer = reader.GetInt32(0)
                            Dim insertSql As String = "INSERT OR IGNORE INTO CASH_WALLET (USERCODE, CW_CODE, CW_ST_DATE, CW_STAUS, CW_BALANCE) VALUES 
                                (@userCode, @cwCode, @cwStDate, @cwStatus, @cwBalance)"
                            Using insertCmd As New SQLiteCommand(insertSql, conn)
                                insertCmd.Parameters.AddWithValue("@userCode", userCode)
                                insertCmd.Parameters.AddWithValue("@cwCode", userCode * 10 + 1) ' Example CW_CODE generation
                                insertCmd.Parameters.AddWithValue("@cwStDate", DateTime.Now)
                                insertCmd.Parameters.AddWithValue("@cwStatus", True)
                                insertCmd.Parameters.AddWithValue("@cwBalance", 0)
                                insertCmd.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

        'create bank wallet for all users
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql4 As String = "SELECT USERCODE FROM USERDATA"
                Using cmd As New SQLiteCommand(sql4, conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim userCode As Integer = reader.GetInt32(0)
                            Dim insertSql As String = "INSERT OR IGNORE INTO BANK_WALLET (USERCODE, BW_CODE, BW_ST_DATE, BW_STAUS, BW_BALANCE) VALUES 
                                (@userCode, @bwCode, @bwStDate, @bwStatus, @bwBalance)"
                            Using insertCmd As New SQLiteCommand(insertSql, conn)
                                insertCmd.Parameters.AddWithValue("@userCode", userCode)
                                insertCmd.Parameters.AddWithValue("@bwCode", userCode * 10 + 1) ' Example BW_CODE generation
                                insertCmd.Parameters.AddWithValue("@bwStDate", DateTime.Now)
                                insertCmd.Parameters.AddWithValue("@bwStatus", True)
                                insertCmd.Parameters.AddWithValue("@bwBalance", 0)
                                insertCmd.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' create default expenses categories 
        Try
            Dim E_Code() As Integer = {11, 12, 13, 14}
            Dim E_Name() As String = {"GROCESSARY", "VEGETABLES", "STATIONARY", "EDUCATION FEES"}
            Dim E_Remarks() As String = {"Food items", "Raw Veg and Fruits", "Books, NoteBooks, Pens etc", "School, College, Tuition Fees"}

            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()

                Dim sqlSave As String = "INSERT OR IGNORE INTO EXPENSES_CATEGORY " &
                                        "(EXP_CAT_CODE, EXP_CAT_NAME, EXP_CAT_HEAD, EXP_CAT_REMARKS) " &
                                        "VALUES (@CODE, @NAME, @HEAD, @REMARK)"

                Using cmdExpCat As New SQLiteCommand(sqlSave, conn)

                    'Add parameters with type
                    cmdExpCat.Parameters.Add("@CODE", DbType.Int32)
                    cmdExpCat.Parameters.Add("@NAME", DbType.String)
                    cmdExpCat.Parameters.Add("@HEAD", DbType.String)
                    cmdExpCat.Parameters.Add("@REMARK", DbType.String)

                    For i As Integer = 0 To E_Code.Length - 1
                        cmdExpCat.Parameters("@CODE").Value = E_Code(i)
                        cmdExpCat.Parameters("@NAME").Value = E_Name(i)
                        cmdExpCat.Parameters("@HEAD").Value = "INDIRECT EXPENSES"
                        cmdExpCat.Parameters("@REMARK").Value = E_Remarks(i)

                        cmdExpCat.ExecuteNonQuery()
                    Next
                End Using



                'ADD DEFAULT BANK NAMES

            End Using
        Catch ex As Exception
            MessageBox.Show("ERROR IS " & ex.Message, "No added", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'No message to show
        End Try


        'STORE DEFULT BANK NAME
        Dim codes = {11, 12, 13, 14}
        Dim names = {"PUNJAB NATIONAL BANK", "STATE BANK OF INDIA", "IDBC BANK", "HDFC BANK LIMITED"}
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
                Dim sql As String = "INSERT OR IGNORE INTO BANK_NAMES (BANK_CODE, BANK_CODE) VALUES (@code, @name)"
                Using cmdSave As New SQLiteCommand(sql, conn)
                    'Add parameters with type
                    cmdSave.Parameters.Add("@code", DbType.Int32)
                    cmdSave.Parameters.Add("@name", DbType.String)

                    For i As Integer = 0 To codes.Length - 1
                        cmdSave.Parameters("@code").Value = codes(i)
                        cmdSave.Parameters("@name").Value = names(i)
                        cmdSave.ExecuteNonQuery()
                    Next
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error while adding default bank names " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim db As New CreateTables()
            db.CreateTable()
            db.DefaultData()
            MessageBox.Show("Necessary databases are created ", "done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            Print(ex.Message)

        End Try
        Me.Close()
        Login.Show()

    End Sub

    Private Sub CreateTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class