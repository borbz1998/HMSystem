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
    public partial class PRODUCTS : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public PRODUCTS()
        {
            InitializeComponent();
            product_tbl();
            stocks_tbl();
            fillcombo();
            getName1();
            getName2();
            timer1.Start();

            this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;


        }
        DataTable dtable;
        int xy = 0;
        int zy = 0;
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

        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Category";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Prod_Category");
                  //  comboBox1.Items.Add(sname);
                    comboBox2.Items.Add(sname);
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
    
    void product_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products ", condatabase);

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
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
              
                    //Here 2 cell is target value and 1 cell is Volume
                    if (Convert.ToInt32(Myrow.Cells[3].Value) < 10 && Convert.ToString(Myrow.Cells[3].Value) != "")// Or your condition 
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Maroon;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        xy++;
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }
                }

           

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void stocks_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StockID,Product_ID as ProductID,Prod_desc as 'ProductName',StockOnHand,StockOnDelivery,DeliveryDate,ExpirationDate,StockStatus from Stocks  ORDER BY ExpirationDate ASC ", condatabase);

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
                dataGridView2.DataSource = bsource;
                loaddb.Update(dtable);
                // dataGridView3.Rows[0].Cells[0].Value = false;
                //   dataGridView2.Columns[4].DefaultCellStyle.Format = "C";

                foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                {
                    DateTime a = Convert.ToDateTime(Myrow.Cells[5].Value);
                    DateTime b = Convert.ToDateTime(DateTime.Now);
                    TimeSpan diffResult = a.Subtract(b);
                    int days = (int)diffResult.TotalMinutes;
                    int x = DateTime.Compare(a, b);

                    if (Convert.ToDateTime(Myrow.Cells[6].Value) <= Convert.ToDateTime(DateTime.Now) && Convert.ToString(Myrow.Cells[6].Value) != "")
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        //Myrow.ReadOnly = true;
                        //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        zy++;
                    }
                    else if (Convert.ToDateTime(Myrow.Cells[6].Value) > Convert.ToDateTime(DateTime.Now))
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }
                

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Product_ID + 1) as Product_ID from Products order by Product_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["Product_ID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Admin' order by Login_ID desc limit 1;";
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
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            int y = Convert.ToInt32(textBox6.Text);
            int z = x + y;
            string s = z.ToString();
            

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Products set Product_ID='" + textBox1.Text + "',Prod_desc='" + textBox2.Text + "',Prod_Category='" + comboBox1.Text + "',Quantity='" + s + "',Price='" + textBox4.Text + "'where Product_ID='" + textBox1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Product has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                xy = 0;
                product_tbl();
                if (xy > 0)
                {
                    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                }
                //getName();
                 condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Product";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label4.Text);
            newuser1.Parameters.AddWithValue("@levels", label5.Text);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            getName1();
            fillcombo();
            textBox6.Text = "0";
            textBox6.Enabled = false;
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string desc = textBox2.Text;
            string category = comboBox1.Text;
            string quantity = textBox3.Text;
            string price = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || quantity == "" || price == "" || category == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            if (quantity == "0")
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
            string newuser_sql = "INSERT INTO Products (Product_ID,Prod_desc,Quantity,Price,Prod_Category) VALUES (@Product_ID, @Prod_desc, @Quantity,@Price,@Prod_Category)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            newuser.Parameters.AddWithValue("@Quantity", quantity);
            newuser.Parameters.AddWithValue("@Price", price);
            newuser.Parameters.AddWithValue("@Prod_Category", category);
            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            //string query1 = "INSERT INTO Account(adminID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

            //MySqlCommand newquery = new MySqlCommand(query1, connection);
            //getName();
            //newquery.ExecuteNonQuery();


            //textBoxX2.Text = "";
            //textBoxX3.Text = "";
            //textBoxX4.Text = "";
            //textBoxX5.Text = "";
            //textBoxX6.Text = "";
            //connection.Close();
            //connection.Open();
           string activity = "Add Products";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label4.Text);
            newuser1.Parameters.AddWithValue("@levels", label5.Text);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            
            //transaction_tbl();
           
            xy = 0;
            product_tbl();
            if (xy > 0)
            { 
                DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            getName1();
            fillcombo();
            textBox6.Text = "0";
            textBox6.Enabled = false;
            connection.Close();
            //  panel5.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                label26.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();              
                textBox3.Text = row.Cells["Quantity"].Value.ToString();
                label28.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                comboBox1.Text = row.Cells["Category"].Value.ToString();
                textBox10.Text = row.Cells["ProductName"].Value.ToString();
                label27.Text = row.Cells["ProductName"].Value.ToString();

                textBox6.Enabled = true;
                simpleButton2.Enabled = false;
                //textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Products where Product_ID='" + textBox1.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                    while (myReader.Read())
                    {

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
                string activity = "Delete Product";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label4.Text);
                newuser1.Parameters.AddWithValue("@levels", label5.Text);
                newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                xy = 0;
                product_tbl();
                if (xy > 0)
                {
                    DialogResult dialog2 = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                }
                getName1();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "0";
                comboBox1.Items.Clear();
                textBox6.Text = "0";
                textBox6.Enabled = false;
                fillcombo();
                simpleButton2.Enabled = true;
                condatabase.Close();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            textBox6.Text = "0";
            textBox6.Enabled = false;
            simpleButton2.Enabled = true;
            fillcombo();
            getName1();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            this.Close();
          

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            product_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ProductName LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = DV;
    
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
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + comboBox2.Text + "' ", condatabase);


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

        private void PRODUCTS_Load(object sender, EventArgs e)
        {
            if (xy > 0)
            {
                //int ab = 0;
               // ab = xy - 1;
                DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            }
            if (zy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                DialogResult dialog = XtraMessageBox.Show("Number of Expired Item =   " + zy, "Confirmation", MessageBoxButtons.OKCancel);
            }
            // int x = ab - 1;
            product_tbl();
            stocks_tbl();
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label6.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
            }
        }

        private void addStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = label26.Text;
            string y = label27.Text;
            string z = label28.Text;

            textBox8.Text = x;
            textBox7.Text = y;
            textBox9.Text = z;
            

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string ids = textBox8.Text;
            string desc = textBox7.Text;
            string stockon = textBox9.Text;
            string stockdeli = textBox11.Text;
            string delidate = dateTimePicker1.Text;
            string expidate = dateTimePicker2.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || stockon == "" || stockdeli == "" )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            if (stockdeli == "0")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
                return;
            }
            if (delidate == expidate)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please change the delivery date or expiration date");
                return;
            }

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO Stocks (Product_ID,Prod_desc,StockOnHand,StockOnDelivery,DeliveryDate,ExpirationDate) VALUES (@Product_ID, @Prod_desc,@StockOnHand,@StockOnDelivery,@DeliveryDate,@ExpirationDate)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            newuser.Parameters.AddWithValue("@StockOnHand", stockon);
            newuser.Parameters.AddWithValue("@StockOnDelivery", stockdeli);
            newuser.Parameters.AddWithValue("@DeliveryDate", delidate);
            newuser.Parameters.AddWithValue("@ExpirationDate", expidate);
            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            //string query1 = "update Management.Products set Product_ID='" + textBox1.Text + "',Prod_desc='" + textBox2.Text + "',Prod_Category='" + comboBox1.Text + "',Quantity='" + s + "',Price='" + textBox4.Text + "'where Product_ID='" + textBox1.Text + "' ;";

            //MySqlCommand newquery = new MySqlCommand(query1, connection);

            //newquery.ExecuteNonQuery();


            //textBoxX2.Text = "";
            //textBoxX3.Text = "";
            //textBoxX4.Text = "";
            //textBoxX5.Text = "";
            //textBoxX6.Text = "";
            //connection.Close();
            ////connection.Open();
            //string activity = "Add Products";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label4.Text);
            //newuser1.Parameters.AddWithValue("@levels", label5.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }

            //transaction_tbl();

            //xy = 0;
       
            //if (xy > 0)
            //{
            //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            //}
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            getName1();
            fillcombo();
            textBox6.Text = "0";
            textBox6.Enabled = false;
            product_tbl();
            stocks_tbl();
            connection.Close();
            //  panel5.Visible = false;
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stocks_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ProductName LIKE '%{0}%'", textBox10.Text);
            dataGridView2.DataSource = DV;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            stocks_tbl();
            product_tbl();
        }

        private void updateInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = label30.Text;
            string b = label31.Text;
            string c = label32.Text;
            string d = label33.Text;
            string f = label34.Text;
            string g = label29.Text;
           

            if (a == "" || b == "" || c == "" || d == "" || g == "" )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Choose the Stocks you want to add in your inventory");
                return;
            }
            if (f == "Completed")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Stocks has been already added in your Inventory");
                return;
            }
            if (f == "Completed")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Stocks has been already added in your Inventory");
                return;
            }
            if (Convert.ToDateTime(d) > DateTime.Now)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Delivery is not in the store yet");
                return;
            }


            int x = Convert.ToInt32(label29.Text);
            int y = Convert.ToInt32(label30.Text);
            int z = x + y;
            string s = z.ToString();


            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Products set Quantity='" + s + "'where Product_ID='" + label32.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Stocks has been Updated!");
                while (myReader.Read())
                {

                }
                condatabase.Close();
                condatabase.Open();

                string query1 = "update Management.Stocks set StockOnDelivery='" + "0" + "',StockOnHand='" + s + "',StockStatus='" + "Completed" +  "'where StockID='" + label31.Text + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                newquery.ExecuteNonQuery();

                xy = 0;
                product_tbl();
                if (xy > 0)
                {
                    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                }
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //condatabase.Open();
          
            {
            }
            //account_tbl();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            getName1();
            fillcombo();
            stocks_tbl();
            textBox6.Text = "0";
            textBox6.Enabled = false;
            product_tbl();
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                label29.Text = row.Cells["StockOnHand"].Value.ToString();
                label30.Text = row.Cells["StockOnDelivery"].Value.ToString();
                label31.Text = row.Cells["StockID"].Value.ToString();
                label32.Text = row.Cells["ProductID"].Value.ToString();
                label33.Text = row.Cells["Deliverydate"].Value.ToString();
                label34.Text = row.Cells["StockStatus"].Value.ToString();
                label35.Text = row.Cells["Expirationdate"].Value.ToString();
                textBox14.Text = row.Cells["Expirationdate"].Value.ToString();
                textBox12.Text = row.Cells["ProductID"].Value.ToString();
                label40.Text = row.Cells["StockOnHand"].Value.ToString();
            }
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip2.Show(dataGridView2, e.X, e.Y);
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void removeExpiredProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string d = label35.Text;

            if (Convert.ToDateTime(d) > DateTime.Now)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Stock is not yet Expired");
                return;
            }

            if (Convert.ToDateTime(d) <= DateTime.Now)
            {
                //panel8.Location = new Point(0, 10);
                panel8.Visible = true;
            }


        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(label40.Text);
            int y = Convert.ToInt32(textBox13.Text);
            int expi = Convert.ToInt32(textBox13.Text);
            int deli = Convert.ToInt32(label30.Text);
            int z = x - y;
            string s = z.ToString();

            if(expi > deli )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The Entered Quantity is Greater than Delivered Items on that Stock");
                    return;
            }

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Products set Quantity='" + s + "'where Product_ID='" + label32.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Expired Products has been Removed!");
                while (myReader.Read())
                {

                }
                condatabase.Close();
                condatabase.Open();

                string query1 = "delete from Management.Stocks where StockID='" + label31.Text + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                newquery.ExecuteNonQuery();

                xy = 0;
                product_tbl();
                if (xy > 0)
                {
                    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                }
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //condatabase.Open();

            {
            }
            //account_tbl();
            panel8.Visible = false;
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            getName1();
            fillcombo();
            stocks_tbl();
            textBox6.Text = "0";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox6.Enabled = false;
            product_tbl();
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                label29.Text = row.Cells["StockOnHand"].Value.ToString();
                label30.Text = row.Cells["StockOnDelivery"].Value.ToString();
                label31.Text = row.Cells["StockID"].Value.ToString();
                label32.Text = row.Cells["ProductID"].Value.ToString();
                label33.Text = row.Cells["Deliverydate"].Value.ToString();
                label34.Text = row.Cells["StockStatus"].Value.ToString();
                label35.Text = row.Cells["Expirationdate"].Value.ToString();
                textBox14.Text = row.Cells["Expirationdate"].Value.ToString();
                textBox12.Text = row.Cells["ProductID"].Value.ToString();
                label40.Text = row.Cells["StockOnHand"].Value.ToString();
            }
        }

        private void dataGridView2_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip2.Show(dataGridView2, e.X, e.Y);
            }
        }
    }
}