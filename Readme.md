<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128628171/23.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E513)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Draw a thick border around the focused cell (CustomDrawCell event)

This example handles the [CustomDrawCell](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawCell) event to paint a thick border around the focused cell.

```csharp
private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
    GridView view = sender as GridView;
    if (e.Column == view.FocusedColumn && e.RowHandle == view.FocusedRowHandle) {
        e.DefaultDraw();
        CellDrawHelper.DrawCellBorder(e);
        e.Handled = true;
    }
}
```

## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Custom Painting Basics](https://docs.devexpress.com/WindowsForms/762/controls-and-libraries/data-grid/appearance-and-conditional-formatting/custom-painting/custom-painting-basics)
* [Custom Painting Scenarios](https://docs.devexpress.com/WindowsForms/763/controls-and-libraries/data-grid/appearance-and-conditional-formatting/custom-painting/custom-painting-scenarios)

## See Also

* [DevExpress WinForms Troubleshooting - Grid Control](https://go.devexpress.com/CheatSheets_WinForms_Examples_T934742.aspx)
