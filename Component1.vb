Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Component1

    Public Class CustomPanel
        Inherits Panel

        <Browsable(True), Category("Appearance")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderColor As Color = Color.Black

        <Browsable(True), Category("Appearance")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property BorderWidth As Integer = 2

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)

            Using pen As New Pen(BorderColor, BorderWidth)
                Dim rect As Rectangle = Me.ClientRectangle
                rect.Width -= 1
                rect.Height -= 1
                e.Graphics.DrawRectangle(pen, rect)
            End Using
        End Sub
    End Class
End Class
