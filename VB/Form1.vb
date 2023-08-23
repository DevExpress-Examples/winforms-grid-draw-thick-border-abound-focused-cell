Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Drawing

Namespace CellBorder

    Public Partial Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim tmp_XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
        End Sub

        Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If e.Column Is view.FocusedColumn AndAlso e.RowHandle = view.FocusedRowHandle Then
                e.DefaultDraw()
                DrawCellBorder(e)
                e.Handled = True
            End If
        End Sub
    End Class

    Public Module CellDrawHelper

        Public Sub DrawCellBorder(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
            Dim penWidth As Integer = 3
            Dim frameBounds As Rectangle = e.Bounds
            Dim skinName As String = UserLookAndFeel.Default.SkinName
            If Not Equals(skinName, "WXI") AndAlso Not Equals(skinName, "WXI Compact") Then
                penWidth = 2
                frameBounds = New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1)
            End If

            penWidth = penWidth * CInt(Math.Ceiling(e.Cache.ScaleDPI.ScaleFactorHorz - 0.5))
            Dim _pen As Pen = e.Cache.GetPen(DXSkinColors.ForeColors.ControlText, penWidth)
            e.Cache.DrawRectangle(_pen, frameBounds)
        End Sub
    End Module
End Namespace
