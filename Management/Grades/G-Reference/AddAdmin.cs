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
    public partial class AddAdmin : DevExpress.XtraEditors.XtraForm
    {
       
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public AddAdmin()
        {
            InitializeComponent();
            account_tbl();
            admin_tbl();
            getName();
            getName1();
            admin_tbl();
        }
        DataTable dtable;
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();


            }
            catch (MySqlException)
            {
                throw;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getName1()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Admin' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label7.Text = reader["login_name"].ToString();
            reader.Read();
            label8.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBoxX1.Text;
            string lname = textBoxX2.Text;
            string fname = textBoxX3.Text;
            string age = textBoxX4.Text;
            string user = textBoxX6.Text;
            string pass = textBoxX5.Text;
            string userlevs = "Admin";

            if (lname == "" || fname == "" || age == "" || user == "" || pass == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO admins (adminID,admin_lname,admin_fname,admin_age) VALUES (@ids, @lname, @fname,@age)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@ids", ids);
            newuser.Parameters.AddWithValue("@lname", lname);
            newuser.Parameters.AddWithValue("@fname", fname);
            newuser.Parameters.AddWithValue("@age", age);
            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("New Admin Registered");

            string query1 = "INSERT INTO Account(adminID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

            MySqlCommand newquery = new MySqlCommand(query1, connection);
            getName();
            newquery.ExecuteNonQuery();


            textBoxX2.Text = "";
            textBoxX3.Text = "";
            textBoxX4.Text = "";
            textBoxX5.Text = "";
            textBoxX6.Text = "";
            connection.Close();
            connection.Open();
            string activity = "Add Admmin";
            string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label7.Text);
            newuser1.Parameters.AddWithValue("@levels", label8.Text);
            newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            account_tbl();
            connection.Close();
        }
        private void getName()
        {
        
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select (adminID + 1) as adminID from admins order by adminID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBoxX1.Text = reader["adminID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        void account_tbl()
        {

            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select adminID,admin_lname as 'LastName',admin_fname as 'FirstName',admin_age as 'Age' from admins ", condatabase);


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
        void admin_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select adminID,Username,Passwords as 'Password',AccountName from account where userlevel = 'Admin' ", condatabase);


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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            string Query = "update GradingSystem.admins set admin_lname='" + textBoxX2.Text + "',admin_fname='" + textBoxX3.Text + "',admin_age='" + textBoxX4.Text + "'where adminID='" + textBoxX1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Admin has been Updated!");
                while (myReader.Read())
                {

                }
                condatabase.Close();
                condatabase.Open();

                string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                newquery.ExecuteNonQuery();

                account_tbl();
                getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Student";
            string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label7.Text);
            newuser1.Parameters.AddWithValue("@levels", label8.Text);
            newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            account_tbl();
            condatabase.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxX1.Text = row.Cells["AdminID"].Value.ToString();
                textBoxX2.Text = row.Cells["LastName"].Value.ToString();
                textBoxX3.Text = row.Cells["FirstName"].Value.ToString();
                textBoxX4.Text = row.Cells["Age"].Value.ToString();
                simpleButton3.Enabled = true;
                simpleButton4.Enabled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from GradingSystem.Admins where adminID='" + textBoxX1.Text + "' ;";

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
                    condatabase.Open();

                    string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    newquery.ExecuteNonQuery();

                    account_tbl();
                    getName();
                    condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                condatabase.Open();
                string activity = "Delete Admmin";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label7.Text);
                newuser1.Parameters.AddWithValue("@levels", label8.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                account_tbl();
                condatabase.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Admin Information")
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                account_tbl();

            }
            if (comboBox1.SelectedItem.ToString() == "Admin Account")
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                admin_tbl();

            }
        }
           
            private void AddAdmin_Load(object sender, EventArgs e)
            {
                account_tbl();
            }

    
    }
    }
