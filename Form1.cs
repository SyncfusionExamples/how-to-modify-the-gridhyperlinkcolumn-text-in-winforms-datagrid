using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCommon.Grid;
using System.Windows.Forms.VisualStyles;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Globalization;
using Syncfusion.WinForms.ListView;
using Syncfusion.WinForms.ListView.Enums;

namespace ColumnTypes
{
    public partial class Form1 : Form
    {
        #region Fields
        OrderInfoCollection orderInfo;
        #endregion

        #region Constuctor
        public Form1()
        {
            InitializeComponent();
            orderInfo = new OrderInfoCollection();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.DataSource = orderInfo.OrdersListDetails;
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = "UnitPrice",
                HeaderText = "Unit Price",
                FormatMode = FormatMode.Currency,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.PercentDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "Discount", HeaderText = "Discount", FormatMode = FormatMode.Percent, NumberFormatInfo = numberFormat });
            this.sfDataGrid1.Columns.Add(new GridHyperlinkColumn() { MappingName = "Hyperlink", HeaderText = "Order URI" });
            this.sfDataGrid1.Columns.Add(new GridComboBoxColumn() { MappingName = "ShipCityID", HeaderText = "Ship City", DisplayMember = "ShipCityName", ValueMember = "ShipCityID", DropDownStyle = DropDownStyle.DropDownList, DataSource = orderInfo.ShipCityDetails });
			this.sfDataGrid1.Columns.Add(new GridMultiSelectComboBoxColumn() { MappingName = "Products", HeaderText = "Products", DisplayMember = "ProductName", ValueMember = "ProductName", DataSource = orderInfo.ProductDetails });

            //Event subscription
            this.sfDataGrid1.DrawCell += SfDataGrid1_DrawCell;
        }

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

        #endregion
    }
}
