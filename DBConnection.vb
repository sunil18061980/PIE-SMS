Imports System.Data.SQLite
Imports System.IO
Imports System.Data
Imports System.Windows.Forms

'==================== DB Connection Class ====================
Public Class DBConnection

    Private Shared ReadOnly dbFile As String =
        Path.Combine(Application.StartupPath, "mysaving.db3")

    Private Shared ReadOnly connString As String =
        $"Data Source={dbFile};Version=3;"

    ' ALWAYS return a NEW connection
    Public Shared Function GetConnection() As SQLiteConnection
        Return New SQLiteConnection(connString)
    End Function

End Class
