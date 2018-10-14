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
    public partial class Login : DevExpress.XtraEditors.XtraForm

    {
        private int counter = 10;
        private string conn;
        private MySqlConnection connect;
        
        public Login()
        {
            InitializeComponent();
            timer1.Start();
            
            
            
           


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
        public bool tryLogin(string uname, string pword)
        {
            string user = username.Text;
            string pass = password.Text;
            db_connection();
            conn = "Server=localhost;Database=Management;Uid=root;Pwd=;";

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Account WHERE Username = '" + user + "' AND passwords ='" + pass + "';", connect);

            cmd.Connection = connect;
            connect = new MySqlConnection(conn);


            MySqlDataReader reader = cmd.ExecuteReader();
            connect.Open();


            if (reader.Read() != false)
            {
                if (reader.IsDBNull(0) == true)
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
                else
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
            }
            else
            {

                return false;

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer3.Start();
            this.AcceptButton = simpleButton1;
            simpleButton1.Enabled = !string.IsNullOrEmpty(username.Text) || !string.IsNullOrEmpty(password.Text);
            label2.Text = DateTime.Now.ToString("MMMM dd, yyyy");


            label4.Text = DateTime.Now.ToString("dddd");
            this.BackColor = System.Drawing.Color.MidnightBlue;
            



        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            simpleButton1.Enabled = !string.IsNullOrEmpty(password.Text);
            
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            simpleButton1.Enabled = !string.IsNullOrEmpty(username.Text);
            
        }
        private int i;
        private void simpleButton1_Click(object sender, EventArgs e)
        {

   

            db_connection();
            string user = username.Text;
            string pass = password.Text;
            string x = Convert.ToString(DateTime.Now);
            if (tryLogin(username.Text, password.Text) == true)
            {
                conn = "Server=localhost;Database=Management;Uid=root;Pwd=;";
                MySqlCommand cmd2 = new MySqlCommand("SELECT userlevel,AccountName,Account_ID FROM Account WHERE Username = '" + user + "';", connect);

                cmd2.Connection = connect;

                object accessCode = cmd2.ExecuteScalar();
                if (accessCode != null && accessCode != DBNull.Value)
                {
                    if (accessCode.ToString() == "Admin")
                    {
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read() == true)
                        {

                            labelname.Text = reader["AccountName"].ToString();
                            reader.Read();
                          //  reader.Close();
                            labelid.Text = reader["Account_ID"].ToString();
                            reader.Read();
                            reader.Close();

                        }
                        //string level = "Cashier";
                        //string namex = labelname.Text;
                        string id = labelid.Text;

                        string level1 = "Admin";
                        string name = labelname.Text;
                        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                        builder.Server = "127.0.0.1";
                        builder.UserID = "root";
                        builder.Password = "";
                        builder.Database = "Management";
                        MySqlConnection connection = new MySqlConnection(builder.ToString());
                        connection.Open();
                        

                        string newbook_sql = "INSERT INTO LOGIN(AccountName,login_username,login_pass,userlevel,DateTimeIn,StaffID) values ('" + name + "','" + user + "','" + pass + "','" + level1 + "','" + x + "','" + id + "');";

                        MySqlCommand newbook = new MySqlCommand(newbook_sql, connect);
                        MySqlDataReader myReader;
                        try
                        {

                            myReader = newbook.ExecuteReader();
                            while (myReader.Read())
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connect.Close();
                        }
                        this.Hide();
                        AdminButtons admins = new AdminButtons();
                       
                        toastNotificationsManager1.ShowNotification(toastNotificationsManager2.Notifications[0]);
                        admins.Show();


                        username.Text = "";
                        password.Text = "";
                    
                    }

                    if (accessCode.ToString() == "Cashier")
                    {
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read() == true)
                        {

                            labelname.Text = reader["AccountName"].ToString();
                            reader.Read();
                            labelid.Text = reader["Account_ID"].ToString();
                            reader.Read();
                            reader.Close();

                        }

                        string level = "Cashier";
                        string namex = labelname.Text;
                        string id = labelid.Text;
                       
                        username.Text = "";
                        password.Text = "";

                        string newbook_sql = "INSERT INTO LOGIN(AccountName,login_username,login_pass,userlevel,DateTimeIn,StaffID) values ('" + namex + "','" + user + "','" + pass + "','" + level + "','" + x + "','" + id + "');";

                        MySqlCommand newbook = new MySqlCommand(newbook_sql, connect);
                        MySqlDataReader myReader;
                        try
                        {

                            myReader = newbook.ExecuteReader();
                            while (myReader.Read())
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connect.Close();
                        }
                        this.Hide();
                        POSFORM gg = new POSFORM();

                        toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        gg.Show();

                    }
                    if (accessCode.ToString() == "Receptionist")
                    {
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read() == true)
                        {

                            labelname.Text = reader["AccountName"].ToString();
                            reader.Read();
                            labelid.Text = reader["Account_ID"].ToString();
                            reader.Read();
                            reader.Close();

                        }

                        string level = "Receptionist";
                        string namex = labelname.Text;
                        string id = labelid.Text;

                        username.Text = "";
                        password.Text = "";

                        string newbook_sql = "INSERT INTO LOGIN(AccountName,login_username,login_pass,userlevel,DateTimeIn,StaffID) values ('" + namex + "','" + user + "','" + pass + "','" + level + "','" + x + "','" + id + "');";

                        MySqlCommand newbook = new MySqlCommand(newbook_sql, connect);
                        MySqlDataReader myReader;
                        try
                        {

                            myReader = newbook.ExecuteReader();
                            while (myReader.Read())
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connect.Close();
                        }
                        this.Hide();
                        CashierMainform gg = new CashierMainform();

                        toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        gg.Show();

                    }



                }
                i = 0;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid Login Credential");
                i++;
                username.Text = "";
                password.Text = "";
            }
            if (i == 3)
            {
                panelControl1.Visible = true;
                timer2.Start();
                username.Enabled = false;
                password.Enabled = false;
                connect.Close();
                i = 0;   
            }
  

        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("Are you sure do you want to exit?", "Confirmation", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result1 == DialogResult.No)
            {
            }
        }

        private void well(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void played(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label3.Text = DateTime.Now.ToString("hh:mm tt");

            reflectionLabel2.Location = new Point(reflectionLabel2.Location.X - 5, reflectionLabel2.Location.Y);

            if(reflectionLabel2.Location.X < -520)
            {
                reflectionLabel2.Location = new Point(0 + 50, reflectionLabel2.Location.Y);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer2.Stop();
            label6.Text = counter.ToString();

            if (counter == 0)
            {
                
                username.Enabled = true;
                password.Enabled = true;
                connect.Close();
                panelControl1.Visible = false;
                counter = 10;
                label6.Text = "10";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox5.Visible = true;
            }
            else if(pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
            }
            else if(pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox3.Visible = true;
            }
        }
    }
    }
        