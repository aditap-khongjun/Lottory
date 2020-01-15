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
    public partial class DetailNumberXXX : Form
    {
        private static DetailNumberXXX _instance;
        public static DetailNumberXXX Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DetailNumberXXX();
                return _instance;
            }
        }
        private void DetailNumberXXX_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
        public DetailNumberXXX()
        {
            InitializeComponent();
        }
        public void DataTableToFrom(DataTable dbTable)
        {
            int row = dbTable.Rows.Count;
            if(row <= 25)
            {
                for(int i = 0;i < row;i++)
                {
                    dgvNumber1.Rows.Add(dbTable.Rows[i][0], dbTable.Rows[i][1]);
                }
                // clear selection
                dgvNumber1.ClearSelection();
            }
            else if(row <= 50)
            {
                for(int i = 0;i < 25;i++)
                {
                    dgvNumber1.Rows.Add(dbTable.Rows[i][0], dbTable.Rows[i][1]);
                }
                int remain = row - 25;
                for(int i = 0;i < remain;i++)
                {
                    dgvNumber2.Rows.Add(dbTable.Rows[25 + i][0], dbTable.Rows[25 + i][1]);
                }

                // clear selection
                dgvNumber1.ClearSelection();
                dgvNumber2.ClearSelection();
            }
            else if(row <= 75)
            {
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber1.Rows.Add(dbTable.Rows[i][0], dbTable.Rows[i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber2.Rows.Add(dbTable.Rows[25 + i][0], dbTable.Rows[25 + i][1]);
                }
                int remain = row - 50;
                for (int i = 0; i < remain; i++)
                {
                    dgvNumber3.Rows.Add(dbTable.Rows[50 + i][0], dbTable.Rows[50 + i][1]);
                }

                // clear selection
                dgvNumber1.ClearSelection();
                dgvNumber2.ClearSelection();
                dgvNumber3.ClearSelection();
            }
            else if(row <= 100)
            {
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber1.Rows.Add(dbTable.Rows[i][0], dbTable.Rows[i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber2.Rows.Add(dbTable.Rows[25 + i][0], dbTable.Rows[25 + i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber3.Rows.Add(dbTable.Rows[50 + i][0], dbTable.Rows[50 + i][1]);
                }
                int remain = row - 75;
                for (int i = 0; i < remain; i++)
                {
                    dgvNumber4.Rows.Add(dbTable.Rows[75 + i][0], dbTable.Rows[75 + i][1]);
                }
                // clear selection
                dgvNumber1.ClearSelection();
                dgvNumber2.ClearSelection();
                dgvNumber3.ClearSelection();
                dgvNumber4.ClearSelection();
            }
            else
            {
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber1.Rows.Add(dbTable.Rows[i][0], dbTable.Rows[i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber2.Rows.Add(dbTable.Rows[25 + i][0], dbTable.Rows[25 + i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber3.Rows.Add(dbTable.Rows[50 + i][0], dbTable.Rows[50 + i][1]);
                }
                for (int i = 0; i < 25; i++)
                {
                    dgvNumber4.Rows.Add(dbTable.Rows[75 + i][0], dbTable.Rows[75 + i][1]);
                }
                int remain = row - 100;
                for (int i = 0; i < remain; i++)
                {
                    dgvNumber5.Rows.Add(dbTable.Rows[100 + i][0], dbTable.Rows[100 + i][1]);
                }
                // clear selection
                dgvNumber1.ClearSelection();
                dgvNumber2.ClearSelection();
                dgvNumber3.ClearSelection();
                dgvNumber4.ClearSelection();
                dgvNumber5.ClearSelection();
            }
        }


    }
}
