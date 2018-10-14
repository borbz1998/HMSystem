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
    public partial class CustomerForm : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public CustomerForm()
        {
            InitializeComponent();
            Customer_tbl();
            getName();
            getName1();
            getName2();
            fillcombo();
        }
        DataTable dtable;


        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from petinfo where Customer_Name='" + textBox2.Text + "' ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Pet_Name");
                    // comboBox1.Items.Add(sname);
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
        void Customer_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Customer_ID as CustomerID,Customer_Name as CustomerName,Contact_No as ContactNumber,Email_Address as EmailAddress from Customer ", condatabase);



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

        void PetInfo_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Pet_ID as PetID,Customer_ID as CustomerID,Customer_Name as CustomerName,Pet_Name as PetName,Breed from PetInfo ", condatabase);



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
            string eug = "select (Customer_ID + 1) as CustomerID from Customer order by CustomerID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["CustomerID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Pet_ID + 1) as PetID from PetInfo order by PetID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox11.Text = reader["PetID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string owner = textBox2.Text;
            string pet = textBox9.Text;
            string breed = textBox12.Text;
            string x = textBox3.Text;
            string contactno = label27.Text + x;
            string email = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || owner == "" ||  contactno == "" || email == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            //if (quantity == "0")
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
            //    return;
            //}
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO Customer (Customer_ID,Customer_Name,Contact_No,Email_Address) VALUES (@Customer_ID, @Customer_Name,@Contact_No,@Email_Address)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Customer_ID", ids);
            newuser.Parameters.AddWithValue("@Customer_Name", owner);
            //newuser.Parameters.AddWithValue("@Pet_Name", pet);
            //newuser.Parameters.AddWithValue("@Breed", breed);
            newuser.Parameters.AddWithValue("@Contact_No", contactno);
            newuser.Parameters.AddWithValue("@Email_Address", email);
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
            string activity = "Add Customer";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            Customer_tbl();
            connection.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string owner = textBox2.Text;
            string pet = textBox9.Text;
            string breed = textBox12.Text;
            string x = textBox3.Text;
            string contactno = label27.Text + x;
            string email = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || owner == "" || contactno == "" || email == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
           
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Customer set Customer_ID='" + textBox1.Text + "',Customer_Name='" + textBox2.Text + "'Contact_No='" + contactno + "',Email_Address='" + textBox4.Text + "'where Customer_ID='" + textBox1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Customer Info has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Customer Info";
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
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            Customer_tbl();
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Customer where Customer_ID='" + textBox1.Text + "' ;";

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
                string activity = "Delete Customer";
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox9.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox12.Text = "";
                Customer_tbl();
                simpleButton2.Enabled = true;
                condatabase.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label3.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.Text == "" || comboBox1.Text == "CustomerInfo")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    textBox1.Text = row.Cells["CustomerID"].Value.ToString();
                    textBox2.Text = row.Cells["CustomerName"].Value.ToString();
                    //  textBox9.Text = row.Cells["Pet_Name"].Value.ToString();
                    //  textBox12.Text = row.Cells["Breed"].Value.ToString();
                    textBox3.Text = row.Cells["ContactNumber"].Value.ToString();
                    textBox4.Text = row.Cells["EmailAddress"].Value.ToString();
                    textBox10.Text = row.Cells["CustomerID"].Value.ToString();
                    textBox8.Text = row.Cells["CustomerName"].Value.ToString();

                    //textBox3.Enabled = true;
                    simpleButton2.Enabled = false;
                    //fillcombo();
                    //  simpleButton4.Enabled = true;
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            getName1();
            simpleButton2.Enabled = true;
            textBox10.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            getName2();
            comboBox2.Items.Clear();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Customer_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("CustomerName LIKE '%{0}%'", textBox5.Text);
            dataGridView2.DataSource = DV;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            textBox10.Text = textBox1.Text;
            textBox8.Text = textBox2.Text;
            groupControl1.Visible = true;
            simpleButton6.Visible = false;
            simpleButton2.Visible = false;
            simpleButton3.Visible = false;
            simpleButton4.Visible = false;
            simpleButton5.Visible = false;


        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = false;
            simpleButton6.Visible = true;
            simpleButton2.Visible = true;
            simpleButton3.Visible = true;
            simpleButton4.Visible = true;
            simpleButton5.Visible = true;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            string petids = textBox11.Text;
            string cID = textBox10.Text;
            string cname = textBox8.Text;
            string pet = textBox7.Text;
            string breed = textBox6.Text;


            if (petids == "" || cID == "" || pet == "" || breed == "" || cname == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            //if (quantity == "0")
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
            //    return;
            //}
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO PetInfo (Pet_ID,Customer_ID,Customer_Name,Pet_Name,Breed) VALUES (@Pet_ID, @Customer_ID, @Customer_Name,@Pet_Name,@Breed)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Pet_ID", petids);
            newuser.Parameters.AddWithValue("@Customer_ID", cID);
            newuser.Parameters.AddWithValue("@Customer_Name", cname);
            newuser.Parameters.AddWithValue("@Pet_Name", pet);
            newuser.Parameters.AddWithValue("@Breed", breed);

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
            string activity = "Add PetInfo";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            Customer_tbl();
            connection.Close();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            string x = textBox3.Text;
            string contactno = label27.Text + x;

            string petids = textBox11.Text;
            string cID = textBox10.Text;
            string cname = textBox8.Text;
            string pet = textBox7.Text;
            string breed = textBox6.Text;

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Customer set Pet_ID='" + petids + "',Customer_ID='" + cID + "',Customer_Name='" + cname + "',Pet_Name='" + pet + "',Breed='" + breed + "'where Pet_ID='" + petids + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Pet Info has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Pet Info";
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
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            Customer_tbl();
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.PetInfo where Pet_ID='" + textBox11.Text + "' ;";

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
                string activity = "Delete PetInfo";
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox9.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox12.Text = "";
                Customer_tbl();
                simpleButton2.Enabled = true;
                condatabase.Close();
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            getName1();
            simpleButton2.Enabled = true;
            comboBox2.Items.Clear();
            textBox10.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            getName2();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "CustomerInfo")
            {
                Customer_tbl();
            }
            if (comboBox1.Text == "PetInfo")
            {
                PetInfo_tbl();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (textBox2.Text != "")
            {
                fillcombo();
            }
            if (textBox2.Text == "")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox9.Text = "";
                textBox12.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                getName1();
                simpleButton2.Enabled = true;
                comboBox2.Items.Clear();
            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from petinfo where Pet_Name='" + comboBox2.Text + "' ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Breed");
                    // comboBox1.Items.Add(sname);
                    textBox12.Text = sname;
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}