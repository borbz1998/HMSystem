using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;


namespace Grades
{
    public partial class Payment : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public Payment()
        {
            InitializeComponent();
            timer1.Start();
            getName();
            getName2();
            
        }
        int row = 1;
        private static int GetRow()
        {
            int row = 0;
            return row;
        }
        private void DrawHeader(Graphics g, ref int y_value)
        {
            int x_value = 0;
            Font bold = new Font(this.Font, FontStyle.Bold);

            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                g.DrawString(dc.HeaderText, bold, Brushes.Black, (float)x_value, (float)y_value);
                x_value += dc.Width + 5;
            }
        }
        private void DrawGridBody(Graphics g, int y_value)
        {
            int x_value;
            int i = 0;
            
            for ( i = 0; (i < dataGridView1.RowCount); ++i)
            {
                DataRow dr = ((DataTable)dataGridView1.DataSource).Rows[i + row];
                x_value = 0;

                // draw a solid line
                g.DrawLine(Pens.Black, new Point(0, y_value), new Point(this.Width, y_value));

                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {
                    string text = dr[dc.DataPropertyName].ToString();
                    g.DrawString(text, this.Font, Brushes.Black, (float)x_value, (float)y_value + 10f);
                    x_value += dc.Width + 5;
                }

                y_value += 40;
            }

            row += dataGridView1.RowCount;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            this.label8.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            timer1.Start();
            getName();
            getName2();
            transaction_tbl();
        }
        DataTable dtable;
        void transaction_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Prod_desc as ProductName,UnitPrice,Quantity,Price from transactiondetails where InvoiceNo='" + textBox7.Text + "'", condatabase);

            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView1.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                dataGridView1.Columns[0].Width = 400;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Cashier' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label22.Text = reader["AccountName"].ToString();
            reader.Read();
            label20.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (InvoiceNo) as InvoiceNo from transactions order by InvoiceNo desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox7.Text = reader["InvoiceNo"].ToString();
            //label27.Text = reader["InvoiceNo"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactions where InvoiceNo='" + textBox7.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("InvoiceNo");
                    string sname2 = myReader.GetInt32("NonVatTotal").ToString();
                    string sname3 = myReader.GetString("VatAmount");
                    string sname4 = myReader.GetString("TotalAmount");

                    
                    textBox7.Text = sname;
                    textBox1.Text = sname2;
                    textBox2.Text = sname3;
                    textBox3.Text = sname4;
                    label6.Text = sname4;
                    textBox1.Text = String.Format("{0:C}", double.Parse(textBox1.Text));
                    textBox2.Text = String.Format("{0:C}", double.Parse(textBox2.Text));
                    textBox3.Text = String.Format("{0:C}", double.Parse(textBox3.Text));

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();

            {
            }

            condatabase.Close();
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.PerformClick();
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox4.Text == "0")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please input the Cash");
                return;
            }

            double x = Convert.ToDouble(textBox4.Text);
            double y = Convert.ToDouble(label6.Text);
           
            if (x >= y)
            {
                double c = x - y;
                textBox5.Text = c.ToString();
                textBox5.Text = String.Format("{0:C}", double.Parse(textBox5.Text));
            }
            else if (x < y)
            {
                MessageBox.Show("The Cash Entered is Not Enough!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Text = "";
                textBox4.Text = "";
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.PerformClick();
            }
        }
        Bitmap bmp1;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            //DVprintPreviewDialog.ShowDialog();
            DVprintPreviewDialog.Document = DVprintDocument;
            DVprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            DVprintPreviewDialog.ShowDialog();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }

        private void DVprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            label8.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            textBox7.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 50, 25, 300, 100);
            //e.Graphics.DrawString("DOG SPA AND HOTEL" , new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(250,50));
            e.Graphics.DrawString("No:" , new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(550, 100));
            e.Graphics.DrawString(textBox7.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(600, 100));
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 16, FontStyle.Italic), Brushes.Black, new Point(550, 130));
            e.Graphics.DrawString(label8.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(600, 130));
            e.Graphics.DrawString("TO:", new Font("Times New Roman", 16, FontStyle.Italic), Brushes.Black, new Point(40, 180));
            e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(80, 180));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 220), new Point(780, 220));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 225), new Point(780, 225));
            //e.Graphics.DrawString(label7.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bmp1 = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bmp1, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            //dataGridView1.Height = height;
            //e.Graphics.DrawImage(bmp1, 90, 250);

            e.Graphics.DrawString("Product Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 230));
            e.Graphics.DrawString("Unit Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(400, 230));
            e.Graphics.DrawString("Quantity", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 230));
            e.Graphics.DrawString("Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(700, 230));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 225), new Point(780, 235));

           


            int x = 250 + (dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2) + 16;


            e.Graphics.DrawString("TOTAL:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(600, x));
            e.Graphics.DrawString(textBox3.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(700, x));

            e.Graphics.DrawString("CASH:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(600, x + 30));
            e.Graphics.DrawString(textBox3.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(700, x + 30));

            e.Graphics.DrawString("CHANGE:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(600, x + 60));
            e.Graphics.DrawString(textBox3.Text, new Font("Times New Roman", 16, FontStyle.Underline), Brushes.Black, new Point(700, x + 60));

            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 90), new Point(780, x + 90));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 95), new Point(780, x + 95));

            e.Graphics.DrawString("Approved for Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, x+100));
            e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(55 , x+120));
            e.Graphics.DrawString("Paid By:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(330, x + 100));
            e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(330, x + 120));
            e.Graphics.DrawString("Received Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(610, x + 100));
            e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(630, x + 120));

        }

        private void DVprintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Size size1 = new Size(100, 100);
            Size size2 = new Size(50, 50);
            Size sizet = Size.Add(size1, size2);
            PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(-50, -100),sizet));
           
            this.InvokePaint(dataGridView1, myPaintArgs);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = dataGridView1.RowCount.ToString();
            label10.Text = dataGridView1.RowTemplate.Height.ToString();

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void DVprintPreviewDialog_Load(object sender, EventArgs e)
        {

        }
    }
}