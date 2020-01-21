using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottory
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            // Example 1 : fill cell by element
            //object[][] data = new object[][]{
            //new object[] {"kjslwe", 3, "w", 45, "erer", 643, "reew", "54", 56, 34},
            //new object [] {23, "e", 1, "so", 123213, "ds", 343433}
            //   };
            
            //   var columns = data.Max(x => x.Count());
            DataTable dt = new DataTable();
            dt.Columns.Add("Number");
            dt.Columns.Add("Price");
            dt.Columns["Price"].DataType = Type.GetType("System.Int32");
            dt.Rows.Add("111", 1);
            dt.Rows.Add("222", 2);
            dt.Rows.Add("333", 3);
            dt.Rows.Add("444", 4);
            dt.Rows.Add("555", 5);
            dt.Rows.Add("666", 6);
            dt.Rows.Add("777", 6);
            dt.Rows.Add("888", 7);
            dt.Rows.Add("999", 8);
            dt.Rows.Add("000", 9);
            dt.Rows.Add("xxx", 10);
            dt.Rows.Add("555", 11);
            dt.Rows.Add("666", 12);
            dt.Rows.Add("777", 13);
            dt.Rows.Add("888", 14);
            dt.Rows.Add("999", 15);
            dt.Rows.Add("000", 16);
            dt.Rows.Add("xxx", 17);

            //dt.DefaultView.Sort
            int row = Convert.ToInt32(dt.Rows.Count / 4);

            int col = 5;
            dataGridView1.ColumnCount = col;
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 80;
            }
            //data.ToList().ForEach(x => dataGridView1.Rows.Add(x));
            //MessageBox.Show("Type of data = " + data.Max();
            int i = 0;
            int j = 0;
            string[] data = new string[col];
            for (int idx = 0; idx < dt.Rows.Count; idx++)
            {
                data[i] = string.Format("บน{0} = {1}",dt.Rows[idx][0].ToString(),dt.Rows[idx][1].ToString());
                i++;
                if (i > col-1)
                {
                    i = 0;
                    j++;

                    dataGridView1.Rows.Add(data);
                    data = new string[col];
                }
                if(idx == dt.Rows.Count - 1)
                {
                    dataGridView1.Rows.Add(data);
                }
            }
            //foreach(var x in data.ToList())
            //{

                //MessageBox.Show(string.Join(",",x));
                //dataGridView1.Rows.Add(x);
            //}
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.AllowUserToDeleteRows = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            //*/

            //PopulateDataGridView();
            //InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            /*
            // Initialize basic DataGridView properties.
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

            // Set property values appropriate for read-only display and 
            // limited interactivity. 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows. 
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            // Set the row and column header styles.
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the Format property on the "Last Prepared" column to cause
            // the DateTime to be formatted as "Month, Year".
            dataGridView1.Columns["Last Prepared"].DefaultCellStyle.Format = "y";

            // Specify a larger font for the "Ratings" column. 
            using (Font font = new Font(
                dataGridView1.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold))
            {
                dataGridView1.Columns["Rating"].DefaultCellStyle.Font = font;
            }
            */
            // Attach a handler to the CellFormatting event.
            dataGridView1.CellFormatting += new
                DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }
        // Changes the foreground color of cells in the "Ratings" column 
        // depending on the number of stars. 
        private void dataGridView1_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Rating"].Index
                && e.Value != null)
            {
                switch (e.Value.ToString().Length)
                {
                    case 1:
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case 2:
                        e.CellStyle.SelectionForeColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Yellow;
                        break;
                    case 3:
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case 4:
                        e.CellStyle.SelectionForeColor = Color.Blue;
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                }
            }
        }
        private void PopulateDataGridView()
        {
            // Set the column header names.
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Recipe";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "Main Ingredients";
            dataGridView1.Columns[3].Name = "Last Prepared";
            dataGridView1.Columns[4].Name = "Rating";

            // Populate the rows.
            object[] row1 = new object[]{"Meatloaf", "Main Dish",
            "ground beef", new DateTime(2000, 3, 23), "*"};
            object[] row2 = new object[]{"Key Lime Pie", "Dessert",
            "lime juice, evaporated milk", new DateTime(2002, 4, 12), "****"};
            object[] row3 = new object[]{"Orange-Salsa Pork Chops", "Main Dish",
            "pork chops, salsa, orange juice", new DateTime(2000, 8, 9), "****"};
            object[] row4 = new object[]{"Black Bean and Rice Salad", "Salad",
            "black beans, brown rice", new DateTime(1999, 5, 7), "****"};
            object[] row5 = new object[]{"Chocolate Cheesecake", "Dessert",
            "cream cheese", new DateTime(2003, 3, 12), "***"};
            object[] row6 = new object[]{"Black Bean Dip", "Appetizer",
            "black beans, sour cream", new DateTime(2003, 12, 23), "***"};

            // Add the rows to the DataGridView.
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };
            foreach (object[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }

            // Adjust the row heights so that all content is visible.
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
