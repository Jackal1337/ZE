using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool check(double EPS, DataGridView data)
        {
            double sum =0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sum +=(Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString()) - Convert.ToDouble(data.Rows[i].Cells[0].Value.ToString())) * (Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString()) - Convert.ToDouble(data.Rows[i].Cells[0].Value.ToString()));
            }
            if(Math.Sqrt(sum)<EPS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        double fix(int i, int j)
        {
            return Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value.ToString());
        }
        private void button2_Click(object sender, EventArgs e) //Simple 
        {
            int k = 1;
            double EPS = 0.001;// Convert.ToDouble(textBox2.Text);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = fix(i, dataGridView1.RowCount) / fix(i, i); //B
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (j == i)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = 0;   //А
                    }
                    else
                    {
                        dataGridView3.Rows[i].Cells[j].Value = -1 * Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value.ToString()) / Convert.ToDouble(dataGridView1.Rows[i].Cells[i].Value.ToString());//А
                    }
                }
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = dataGridView4.Rows[i].Cells[0].Value;
            }
            while (!check(EPS, dataGridView5))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView5.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value;
                }
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = 0;
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString()) + (Convert.ToDouble(dataGridView3.Rows[i].Cells[j].Value.ToString()) * Convert.ToDouble(dataGridView5.Rows[j].Cells[0].Value.ToString()));
                    }
                    dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
                }
                k++;
            }
            textBox3.Text = k + "";


        }

        private void button1_Click(object sender, EventArgs e)  // Create
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView1.RowCount = Convert.ToInt32(textBox1.Text);
            dataGridView1.ColumnCount = dataGridView1.RowCount + 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Red;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                }
            }
            dataGridView2.RowCount = dataGridView1.RowCount;
            dataGridView3.RowCount = dataGridView1.RowCount;
            dataGridView3.ColumnCount = dataGridView1.RowCount;
            dataGridView4.RowCount = dataGridView1.RowCount;
            dataGridView5.RowCount = dataGridView1.RowCount;
            dataGridView6.RowCount = dataGridView1.RowCount;
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = 0;
                dataGridView5.Rows[i].Cells[0].Value = 0;
                dataGridView6.Rows[i].Cells[0].Value = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e) //ZE
        {
            int k = 1;
            double EPS = 0.001;// Convert.ToDouble(textBox2.Text);
            for (int i = 0; i < dataGridView1.RowCount;i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = fix(i, dataGridView1.RowCount) / fix(i, i); //B
                for (int j = 0; j< dataGridView1.RowCount; j++)
                {
                    if(j==i)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = 0;   //А
                    }
                    else
                    {
                        dataGridView3.Rows[i].Cells[j].Value = -1 * Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value.ToString()) / Convert.ToDouble(dataGridView1.Rows[i].Cells[i].Value.ToString());//А
                    }
                }
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView6.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value;
                dataGridView2.Rows[i].Cells[0].Value = 0;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString()) + (Convert.ToDouble(dataGridView3.Rows[i].Cells[j].Value.ToString()) * Convert.ToDouble(dataGridView5.Rows[j].Cells[0].Value.ToString()));
                }
                dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
                dataGridView5.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value;
            }
            while(!check(EPS,dataGridView6))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView6.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value;
                    dataGridView2.Rows[i].Cells[0].Value = 0;
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString()) + (Convert.ToDouble(dataGridView3.Rows[i].Cells[j].Value.ToString()) * Convert.ToDouble(dataGridView5.Rows[j].Cells[0].Value.ToString()));
                    }
                    dataGridView2.Rows[i].Cells[0].Value = Convert.ToDouble(dataGridView4.Rows[i].Cells[0].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    dataGridView5.Rows[i].Cells[0].Value = dataGridView2.Rows[i].Cells[0].Value;
                }
                k++;
                
            }
            textBox3.Text = k + "";
        }
    }
}
