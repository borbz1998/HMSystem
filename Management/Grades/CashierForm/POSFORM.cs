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
using System.Data.SqlClient;

namespace Grades
{

    public partial class POSFORM : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public POSFORM()
        {
            InitializeComponent();
            product_tbl();
            transaction_tbl();
            Products_tbll();
            timer2.Start();
            getName1();
            getName2();
            getName();
            ReturnItem_tbl();
            autocomplete();
            autocomplete2();
            //fillcombo();
            TAX_tbl();
            Sales_tbl();
            getName4();
            fillcombo2();


            this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;


            this.dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView3.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView3.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView4.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView4.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView4.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView6.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView6.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView6.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridView7.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView7.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView7.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        
        }
        DataTable dtable;
        private List<AddToCart> shoppingcart = new List<AddToCart>();
        string vatxxx;
        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select Distinct InvoiceNo from TransactionDetails";

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
                    comboBox1.Items.Add(sname);
                   
                }
                condatabase.Close();


                //condatabase.Open();

                //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                //newquery.ExecuteNonQuery();

                //account_tbl();
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();
            //string activity = "Delete Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }

            condatabase.Close();
        }
        void fillcombo2()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string x = "Products";

            string Query = "Select InvoiceNo from Transactions where TransactionType='" + x + "' ;";

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
                    comboBox5.Items.Add(sname);

                }
               // condatabase.Close();


                //condatabase.Open();

                //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                //newquery.ExecuteNonQuery();

                //account_tbl();
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //condatabase.Open();
            //string activity = "Delete Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }

            condatabase.Close();
        }
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=Management;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();


            }
            catch (MySqlException)
            {
                throw;
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
            label18.Text = reader["AccountName"].ToString();
            reader.Read();
            label28.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (InvoiceNo + 1) as InvoiceNo from transactions order by InvoiceNo desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox17.Text = reader["InvoiceNo"].ToString();
            //label27.Text = reader["InvoiceNo"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName4()
        {
           
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select VatPercent from vatsetting ;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            vatxxx = reader["VatPercent"].ToString();
            //label27.Text = reader["InvoiceNo"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (InvoiceNo + 1) as InvoiceNo from transactiondetails order by InvoiceNo desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox6.Text = reader["InvoiceNo"].ToString();
            comboBox1.Text = reader["InvoiceNo"].ToString();
            
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            panel3.Visible = true;
        //    panel4.Visible = false;
            panel2.Visible = false;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
         //   panel4.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
         //   panel4.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            autocomplete();
        }
        void autocomplete()
        {
            textBox30.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox30.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactiondetails";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Prod_desc");
                    coll.Add(sname);

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox30.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }
        void autocomplete2()
        {
            textBox31.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox31.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactions";

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
                    coll.Add(sname);

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox31.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }
        void product_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID ,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price,Discount from Products ", condatabase);

            //MySqlDataAdapter loaddb = new MySqlDataAdapter();
            //loaddb.SelectCommand = cmddatabase;
            //dtable = new DataTable();
            //loaddb.Fill(dtable);
            //dataGridView3.Rows.Clear();
            
            // foreach (DataRow item in dtable.Rows)
            // {
            //    int n = dataGridView3.Rows.Add();
            //    dataGridView3.Rows[n].Cells[0].Value = false;
            //   dataGridView3.Rows[n].Cells[1].Value = item["Product_ID"].ToString();
            //   dataGridView3.Rows[n].Cells[2].Value = item["Prod_desc"].ToString();
            //    dataGridView3.Rows[n].Cells[3].Value = item["Quantity"].ToString();
            //    dataGridView3.Rows[n].Cells[4].Value = item["Price"].ToString();
            //}

            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                ProductClick.Location = new Point(300, 200);
                dataGridView3.Columns[4].DefaultCellStyle.Format = "C";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void TAX_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select TDate,InvoiceNo,VatAmount from TAXRECORD ", condatabase);

           

            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView6.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                //ProductClick.Location = new Point(300, 200);
                dataGridView6.Columns[2].DefaultCellStyle.Format = "C";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
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
        void Products_tbll()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID ,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price,Discount from Products ", condatabase);

            //MySqlDataAdapter loaddb = new MySqlDataAdapter();
            //loaddb.SelectCommand = cmddatabase;
            //dtable = new DataTable();
            //loaddb.Fill(dtable);
            //dataGridView3.Rows.Clear();
           
            // foreach (DataRow item in dtable.Rows)
            // {
            //    int n = dataGridView3.Rows.Add();
            //    dataGridView3.Rows[n].Cells[0].Value = false;
            //   dataGridView3.Rows[n].Cells[1].Value = item["Product_ID"].ToString();
            //   dataGridView3.Rows[n].Cells[2].Value = item["Prod_desc"].ToString();
            //    dataGridView3.Rows[n].Cells[3].Value = item["Quantity"].ToString();
            //    dataGridView3.Rows[n].Cells[4].Value = item["Price"].ToString();
            //}

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
                dataGridView1.Columns[4].DefaultCellStyle.Format = "C";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void ReturnItem_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID ,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price, return_date as ReturnDate from ReturnItem ", condatabase);


            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView7.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                dataGridView7.Columns[4].DefaultCellStyle.Format = "C";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void transaction_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID, Prod_desc as ProductName,UnitPrice,Quantity,Price as 'Price (PHP)',Discount as 'Discount(%)'  from transactiondetails where InvoiceNo='" + textBox6.Text + "'", condatabase);

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
                dataGridView2.Columns[4].DefaultCellStyle.Format = "C";
                
                //dataGridView2.Columns[4].DefaultCellStyle.FormatProvider = CultureInfoConverter.ReferenceEquals("en-Ph");
                double sum = 0;
                double x = Convert.ToDouble(vatxxx);
                double vat = 0;
                double nonvat = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                    vat = (sum * x);
                    nonvat = sum - vat;


                }
                label23.Text = sum.ToString();
                label15.Text = sum.ToString();
                label15.Text = String.Format("{0:C}", double.Parse(label15.Text));
                label24.Text = vat.ToString();
                label14.Text = vat.ToString();
                label14.Text = String.Format("{0:C}", double.Parse(label14.Text));


                
                label31.Text = nonvat.ToString();
                label31.Text = String.Format("{0:C}", double.Parse(label31.Text));

                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

            string ids = textBox1.Text;
            string desc = textBox2.Text;
            string quantity = textBox3.Text;


            if (quantity == "0" || quantity == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
                return;
            }

            string price = textBox4.Text;
            string invoice = textBox6.Text;
            string dis = textBox16.Text;
            int quan = Convert.ToInt32(textBox3.Text);
            int resquan = Convert.ToInt32(label16.Text);
            int x = 0;
            double y = 0;
            double z = 0;
            double disss = Convert.ToDouble(textBox16.Text);
            double disfinal = 0;
            double tt = 0;
            double disprice = 0;

            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || quantity == "" || price == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
           

            if (disss == 0)
            {
                z = Convert.ToDouble(price);


                x = resquan - quan;

                if (x <= 0)
                {
                    textBox3.Text = "0";
                    DevExpress.XtraEditors.XtraMessageBox.Show("Our Stocks for that Item cannot fulfill your Order");
                    return;
                }
                y = quan * z;
                string prices = y.ToString();
                string newquan = x.ToString();

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                gsdb.Server = "localhost";
                gsdb.UserID = "root";
                gsdb.Password = "";
                gsdb.Database = "Management";
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                connection.Open();
                string newuser_sql = "INSERT INTO transactiondetails (InvoiceNo,Product_ID,Prod_desc,UnitPrice,Quantity,Price,Discount) VALUES (@InvoiceNo,@Product_ID, @Prod_desc,@UnitPrice, @Quantity,@Price, @Discount)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@InvoiceNo", invoice);
                newuser.Parameters.AddWithValue("@Product_ID", ids);
                newuser.Parameters.AddWithValue("@Prod_desc", desc);
                newuser.Parameters.AddWithValue("@UnitPrice", z);
                newuser.Parameters.AddWithValue("@Quantity", quantity);
                newuser.Parameters.AddWithValue("@Price", y);
                newuser.Parameters.AddWithValue("@Discount", dis);

                AddToCart itemss = new AddToCart()
                {
                    ProductID = ids,
                    ProductName = desc,
                    UnitPrice = Convert.ToDecimal(price),
                    Quantity = Convert.ToInt32(quantity),
                    Price = Convert.ToDecimal(y),
                    Discount = Convert.ToInt32(dis),
                };
                shoppingcart.Add(itemss);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = shoppingcart;



                newuser.ExecuteNonQuery();



                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                string query1 = "update Management.Products set Quantity='" + newquan + "'where Product_ID='" + ids + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                //getName();
                newquery.ExecuteNonQuery();




                product_tbl();
                transaction_tbl();
                connection.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "0";
                ProductClick.Visible = false;
                simpleButton1.Enabled = true;
            }
            if (disss != 0)
            {
                x = resquan - quan;

                if (x <= 0)
                {
                    textBox3.Text = "0";
                    DevExpress.XtraEditors.XtraMessageBox.Show("Our Stocks for that Item cannot fulfill your Order");
                    return;
                }
                z = Convert.ToDouble(price);
                disfinal = disss / 100;
                tt = z * disfinal;
                disprice = z - tt;
                y = quan * disprice;


                x = resquan - quan;
                
                string prices = y.ToString();
                string newquan = x.ToString();

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                gsdb.Server = "localhost";
                gsdb.UserID = "root";
                gsdb.Password = "";
                gsdb.Database = "Management";
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                connection.Open();
                string newuser_sql = "INSERT INTO transactiondetails (InvoiceNo,Product_ID,Prod_desc,UnitPrice,Quantity,Price,Discount) VALUES (@InvoiceNo,@Product_ID, @Prod_desc,@UnitPrice, @Quantity,@Price, @Discount)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@InvoiceNo", invoice);
                newuser.Parameters.AddWithValue("@Product_ID", ids);
                newuser.Parameters.AddWithValue("@Prod_desc", desc);
                newuser.Parameters.AddWithValue("@UnitPrice", z);
                newuser.Parameters.AddWithValue("@Quantity", quantity);
                newuser.Parameters.AddWithValue("@Price", y);
                newuser.Parameters.AddWithValue("@Discount", dis);

                AddToCart itemss = new AddToCart()
                {
                    ProductID = ids,
                    ProductName = desc,
                    UnitPrice = Convert.ToDecimal(price),
                    Quantity = Convert.ToInt32(quantity),
                    Price = Convert.ToDecimal(y),
                    Discount = Convert.ToInt32(dis),
                };
                shoppingcart.Add(itemss);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = shoppingcart;



                newuser.ExecuteNonQuery();



                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                string query1 = "update Management.Products set Quantity='" + newquan + "'where Product_ID='" + ids + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                //getName();
                newquery.ExecuteNonQuery();




                product_tbl();
                transaction_tbl();
                connection.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "0";
                ProductClick.Visible = false;
                simpleButton1.Enabled = true;
            }

        }
       
        

        

        // private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        // {

        //    if ((bool)dataGridView3.SelectedRows[0].Cells[0].Value == false)
        //     {
        //         dataGridView3.SelectedRows[0].Cells[0].Value = true;
        //    }
        //     else
        //    {
        //         dataGridView1.SelectedRows[0].Cells[0].Value = false;
        //     }

        //}

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            product_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ProductName LIKE '%{0}%'", textBox5.Text);
            dataGridView3.DataSource = DV;
        }

      

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                //  textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
                ProductClick.Visible = true;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            ProductClick.Visible = false;
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            PRODUCTS hackers = new PRODUCTS();
            hackers.ShowDialog();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                label16.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                textBox16.Text = row.Cells["Discount"].Value.ToString();
                textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
                ProductClick.Visible = true;
            }
        }

        private void dogFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ServiceClick.Visible = false;

            panel2.Visible = false;
          //  panel4.Visible = false;
            panel3.Visible = true;

            product_tbl();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + "Dog Food" + "' ", condatabase);


            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sanitaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ServiceClick.Visible = false;

            panel2.Visible = false;
            //panel4.Visible = false;
            panel3.Visible = true;

            product_tbl();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + "Sanitary" + "' ", condatabase);


            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void healthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ServiceClick.Visible = false;
            panel2.Visible = false;
            //panel4.Visible = false;
            panel3.Visible = true;
            product_tbl();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + "Health" + "' ", condatabase);


            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ServiceClick.Visible = false;
            panel2.Visible = false;
            //panel4.Visible = false;
            panel3.Visible = true;
            product_tbl();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + "Treats" + "' ", condatabase);


            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           // ServiceClick.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            Products_tbll();
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * from Services where Service_Category = '" + "Ala Carte Services" + "' ", condatabase);


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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           // ServiceClick.Visible = false;
            panel3.Visible = false;
            //panel4.Visible = false;
            panel2.Visible = true;
        }

        private void addOnServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ServiceClick.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            Products_tbll();
            //ServiceClick.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            Products_tbll();
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * from Services where Service_Category = '" + "Add-On Services" + "' ", condatabase);


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

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ServiceClick.Visible = false;
            panel2.Visible = false;
           // panel4.Visible = false;
            panel3.Visible = true;
            product_tbl();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //ServiceClick.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            Products_tbll();
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * from Services where Service_Category = '" + "Package" + "' ", condatabase);


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

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
        //        textBox11.Text = row.Cells["Services_ID"].Value.ToString();
        //        textBox12.Text = row.Cells["Service_desc"].Value.ToString();
        //        textBox10.Text = row.Cells["Service_Category"].Value.ToString();
        //        textBox13.Text = row.Cells["Price"].Value.ToString();
        //        //textBox3.Enabled = true;
        //        //  simpleButton3.Enabled = true;
        //        //  simpleButton4.Enabled = true;
        //        ServiceClick.Visible = true;
        //    }
        //}

        private void POSFORM_Load(object sender, EventArgs e)
        {
            transaction_tbl();
              panel46.Location = new Point(200, 150);
            panel3.Visible = true;
            timer1.Start();
            label13.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        //private void simpleButton4_Click(object sender, EventArgs e)
        //{
        //    textBox11.Text = "";
        //    textBox12.Text = "";
        //    textBox13.Text = "";
        //    textBox10.Text = "";
        //    ServiceClick.Visible = false;
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label17.Text = DateTime.Now.ToString("hh:mm tt");
            this.label7.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text != "" || comboBox1.Text != "" || comboBox4.Text != "")
            {
                textBox17.Text = textBox6.Text;
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select * from transactions where InvoiceNo='" + textBox6.Text + "' ", condatabase);

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                int i = dtable.Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("The transaction has been added to the Sales");
                    simpleButton22.Visible = true;
                    simpleButton23.Visible = true;
                    dtable.Clear();
                    return;
                }

                else if (i == 0)
                {

                    try
                    {
                        if (comboBox4.Text == "Products" || comboBox4.Text == "")
                        {
                            string type = "Products";
                            string ids = textBox6.Text;
                            string tdate = label13.Text;
                            string ttime = label17.Text;
                            string price = label23.Text;
                            string vat = label24.Text;
                            string staff = label28.Text;
                            //int quan = Convert.ToInt32(textBox3.Text);
                            //int resquan = Convert.ToInt32(label16.Text);
                            int x = 0;
                            double y = 0;

                            if (price == "0" || vat == "0" || price == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }

                            if (ids == "" || ttime == "" || tdate == "" || price == "" || vat == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }
                            double v = Convert.ToDouble(vat);
                            double z = Convert.ToDouble(price);
                            //x = resquan - quan;
                            //y = quan * z;
                            double u = z - v;
                            string prices = z.ToString();
                            string newquan = x.ToString();
                            string nonvat = u.ToString();

                            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                            gsdb.Server = "localhost";
                            gsdb.UserID = "root";
                            gsdb.Password = "";
                            gsdb.Database = "Management";
                            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                            connection.Open();
                            string newuser_sql = "INSERT INTO transactions (InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount,StaffID,TransactionType) VALUES (@InvoiceNo, @TDate, @TTime,@NonVatTotal,@VatAmount,@TotalAmount,@StaffID,@TransactionType)";
                            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                            newuser.CommandText = newuser_sql;
                            newuser.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser.Parameters.AddWithValue("@TDate", tdate);
                            newuser.Parameters.AddWithValue("@TTime", ttime);
                            newuser.Parameters.AddWithValue("@NonVatTotal", nonvat);
                            newuser.Parameters.AddWithValue("@VatAmount", vat);
                            newuser.Parameters.AddWithValue("@TotalAmount", price);
                            newuser.Parameters.AddWithValue("@StaffID", staff);
                            newuser.Parameters.AddWithValue("@TransactionType", type);


                            newuser.ExecuteNonQuery();



                            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                            string newuser_sql2 = "INSERT INTO taxrecord (InvoiceNo,VatAmount,TDate) VALUES (@InvoiceNo,@VatAmount,@TDate)";
                            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                            newuser1.CommandText = newuser_sql2;
                            newuser1.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser1.Parameters.AddWithValue("@VatAmount", vat);
                            newuser1.Parameters.AddWithValue("@TDate", tdate);
                            //  newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                            newuser1.ExecuteNonQuery();
                            {
                            }

                            //connection.Close();
                            //connection.Open();
                            //panel46.Location = new Point(300, 100);
                            Sales_tbl();
                            product_tbl();
                            transaction_tbl();
                            connection.Close();

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "0";



                            textBox18.Text = nonvat;
                            textBox20.Text = vat;
                            textBox22.Text = price;
                            label54.Text = price;
                            textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                            textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                            textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));
                            textBox23.Enabled = true;
                            panel3.Visible = true;
                            panel46.Visible = true;
                            ProductClick.Visible = false;
                        }

                        else if (comboBox4.Text == "Services" )
                        {
                            string type = "Services";
                            string ids = textBox6.Text;
                            string tdate = label13.Text;
                            string ttime = label17.Text;
                            string price = label23.Text;
                            string vat = label24.Text;
                            string staff = label28.Text;
                            //int quan = Convert.ToInt32(textBox3.Text);
                            //int resquan = Convert.ToInt32(label16.Text);
                            int x = 0;
                            double y = 0;

                            if (price == "0" || vat == "0" || price == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }

                            if (ids == "" || ttime == "" || tdate == "" || price == "" || vat == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }
                            double v = Convert.ToDouble(vat);
                            double z = Convert.ToDouble(price);
                            //x = resquan - quan;
                            //y = quan * z;
                            double u = z - v;
                            string prices = z.ToString();
                            string newquan = x.ToString();
                            string nonvat = u.ToString();

                            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                            gsdb.Server = "localhost";
                            gsdb.UserID = "root";
                            gsdb.Password = "";
                            gsdb.Database = "Management";
                            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                            connection.Open();
                            string newuser_sql = "INSERT INTO transactions (InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount,StaffID,TransactionType) VALUES (@InvoiceNo, @TDate, @TTime,@NonVatTotal,@VatAmount,@TotalAmount,@StaffID,@TransactionType)";
                            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                            newuser.CommandText = newuser_sql;
                            newuser.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser.Parameters.AddWithValue("@TDate", tdate);
                            newuser.Parameters.AddWithValue("@TTime", ttime);
                            newuser.Parameters.AddWithValue("@NonVatTotal", nonvat);
                            newuser.Parameters.AddWithValue("@VatAmount", vat);
                            newuser.Parameters.AddWithValue("@TotalAmount", price);
                            newuser.Parameters.AddWithValue("@StaffID", staff);
                            newuser.Parameters.AddWithValue("@TransactionType", type);


                            newuser.ExecuteNonQuery();



                            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                            string newuser_sql2 = "INSERT INTO taxrecord (InvoiceNo,VatAmount,TDate) VALUES (@InvoiceNo,@VatAmount,@TDate)";
                            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                            newuser1.CommandText = newuser_sql2;
                            newuser1.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser1.Parameters.AddWithValue("@VatAmount", vat);
                            newuser1.Parameters.AddWithValue("@TDate", tdate);
                            //  newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                            newuser1.ExecuteNonQuery();
                            {
                            }

                            //connection.Close();
                            //connection.Open();
                            //panel46.Location = new Point(300, 100);
                            Sales_tbl();
                            product_tbl();
                            transaction_tbl();
                            connection.Close();

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "0";



                            textBox18.Text = nonvat;
                            textBox20.Text = vat;
                            textBox22.Text = price;
                            label54.Text = price;
                            textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                            textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                            textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));
                            textBox23.Enabled = true;
                            panel3.Visible = true;
                            panel46.Visible = true;
                            ProductClick.Visible = false;
                        }


                        else if (comboBox4.Text == "Rooms")
                        {
                            string type = "Rooms";
                            string ids = textBox6.Text;
                            string tdate = label13.Text;
                            string ttime = label17.Text;
                            string price = label23.Text;
                            string vat = label24.Text;
                            string staff = label28.Text;
                            //int quan = Convert.ToInt32(textBox3.Text);
                            //int resquan = Convert.ToInt32(label16.Text);
                            int x = 0;
                            double y = 0;

                            if (price == "0" || vat == "0" || price == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }

                            if (ids == "" || ttime == "" || tdate == "" || price == "" || vat == "")
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                                return;
                            }
                            double v = Convert.ToDouble(vat);
                            double z = Convert.ToDouble(price);
                            //x = resquan - quan;
                            //y = quan * z;
                            double u = z - v;
                            string prices = z.ToString();
                            string newquan = x.ToString();
                            string nonvat = u.ToString();

                            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                            gsdb.Server = "localhost";
                            gsdb.UserID = "root";
                            gsdb.Password = "";
                            gsdb.Database = "Management";
                            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                            connection.Open();
                            string newuser_sql = "INSERT INTO transactions (InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount,StaffID,TransactionType) VALUES (@InvoiceNo, @TDate, @TTime,@NonVatTotal,@VatAmount,@TotalAmount,@StaffID,@TransactionType)";
                            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                            newuser.CommandText = newuser_sql;
                            newuser.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser.Parameters.AddWithValue("@TDate", tdate);
                            newuser.Parameters.AddWithValue("@TTime", ttime);
                            newuser.Parameters.AddWithValue("@NonVatTotal", nonvat);
                            newuser.Parameters.AddWithValue("@VatAmount", vat);
                            newuser.Parameters.AddWithValue("@TotalAmount", price);
                            newuser.Parameters.AddWithValue("@StaffID", staff);
                            newuser.Parameters.AddWithValue("@TransactionType", type);


                            newuser.ExecuteNonQuery();



                            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                            string newuser_sql2 = "INSERT INTO taxrecord (InvoiceNo,VatAmount,TDate) VALUES (@InvoiceNo,@VatAmount,@TDate)";
                            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                            newuser1.CommandText = newuser_sql2;
                            newuser1.Parameters.AddWithValue("@InvoiceNo", ids);
                            newuser1.Parameters.AddWithValue("@VatAmount", vat);
                            newuser1.Parameters.AddWithValue("@TDate", tdate);
                            //  newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                            newuser1.ExecuteNonQuery();
                            {
                            }

                            //connection.Close();
                            //connection.Open();
                            //panel46.Location = new Point(300, 100);
                            Sales_tbl();
                            product_tbl();
                            transaction_tbl();
                            connection.Close();

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "0";



                            textBox18.Text = nonvat;
                            textBox20.Text = vat;
                            textBox22.Text = price;
                            label54.Text = price;
                            textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                            textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                            textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));
                            textBox23.Enabled = true;
                            panel3.Visible = true;
                            panel46.Visible = true;
                            ProductClick.Visible = false;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }


            else if (textBox6.Text != "")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select * from transactions where InvoiceNo='" + textBox6.Text + "' ", condatabase);

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                int i = dtable.Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("The transaction has been added to the Sales");
                    simpleButton22.Visible = true;
                    simpleButton23.Visible = true;
                    dtable.Clear();
                    return;
                }

                else if (i == 0)
                {

                    try
                    {

                        string ids = textBox6.Text;
                        string tdate = label13.Text;
                        string ttime = label17.Text;
                        string price = label23.Text;
                        string vat = label24.Text;
                        string staff = label19.Text;
                        //int quan = Convert.ToInt32(textBox3.Text);
                        //int resquan = Convert.ToInt32(label16.Text);
                        int x = 0;
                        double y = 0;

                        if (price == "0" || vat == "0" || price == "")
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                            return;
                        }

                        if (ids == "" || ttime == "" || tdate == "" || price == "" || vat == "")
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                            return;
                        }
                        double v = Convert.ToDouble(vat);
                        double z = Convert.ToDouble(price);
                        //x = resquan - quan;
                        //y = quan * z;
                        double u = z - v;
                        string prices = z.ToString();
                        string newquan = x.ToString();
                        string nonvat = u.ToString();

                        MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                        gsdb.Server = "localhost";
                        gsdb.UserID = "root";
                        gsdb.Password = "";
                        gsdb.Database = "Management";
                        MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                        connection.Open();
                        string newuser_sql = "INSERT INTO transactions (InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount,StaffID) VALUES (@InvoiceNo, @TDate, @TTime,@NonVatTotal,@VatAmount,@TotalAmount,@StaffID)";
                        MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                        newuser.CommandText = newuser_sql;
                        newuser.Parameters.AddWithValue("@InvoiceNo", ids);
                        newuser.Parameters.AddWithValue("@TDate", tdate);
                        newuser.Parameters.AddWithValue("@TTime", ttime);
                        newuser.Parameters.AddWithValue("@NonVatTotal", nonvat);
                        newuser.Parameters.AddWithValue("@VatAmount", vat);
                        newuser.Parameters.AddWithValue("@TotalAmount", price);
                        newuser.Parameters.AddWithValue("@StaffID", staff);


                        newuser.ExecuteNonQuery();



                        DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                        string newuser_sql2 = "INSERT INTO taxrecord (InvoiceNo,VatAmount,TDate) VALUES (@InvoiceNo,@VatAmount,@TDate)";
                        MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                        newuser1.CommandText = newuser_sql2;
                        newuser1.Parameters.AddWithValue("@InvoiceNo", ids);
                        newuser1.Parameters.AddWithValue("@VatAmount", vat);
                        newuser1.Parameters.AddWithValue("@TDate", tdate);
                        //  newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                        newuser1.ExecuteNonQuery();
                        {
                        }

                        //connection.Close();
                        //connection.Open();
                        //panel46.Location = new Point(300, 100);
                        Sales_tbl();
                        product_tbl();
                        transaction_tbl();
                        connection.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox3.Text = "0";



                        textBox18.Text = nonvat;
                        textBox20.Text = vat;
                        textBox22.Text = price;
                        label54.Text = price;
                        textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                        textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                        textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));
                        textBox23.Enabled = true;
                        panel3.Visible = true;
                        panel46.Visible = true;
                        ProductClick.Visible = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (label20.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Choose Product To be Remove");
                return;
            }
            if (shoppingcart.Count == 0)
            {
                shoppingcart.Clear();
                DevExpress.XtraEditors.XtraMessageBox.Show("The Shopping Cart is Empty");
                return;
            }
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            shoppingcart.RemoveAt(rowIndex);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = shoppingcart;
            double sum = 0;
            double x = Convert.ToDouble(vatxxx);
            double vat = 0;
            double nonvat = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                vat = (sum * x);
                nonvat = sum - vat;
            }

            label15.Text = sum.ToString();
            label15.Text = String.Format("{0:C}", double.Parse(label15.Text));

            label14.Text = vat.ToString();
            label14.Text = String.Format("{0:C}", double.Parse(label14.Text));


            label31.Text = nonvat.ToString();
            label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
            int ap = Convert.ToInt32(label20.Text);
            int ay = Convert.ToInt32(label22.Text);
            int tt = ap + ay;
            string newq = tt.ToString();




            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Products set Quantity='" + newq + "'where Product_ID='" + label21.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;

            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("The product has been removed to the cart");
                while (myReader.Read())
                {

                }
                condatabase.Close();
                condatabase.Open();

                string query1 = "delete from Management.transactiondetails where Product_ID='" + label25.Text + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //getName();
                newquery.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //transaction_tbl();
            product_tbl();
            condatabase.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                
                label20.Text = row.Cells["Quantity"].Value.ToString();
                int x = Convert.ToInt32(label20.Text);
                label21.Text = row.Cells["ProductID"].Value.ToString();
                label25.Text = row.Cells["ProductID"].Value.ToString();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select * from Products where Product_ID='" + label21.Text + "' ";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();


                    while (myReader.Read())
                    {
                        string sname = myReader.GetString("Quantity");
                        label22.Text = sname;
                        label20.Visible = false;
                        label21.Visible = false;
                        label22.Visible = false;
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
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            textBox23.Enabled = true;
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to drop the items in the cart?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (comboBox1.Text != "")
                {
                    getName1();
                    simpleButton22.Visible = false;
                    simpleButton23.Visible = false;
                    comboBox4.SelectedIndex = -1;
                    comboBox1.SelectedIndex = -1;
                }
                else if (comboBox1.Text == "")
                {
                    string Query = "delete from Management.Transactiondetails where InvoiceNo='" + textBox6.Text + "' ;";

                    MySqlConnection condatabase = new MySqlConnection(constring);
                    MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                    MySqlDataReader myReader;
                    try
                    {
                        condatabase.Open();
                        myReader = cmddatabase.ExecuteReader();
                        shoppingcart.Clear();
                        //DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                        while (myReader.Read())
                        {

                        }

                        condatabase.Close();

                        condatabase.Open();

                        string Query1 = "delete from Management.transactions where InvoiceNo='" + textBox6.Text + "' ;";
                        MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                        newquery.ExecuteNonQuery();

                        transaction_tbl();
                        getName();
                        condatabase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //condatabase.Open();
                    //string activity = "Delete Product";
                    //string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                    //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    //newuser1.CommandText = newuser_sql2;
                    //newuser1.Parameters.AddWithValue("@act", activity);
                    //newuser1.Parameters.AddWithValue("@namc", label4.Text);
                    //newuser1.Parameters.AddWithValue("@levels", label5.Text);
                    //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                    //newuser1.ExecuteNonQuery();
                    {
                    }
                    //xy = 0;
                    //product_tbl();
                    //if (xy > 0)
                    //{
                    //    DialogResult dialog2 = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                    //}
                    //getName1();
                    //textBox1.Text = "";
                    //textBox2.Text = "";
                    //textBox4.Text = "";
                    //textBox3.Text = "0";
                    //comboBox1.Items.Clear();
                    //textBox6.Text = "0";
                    //textBox6.Enabled = false;
                    //fillcombo();
                    getName1();
                    getName2();
                    shoppingcart.Clear();
                    transaction_tbl();
                    product_tbl();
                    Sales_tbl();
                    simpleButton22.Visible = false;
                    simpleButton23.Visible = false;
                    condatabase.Close();
                }
            }
        }

        private void dataGridView3_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                label16.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                textBox16.Text = row.Cells["Discount"].Value.ToString();
                textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
                ProductClick.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox23.Enabled = false;
            textBox6.Text = comboBox1.Text;
            textBox24.Text = comboBox1.Text;
            

            if (comboBox4.Text == "" || comboBox4.Text == "Products")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID,Prod_desc as ProductName,UnitPrice,Quantity,Price as 'Price (PHP)' ,Discount as 'Discount(%)' from transactiondetails where InvoiceNo='" + comboBox1.Text + "'", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();
                    double x = Convert.ToDouble(vatxxx);
                    bsource.DataSource = dtable;
                    dataGridView2.DataSource = bsource;
                    loaddb.Update(dtable);
                    // dataGridView3.Rows[0].Cells[0].Value = false;

                    double sum = 0;
                   
                    double vat = 0;
                    double nonvat = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                        vat = (sum * x);
                        nonvat = sum - vat;
                    }
                    label23.Text = sum.ToString();
                    label15.Text = sum.ToString();
                    label15.Text = String.Format("{0:C}", double.Parse(label15.Text));
                    label24.Text = vat.ToString();
                    label14.Text = vat.ToString();
                    label14.Text = String.Format("{0:C}", double.Parse(label14.Text));
                    label31.Text = nonvat.ToString();
                    label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox4.Text == "Services")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ServicesID,Prod_desc as ServiceName,UnitPrice,Quantity,Price as 'Price (PHP)',Discount as 'Discount(%)' from transactiondetails where InvoiceNo='" + comboBox1.Text + "'", condatabase);

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

                    double sum = 0;
                    double x = Convert.ToDouble(vatxxx);
                    double vat = 0;
                    double nonvat = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                        vat = (sum * x);
                        nonvat = sum - vat;
                    }
                    label23.Text = sum.ToString();
                    label15.Text = sum.ToString();
                    label15.Text = String.Format("{0:C}", double.Parse(label15.Text));
                    label24.Text = vat.ToString();
                    label14.Text = vat.ToString();
                    label14.Text = String.Format("{0:C}", double.Parse(label14.Text));
                    label31.Text = nonvat.ToString();
                    label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox4.Text == "Rooms")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as RoomID,Prod_desc as RoomName, UnitPrice,Quantity,Price as 'Price (PHP)',Discount as 'Discount(%)' from transactiondetails where InvoiceNo='" + comboBox1.Text + "'", condatabase);

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

                    double sum = 0;
                    double x = Convert.ToDouble(vatxxx);
                    double vat = 0;
                    double nonvat = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                        vat = (sum * x);
                        nonvat = sum - vat;
                    }
                    label23.Text = sum.ToString();
                    label15.Text = sum.ToString();
                    label15.Text = String.Format("{0:C}", double.Parse(label15.Text));
                    label24.Text = vat.ToString();
                    label14.Text = vat.ToString();
                    label14.Text = String.Format("{0:C}", double.Parse(label14.Text));
                    label31.Text = nonvat.ToString();
                    label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                product_tbl();
            }

            else {
                product_tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price,Discount from Products where Prod_Category = '" + comboBox2.Text + "' ", condatabase);


                try
                {
                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView3.DataSource = bsource;
                    loaddb.Update(dtable);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "All")
            {
                Products_tbll();
            }

            else {
                Products_tbll();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID ,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price,Discount from Products where Prod_Category = '" + comboBox3.Text + "' ", condatabase);


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
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Products_tbll();
            panel29.Visible = false;
            panel24.Visible = false;
            panel2.Visible = true;  
            panel2.Location= new Point (0,0);
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            product_tbl();
            panel34.Visible = false;
            panel29.Visible = false;
            panel24.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            ProductClick.Location = new Point(300, 200);
              panel46.Location = new Point(200, 150);

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel29.Visible = false;
            panel24.Visible = true;
            panel24.Location = new Point(0, 0);
              panel46.Location = new Point(200, 150);

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            WAIVER hackers = new WAIVER();
            hackers.ShowDialog();
            //panel34.Visible = false;
            //panel2.Visible = true;
            //panel24.Visible = true;
            //panel29.Visible = true;
            panel29.Location = new Point(0, 0);
              panel46.Location = new Point(200, 150);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            TAX_tbl();
            panel39.Visible = false;
            panel2.Visible = true;
            panel24.Visible = true;
            panel29.Visible = true;
            panel34.Visible = true;
            panel34.Location = new Point(0, 0);
              panel46.Location = new Point(200, 150);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel24.Visible = true;
            panel29.Visible = true;
            panel34.Visible = true;
            panel39.Visible = true;
            panel39.Location = new Point(0, 0);
             panel46.Location = new Point(200, 150);

        }

        private void simpleButton14_Click_2(object sender, EventArgs e)
        {
            double x = 100;
            double vat = Convert.ToDouble(textBox13.Text);
            double vats = vat / x ; 

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.vatsetting set VatPercent='" + vats + "'where VatID='" + 1000100000 + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("VAT PERCENTAGE has been Updated!");
                while (myReader.Read())
                {

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
            //account_tbl();
            textBox13.Text = "";
          

      
            condatabase.Close();
            getName1();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Products_tbll();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ProductName LIKE '%{0}%'", textBox7.Text);
            dataGridView1.DataSource = DV;
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            //double x = 100;
            double disc = Convert.ToDouble(textBox14.Text);
            //double diss = disc / x;

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Products set Discount='" + disc + "'where Product_ID='" + textBox9.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Discount PERCENTAGE has been Updated!");
                while (myReader.Read())
                {

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
            //account_tbl();
            textBox13.Text = "";

            Products_tbll();

            condatabase.Close();
            getName1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox9.Text = row.Cells["ProductID"].Value.ToString();
                textBox8.Text = row.Cells["ProductName"].Value.ToString();
                textBox10.Text = row.Cells["Quantity"].Value.ToString();
                textBox11.Text = row.Cells["Price"].Value.ToString();
                textBox15.Text = row.Cells["Category"].Value.ToString();
                textBox14.Text = row.Cells["Discount"].Value.ToString();
                //textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            //double x = Convert.ToDouble(textBox16.Text);
            //double y = 100;
            //double pri = Convert.ToDouble(textBox4.Text);
            
            //if (x > 0)
            //{
            //    double diss = x / y ;
            //    double z = diss * pri;
            //    double final = pri - z;
            //    textBox4.Text = final.ToString();
            //}
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView2, e.X, e.Y);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label20.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Choose Product To be Remove");
                return;
            }
            if (shoppingcart.Count == 0)
            {
                shoppingcart.Clear();
                DevExpress.XtraEditors.XtraMessageBox.Show("The Shopping Cart is Empty");
                return;
            }
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
                shoppingcart.RemoveAt(rowIndex);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = shoppingcart;
                double sum = 0;
                double x = Convert.ToDouble(vatxxx);
                double vat = 0;
                double nonvat = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                    vat = (sum * x);
                    nonvat = sum - vat;
                }

                label15.Text = sum.ToString();
                label15.Text = String.Format("{0:C}", double.Parse(label15.Text));

                label14.Text = vat.ToString();
                label14.Text = String.Format("{0:C}", double.Parse(label14.Text));


                label31.Text = nonvat.ToString();
                label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
                int ap = Convert.ToInt32(label20.Text);
                int ay = Convert.ToInt32(label22.Text);
                int tt = ap + ay;
                string newq = tt.ToString();




                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                string Query = "update Management.Products set Quantity='" + newq + "'where Product_ID='" + label21.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;

                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("The product has been removed to the cart");
                    while (myReader.Read())
                    {

                    }
                    condatabase.Close();
                    condatabase.Open();

                    string query1 = "delete from Management.transactiondetails where Product_ID='" + label25.Text + "' ;";

                    MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                    //getName();
                    newquery.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                //transaction_tbl();
                product_tbl();
                condatabase.Close();
            }
        

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactions where InvoiceNo='" + textBox17.Text + "';";

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


                    textBox17.Text = sname;
                    textBox18.Text = sname2;
                    textBox20.Text = sname3;
                    textBox22.Text = sname4;
                    label54.Text = sname4;
                    textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                    textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                    textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            //string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            ////DialogResult dialog = XtraMessageBox.Show("Are you sure you want new Transaction?", "Confirmation", MessageBoxButtons.YesNo);
            ////if (dialog == DialogResult.Yes)
            ////{

            //    string Query = "delete from Management.Transactions where InvoiceNo='" + textBox17.Text + "' ;";

            //    MySqlConnection condatabase = new MySqlConnection(constring);
            //    MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            //    MySqlDataReader myReader;
            //    try
            //    {
            //        condatabase.Open();
            //        myReader = cmddatabase.ExecuteReader();
            //        //DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

            //        while (myReader.Read())
            //        {

            //        }

            //        condatabase.Close();

            //        //condatabase.Open();

            //        //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
            //        //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
            //        //newquery.ExecuteNonQuery();

            //        //account_tbl();
            //        //getName();
            //        //condatabase.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //    condatabase.Open();
            //    //string activity = "Delete Product";
            //    //string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            //    //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //    //newuser1.CommandText = newuser_sql2;
            //    //newuser1.Parameters.AddWithValue("@act", activity);
            //    //newuser1.Parameters.AddWithValue("@namc", label4.Text);
            //    //newuser1.Parameters.AddWithValue("@levels", label5.Text);
            //    //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            //    //newuser1.ExecuteNonQuery();
            //    {
            //    }
            //    //xy = 0;
            //    //product_tbl();
            //    //if (xy > 0)
            //    //{
            //    //    DialogResult dialog2 = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            //    //}
            //    //getName1();
            //    //textBox1.Text = "";
            //    //textBox2.Text = "";
            //    //textBox4.Text = "";
            //    //textBox3.Text = "0";
            //    //comboBox1.Items.Clear();
            //    //textBox6.Text = "0";
            //    //textBox6.Enabled = false;
            //    //fillcombo();
            //transaction_tbl();
            //product_tbl();
            //textBox23.Enabled = true;
            //condatabase.Close();
            
            panel46.Visible = false;

        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            if (textBox21.Text == "" || textBox21.Text == "0")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please input the Cash");
                return;
            }
            string cc = textBox21.Text;
            string fc = cc + ".00";
            label67.Text = fc;
            double x = Convert.ToDouble(textBox21.Text);
            double y = Convert.ToDouble(label54.Text);

            if (x >= y)
            {
                double c = x - y;
                string v = c.ToString();
                string fv = v + ".00";
                label61.Text = fv;
                textBox19.Text = c.ToString();
                textBox19.Text = String.Format("{0:C}", double.Parse(textBox19.Text));
                textBox21.Text = String.Format("{0:C}", double.Parse(textBox21.Text));
                simpleButton16.Enabled = true;
                simpleButton17.Enabled = true;
                simpleButton19.Enabled = false;
                textBox21.Enabled = false;
            }
            else if (x < y)
            {
                MessageBox.Show("The Cash Entered is Not Enough!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox19.Text = "";
                textBox21.Text = "";
                simpleButton16.Enabled = false;
                simpleButton17.Enabled = false;
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton19.PerformClick();
               
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
            e.Graphics.DrawString("InvoiceNo:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 140));
            e.Graphics.DrawString(textBox17.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 160));
            e.Graphics.DrawString("Date of Issue", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString(label13.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 220));
            e.Graphics.DrawString("Billed To:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 140));
            e.Graphics.DrawString(textBox23.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 250), new Point(780, 250));
            e.Graphics.DrawString("****************************************************************************************", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(38, 248));
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 255), new Point(780, 255));


            e.Graphics.DrawString("09777492858", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 40));
            e.Graphics.DrawString("dogspaandhotel18@gmail.com", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 80));
            e.Graphics.DrawString("Invoice Total", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(600, 140));
            e.Graphics.DrawString(textBox22.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(600,160));
            e.Graphics.DrawString("Unit 101-C Lancaster The ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 40));
            e.Graphics.DrawString("Square, Alapan II-B,Imus, ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 60));
            e.Graphics.DrawString("Cavite,Philippines,4103", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 80));
            //e.Graphics.DrawString(label7.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bmp1 = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bmp1, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            //dataGridView1.Height = height;        
            //e.Graphics.DrawImage(bmp1, 90, 250);
            if (comboBox4.Text == "" || comboBox4.Text == "Products")
            {
                e.Graphics.DrawRectangle(Pens.Black, 40, 260, 750, 30);
                e.Graphics.FillRectangle(Brushes.SkyBlue,new Rectangle(40, 261, 750, 29));
                e.Graphics.DrawString("Product Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Unit Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(400, 260));
                e.Graphics.DrawString("Quantity", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price (PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }
            else if (comboBox4.Text == "Services")
            {
                e.Graphics.DrawString("Service Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Service Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(380, 260));
                e.Graphics.DrawString("Quantity", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price (PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }
            else if (comboBox4.Text == "Rooms")
            { 
                e.Graphics.DrawString("Room Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Room Type", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(250, 260));
                e.Graphics.DrawString("Unit Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(400, 260));
                e.Graphics.DrawString("Hours/Day", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price(PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }

            int yPos = 290;
            //foreach (var i in shoppingcart)
            //{
            //    //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    e.Graphics.DrawString(i.ProductName, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    e.Graphics.DrawString(i.UnitPrice.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(420, yPos));
            //    e.Graphics.DrawString(i.Quantity.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos));
            //    e.Graphics.DrawString(i.Price.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(710, yPos));
            //    //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    yPos += 25;
            //}

            foreach (DataGridViewRow i in dataGridView2.Rows)
            {
                string ProductName = Convert.ToString(i.Cells[1].Value);
                string UnitPrice = Convert.ToString(i.Cells[2].Value);
                string Quantity = Convert.ToString(i.Cells[3].Value);
                string Price = Convert.ToString(i.Cells[4].Value);

                //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos - 30), new Point(40, yPos));
                e.Graphics.DrawString(ProductName, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(370, yPos-30), new Point(370, yPos));
                e.Graphics.DrawString(UnitPrice.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(420, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(520, yPos - 30), new Point(520, yPos));
                e.Graphics.DrawString(Quantity.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(650, yPos - 30), new Point(650, yPos));
                e.Graphics.DrawString(Price.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(710, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(790, yPos - 30), new Point(790, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos), new Point(790, yPos));
                //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                yPos += 25;
            }
            e.Graphics.DrawString("****************************************************************************************", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(40, yPos - 26));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos-15), new Point(790, yPos-15));
            //int x = 250 + (dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2) + 16;


            e.Graphics.DrawString("TOTAL:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos+10));
            e.Graphics.DrawString(textBox22.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos+10));

            e.Graphics.DrawString("CASH:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos + 30));
            e.Graphics.DrawString(textBox21.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos + 30));

            e.Graphics.DrawString("CHANGE:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos + 50));
            e.Graphics.DrawString(textBox19.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos + 50));

            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 90), new Point(780, x + 90));
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 95), new Point(780, x + 95));

            //e.Graphics.DrawString("Approved for Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(55, x + 120));
            //e.Graphics.DrawString("Paid By:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(330, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(330, x + 120));
            //e.Graphics.DrawString("Received Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(610, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(630, x + 120));
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.transactions set CashPaid='" + label67.Text + "',ChangeReceive='" + label61.Text + "'where InvoiceNo='" + textBox17.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                //DevExpress.XtraEditors.XtraMessageBox.Show("Product has been Updated!");
                while (myReader.Read())
                {

                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            {
            }
            //account_tbl();

            condatabase.Close();
            DVprintPreviewDialog.Document = DVprintDocument;
            DVprintPreviewDialog.PrintPreviewControl.Zoom = 1;
            DVprintPreviewDialog.ShowDialog();

        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = DVprintDocument;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                DVprintDocument.DocumentName = "Invoice" + textBox6.Text;
                DVprintDocument.Print();
            }
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("Are you sure do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Close();
                Login gg = new Login();
                gg.Show();
            }
            else if (result1 == DialogResult.No)
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID, Prod_desc as ProductName,UnitPrice,Quantity,Price,Discount from transactiondetails where InvoiceNo='" + textBox6.Text + "'", condatabase);

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

                double sum = 0;
                double x = Convert.ToDouble(vatxxx);
                double vat = 0;
                double nonvat = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);

                    vat = (sum * x);
                    nonvat = sum - vat;
                }
                label23.Text = sum.ToString();
                label15.Text = sum.ToString();
                label15.Text = String.Format("{0:C}", double.Parse(label15.Text));
                label24.Text = vat.ToString();
                label14.Text = vat.ToString();
                label14.Text = String.Format("{0:C}", double.Parse(label14.Text));
                label31.Text = nonvat.ToString();
                label31.Text = String.Format("{0:C}", double.Parse(label31.Text));
                {
                }
             

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = shoppingcart;

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (comboBox4.Text == "All")
            {
                fillcombo();
            }

            else {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select Distinct InvoiceNo from TransactionDetails where transaction_type='" + comboBox4.Text + "' ;";

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
                        comboBox1.Items.Add(sname);

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
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select Distinct Customer_Name from TransactionDetails where InvoiceNo='" + textBox24.Text + "' ;";

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
                    textBox23.Text = sname;

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

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Products where Prod_desc='" + textBox30.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Prod_desc");
                    string sname2 = myReader.GetInt32("Product_ID").ToString();
                    string sname3 = myReader.GetString("Prod_Category");
                    //string sname4 = myReader.GetString("Quantity");
                    string sname5 = myReader.GetString("Price");
                    

                    textBox29.Text = sname2;
                    textBox30.Text = sname;
               //     textBox25.Text = sname3;
                    //textBox12.Text = sname4;
                    textBox28.Text = sname5;
                    

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

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            string ids = textBox29.Text;
            string desc = textBox30.Text;
      //      string category = textBox25.Text;
            string quantity = textBox27.Text;
            string price = textBox28.Text;
            string date = label13.Text;
            double x = Convert.ToInt32(textBox27.Text);
            double y = Convert.ToInt32(textBox28.Text);
            string status = "Void";
            double total = Convert.ToDouble(textBox32.Text);
            double ntotal = 0;
            double vatamount = Convert.ToDouble(textBox33.Text);
            double nonvat = Convert.ToDouble(textBox34.Text);
            ntotal = total - y;
            vatamount = ntotal * 0.12;
            nonvat = ntotal - vatamount;
            string ntotal1 = Convert.ToString(ntotal);
            string vatamount1 = Convert.ToString(vatamount);
            string nonvat1 = Convert.ToString(nonvat);

            double z = x * y;
            string final = z.ToString();
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            //if (desc == "" || quantity == "" || price == "" )
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
            //    return;
            //}
            if (quantity == "0" || quantity == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
                return;
            }
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO ReturnItem (Product_ID,Prod_desc,Quantity,Price,return_date) VALUES (@Product_ID, @Prod_desc, @Quantity,@Price,@return_date)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            newuser.Parameters.AddWithValue("@Quantity", quantity);
            newuser.Parameters.AddWithValue("@Price", final);
           // newuser.Parameters.AddWithValue("@Prod_Category", category);
            newuser.Parameters.AddWithValue("@return_date", date);
            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            string query1 = "update Management.Transactions set TotalAmount='" + ntotal1 + "',VatAmount='" + vatamount1 + "',NonVatTotal='" + nonvat1 + "'where InvoiceNo='" + textBox31.Text + "' ;";

            MySqlCommand newquery = new MySqlCommand(query1, connection);
            getName();
            newquery.ExecuteNonQuery();


            //textBoxX2.Text = "";
            //textBoxX3.Text = "";
            //textBoxX4.Text = "";
            //textBoxX5.Text = "";
            //textBoxX6.Text = "";
            //connection.Close();
            //connection.Open();
            //string activity = "Add Products";
            string newuser_sql2 = "update Management.transactiondetails set Status='" + status + "'where InvoiceNo='" + textBox31.Text + "' ;";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label4.Text);
            //newuser1.Parameters.AddWithValue("@levels", label5.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            //{
            //}

            //transaction_tbl();

            //xy = 0;
            //product_tbl();
            //if (xy > 0)
            //{
            //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            //}
            textBox29.Text = "";
            textBox30.Text = "";
           // textBox25.Text = "";
            textBox27.Text = "0";
            textBox28.Text = "";
            getName1();
            TAX_tbl();
            Sales_tbl();
            ReturnItem_tbl();
            comboBox6.Items.Clear();
          //  fillcombo();

            // textBox6.Text = "0";
            // textBox6.Enabled = false;
            connection.Close();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
        


        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            label8.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            textBox7.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            Bitmap bmp = Properties.Resources.logo;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 50, 25, 300, 100);
            //e.Graphics.DrawString("DOG SPA AND HOTEL" , new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(250,50));
            e.Graphics.DrawString("InvoiceNo:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 140));
            e.Graphics.DrawString(textBox17.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 160));
            e.Graphics.DrawString("Date of Issue", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 200));
            e.Graphics.DrawString(label13.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(370, 220));
            e.Graphics.DrawString("Billed To:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 140));
            e.Graphics.DrawString(textBox23.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, 160));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 250), new Point(780, 250));
            e.Graphics.DrawString("****************************************************************************************", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(38, 248));
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 255), new Point(780, 255));


            e.Graphics.DrawString("09777492858", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 40));
            e.Graphics.DrawString("dogspaandhotel18@gmail.com", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(370, 80));
            e.Graphics.DrawString("Invoice Total", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(600, 140));
            e.Graphics.DrawString(textBox22.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(600, 160));
            e.Graphics.DrawString("Unit 101-C Lancaster The ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 40));
            e.Graphics.DrawString("Square, Alapan II-B,Imus, ", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 60));
            e.Graphics.DrawString("Cavite,Philippines,4103", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, 80));
            //e.Graphics.DrawString(label7.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bmp1 = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bmp1, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            //dataGridView1.Height = height;        
            //e.Graphics.DrawImage(bmp1, 90, 250);
            if (comboBox4.Text == "" || comboBox4.Text == "Products")
            {
                e.Graphics.DrawRectangle(Pens.Black, 40, 260, 750, 30);
                e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(40, 261, 750, 29));
                e.Graphics.DrawString("Product Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Unit Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(400, 260));
                e.Graphics.DrawString("Quantity", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price (PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }
            else if (comboBox4.Text == "Services")
            {
                e.Graphics.DrawString("Service Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Service Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(380, 260));
                e.Graphics.DrawString("Quantity", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price (PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }
            else if (comboBox4.Text == "Rooms")
            {
                e.Graphics.DrawString("Room Name", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(40, 260));
                e.Graphics.DrawString("Room Type", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(250, 260));
                e.Graphics.DrawString("Unit Price", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(400, 260));
                e.Graphics.DrawString("Hours/Day", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, 260));
                e.Graphics.DrawString("Price(PHP)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(670, 260));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, 260), new Point(790, 260));
            }

            int yPos = 290;
            //foreach (var i in shoppingcart)
            //{
            //    //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    e.Graphics.DrawString(i.ProductName, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    e.Graphics.DrawString(i.UnitPrice.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(420, yPos));
            //    e.Graphics.DrawString(i.Quantity.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos));
            //    e.Graphics.DrawString(i.Price.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(710, yPos));
            //    //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
            //    yPos += 25;
            //}

            foreach (DataGridViewRow i in dataGridView2.Rows)
            {
                string ProductName = Convert.ToString(i.Cells[1].Value);
                string UnitPrice = Convert.ToString(i.Cells[2].Value);
                string Quantity = Convert.ToString(i.Cells[3].Value);
                string Price = Convert.ToString(i.Cells[4].Value);

                //e.Graphics.DrawString(i.ProductID, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos - 30), new Point(40, yPos));
                e.Graphics.DrawString(ProductName, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(370, yPos - 30), new Point(370, yPos));
                e.Graphics.DrawString(UnitPrice.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(420, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(520, yPos - 30), new Point(520, yPos));
                e.Graphics.DrawString(Quantity.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(580, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(650, yPos - 30), new Point(650, yPos));
                e.Graphics.DrawString(Price.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(710, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(790, yPos - 30), new Point(790, yPos));
                e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos), new Point(790, yPos));
                //e.Graphics.DrawString(i.Discount.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, yPos));
                yPos += 25;
            }
            e.Graphics.DrawString("****************************************************************************************", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(40, yPos - 26));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, yPos - 15), new Point(790, yPos - 15));
            //int x = 250 + (dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2) + 16;


            e.Graphics.DrawString("TOTAL:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos + 10));
            e.Graphics.DrawString(textBox22.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos + 10));

            e.Graphics.DrawString("CASH:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos + 30));
            e.Graphics.DrawString(textBox21.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos + 30));

            e.Graphics.DrawString("CHANGE:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(600, yPos + 50));
            e.Graphics.DrawString(textBox19.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, yPos + 50));

            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 90), new Point(780, x + 90));
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(40, x + 95), new Point(780, x + 95));

            //e.Graphics.DrawString("Approved for Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(40, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(55, x + 120));
            //e.Graphics.DrawString("Paid By:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(330, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(330, x + 120));
            //e.Graphics.DrawString("Received Payment:", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(610, x + 100));
            //e.Graphics.DrawString(label22.Text, new Font("Times New Roman", 12, FontStyle.Underline), Brushes.Black, new Point(630, x + 120));
        }

        private void DVprintPreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
        
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Invoice" + textBox6.Text;
                printDocument1.Print();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount  from Transactions where TDate BETWEEN'" + dateTimePicker3.Text + "' AND '" + dateTimePicker1.Text + "' ", condatabase);

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




                //dataGridView2.DataSource = null;
                //dataGridView2.DataSource = shoppingcart;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker3.Text == dateTimePicker1.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select TDate,InvoiceNo,VatAmount from  TaxRecord where TDate BETWEEN'" + dateTimePicker3.Text + "' AND '" + dateTimePicker1.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView6.DataSource = bsource;
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
            if (dateTimePicker3.Value < dateTimePicker1.Value)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select TDate,InvoiceNo,VatAmount from  TaxRecord where TDate BETWEEN'" + dateTimePicker3.Text + "' AND   '" + dateTimePicker1.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView6.DataSource = bsource;
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
            if (dateTimePicker3.Value > dateTimePicker1.Value)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("To Date is Later than From Date ");
                return;
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = "";
            comboBox1.Text = x;
            textBox31.Text = x;
            comboBox1.Items.Clear();
            
            if (comboBox5.Text == "All")
            {
                fillcombo2();
            }

            else {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select Distinct Prod_desc, InvoiceNo from TransactionDetails where InvoiceNo='" + comboBox5.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();


                    while (myReader.Read())
                    {
                        string sname = myReader.GetString("Prod_desc");
                        string sname2 = myReader.GetString("InvoiceNo");
                        comboBox6.Items.Add(sname);

                        
                        textBox31.Text = sname2;

                    }
                    condatabase.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //condatabase.Open();

                {
                }

                //condatabase.Close();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactiondetails where Prod_desc='" + comboBox6.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Prod_desc");
                    string sname2 = myReader.GetInt32("Quantity").ToString();
                    string sname3 = myReader.GetString("Price");
                    string sname4 = myReader.GetString("UnitPrice");
                    string sname5 = myReader.GetString("Product_ID");
                    string sname6 = myReader.GetString("TDetailNo");


                    textBox29.Text = sname5;
                    textBox27.Text = sname2;
                    textBox28.Text = sname4;
                    textBox25.Text = sname6;
                    //textBox22.Text = sname4;
                    //label54.Text = sname5;
                    //textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                    //textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                    //textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                simpleButton19.Enabled = true;
            }
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox21.Text = "";
            //label67.Text = "";
            //label61.Text = "";
            //label54.Text = "";
            textBox21.Enabled = true;
            simpleButton16.Enabled = false;
            simpleButton17.Enabled = false;
            simpleButton19.Enabled = true;
        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactions where InvoiceNo='" + textBox31.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    //string sname = myReader.GetString("InvoiceNo");
                    string sname2 = myReader.GetString("TotalAmount").ToString();
                    string sname3 = myReader.GetString("VatAmount").ToString(); 
                    string sname4 = myReader.GetString("NonVatTotal").ToString(); 
                    //string sname5 = myReader.GetString("Product_ID");
                    //string sname6 = myReader.GetString("TDetailNo");


                    //textBox31.Text = sname;
                    textBox32.Text = sname2;
                    textBox33.Text = sname3;
                    textBox34.Text = sname4;
                    //textBox22.Text = sname4;
                    //label54.Text = sname5;
                    //textBox18.Text = String.Format("{0:C}", double.Parse(textBox18.Text));
                    //textBox20.Text = String.Format("{0:C}", double.Parse(textBox20.Text));
                    //textBox22.Text = String.Format("{0:C}", double.Parse(textBox22.Text));

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            shoppingcart.Clear();
            transaction_tbl();
            getName1();
            getName2();
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            TAX_tbl();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker3.Text == dateTimePicker1.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select TDate,InvoiceNo,VatAmount from  TaxRecord where TDate BETWEEN'" + dateTimePicker3.Text + "' AND '" + dateTimePicker1.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView6.DataSource = bsource;
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
            if (dateTimePicker3.Value < dateTimePicker1.Value)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select TDate,InvoiceNo,VatAmount from  TaxRecord where TDate BETWEEN'" + dateTimePicker3.Text + "' AND   '" + dateTimePicker1.Text + "' ", condatabase);

                try
                {

                    MySqlDataAdapter loaddb = new MySqlDataAdapter();
                    loaddb.SelectCommand = cmddatabase;
                    dtable = new DataTable();
                    loaddb.Fill(dtable);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dtable;
                    dataGridView6.DataSource = bsource;
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
            if (dateTimePicker3.Value > dateTimePicker1.Value)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("To Date is Later than From Date ");
                return;
            }
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            Sales_tbl();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker4.Text == dateTimePicker2.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount  from Transactions where TDate BETWEEN'" + dateTimePicker4.Text + "' AND '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (dateTimePicker4.Text == dateTimePicker2.Text)
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select InvoiceNo,TDate,TTime,NonVatTotal,VatAmount,TotalAmount  from Transactions where TDate BETWEEN'" + dateTimePicker4.Text + "' AND '" + dateTimePicker2.Text + "' ", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

             

            }
            if (dateTimePicker4.Value > dateTimePicker2.Value)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("To Date is Later than From Date ");
                return;
            }
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
            //    textBox1.Text = row.Cells["ProductID"].Value.ToString();
            //    textBox2.Text = row.Cells["ProductName"].Value.ToString();
            //    //  textBox3.Text = row.Cells["Quantity"].Value.ToString();
            //    textBox3.Text = row.Cells["Price"].Value.ToString();
            //    textBox3.Enabled = true;
            //    //  simpleButton3.Enabled = true;
            //    //  simpleButton4.Enabled = true;
            //    ProductClick.Visible = true;
            //}
        }
    }
}
