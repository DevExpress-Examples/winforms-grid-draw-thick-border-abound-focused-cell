Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.Drawing

Namespace CellBorder

    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits Form

        Private gridControl1 As GridControl

        Private gridView1 As GridView

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            gridControl1 = New GridControl()
            gridView1 = New GridView()
            CType(gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            gridControl1.Dock = DockStyle.Fill
            gridControl1.EmbeddedNavigator.Name = ""
            gridControl1.Location = New System.Drawing.Point(0, 0)
            gridControl1.MainView = gridView1
            gridControl1.Name = "gridControl1"
            gridControl1.Size = New System.Drawing.Size(476, 293)
            gridControl1.TabIndex = 0
            gridControl1.ViewCollection.AddRange(New BaseView() {gridView1})
            ' 
            ' gridView1
            ' 
            gridView1.GridControl = gridControl1
            gridView1.Name = "gridView1"
            AddHandler gridView1.CustomDrawCell, New RowCellCustomDrawEventHandler(AddressOf gridView1_CustomDrawCell)
            ' 
            ' Form1
            ' 
            AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            ClientSize = New System.Drawing.Size(476, 293)
            Me.Controls.Add(gridControl1)
            Name = "Form1"
            Text = "Form1"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            CType(gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            Call Application.Run(New Form1())
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim tmp_XViewsPrinting = New Design.XViewsPrinting(gridControl1)
        End Sub

        Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If e.Column Is view.FocusedColumn AndAlso e.RowHandle = view.FocusedRowHandle Then
                DoDefaultDrawCell(view, e)
                DrawCellBorder(e)
                e.Handled = True
            End If
        End Sub
    End Class

    Public Module CellDrawHelper

        Public Sub DrawCellBorder(ByVal e As RowCellCustomDrawEventArgs)
            Dim brush As Brush = Brushes.Black
            e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 2, 2))
            e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.Right - 1, e.Bounds.Y - 1, 2, e.Bounds.Height + 2))
            e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Bottom - 1, e.Bounds.Width + 2, 2))
            e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, 2, e.Bounds.Height + 2))
        End Sub

        Public Sub DoDefaultDrawCell(ByVal view As GridView, ByVal e As RowCellCustomDrawEventArgs)
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
    End Module
End Namespace
