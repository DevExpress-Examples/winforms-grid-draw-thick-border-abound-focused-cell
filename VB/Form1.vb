Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports System.Reflection
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private gridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

    Public Sub New()
        InitializeComponent()
    End Sub


#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.gridControl1 = New DevExpress.XtraGrid.GridControl
        Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridControl1
        '
        Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridControl1.EmbeddedNavigator.Name = ""
        Me.gridControl1.Location = New System.Drawing.Point(0, 0)
        Me.gridControl1.MainView = Me.gridView1
        Me.gridControl1.Name = "gridControl1"
        Me.gridControl1.Size = New System.Drawing.Size(478, 293)
        Me.gridControl1.TabIndex = 0
        Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
        '
        'gridView1
        '
        Me.gridView1.GridControl = Me.gridControl1
        Me.gridView1.Name = "gridView1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(478, 293)
        Me.Controls.Add(Me.gridControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
    End Sub

    Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gridView1.CustomDrawCell
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column Is view.FocusedColumn AndAlso e.RowHandle = view.FocusedRowHandle Then
            CellDrawHelper.DoDefaultDrawCell(view, e)
            CellDrawHelper.DrawCellBorder(e)
            e.Handled = True
        End If
    End Sub
End Class

Public NotInheritable Class CellDrawHelper
    Public Shared Sub DrawCellBorder(ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
        Dim brush As Brush = Brushes.Black
        e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 2, 2))
        e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.Right - 1, e.Bounds.Y - 1, 2, e.Bounds.Height + 2))
        e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Bottom - 1, e.Bounds.Width + 2, 2))
        e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, 2, e.Bounds.Height + 2))
    End Sub

    Public Shared Sub DoDefaultDrawCell(ByVal view As GridView, ByVal e As RowCellCustomDrawEventArgs)
        Dim pi As PropertyInfo
        Dim grid As GridControl
        Dim info As GridViewInfo
        Dim cell As GridCellInfo
        Dim helper As GridEditorContainerHelper
        Dim args As GridViewDrawArgs

        info = TryCast(view.GetViewInfo(), GridViewInfo)
        cell = TryCast(e.Cell, GridCellInfo)
        grid = view.GridControl
        pi = grid.GetType().GetProperty("EditorHelper", BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
        helper = TryCast(pi.GetValue(grid, Nothing), GridEditorContainerHelper)
        args = New GridViewDrawArgs(e.Cache, info, e.Bounds)
        e.Appearance.FillRectangle(e.Cache, e.Bounds)
        helper.DrawCellEdit(args, cell.Editor, cell.ViewInfo, e.Appearance, cell.CellValueRect.Location)
    End Sub
End Class