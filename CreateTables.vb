Imports System.Data.SQLite
Imports System.Data.SqlTypes
Imports System.Drawing.Imaging
Imports System.[Private].Windows
Public Class CreateTables
    Private Sub CreateTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub CreateTable()
        ' Table to store user data
        Try
            Using conn As SQLiteConnection = DBConnection.GetConnection()
                conn.Open()
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
                    FOREIGN KEY (USERCODE) REFERENCES USERDATA(USERCODE)
                    )"
                Using cmd As New SQLiteCommand(sql2, conn)
                    cmd.ExecuteNonQuery()
                End Using

                Dim sql3 As String = "CREATE TABLE IF NOT EXISTS BANK_WALLET (
                    USERCODE INTEGER, 
                    BW_CODE INTEGER PRIMARY KEY,
                    BW_ST_DATE DATE NOT NULL,
                    BW_END_DATE DATE,
                    BW_STAUS BOOLEAN NOT NULL,
                    BW_REMARKS TEXT,
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
                    PRIMARY KEY (USERCODE, INC_S_CODE),
                    FOREIGN KEY (USERCODE) REFERENCES USERDATA(USERCODE),
                    FOREIGN KEY (INC_S_CODE) REFERENCES INCOME_SOURCE(INC_S_CODE)
                )"

                Using cmd As New SQLiteCommand(sql5, conn)
                    cmd.ExecuteNonQuery()
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

                'Create table for income source category
                Dim sql11 As String = "CREATE TABLE IF NOT EXISTS INCOME_SOURCE_CATEGORY (
                    INC_S_CAT_CODE INTEGER PRIMARY KEY,
                    INC_S_CAT_NAME TEXT NOT NULL UNIQUE,
                    INC_S_CAT_REMARKS TEXT
                )"
                Using cmd As New SQLiteCommand(sql11, conn)
                    cmd.ExecuteNonQuery()
                End Using

                'Create table to map income source and category
                Dim sql12 As String = "CREATE TABLE IF NOT EXISTS SOURCE_CATEGORY_MAPPING (
                    INC_S_CODE INTEGER,
                    INC_USERCODE INTEGER,
                    INC_S_CAT_CODE INTEGER,
                    FOREIGN KEY (INC_S_CODE) REFERENCES INCOME_SOURCE(INC_S_CODE),
                    FOREIGN KEY (INC_S_CAT_CODE) REFERENCES INCOME_SOURCE_CATEGORY(INC_S_CAT_CODE)
                    FOREIGN KEY (INC_USERCODE) REFERENCES USERDATA(USERCODE)
                )"
                Using cmd As New SQLiteCommand(sql12, conn)
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
                            Dim insertSql As String = "INSERT OR IGNORE INTO CASH_WALLET (USERCODE, CW_CODE, CW_ST_DATE, CW_STAUS) VALUES 
                                (@userCode, @cwCode, @cwStDate, @cwStatus)"
                            Using insertCmd As New SQLiteCommand(insertSql, conn)
                                insertCmd.Parameters.AddWithValue("@userCode", userCode)
                                insertCmd.Parameters.AddWithValue("@cwCode", userCode * 10 + 1) ' Example CW_CODE generation
                                insertCmd.Parameters.AddWithValue("@cwStDate", DateTime.Now)
                                insertCmd.Parameters.AddWithValue("@cwStatus", True)
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
                            Dim insertSql As String = "INSERT OR IGNORE INTO BANK_WALLET (USERCODE, BW_CODE, BW_ST_DATE, BW_STAUS) VALUES 
                                (@userCode, @bwCode, @bwStDate, @bwStatus)"
                            Using insertCmd As New SQLiteCommand(insertSql, conn)
                                insertCmd.Parameters.AddWithValue("@userCode", userCode)
                                insertCmd.Parameters.AddWithValue("@bwCode", userCode * 10 + 1) ' Example BW_CODE generation
                                insertCmd.Parameters.AddWithValue("@bwStDate", DateTime.Now)
                                insertCmd.Parameters.AddWithValue("@bwStatus", True)
                                insertCmd.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
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
End Class