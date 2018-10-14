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
    public partial class WAIVER : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public WAIVER()
        {
            InitializeComponent();
            autocomplete();
            timer1.Start();
            serviceregistration();
            Sales_tbl();
            products_tbl();
            roomreservation();
            reserveprintDocument.DefaultPageSettings.Landscape = true;
            SVprintDocument.DefaultPageSettings.Landscape = true;

            this.dataGridView4.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView4.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView5.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView5.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView5.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        DataTable dtable;
        void Sales_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount  from Transactions ", condatabase);



            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView4.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                dataGridView4.Columns[3].DefaultCellStyle.Format = "C";
                dataGridView4.Columns[4].DefaultCellStyle.Format = "C";
                dataGridView4.Columns[5].DefaultCellStyle.Format = "C";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        void products_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products ", condatabase);



            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView5.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
               // dataGridView5.Columns[3].DefaultCellStyle.Format = "C";
                dataGridView5.Columns[4].DefaultCellStyle.Format = "C";
               // dataGridView5.Columns[5].DefaultCellStyle.Format = "C";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Receptionist' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label4.Text = reader["AccountName"].ToString();
            reader.Read();
            label3.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void ExportToExcel()
        {
           
                Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                try
                {

                    worksheet = workbook.ActiveSheet;

                    worksheet.Name = "Reports";

                    int cellRowIndex = 1;
                    int cellColumnIndex = 1;


                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {

                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            cellColumnIndex++;
                        }
                        cellColumnIndex = 1;
                        cellRowIndex++;
                    }


                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 1;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show(this, "Export Successful", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    excel.Quit();
                    workbook = null;
                    excel = null;
                }
            
        }
        private void ExportToExcel4()
        {

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Reports";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;


                for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView5.Columns.Count; j++)
                    {

                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView5.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView5.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }


                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(this, "Export Successful", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        private void ExportToExcel2()
        {

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Reports";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;


                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {

                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView2.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }


                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(this, "Export Successful", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }


        private void ExportToExcel3()
        {

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Reports";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;


                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView4.Columns.Count; j++)
                    {

                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView4.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView4.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }


                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(this, "Export Successful", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        void serviceregistration()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Customer_Name as CustomerName,Contact_Details as ContactNumber,Pet_Name as PetName,Breed,Service_desc as ServiceName,Service_Category,GroomerName,AccountName,TransactionDate from serviceregistration ", condatabase);

            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView2.DataSource = bsource;
                loaddb.Update(dtable);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void roomreservation()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Date_Reserved as DateReserved,Room_Name as RoomName,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,TimeArrival,No_Days as NumberofDays,AccountName from roomreservation ", condatabase);

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



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void autocomplete()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Customer";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Customer_Name");
                    coll.Add(sname);

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox2.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }

        private void DVprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("DOG SPA AND HOTEL WAIVER", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(230, 50));

            e.Graphics.DrawString("Owner's Name:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 150));
            e.Graphics.DrawString(textBox2.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(180, 150));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(183, 175), new Point(500, 175));
            e.Graphics.DrawString("Pet Name:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 180));
            e.Graphics.DrawString(textBox9.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(180, 180));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(183, 205), new Point(500, 205));
            e.Graphics.DrawString("Breed:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 210));
            e.Graphics.DrawString(textBox12.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(180, 210));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(183, 235), new Point(500, 235));
            e.Graphics.DrawString("Mobile No:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 240));
            e.Graphics.DrawString(textBox3.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(180, 240));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(183, 265), new Point(500, 265));
            e.Graphics.DrawString("Email:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 270));
            e.Graphics.DrawString(textBox4.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(180, 270));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(183, 295), new Point(500, 295));


            e.Graphics.DrawString("By Availing of Services of The Dog Spa and Hotel, the undersigned, ", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(100, 350));
            e.Graphics.DrawString("hereby absolves the The Dog Spa and Hotel from liability arising from any", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 380));
            e.Graphics.DrawString("accident not solely attributable to the Dog Spa and Hotel.", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 410));

            e.Graphics.DrawString("Signature", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(365, 500));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(250, 490), new Point(580, 490));

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 580), new Point(800, 580));


            e.Graphics.DrawString("DOG SPA AND HOTEL WAIVER", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new Point(230, 620));

            e.Graphics.DrawString("Name:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 700));
            e.Graphics.DrawString(textBox2.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(130, 700));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(133, 725), new Point(350, 725));
            e.Graphics.DrawString("Pet Name:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(500, 700));
            e.Graphics.DrawString(textBox9.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(600, 700));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(603, 725), new Point(750, 725));
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 730));
            e.Graphics.DrawString(label2.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(130, 730));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(133, 755), new Point(350, 755));


            e.Graphics.DrawString("I certify receipt of my pet in good condition and hereby acknowledge", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(100, 800));
            e.Graphics.DrawString("that the services availed have been duty provided. I hereby waive my claims", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 830));
            e.Graphics.DrawString("against THE DOG SPA with regard to the above mentioned services.", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(60, 860));

            e.Graphics.DrawString("Signature", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(365, 970));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(250, 960), new Point(580, 960));


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DVprintPreviewDialog.Document = DVprintDocument;
            DVprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            DVprintPreviewDialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = DVprintDocument;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                DVprintDocument.DocumentName = "Test Page Print";
                DVprintDocument.Print();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Customer where Customer_Name='" + textBox2.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Customer_Name");
                    string sname2 = myReader.GetInt32("Customer_ID").ToString();
                    string sname3 = myReader.GetString("Pet_Name");
                    string sname4 = myReader.GetString("Breed");
                    string sname5 = myReader.GetString("Contact_No");
                    string sname6 = myReader.GetString("Email_Address");

                    textBox1.Text = sname2;
                    textBox2.Text = sname;
                    textBox9.Text = sname3;
                    textBox12.Text = sname4;
                    textBox3.Text = sname5;
                    textBox4.Text = sname6;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            //this.label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            this.label2.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
            this.label13.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
        }

        private void FLYprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bmp = Properties.Resources.logo;
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 180, 25, newImage.Width, newImage.Height);
            e.Graphics.DrawString("Ground Floor, The Square, Lancaster New City, Cavite", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(170, 135));

            e.Graphics.DrawString("Expert Groom Package", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(40, 180));
            e.Graphics.DrawString("Small", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(330, 180));
            e.Graphics.DrawString("Medium", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(495, 180));
            e.Graphics.DrawString("Large", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(670, 180));
            e.Graphics.DrawString("Includes bath using Pup", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 210));
            e.Graphics.DrawString("Organics,blowdry,haircut,", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 240));
            e.Graphics.DrawString("organic ear cleaning,nail & paw ", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 270));
            e.Graphics.DrawString("trim,sanitary trim, powder", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 300));
            e.Graphics.DrawString("cologne & toothbrush", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 330));

            //prices
            e.Graphics.DrawString("PHP 500.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 270));
            e.Graphics.DrawString("PHP 650.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(485, 270));
            e.Graphics.DrawString("PHP 850.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 270));

            e.Graphics.DrawString("Groom Ala-Carte:", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(40, 410));

            //service name
            e.Graphics.DrawString("Bath & Blowdry", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 440));
            e.Graphics.DrawString("Anti-Tick and Flea Bath", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 470));
            e.Graphics.DrawString("Whitening Bath", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 500));
            e.Graphics.DrawString("Dog Hair Spa & Massage", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 530));
            e.Graphics.DrawString("Anal Sac Cleaning", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 560));
            e.Graphics.DrawString("Nail Trim", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 590));
            e.Graphics.DrawString("Ear Cleaning", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 620));
            e.Graphics.DrawString("Toothbrush", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 650));


            //prices
            e.Graphics.DrawString("PHP 250.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 440));
            e.Graphics.DrawString("PHP 250.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 470));
            e.Graphics.DrawString("PHP 250.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 500));
            e.Graphics.DrawString("PHP 250.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 530));
            e.Graphics.DrawString("PHP 100.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 560));
            e.Graphics.DrawString("PHP 100.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 590));
            e.Graphics.DrawString("PHP 100.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 620));
            e.Graphics.DrawString("PHP 100.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 650));

            e.Graphics.DrawString("PHP 450.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(485, 440));
            e.Graphics.DrawString("PHP 350.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(485, 470));
            e.Graphics.DrawString("PHP 350.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(485, 500));
            e.Graphics.DrawString("PHP 350.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(485, 530));

            e.Graphics.DrawString("PHP 650.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 440));
            e.Graphics.DrawString("PHP 450.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 470));
            e.Graphics.DrawString("PHP 450.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 500));
            e.Graphics.DrawString("PHP 450.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 530));
            //e.Graphics.DrawString("Mobile No:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 240));

            //e.Graphics.DrawString("Email:", new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(40, 270));

            e.Graphics.DrawString("Day Care:", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(40, 730));
            e.Graphics.DrawString("1 Hour", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 760));
            e.Graphics.DrawString("Succeeding Hour", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 790));

            //price
            e.Graphics.DrawString("PHP 100.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 760));
            e.Graphics.DrawString("PHP 50.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 790));


            e.Graphics.DrawString("Boarding:", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(40, 870));
            e.Graphics.DrawString("Regular Room", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(320, 870));
            e.Graphics.DrawString("Suites", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, new Point(600, 870));

            e.Graphics.DrawString("Overnight", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 900));
            e.Graphics.DrawString("5 Nights with free", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(100, 930));
            e.Graphics.DrawString("Bath & Blowdry", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(120, 960));

            e.Graphics.DrawString("PHP 450.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 900));
            e.Graphics.DrawString("PHP 400.00/per day", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(320, 930));

            e.Graphics.DrawString("PHP 800.00", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(600, 900));
            e.Graphics.DrawString("PHP 700.00/per day", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(600, 930));


            e.Graphics.DrawString("For Reservation, Orders and other inquiry please call or text ", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(170, 1050));
            e.Graphics.DrawString("0977-7492858 / 0956-9002912 / 0915-2717228", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(210, 1080));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = FLYprintDocument;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                FLYprintDocument.DocumentName = "Test Page Print";
                FLYprintDocument.Print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FLYprintPreviewDialog.Document = FLYprintDocument;
            FLYprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            FLYprintPreviewDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
      
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
       
        }

        private void dogFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sanitaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void healthToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treatsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DVprintPreviewDialog.Document = DVprintDocument;
            DVprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            DVprintPreviewDialog.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = DVprintDocument;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                DVprintDocument.DocumentName = "Test Page Print";
                DVprintDocument.Print();
            }
        }

        private void printPreviewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FLYprintPreviewDialog.Document = FLYprintDocument;
            FLYprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            FLYprintPreviewDialog.ShowDialog();
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = FLYprintDocument;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                FLYprintDocument.DocumentName = "Test Page Print";
                FLYprintDocument.Print();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WAIVER_Load(object sender, EventArgs e)
        {
            getName();
            roomreservation();
            serviceregistration();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            reserveprintDocument.DefaultPageSettings.Landscape = true;
            reservePreviewDialog.Document = reserveprintDocument;
            reservePreviewDialog.PrintPreviewControl.Zoom = 1;
            reservePreviewDialog.ShowDialog();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            ExportToExcel();
            //PrintDialog printDialog = new PrintDialog();
          
            //printDialog.Document = reserveprintDocument;
            //reserveprintDocument.DefaultPageSettings.Landscape = true;
            //printDialog.UseEXDialog = true;
            ////Get the document
            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //    reserveprintDocument.DocumentName = "Test Page Print";
            //    reserveprintDocument.Print();
            //}
        }

        private void reserveprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            reserveprintDocument.DefaultPageSettings.Landscape = true;
            //label8.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            //textBox7.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 40, 40, 300, 100);
            e.Graphics.DrawString("BOARDING RESERVATION SCHEDULE" , new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(350,50));
            e.Graphics.DrawString("Prepared By:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(800, 150));
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(40, 150));
            e.Graphics.DrawString(label4.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(900, 150));
            //e.Graphics.DrawString("Date of Issue", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString(label13.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(100, 150));
            //e.Graphics.DrawString("Billed To:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 140));
            //e.Graphics.DrawString(textBox23.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 170), new Point(1130, 170));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 175), new Point(1130, 175));

            e.Graphics.DrawRectangle(Pens.Black, 40, 180, 1090, 22);
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(40, 181, 1090, 21));
            e.Graphics.DrawString("DateReserved", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(40, 180));
            e.Graphics.DrawString("Time", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(220, 180));
            //e.Graphics.DrawString("Room Name", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(320, 180));
            e.Graphics.DrawString("Customer Name", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(370, 180));
            e.Graphics.DrawString("Pet Name", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(600, 180));
            e.Graphics.DrawString("Breed", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(800, 180));
            e.Graphics.DrawString("Contact Details", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(1000, 180));
           
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 180), new Point(790, 180));
            //e.Graphics.DrawString("09777492858", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 40));
            //e.Graphics.DrawString("DogSpaPhilippines@yahoo.com", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 80));
            //e.Graphics.DrawString("Invoice Total", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(600, 140));
            ////e.Graphics.DrawString(textBox22.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(600, 160));
            //e.Graphics.DrawString("Unit 101-C Lancaster The ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 40));
            //e.Graphics.DrawString("Square, Alapan II-B,Imus, ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 60));
            //e.Graphics.DrawString("Cavite,Philippines,4103", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 80));
            ////e.Graphics.DrawString(label7.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));


            int yPos = 210;
         

            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                string DateReserved = Convert.ToString(i.Cells[0].Value);
                string TimeArrival = Convert.ToString(i.Cells[6].Value);
                string RoomName = Convert.ToString(i.Cells[1].Value);
                string CustomerName = Convert.ToString(i.Cells[2].Value);
                string PetName = Convert.ToString(i.Cells[3].Value);
                string Breed = Convert.ToString(i.Cells[4].Value);
                string ContactDetails  = Convert.ToString(i.Cells[5].Value);
               

                //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawString(DateReserved, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawString(TimeArrival.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(220, yPos));
                e.Graphics.DrawString(RoomName.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(250, yPos));
                e.Graphics.DrawString(CustomerName.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, yPos));
                e.Graphics.DrawString(PetName.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos));
                e.Graphics.DrawString(Breed.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(800, yPos));
                e.Graphics.DrawString(ContactDetails.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(1000, yPos));
                //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                yPos += 25;
            }
           // reserveprintDocument.DefaultPageSettings.Landscape = true;



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SVprintDocument.DefaultPageSettings.Landscape = true;
            SVprintPreviewDialog.Document = SVprintDocument;
            SVprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            SVprintPreviewDialog.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ExportToExcel2();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ExportToExcel3();
        }

        private void SVprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            //label8.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            //textBox7.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 40, 40, 300, 100);
            e.Graphics.DrawString("SERVICE REGISTRATION", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(450, 50));
            e.Graphics.DrawString("Prepared By:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(800, 150));
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(40, 150));
            e.Graphics.DrawString(label4.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(900, 150));
            //e.Graphics.DrawString("Date of Issue", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString(label13.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(100, 150));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 170), new Point(1130, 170));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 175), new Point(1130, 175));

            e.Graphics.DrawRectangle(Pens.Black, 40, 180, 1090, 22);
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(40, 181, 1090, 21));
            e.Graphics.DrawString("CustomerName", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(40, 180));
            e.Graphics.DrawString("ContactNo", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(200, 180));
            e.Graphics.DrawString("PetName", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(350, 180));
            e.Graphics.DrawString("Breed", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(450, 180));
            e.Graphics.DrawString("ServiceDesc", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(620, 180));
            e.Graphics.DrawString("GroomerName", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(920, 180));
            //e.Graphics.DrawString("TimeArrival", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(850, 180));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 180), new Point(790, 180));
         
            int yPos = 210;



            foreach (DataGridViewRow i in dataGridView2.Rows)
            {
                string CustomerName = Convert.ToString(i.Cells[0].Value);
                string ContactNo = Convert.ToString(i.Cells[1].Value);
                string PetName = Convert.ToString(i.Cells[2].Value);
                string Breed = Convert.ToString(i.Cells[3].Value);
                string ServiceDesc = Convert.ToString(i.Cells[4].Value);
               // string GroomerName = Convert.ToString(i.Cells[5].Value);
                string GroomerName = Convert.ToString(i.Cells[6].Value);

                //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawString(CustomerName, new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawString(ContactNo.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(200, yPos));
                e.Graphics.DrawString(PetName.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(350, yPos));
                e.Graphics.DrawString(Breed.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(450, yPos));
                e.Graphics.DrawString(ServiceDesc.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(620, yPos));
                //e.Graphics.DrawString(GroomerName.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(750, yPos));
                e.Graphics.DrawString(GroomerName.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(920, yPos));
                //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                yPos += 25;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = reserveprintDocument;
            reserveprintDocument.DefaultPageSettings.Landscape = true;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                reserveprintDocument.DocumentName = "Reservation List";
                reserveprintDocument.Print();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = SVprintDocument;
            SVprintDocument.DefaultPageSettings.Landscape = true;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                SVprintDocument.DocumentName = "Service Registration";
                SVprintDocument.Print();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == dateTimePicker2.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Date_Reserved as DateReserved,Room_Name as RoomName,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,TimeArrival,No_Days as NumberofDays,AccountName from  roomreservation where Date_Reserved='" + dateTimePicker1.Text + "' AND  Date_Reserved= '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Date_Reserved as DateReserved,Room_Name as RoomName,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,TimeArrival,No_Days as NumberofDays,AccountName from  roomreservation where Date_Reserved>='" + dateTimePicker1.Text + "' AND  Date_Reserved<= '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == dateTimePicker2.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Date_Reserved as DateReserved,Room_Name as RoomName,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,TimeArrival,No_Days as NumberofDays,AccountName from  roomreservation where Date_Reserved='" + dateTimePicker1.Text + "' AND  Date_Reserved= '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Date_Reserved as DateReserved,Room_Name as RoomName,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,TimeArrival,No_Days as NumberofDays,AccountName from  roomreservation where Date_Reserved>='" + dateTimePicker1.Text + "' AND  Date_Reserved<= '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            roomreservation();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == dateTimePicker2.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Customer_Name as CustomerName,Contact_Details as ContactNumber,Pet_Name as PetName,Breed,Service_desc as ServiceName,Service_Category,GroomerName,AccountName,TransactionDate from serviceregistration where TransactionDate='" + dateTimePicker4.Text + "' AND  TransactionDate= '" + dateTimePicker3.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView2.DataSource = bsource;
                    loaddb.Update(dtable);
                    // dataGridView3.Rows[0].Cells[0].Value = false;




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Customer_Name as CustomerName,Contact_Details as ContactNumber,Pet_Name as PetName,Breed,Service_desc as ServiceName,Service_Category,GroomerName,AccountName,TransactionDate from serviceregistration where TransactionDate='" + dateTimePicker4.Text + "' AND  TransactionDate= '" + dateTimePicker3.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView2.DataSource = bsource;
                    loaddb.Update(dtable);
                    // dataGridView3.Rows[0].Cells[0].Value = false;




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            serviceregistration();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {

            SalesprintDocument.DefaultPageSettings.Landscape = true;
            SalesprintPreviewDialog.Document = SalesprintDocument;
            SalesprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            SalesprintPreviewDialog.ShowDialog();
        }

        private void SalesprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //label8.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            //textBox7.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 40, 40, 300, 100);
            e.Graphics.DrawString("SALES REPORT", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(450, 50));
            e.Graphics.DrawString("Prepared By:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(800, 150));
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(40, 150));
            e.Graphics.DrawString(label4.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(900, 150));
            //e.Graphics.DrawString("Date of Issue", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString(label13.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(100, 150));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 170), new Point(1130, 170));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 175), new Point(1130, 175));

            e.Graphics.DrawRectangle(Pens.Black, 40, 180, 1090, 22);
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(40, 181, 1090, 21));
            e.Graphics.DrawString("InvoiceNo", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(40, 180));
            e.Graphics.DrawString("TransactionDate", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(200, 180));
            e.Graphics.DrawString("TransactionTime", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(380, 180));
            e.Graphics.DrawString("NonVatTotal(PHP)", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(550, 180));
            e.Graphics.DrawString("VatAmount(PHP)", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(750, 180));
            e.Graphics.DrawString("TotalAmount(PHP)", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.White, new Point(930, 180));
            //e.Graphics.DrawString("TimeArrival", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(850, 180));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 180), new Point(790, 180));

            int yPos = 210;



            foreach (DataGridViewRow i in dataGridView4.Rows)
            {

                if (Convert.ToString(i.Cells[3].Value) != "")// Or your condition 
                {
                    string CustomerName = Convert.ToString(i.Cells[0].Value);
                    string ContactNo = Convert.ToString(i.Cells[1].Value);
                    string PetName = Convert.ToString(i.Cells[2].Value);
                    string Breed = Convert.ToString(i.Cells[3].Value);
                    string ServiceDesc = Convert.ToString(i.Cells[4].Value);
                    // string GroomerName = Convert.ToString(i.Cells[5].Value);
                    string GroomerName = Convert.ToString(i.Cells[5].Value);



                    //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                    e.Graphics.DrawString(CustomerName, new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                    e.Graphics.DrawString(ContactNo.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(200, yPos));
                    e.Graphics.DrawString(PetName.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(380, yPos));
                    e.Graphics.DrawString("PHP " + Breed.ToString() + ".00", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(550, yPos));
                    e.Graphics.DrawString("PHP " + ServiceDesc.ToString() + ".00", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(750, yPos));
                    //e.Graphics.DrawString(GroomerName.ToString(), new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(750, yPos));
                    e.Graphics.DrawString("PHP " + GroomerName.ToString() + ".00", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(930, yPos));
                    //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                    yPos += 25;
                }
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
 
            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = reserveprintDocument;
            SalesprintDocument.DefaultPageSettings.Landscape = true;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                SalesprintDocument.DocumentName = "Reservation List";
                SalesprintDocument.Print();
            }
        
    }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Sales_tbl();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            ExportToExcel3();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            ExportToExcel4();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        //private void simpleButton5_Click(object sender, EventArgs e)
        //{

        //}
    }
    }
