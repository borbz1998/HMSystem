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
    public partial class ACCOUNT : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public ACCOUNT()
        {
            InitializeComponent();
            getName();
            getName1();
            Account_tbl();
            Staff_tbl();
            fillcombo();
            getName2();
            timer1.Start();
        }
        DataTable dtable;
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
            string eug = "select (Account_ID + 1) as Account_ID from Account order by Account_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox5.Text = reader["Account_ID"].ToString();
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
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (StaffID + 1) as StaffID from Staffs order by StaffID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox10.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        void Account_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select S.StaffID as 'StaffID', A.Account_ID , S.Firstname as 'First Name', S.Lastname as 'Last Name', S.Birthday, S.address,S.userlevel, S.contactno, A.Username, A.Passwords from Staffs S INNER JOIN Account A on S.StaffID = A.StaffID ", condatabase);



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
        void Staff_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * from Staffs ", condatabase);



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
        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from StaffLevel";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("userlevel");
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string ids = textBox5.Text;
            string lname = textBox6.Text;
            string age = textBox2.Text;
            string user = textBox3.Text;
            string staffids = textBox10.Text;
            string contactno = textBox9.Text;
            string address = textBox7.Text;
            string pass = textBox4.Text;
            string userlevs = comboBox1.Text;
            string bday = dateTimePicker1.Text;

           

            if (comboBox1.Text == "Admin")
            {
                if (lname == "" || fname == "" || user == "" || pass == "" || contactno == "" || address == "")
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
                string newuser_sql = "INSERT INTO Staffs (StaffID,Firstname,Lastname,Birthday,address,userlevel,contactno) VALUES (@ids,@fname, @lname, @Birthday,@address,@userlevel,@contactno)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", staffids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@Birthday", bday);
                newuser.Parameters.AddWithValue("@address", address);
                newuser.Parameters.AddWithValue("@userlevel", userlevs);
                newuser.Parameters.AddWithValue("@contactno", contactno);
                //newuser.Parameters.AddWithValue("@accID", ids);
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Admin Registered");
                int staffids2 = Convert.ToInt32(textBox10.Text);

                string query1 = "INSERT INTO Account(Account_ID,StaffID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + staffids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                getName();
                newquery.ExecuteNonQuery();


                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();

                connection.Close();
                connection.Open();
                string activity = "Add Admin";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                connection.Close();
                Account_tbl();
            }
            if (comboBox1.Text == "Cashier")
            {
                if (lname == "" || fname == "" || user == "" || pass == "" || contactno == "" || address == "")
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
                string newuser_sql = "INSERT INTO Staffs (StaffID,Firstname,Lastname,Birthday,address,userlevel,contactno) VALUES (@ids,@fname, @lname, @Birthday,@address,@userlevel,@contactno)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", staffids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@Birthday", bday);
                newuser.Parameters.AddWithValue("@address", address);
                newuser.Parameters.AddWithValue("@userlevel", userlevs);
                newuser.Parameters.AddWithValue("@contactno", contactno);
                //newuser.Parameters.AddWithValue("@accID", ids);
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Cashier Registered");
                int staffids2 = Convert.ToInt32(textBox10.Text);

                string query1 = "INSERT INTO Account(Account_ID,StaffID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + staffids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                getName();
                newquery.ExecuteNonQuery();


                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();

                connection.Close();
                connection.Open();
                string activity = "Add Cashier";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                connection.Close();
                Account_tbl();
            }
            if (comboBox1.Text == "Receptionist")
            {
                if (lname == "" || fname == "" || user == "" || pass == "" || contactno == "" || address == "")
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
                string newuser_sql = "INSERT INTO Staffs (StaffID,Firstname,Lastname,Birthday,address,userlevel,contactno) VALUES (@ids,@fname, @lname, @Birthday,@address,@userlevel,@contactno)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", staffids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@Birthday", bday);
                newuser.Parameters.AddWithValue("@address", address);
                newuser.Parameters.AddWithValue("@userlevel", userlevs);
                newuser.Parameters.AddWithValue("@contactno", contactno);
                //newuser.Parameters.AddWithValue("@accID", ids);
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Cashier Registered");
                int staffids2 = Convert.ToInt32(textBox10.Text);

                string query1 = "INSERT INTO Account(Account_ID,StaffID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + staffids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                getName();
                newquery.ExecuteNonQuery();


                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();

                connection.Close();
                connection.Open();
                string activity = "Add Receptionist";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                connection.Close();
                Account_tbl();
            }
            if (comboBox1.Text == "Staff")
            {
                if (lname == "" || fname == "" || contactno == "" || address == "")
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
                string newuser_sql = "INSERT INTO Staffs (StaffID,Firstname,Lastname,Birthday,address,userlevel,contactno) VALUES (@ids,@fname, @lname, @Birthday,@address,@userlevel,@contactno)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", staffids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@Birthday", bday);
                newuser.Parameters.AddWithValue("@address", address);
                newuser.Parameters.AddWithValue("@userlevel", userlevs);
                newuser.Parameters.AddWithValue("@contactno", contactno);
                //newuser.Parameters.AddWithValue("@accID", ids);
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Staff Registered");

                //string query1 = "INSERT INTO Account(Account_ID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

                //MySqlCommand newquery = new MySqlCommand(query1, connection);
                ////getName();
                //newquery.ExecuteNonQuery();


                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();



                connection.Close();
                connection.Open();
                string activity = "Add Staff";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels",level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                connection.Close();
                Account_tbl();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.Text == "Cashier")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.Text == "Receptionist")
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.Text == "Staff")
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Account")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
            }
            if (comboBox2.Text == "Staff")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox10.Text = row.Cells["StaffID"].Value.ToString();
                textBox1.Text = row.Cells["FirstName"].Value.ToString();
                textBox6.Text = row.Cells["LastName"].Value.ToString();
                textBox2.Text = row.Cells["Birthday"].Value.ToString();
                textBox7.Text = row.Cells["address"].Value.ToString();
                textBox9.Text = row.Cells["contactno"].Value.ToString();
                comboBox1.Text = row.Cells["userlevel"].Value.ToString();
                //textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox10.Text = row.Cells["StaffID"].Value.ToString();
                textBox1.Text = row.Cells["First Name"].Value.ToString();
                textBox6.Text = row.Cells["Last Name"].Value.ToString();
                textBox2.Text = row.Cells["Birthday"].Value.ToString();
                textBox7.Text = row.Cells["address"].Value.ToString();
                textBox9.Text = row.Cells["contactno"].Value.ToString();
                comboBox1.Text = row.Cells["userlevel"].Value.ToString();
                textBox5.Text = row.Cells["Account_ID"].Value.ToString();
                textBox4.Text = row.Cells["Username"].Value.ToString();
                textBox3.Text = row.Cells["Passwords"].Value.ToString();
                //textBox3.Enabled = true;
                simpleButton2.Enabled = false;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                string Query = "update Management.Staffs set StaffID='" + textBox10.Text + "',Firstname='" + textBox1.Text + "',Lastname='" + textBox6.Text + "',Birthday='" + dateTimePicker1.Text + "',address='" + textBox7.Text + "',userlevel='" + comboBox1.Text + "',contactno='" + textBox9.Text + "'where StaffID='" + textBox10.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Staff has been Updated!");
                    while (myReader.Read())
                    {

                    }
                    condatabase.Close();
                    condatabase.Open();

                    string query1 = "update Management.Account set AccountName='" + textBox1.Text + ',' + textBox6.Text + "', username='" + textBox3.Text + "',passwords='" + textBox4.Text + "'where Account_ID='" + textBox5.Text + "' ;";

                    MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                    newquery.ExecuteNonQuery();


                  
                    condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                condatabase.Open();
                string activity = "Update Account";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
                condatabase.Close();
            }
            if (comboBox1.Text == "Cashier")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                string Query = "update Management.Staffs set StaffID='" + textBox10.Text + "',Firstname='" + textBox1.Text + "',Lastname='" + textBox6.Text + "',Birthday='" + dateTimePicker1.Text + "',address='" + textBox7.Text + "',userlevel='" + comboBox1.Text + "',contactno='" + textBox9.Text + "'where StaffID='" + textBox10.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Staff has been Updated!");
                    while (myReader.Read())
                    {

                    }
                    condatabase.Close();
                    condatabase.Open();

                    string query1 = "update Management.Account set AccountName='" + textBox1.Text + ',' + textBox6.Text + "', username='" + textBox3.Text + "',passwords='" + textBox4.Text + "'where Account_ID='" + textBox5.Text + "' ;";

                    MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                    newquery.ExecuteNonQuery();


                    getName();
                    condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                condatabase.Open();
                string activity = "Update Account";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text); 
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
                condatabase.Close();
            }
            if (comboBox1.Text == "Receptionist")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                string Query = "update Management.Staffs set StaffID='" + textBox10.Text + "',Firstname='" + textBox1.Text + "',Lastname='" + textBox6.Text + "',Birthday='" + dateTimePicker1.Text + "',address='" + textBox7.Text + "',userlevel='" + comboBox1.Text + "',contactno='" + textBox9.Text + "'where StaffID='" + textBox10.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Staff has been Updated!");
                    while (myReader.Read())
                    {

                    }
                    condatabase.Close();
                    condatabase.Open();

                    string query1 = "update Management.Account set AccountName='" + textBox1.Text + ',' + textBox6.Text + "', username='" + textBox3.Text + "',passwords='" + textBox4.Text + "'where Account_ID='" + textBox5.Text + "' ;";

                    MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                    newquery.ExecuteNonQuery();


                    getName();
                    condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                condatabase.Open();
                string activity = "Update Account";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
                condatabase.Close();
            }
            if (comboBox1.Text == "Staff")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                string Query = "update Management.Staffs set StaffID='" + textBox10.Text + "',Firstname='" + textBox1.Text + "',Lastname='" + textBox6.Text + "',Birthday='" + dateTimePicker1.Text + "',address='" + textBox7.Text + "',userlevel='" + comboBox1.Text + "',contactno='" + textBox9.Text + "'where StaffID='" + textBox10.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Staff has been Updated!");
                    while (myReader.Read())
                    {

                    }
                    condatabase.Close();
                    //condatabase.Open();

                    //string query1 = "update Management.Account set AccountName='" + textBox1.Text + ',' + textBox6.Text + "', username='" + textBox3.Text + "',passwords='" + textBox4.Text + "'where Account_ID='" + textBox5.Text + "' ;";

                    //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                    //newquery.ExecuteNonQuery();


                    //getName();
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                condatabase.Open();
                string name = "Borbe,Charlie";
                string level = "Admin";
                string activity = "Update Staff";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                //account_tbl();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                getName();
                getName1();
                comboBox1.Items.Clear();
                fillcombo();
                Account_tbl();
                Staff_tbl();
                condatabase.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
        
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                if (comboBox1.Text == "Admin")
                {
                    string Query = "delete from Management.Staffs where StaffID='" + textBox10.Text + "' ;";

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

                        string Query1 = "delete from Management.Account where Account_ID='" + textBox5.Text + "' ;";
                        MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                        newquery.ExecuteNonQuery();

                        //account_tbl();

                        condatabase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    condatabase.Open();
                    string name = "Borbe,Charlie";
                    string level = "Admin";
                    string activity = "Delete Admmin";
                    string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", name);
                    newuser1.Parameters.AddWithValue("@levels", level);
                    newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                    getName();
                    getName1();
                    comboBox1.Items.Clear();
                    fillcombo();
                    Account_tbl();
                    Staff_tbl();
                    simpleButton2.Enabled = true;
                    condatabase.Close();
                }
                if (comboBox1.Text == "Cashier")
                {
                    string Query = "delete from Management.Staffs where StaffID='" + textBox10.Text + "' ;";

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

                        string Query1 = "delete from Management.Account where Account_ID='" + textBox5.Text + "' ;";
                        MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                        newquery.ExecuteNonQuery();

                        //account_tbl();

                        condatabase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    condatabase.Open();
                    string activity = "Delete Cashier";
                    string name = "Borbe,Charlie";
                    string level = "Admin";
                    string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", name);
                    newuser1.Parameters.AddWithValue("@levels", level);
                    newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                    getName();
                    getName1();
                    comboBox1.Items.Clear();
                    fillcombo();
                    Account_tbl();
                    Staff_tbl();
                    simpleButton2.Enabled = true;
                    condatabase.Close();
                }
                if (comboBox1.Text == "Staff")
                {
                    string Query = "delete from Management.Staffs where StaffID='" + textBox10.Text + "' ;";

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

                        string Query1 = "delete from Management.Account where Account_ID='" + textBox5.Text + "' ;";
                        MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                        newquery.ExecuteNonQuery();

                        //account_tbl();

                        condatabase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    condatabase.Open();
                    string name = "Borbe,Charlie";
                    string level = "Admin";
                    string activity = "Delete Staff";
                    string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", name);
                    newuser1.Parameters.AddWithValue("@levels", level);
                    newuser1.Parameters.AddWithValue("@act1", textBox10.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                    getName();
                    getName1();
                    comboBox1.Items.Clear();
                    fillcombo();
                    Account_tbl();
                    Staff_tbl();
                    simpleButton2.Enabled = true;
                    condatabase.Close();
                }

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            getName();
            getName1();
            comboBox1.Items.Clear();
            fillcombo();
            Account_tbl();
            Staff_tbl();
            simpleButton2.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label17.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Random slumpGenerator = new Random(); int tals;
            tals = slumpGenerator.Next(0, 100);
            //string x = string.Concat(textBox1.Text, " . ", textBox6.Text,tals.ToString());
            textBox3.Text = string.Concat(textBox1.Text, ".", textBox6.Text, tals.ToString());

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Random slumpGenerator = new Random(); int tals;
            tals = slumpGenerator.Next(0, 100);
            //string x = string.Concat(textBox1.Text, " . ", textBox6.Text,tals.ToString());
            textBox3.Text = string.Concat(textBox1.Text,".",textBox6.Text, tals.ToString());

            Random slumpGenerator2 = new Random(); int tal;
            tal = slumpGenerator2.Next(0, 1000);
            textBox4.Text = string.Concat(textBox1.Text,tal.ToString());
        }
    }
}