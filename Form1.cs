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

        private void button1_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox1.Text);
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = N;
            dataGridView1.RowCount = N;
            dataGridView2.RowCount = N;
            dataGridView2.ColumnCount = 1;
            dataGridView3.RowCount = N;
            dataGridView3.ColumnCount = N;
            dataGridView4.RowCount = N;
            dataGridView4.ColumnCount = 1;
            dataGridView5.RowCount = N;
            dataGridView5.ColumnCount = 1;
            for (int i = 0; i < N; i++)
            {

                for (int j = 0; j < (N); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 1;
                    dataGridView2.Rows[i].Cells[0].Value = 2;
                }

            }
        }
         
        bool Cheker()
        {
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 1;
            double EPS = Convert.ToDouble(textBox3.Text);
            int N = Convert.ToInt32(textBox1.Text);
            double[,] A = new double[N, N];
            double[,] Alpha = new double[N, N];
            double[] Beta = new double[N];
            double[] B = new double[N];
            double[] data5 = new double[N]; //datagridview5
            double[] TempX = new double[N];
            double[] TempX_Zeid = new double[N];
            double s = 66;

            for (int i = 0; i < N; i++)
            {

                for (int j = 0; j < (N); j++)
                {
                    A[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            for (int i = 0; i < N; i++)
            {
                B[i] = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 0; i < N; i++)
            {
                Beta[i] = B[i] / A[i, i];
                dataGridView4.Rows[i].Cells[0].Value = Beta[i];
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        Alpha[i, j] = 0;
                        dataGridView3.Rows[i].Cells[j].Value = Alpha[i, j];
                    }
                    else
                    {
                        Alpha[i, j] = -1 * A[i, j] / A[i, i];
                        dataGridView3.Rows[i].Cells[j].Value = Alpha[i, j];
                    }
                }
            }
          /*  for (int i = 0; i < N; i++)
            {
                dataGridView5.Rows[i].Cells[0].Value = Beta[i];
                data5[i] = Beta[i];
               // TempX[i] = data5[i];
            }*/
            for (int i = 0; i < N; i++)
            {
                TempX_Zeid[i] = data5[i];
                data5[i] = 0;
                for (int j = 0; j < N; j++)
                {
                    data5[i] = data5[i] + Alpha[i, j] * TempX[j];
                }
                data5[i] = Beta[i] + data5[i];
                TempX[i] = data5[i];
            }
               while(s>EPS)
                {
                    for(int i = 0;i<N;i++)
                    {
                        TempX_Zeid[i] = data5[i];
                        data5[i] = 0;
                        for(int j=0; j<N;j++)
                        {
                            data5[i] = data5[i] + Alpha[i, j] * TempX[j];
                        }
                        data5[i] = Beta[i] + data5[i];
                        TempX[i] = data5[i];
                        dataGridView5.Rows[i].Cells[0].Value = data5[i];
                }
                k++;
                double sum = 0;
                for (int i = 0; i < N; i++)
                {
                    sum += (data5[i] - TempX_Zeid[i]) * (data5[i] - TempX_Zeid[i]);
                }
                s = Math.Sqrt(sum);
            }
            textBox2.Text = "" + k;
        }


        private void button3_Click(object sender, EventArgs e)  //итерации
        {
            int k = 1;
            double EPS = Convert.ToDouble(textBox3.Text);
            int N = Convert.ToInt32(textBox1.Text);
            double[,] A = new double[N, N];
            double[,] Alpha = new double[N, N];
            double[] Beta = new double[N];
            double[] B = new double[N];
            double[] data5 = new double[N]; //datagridview5
            double[] TempX = new double[N];
            double s = 66;

            for (int i = 0; i < N; i++)
            {

                for (int j = 0; j < (N); j++)
                {
                    A[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            for (int i = 0; i < N; i++)
            {
                B[i] = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }

            for (int i = 0; i < N; i++)
            {
                Beta[i] = B[i] / A[i, i];
                dataGridView4.Rows[i].Cells[0].Value = Beta[i];
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        Alpha[i, j] = 0;
                        dataGridView3.Rows[i].Cells[j].Value = Alpha[i, j];
                    }
                    else
                    {
                        Alpha[i, j] = -1 * A[i, j] / A[i, i];
                        dataGridView3.Rows[i].Cells[j].Value = Alpha[i, j];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                dataGridView5.Rows[i].Cells[0].Value = Beta[i];
                data5[i] = Beta[i];
            }

            //до сих верно

            while(s>EPS)//условие остановки заработало
          {
              for(int i = 0;i<N;i++)
              {
                  TempX[i] = data5[i];
              }
              for(int i = 0;i<N;i++)
              {
                  data5[i] = 0;
                  for(int j=0;j<N;j++)
                  {
                      data5[i] = data5[i] + Alpha[i, j] * TempX[j]; //все верно работает
                  }
                  data5[i] = Beta[i] + data5[i];
                  dataGridView5.Rows[i].Cells[0].Value = data5[i];
              }
              k++;
              double sum = 0;
              for(int i = 0; i<N;i++)
              {
                  sum += (data5[i] - TempX[i])*(data5[i] - TempX[i]); 
              }
              s = Math.Sqrt(sum);
           }
              textBox2.Text = "" + k;
          }
        }
    }

