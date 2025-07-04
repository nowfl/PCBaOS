Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel

<DefaultEvent("CheckedChanged")>
Public Class Toggle
    Inherits System.Windows.Forms.UserControl

    Private _checked As Boolean
    Public Property Checked As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            If Not _checked.Equals(value) Then
                _checked = value
                Me.OnCheckedChanged()
            End If
        End Set
    End Property

    Protected Overridable Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub

    Public Event CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
        Me.Checked = Not Me.Checked
        Me.Invalidate()
        MyBase.OnMouseClick(e)
    End Sub

    Private isMouseOverEllipse As Boolean = False
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        isMouseOverEllipse = True
        Me.Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        isMouseOverEllipse = False
        Me.Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Me.OnPaintBackground(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Using path = New GraphicsPath()
            Dim d = Padding.All
            Dim r = Me.Height - 2 * d
            Dim rnew = Me.Height - 2 * d - 5
            path.AddArc(d, d, r, r, 90, 180)
            path.AddArc(Me.Width - r - d, d, r, r, -90, 180)
            path.CloseFigure()
            Dim fillColor = If(isMouseOverEllipse AndAlso Not Checked, Brushes.LightSteelBlue, If(Checked, Brushes.Blue, Brushes.LightGray))
            e.Graphics.FillPath(fillColor, path)
            r = Height - 1
            Dim rect = If(Checked, New System.Drawing.Rectangle(Width - rnew - 3, 2.5, rnew, rnew), New System.Drawing.Rectangle(3, 2.5, rnew, rnew))
            e.Graphics.FillEllipse(If(Checked, Brushes.White, Brushes.White), rect)
        End Using
    End Sub

    Private Sub Toggle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
