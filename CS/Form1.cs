using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;

namespace CellBorder {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e) {
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            GridView view = sender as GridView;
            if (e.Column == view.FocusedColumn && e.RowHandle == view.FocusedRowHandle) {
                e.DefaultDraw();
                CellDrawHelper.DrawCellBorder(e);
                e.Handled = true;
            }
        }
    }
    public static class CellDrawHelper {
        public static void DrawCellBorder(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            int penWidth = 3;
            Rectangle frameBounds = e.Bounds;
            string skinName = UserLookAndFeel.Default.SkinName;
            if (skinName != "WXI" && skinName != "WXI Compact") {
                penWidth = 2;
                frameBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 1, e.Bounds.Height + 1);
            }
            penWidth = penWidth * (int)Math.Ceiling(e.Cache.ScaleDPI.ScaleFactorHorz - 0.5);
            Pen _pen = e.Cache.GetPen(DXSkinColors.ForeColors.ControlText, penWidth);
            e.Cache.DrawRectangle(_pen, frameBounds);
        }
    }
}