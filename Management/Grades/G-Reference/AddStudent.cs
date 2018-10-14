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
    public partial class AddStudent : DevExpress.XtraEditors.XtraForm
    {
        private string conn;
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        
        MySqlCommand cmd;
        static string id;
        private void AddStudent_Load_1Extracted()
        {
            
        }
        private MySqlConnection connect;
        public AddStudent()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            load_year();
            student_tbl();



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
        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select g.StudentID as 'Student ID',g.student_lname as 'Surname',g.student_fname as 'First Name',y.sectionId as 'Section',y.YearLevelID as 'Year',g.age as 'Age',g.address as 'Address',g.gender as 'Gender' from students as g inner join sections as y on g.SectionId = y.SectionId ", condatabase);


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
        void studentAct_tbl()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StudentID as 'Student ID',concat(student_lname,', ',student_fname) as 'Name',username as 'Username',pwords as 'Password' from students ", condatabase);


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
        void load_year()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT * FROM YearLevel ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("YearLevelID");

                    comboBox4.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void load_g7()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox4.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox3.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void load_g8()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox4.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox3.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void load_g9()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox4.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox3.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void load_g10()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox4.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox3.Items.Add(x);


                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
            string sql = "SELECT DISTINCT student_lname FROM students";
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
        private void getData2(AutoCompleteStringCollection dataCollection2)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
            string sql = "SELECT DISTINCT student_lname FROM students";
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
        private void fname_auto()
        {
            textBoxX3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData2(DataCollection);
            textBoxX3.AutoCompleteCustomSource = DataCollection;
        }
        private void search_lname_auto()
        {
            textBoxX2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBoxX2.AutoCompleteCustomSource = DataCollection;
        }
        private void AddStudent_Load_1(object sender, EventArgs e)
        {
            id = textBoxX4.Text;
            id = id + 1;
            textBoxX4.Text = id.ToString();
            textBoxX4.Enabled = false;
            getName();
            fname_auto();
            search_lname_auto();
            getnamex();
            getuserlevs();
            
        }
        private void getName()
        {
            //int x = 1;
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select (StudentID + 1) as StudentID from Students order by StudentID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
            textBoxX4.Text = reader["StudentID"].ToString();
            reader.Read();
            
            
            reader.Dispose();
            reader.Close();
            con.Close();
        }
       
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox4.SelectedItem.ToString() == "Grade 7")
            {
                load_g7();
                
            }
            if (comboBox4.SelectedItem.ToString() == "Grade 8")
            {
                load_g8();
                
            }
            if (comboBox4.SelectedItem.ToString() == "Grade 9")
            {
                load_g9();
                
            }
            if (comboBox4.SelectedItem.ToString() == "Grade 10")
            {
                load_g10();
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxX4.Text = row.Cells["Student ID"].Value.ToString();
                textBoxX3.Text = row.Cells["Surname"].Value.ToString();
                textBoxX5.Text = row.Cells["First Name"].Value.ToString();
                comboBox4.Text = row.Cells["Year"].Value.ToString();
                comboBox3.Text = row.Cells["Section"].Value.ToString();
                textBoxX7.Text = row.Cells["Age"].Value.ToString();
                textBoxX8.Text = row.Cells["Address"].Value.ToString();


            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Student Information")
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                student_tbl();
            }
            if (comboBox1.SelectedItem.ToString() == "Student Account")
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                studentAct_tbl();

            }
                
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void getnamex()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label10.Text = reader["login_name"].ToString();
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
            label3.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                textBoxX1.Text = row.Cells["Username"].Value.ToString();
                textBoxX6.Text = row.Cells["Password"].Value.ToString();
                



            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string ids = textBoxX4.Text;
            string lname = textBoxX3.Text;
            string fname = textBoxX5.Text;
            string edge = textBoxX7.Text;
            string add = textBoxX8.Text;
            string year = comboBox4.Text;
            string sec = comboBox3.Text;
            string gen = comboBox2.Text;
            string user = textBoxX1.Text;
            string pass = textBoxX6.Text;

            if (ids =="" || lname == "" || fname == "" || fname == "" || edge == "" || add == "" || year == "" || sec == "" || gen == "" || user == "" || pass == "")
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

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from students", connection);

            MySqlDataReader myReader;
            string studID = "";
            
          

            int x = 0;

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    studID = myReader.GetString("StudentID");


                    if (studID == ids)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Student ID is already taken");
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
                string newuser_sql = "INSERT INTO students (StudentID,student_lname,student_fname,YearLevelID,SectionId,age,address,gender,username,pwords) VALUES (@ids, @lname, @fname,@year,@sec,@edge,@add,@gen,@user,@pass)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@ids", ids);
                newuser.Parameters.AddWithValue("@lname", lname);
                newuser.Parameters.AddWithValue("@fname", fname);
                newuser.Parameters.AddWithValue("@edge", edge);
                newuser.Parameters.AddWithValue("@add", add);
                newuser.Parameters.AddWithValue("@year", year);
                newuser.Parameters.AddWithValue("@sec", sec);
                newuser.Parameters.AddWithValue("@gen", gen);
                newuser.Parameters.AddWithValue("@user", user);
                newuser.Parameters.AddWithValue("@pass", pass);

                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Student Registered");
                student_tbl();
                studentAct_tbl();
                getName();
                textBoxX3.Text="";
                textBoxX5.Text = "";
                textBoxX7.Text = "";
                textBoxX8.Text = "";
                comboBox4.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                textBoxX1.Text = "";
                textBoxX6.Text = "";
                connection.Close();
                connection.Open();
                string activity = "Add Student";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label10.Text);
                newuser1.Parameters.AddWithValue("@levels", label3.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX4.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                connection.Close();
            }
            
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ID = textBoxX4.Text;
            string lname = textBoxX3.Text;
            string fname = textBoxX5.Text;
            string year = comboBox4.Text;
            string section = comboBox4.Text;
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";

            if (ID == "" || lname == "" || fname == "" || year == "" || section == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            DialogResult dialog = XtraMessageBox.Show("are you sure do you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from GradingSystem.students where StudentID='" + ID + "' ;";

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
                condatabase.Close();
                condatabase.Open();
                string activity = "Delete Student";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label10.Text);
                newuser1.Parameters.AddWithValue("@levels", label3.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX4.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                string Query1 = "delete from GradingSystem.account where Student_ID='" + textBoxX4.Text + "' ;";
                MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                newquery.ExecuteNonQuery();

                student_tbl();
                studentAct_tbl();
                getName();
                condatabase.Close();
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            string Query = "update students set student_lname='" + textBoxX3.Text + "',student_fname='" + textBoxX5.Text + "',age='" + textBoxX7.Text + "',address='" + textBoxX8.Text + "',YearLevelID='" + comboBox4.Text + "',SectionId='" + comboBox3.Text + "',Gender='" + comboBox2.Text + "',username='" + textBoxX1.Text + "',pwords='" + textBoxX6.Text + "' where studentID='" + textBoxX4.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Student has been updated");
                while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Close();
            condatabase.Open();
            string activity = "Update Student";
            string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label10.Text);
            newuser1.Parameters.AddWithValue("@levels", label3.Text);
            newuser1.Parameters.AddWithValue("@act1", textBoxX4.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            string query1 = "update GradingSystem.account set AccountName='" + textBoxX3.Text + ',' + textBoxX5.Text + "', username='" + textBoxX1.Text + "',passwords='" + textBoxX6.Text + "'where Student_ID='" + textBoxX4.Text + "' ;";

            MySqlCommand newquery = new MySqlCommand(query1, condatabase);
            newquery.ExecuteNonQuery();
            student_tbl();
            studentAct_tbl();
        }

        private void mmxc(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void fg(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void io(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void kl(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            textBoxX3.Text = "";
            textBoxX5.Text = "";
            textBoxX7.Text = "";
            textBoxX8.Text = "";
            textBoxX1.Text = "";
            textBoxX6.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            getName();
        }

        private void jklo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void klklkl(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("Surname LIKE '%{0}%'", textBoxX2.Text);
            dataGridView1.DataSource = DV;
        }

     
    }
}