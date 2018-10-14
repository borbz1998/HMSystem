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
    public partial class AddTeacher : DevExpress.XtraEditors.XtraForm
    {
        MySqlCommand cmd;
        static int id = 21;
        private string conn;
        private MySqlConnection connect;
        public AddTeacher()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacher_tbl();
         
            
        }
        DataTable dtable;
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
            string sql = "SELECT DISTINCT teacher_Fname FROM teachers";
            connection = new MySqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new MySqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         private void getData1(AutoCompleteStringCollection dataCollection1)
         {
             string connetionString = null;
             MySqlConnection connection;
             MySqlCommand command;
             MySqlDataAdapter adapter = new MySqlDataAdapter();
             DataSet ds = new DataSet();
             connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
             string sql = "SELECT DISTINCT teacher_lname FROM teachers";
             connection = new MySqlConnection(connetionString);
             try
             {
                 connection.Open();
                 command = new MySqlCommand(sql, connection);
                 adapter.SelectCommand = command;
                 adapter.Fill(ds);
                 adapter.Dispose();
                 command.Dispose();
                 connection.Close();
                 foreach (DataRow row in ds.Tables[0].Rows)
                 {
                     dataCollection1.Add(row[0].ToString());
                 }
             }
             catch (MySqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         private void getData2(AutoCompleteStringCollection dataCollection2)
         {
             string connetionString = null;
             MySqlConnection connection;
             MySqlCommand command;
             MySqlDataAdapter adapter = new MySqlDataAdapter();
             DataSet ds = new DataSet();
             connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
             string sql = "SELECT DISTINCT concat(teacher_fname,teacher_lname,age) FROM teachers";
             connection = new MySqlConnection(connetionString);
             try
             {
                 connection.Open();
                 command = new MySqlCommand(sql, connection);
                 adapter.SelectCommand = command;
                 adapter.Fill(ds);
                 adapter.Dispose();
                 command.Dispose();
                 connection.Close();
                 foreach (DataRow row in ds.Tables[0].Rows)
                 {
                     dataCollection2.Add(row[0].ToString());
                 }
             }
             catch (MySqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         private void getData3(AutoCompleteStringCollection dataCollection3)
         {
             string connetionString = null;
             MySqlConnection connection;
             MySqlCommand command;
             MySqlDataAdapter adapter = new MySqlDataAdapter();
             DataSet ds = new DataSet();
             connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
             string sql = "SELECT DISTINCT teacher_lname FROM teachers";
             connection = new MySqlConnection(connetionString);
             try
             {
                 connection.Open();
                 command = new MySqlCommand(sql, connection);
                 adapter.SelectCommand = command;
                 adapter.Fill(ds);
                 adapter.Dispose();
                 command.Dispose();
                 connection.Close();
                 foreach (DataRow row in ds.Tables[0].Rows)
                 {
                     dataCollection3.Add(row[0].ToString());
                 }
             }
             catch (MySqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
        private void getName()
        {
            int x = 1;
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select (teacher_ID + 1) as teacher_ID from teachers order by teacher_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBoxX1.Text = reader["teacher_ID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void AddTeacher_Load(object sender, EventArgs e)
        {
            getName();
            fname_auto();
            username_auto();
            lname_auto();
            search_lname_auto();
            getnamex();
            getuserlevs();
            
        }
        private void getnamex()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label11.Text = reader["login_name"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getuserlevs()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label12.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void fname_auto()
        {
            textBoxX3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBoxX3.AutoCompleteCustomSource = DataCollection;
        }
        private void search_lname_auto()
        {
            textBoxX8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData3(DataCollection);
            textBoxX8.AutoCompleteCustomSource = DataCollection;
        }
        private void lname_auto()
        {
            textBoxX2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getData1(DataCollection1);
            textBoxX2.AutoCompleteCustomSource = DataCollection1;
        }
        private void username_auto()
        {
            textBoxX6.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getData2(DataCollection2);
            textBoxX6.AutoCompleteCustomSource = DataCollection2;
        }
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
        void teacher_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select teacher_id as 'ID number',teacher_lname as 'Surname',teacher_fname as 'First Name',teacher_Mi as 'Middle initial',age as 'Age' from teachers", condatabase);


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
        void Account_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select username,passwords,accountname from account inner join teachers on account.Teacher_id = teachers.teacher_id where userlevel ='Teacher'", condatabase);


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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxX1.Text = row.Cells["ID number"].Value.ToString();
                textBoxX2.Text = row.Cells["Surname"].Value.ToString();
                textBoxX3.Text = row.Cells["First Name"].Value.ToString();
                textBoxX4.Text = row.Cells["Middle initial"].Value.ToString();
                textBoxX5.Text = row.Cells["Age"].Value.ToString();




            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ids = textBoxX1.Text;
            string lname = textBoxX2.Text;
            string fname = textBoxX3.Text;
            string mi = textBoxX4.Text;
            string edge = textBoxX5.Text;
            string user = textBoxX6.Text;
            string pass = textBoxX7.Text;
            string level = "Teacher";

            if(ids==""||lname==""||fname==""||fname==""||mi==""||edge=="")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Field/s detected");
                return;
            }
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from teachers", connection);

            MySqlDataReader myReader;
            string teachID = "";



            int x = 0;

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    teachID = myReader.GetString("teacher_id");


                    if (teachID == ids)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Teacher ID is already taken");
                        x = 1;
                    }

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (x == 0)
            {
                connection.Open();
                string newuser_sql = "INSERT INTO teachers (teacher_id,teacher_lname,teacher_fname,teacher_mi,age) VALUES (@ids, @lname, @fname,@mi,@edge)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", ids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@mi", mi);
                newuser.Parameters.AddWithValue("@edge", edge);
                 
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Teacher Registered");

                string activity = "Add Teacher";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label11.Text);
                newuser1.Parameters.AddWithValue("@levels", label12.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                newuser1.ExecuteNonQuery();
                {
                }

                string query1 = "INSERT INTO Account(teacher_ID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname+','+fname +   "','" + level + "','" + user + "','" + pass + "');";

                MySqlCommand newquery = new MySqlCommand(query1, connection);
                getName();
                newquery.ExecuteNonQuery();

                
                textBoxX2.Text = "";
                textBoxX3.Text = "";
                textBoxX4.Text = "";
                textBoxX5.Text = "";
                textBoxX7.Text = "";
                textBoxX7.Text = "";

                connection.Close();


                teacher_tbl();
                connection.Close();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string ID = textBoxX1.Text;
            string lname = textBoxX2.Text;
            string fname = textBoxX3.Text;
            string MI = textBoxX4.Text;
            string age = textBoxX5.Text;
          

            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";

            if (ID == "" || lname == "" || fname == "" || MI == "" || age == "" )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            DialogResult dialog = XtraMessageBox.Show("are you sure do you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from GradingSystem.teachers where teacher_ID='" + ID + "' ;";

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



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                teacher_tbl();
                condatabase.Close();
                condatabase.Open();
                string activity = "Delete Teacher";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label11.Text);
                newuser1.Parameters.AddWithValue("@levels", label12.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                newuser1.ExecuteNonQuery();
                {
                }
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBoxX2.Text = "";
            textBoxX3.Text = "";
            textBoxX4.Text = "";
            textBoxX5.Text = "";
            textBoxX6.Text = "";
            textBoxX7.Text = "";
            getName();
        }

        private void fuckup(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void bitches(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void nigga(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void wewwe(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&  e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void hj(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void lkl(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string id = textBoxX1.Text;
            string lname = textBoxX2.Text;
            string fname = textBoxX3.Text;
            string Mi = textBoxX4.Text;
            string Ages = textBoxX5.Text;
            string users = textBoxX6.Text;
            string passes = textBoxX7.Text;

            if (lname == "" || fname == "" || Mi == "" || Ages == "" || users == "" ||passes == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty fields detected");
                return;
            }

          
                {
                    string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query = "update teachers set teacher_lname='" + lname + "',teacher_fname='" + fname + "',teacher_Mi='" + Mi + "',age='" + Ages + "' where teacher_id='" + id + "' ;";
                    

                    MySqlConnection condatabase = new MySqlConnection(constring);
                    MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                   
                    MySqlDataReader myReader;
                    try
                    {
                        condatabase.Open();
                        myReader = cmddatabase.ExecuteReader();
                        DevExpress.XtraEditors.XtraMessageBox.Show("Teacher has been updated");
                        teacher_tbl();
                        Account_tbl();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    string constring1 = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query1 = "update account set Username='" + textBoxX6.Text + "',Passwords='" + textBoxX7.Text + "' where teacher_id='" + id + "' ;";


                    MySqlConnection condatabase1 = new MySqlConnection(constring1);
                    MySqlCommand cmddatabase1 = new MySqlCommand(Query1, condatabase1);
                    try
                    {
                        condatabase1.Open();
                        myReader = cmddatabase1.ExecuteReader();
                        teacher_tbl();
                        Account_tbl();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    condatabase1.Close();

                    condatabase1.Open();
                    string activity = "Update Teacher";
                    string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase1);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", label11.Text);
                    newuser1.Parameters.AddWithValue("@levels", label12.Text);
                    newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }

                }

            }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Teacher Information")
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                teacher_tbl();
                textBoxX8.Enabled = true;
            }
            if(comboBox1.SelectedItem.ToString()=="Teacher Account")
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                Account_tbl();
                textBoxX8.Enabled = false;
            }
        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("Surname LIKE '%{0}%'", textBoxX8.Text);
            dataGridView1.DataSource = DV;
            
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

    }
}