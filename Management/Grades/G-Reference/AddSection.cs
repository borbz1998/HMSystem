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
    public partial class AddSection : DevExpress.XtraEditors.XtraForm
    {
        MySqlCommand cmd;
        private string conn;
        private MySqlConnection connect;
        public AddSection()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            load_year();
            section_tbl();
            teacher_tbl();
            
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

                    comboBox1.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void section_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select SectionId as 'Section' ,YearLevelID as 'Year',teacher_lname as 'Last Name', teacher_Fname as 'First Name' from Sections inner join Teachers  ON Sections.teacher_ID = Teachers.teacher_ID", condatabase);


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
        void teacher_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("select teacher_ID as 'ID Number',teacher_lname as 'Last Name',teacher_fname as 'First Name' from teachers where sec_status = ''", condatabase);


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
        private void AddSection_Load(object sender, EventArgs e)
        {
            getnamex();
            getuserlevs();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxX1.Text = row.Cells["Section"].Value.ToString();
                comboBox1.Text = row.Cells["Year"].Value.ToString();
                textBoxX2.Text = row.Cells["Last Name"].Value.ToString();
                textBoxX4.Text = row.Cells["First Name"].Value.ToString();
                textBoxX5.Text = row.Cells["Last Name"].Value.ToString();
                textBoxX3.Text = "";
                simpleButton4.Enabled = true;
                simpleButton3.Enabled = true;
                
               


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBoxX3.Text = row.Cells["ID Number"].Value.ToString();
                textBoxX2.Text = row.Cells["Last Name"].Value.ToString();
                textBoxX4.Text = row.Cells["First Name"].Value.ToString();
           
                
                simpleButton3.Enabled = false;
            }
        }
        private void getnamex()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label7.Text = reader["login_name"].ToString();
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
            label6.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string secname = textBoxX1.Text;
            string year = comboBox1.Text;
            string id = textBoxX3.Text;
            string stats = "Taken";


            if (secname == "" || year == "" || id == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty fields detected");
                return;
            }

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from sections", connection);

            MySqlDataReader myReader;
            string sectionx = "";
            string yearx = "";
            string ids = "";
            
            int x = 0;

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    sectionx = myReader.GetString("SectionId");
                    yearx = myReader.GetString("YearLevelID");
                    ids = myReader.GetString("teacher_ID");


                    if (sectionx == secname)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Section already in the list");
                        x = 1;
                    }
                    if (ids == id)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Teacher has already advisory class");
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
                string newuser_sql = "INSERT INTO sections (SectionId,YearLevelID,teacher_ID) VALUES (@sec, @yearf, @teachids)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@sec", secname);
                newuser.Parameters.AddWithValue("@yearf", year);
                newuser.Parameters.AddWithValue("@teachids", id);
                newuser.ExecuteNonQuery();
                {
                }
                string activity = "Add Section";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label7.Text);
                newuser1.Parameters.AddWithValue("@levels", label6.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Section registered");
                section_tbl();
                textBoxX1.Text = "";
                comboBox1.Text = "";
                textBoxX3.Text = "";
                string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                string Query = "update teachers set sec_status='" + stats + "' where teacher_id = '"+id+"';";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);

                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    
                    section_tbl();
                    teacher_tbl();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string name = textBoxX1.Text;
            string ID = textBoxX3.Text;
            string year = comboBox1.Text;
            string stat = "";


            string constring = "Server=localhost;Database=gradingsystem;Uid=root;Pwd=";

            if (name == "" || year == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;

            }

            DialogResult dialog = XtraMessageBox.Show("are you sure do you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from gradingsystem.sections where sectionId='" + name + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selectd Record has been deleted");
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
                string Activity = "Delete Section";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", Activity);
                newuser1.Parameters.AddWithValue("@namc", label7.Text);
                newuser1.Parameters.AddWithValue("@levels", label6.Text);
                newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                
                string Query2 = "update teachers set sec_status='" + stat + "' where teacher_lname = '" + textBoxX2.Text + "';";

                MySqlConnection condatabase1 = new MySqlConnection(constring);
                MySqlCommand cmddatabase1 = new MySqlCommand(Query2, condatabase1);

                try
                {
                    condatabase1.Open();
                    myReader = cmddatabase1.ExecuteReader();

                    section_tbl();
                    teacher_tbl();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                section_tbl();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {


            string secname = textBoxX1.Text;
            string year = comboBox1.Text;
            string id = textBoxX3.Text;
            string status = "Taken";
            string single = "";


            if (secname == "" || year == "" || id == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty fields detected");
                return;
            }

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from sections", connection);

            MySqlDataReader myReader;
            string sectionx = "";
            string yearx = "";
            string ids = "";

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    sectionx = myReader.GetString("SectionId");
                    yearx = myReader.GetString("YearLevelID");
                    ids = myReader.GetString("teacher_ID");

                   
                    if (ids == id)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cannot Update beacuse teacher has already advisory class");
                        return;
                    }
                }
                
                if (sectionx != id)
                {
                    string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query = "update sections set YearLevelID='" + year + "',teacher_ID='" + id + "' where SectionId='" + secname + "' ;";

                    MySqlConnection condatabase = new MySqlConnection(constring);
                    MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);

                    try
                    {
                        condatabase.Open();
                        myReader = cmddatabase.ExecuteReader();
                        DevExpress.XtraEditors.XtraMessageBox.Show("Section has been updated");
                        section_tbl();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    condatabase.Close();
                    string constring1 = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query1 = "update teachers set sec_status='" + status + "' where teacher_id='" + id + "' ;";

                    MySqlConnection condatabase1 = new MySqlConnection(constring1);
                    MySqlCommand cmddatabase1 = new MySqlCommand(Query1, condatabase1);

                    try
                    {
                        condatabase1.Open();
                        myReader = cmddatabase1.ExecuteReader();  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    condatabase1.Close();

                    string constring2 = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query2 = "update teachers set sec_status='" + single + "' where teacher_lname='" + textBoxX5.Text + "' ;";

                    MySqlConnection condatabase2 = new MySqlConnection(constring2);
                    MySqlCommand cmddatabase2 = new MySqlCommand(Query2, condatabase2);

                    try
                    {
                        condatabase2.Open();
                        myReader = cmddatabase2.ExecuteReader();  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    condatabase2.Close();

                    string Activity = "Update Section";
                    string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", Activity);
                    newuser1.Parameters.AddWithValue("@namc", label7.Text);
                    newuser1.Parameters.AddWithValue("@levels", label6.Text);
                    newuser1.Parameters.AddWithValue("@act1", textBoxX1.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            section_tbl();
            teacher_tbl();

        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
            comboBox1.Text = "";
            textBoxX3.Text = "";
            textBoxX2.Text = "";
            textBoxX4.Text = "";
        }

        private void ASDFGHJKL(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&  !char.IsWhiteSpace(e.KeyChar) &&  e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }
    }
}