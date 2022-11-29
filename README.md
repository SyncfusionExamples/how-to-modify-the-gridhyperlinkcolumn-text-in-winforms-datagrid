# How to modify the GridHyperLinkColumn text in WinForms DataGrid (SfDataGrid)

By default, the text in GridHypelinkColumn will be updated with provided link. To change the text of hyperlink in the cells, the DisplayText can be changed based on our requirement using [SfDataGrid.DrawCell](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html?_gl=1*53s5q5*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2OTcyMzQ0My4zMjIuMS4xNjY5NzI1OTU0LjAuMC4w&_ga=2.126733002.696256746.1669612014-766490130.1650530957) event.

```
//Event subscription
this.sfDataGrid1.DrawCell += SfDataGrid1_DrawCell;
 
//Event customization
private void SfDataGrid1_DrawCell(object sender, DrawCellEventArgs e)
{
    if(e.Column.MappingName == "Hyperlink")
    {
        string displayText = e.DisplayText;
        int index = displayText.LastIndexOf('.');
        int firstIndex = displayText.IndexOf('.');
        int length = displayText.Length - (displayText.Length - index) - firstIndex;
        displayText = e.DisplayText.Substring(firstIndex + 1, length - 1);
 
        //To update text of hyperlink.
        e.DisplayText = displayText;
    }
}
```