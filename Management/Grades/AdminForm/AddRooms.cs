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
    public partial class AddRooms : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public AddRooms()
        {
            InitializeComponent();
            Rooms_tbl();
            getName1();
            getName();
        }
        DataTable dtable;

        void Rooms_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Room_ID as RoomID,Room_Name as RoomName,Room_Type as RoomType,Room_Status as RoomStatus from Rooms ", condatabase);



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

                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                //{

                //    //Here 2 cell is target value and 1 cell is Volume
                //    if (Convert.ToDateTime(Myrow.Cells[5].Value) >= DateTime.Now && Convert.ToString(Myrow.Cells[5].Value) != "")// Or your condition 
                //    {
                //        panel1.Visible = true;
                //    }
                //    else
                //    {
                //        Myrow.DefaultCellStyle.BackColor = Color.White;
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Room_ID + 1) as RoomID from Rooms order by RoomID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["RoomID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string desc = textBox2.Text;
            string category = comboBox1.Text;
            string status = textBox3.Text;
            //string price = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || status == "" || category == "")
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
            string newuser_sql = "INSERT INTO Rooms (Room_ID,Room_Name,Room_Type,Room_Status) VALUES (@Room_ID, @Room_Name,@Room_Type,@Room_Status)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Room_ID", ids);
            newuser.Parameters.AddWithValue("@Room_Name", desc);
            //newuser.Parameters.AddWithValue("@Quantity", quantity);
            newuser.Parameters.AddWithValue("@Room_Type", category);
            newuser.Parameters.AddWithValue("@Room_Status", status);
            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("A Room has been added!");

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
            string activity = "Add Room";
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
            Rooms_tbl();
            //transaction_tbl();
            connection.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            //textBox4.Text = "";
            textBox3.Text = "Available";
            
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Regular");
            comboBox1.Items.Add("Private Suite");
            getName1();
            //fillcombo();
            //  panel5.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label6.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void AddRooms_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label6.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Rooms set Room_ID='" + textBox1.Text + "',Room_Name='" + textBox2.Text + "',Room_Type='" + comboBox1.Text + "',Room_Status='" + textBox3.Text + "'where Room_ID='" + textBox1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Room has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                Rooms_tbl();
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Rooms";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels",level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            textBox1.Text = "";
            textBox2.Text = "";
            //textBox4.Text = "";
            textBox3.Text = "Available";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Regular");
            comboBox1.Items.Add("Private Suite");
            simpleButton2.Enabled = true;
            ///fillcombo();
            condatabase.Close();
            getName1();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Rooms where Room_ID='" + textBox1.Text + "' ;";

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
                string activity = "Delete Room";
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
                Rooms_tbl();
                textBox1.Text = "";
                textBox2.Text = "";
                //textBox4.Text = "";
                textBox3.Text = "Available";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Regular");
                comboBox1.Items.Add("Private Suite");
                simpleButton2.Enabled = true;
                //fillcombo();
                getName1();
                condatabase.Close();


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["RoomID"].Value.ToString();
                textBox2.Text = row.Cells["RoomName"].Value.ToString();
                //textBox3.Text = row.Cells["Room_Type"].Value.ToString();
                textBox3.Text = row.Cells["RoomStatus"].Value.ToString();
                comboBox1.Text = row.Cells["RoomType"].Value.ToString();
                //textBox3.Enabled = true;
                 simpleButton2.Enabled = false;
                //  simpleButton4.Enabled = true;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            //textBox4.Text = "";
            textBox3.Text = "Available";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Regular");
            comboBox1.Items.Add("Private Suite");
            //fillcombo();
            getName1();
            simpleButton2.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Rooms_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = DV;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                Rooms_tbl();
            }

            else {
                Rooms_tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Room_ID as RoomID,Room_Name as RoomName,Room_Type as RoomType,Room_Status as RoomStatus from Rooms where Room_Type = '" + comboBox2.Text + "' ", condatabase);


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
    }
}