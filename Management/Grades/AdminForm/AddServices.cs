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
    public partial class AddServices : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public AddServices()
        {
            InitializeComponent();
            services_Tbl();
            
            getName1();
            getName();
            timer1.Start();
        }
        DataTable dtable;


        private void getName()
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
                    comboBox1.Items.Add(sname);
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
        void services_Tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Services_ID as ServiceID, Service_desc as ServiceName, Service_Category as ServiceCategory,Price from Services ", condatabase);



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
                dataGridView1.Columns[3].DefaultCellStyle.Format = "C";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Services_ID + 1) as Services_ID from Services order by Services_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["Services_ID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ServiceID"].Value.ToString();
                textBox2.Text = row.Cells["ServiceName"].Value.ToString();
                ///  textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                comboBox1.Text = row.Cells["ServiceCategory"].Value.ToString();
                //textBox3.Enabled = true;
                simpleButton2.Enabled = false;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string desc = textBox2.Text;
            string category = comboBox1.Text;
            //string quantity = textBox3.Text;
            string price = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || price == "" || category == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO Services (Services_ID,Service_desc,Price,Service_Category) VALUES (@Product_ID, @Prod_desc,@Price,@Prod_Category)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            //newuser.Parameters.AddWithValue("@Quantity", quantity);
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
            string activity = "Add Services";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels", level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            services_Tbl();
            //transaction_tbl();
            connection.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";

            comboBox1.SelectedItem = -1;
            getName1();
            //fillcombo();
            //  panel5.Visible = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Services set Services_ID='" + textBox1.Text + "',Service_desc='" + textBox2.Text + "',Service_Category='" + comboBox1.Text + "',Price='" + textBox4.Text + "'where Services_ID='" + textBox1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Services has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                services_Tbl();
                //getName();
                 condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Services";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels", level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            simpleButton2.Enabled = true;
            comboBox1.SelectedItem = -1;

            //fillcombo();
            condatabase.Close();
            getName1();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Services where Services_ID='" + textBox1.Text + "' ;";

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
                string activity = "Delete Services";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                services_Tbl();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                simpleButton2.Enabled = true;
                comboBox1.SelectedItem = -1;

                //fillcombo();
                getName1();
                condatabase.Close();
               

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            services_Tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ServiceName LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = DV;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                services_Tbl();
            }

            else {
                services_Tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Services_ID as ServiceID,Service_desc as ServiceName,Service_Category as ServiceCategory ,Price from Services where Service_Category = '" + comboBox2.Text + "' ", condatabase);


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

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
           //textBox3.Text = "0";
            comboBox1.Items.Clear();
     
            comboBox1.Items.Add("Package");
            comboBox1.Items.Add("Ala Carte Services");
            comboBox1.Items.Add("Add-On Services");
            simpleButton2.Enabled = true;
            //fillcombo();
            getName1();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label6.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }
    }
}