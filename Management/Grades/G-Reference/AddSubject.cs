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
using DevExpress.XtraPrintingLinks;

namespace Grades
{
    public partial class AddSubject : DevExpress.XtraEditors.XtraForm
    {
        MySqlCommand cmd;
        private string conn;
        private MySqlConnection connect;
        public AddSubject()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            subject_tbl();
            teacher_tbl();
            load_year();
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
        private void getName()
        {
            int x = 1;
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select (SubjectID + 1) as SubjectID from subjects order by SubjectID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            txtID.Text = reader["SubjectID"].ToString();
            reader.Read();


            reader.Dispose();
            reader.Close();
            con.Close();
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
        void load_g7()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox1.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox2.Items.Add(x);

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


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox1.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox2.Items.Add(x);

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


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox1.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox2.Items.Add(x);

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


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT SectionId FROM sections where YearLevelID ='" + comboBox1.Text + "' ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("SectionId");

                    comboBox2.Items.Add(x);


                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
          
        void subject_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select SubjectID as 'ID',SubjectDesc as 'Subject',SectionId as 'Section',concat(teacher_lname,', ',teacher_Fname) as Teacher,YearLevelID as 'Year' from subjects inner join teachers on subjects.teacher_ID = teachers.teacher_ID", condatabase);


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
            MySqlCommand cmddatabase = new MySqlCommand("Select teacher_ID as 'Teacher ID',concat(teacher_lname,', ',teacher_fname) as Teacher,age as Age from teachers", condatabase);


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
        private void AddSubject_Load(object sender, EventArgs e)
        {
            getName();
            getSubjects();
            subject_tbl();
            search_subname_auto();
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
            label9.Text = reader["login_name"].ToString();
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
            label10.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = "Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;";
            string sql = "SELECT DISTINCT SubjectDesc FROM subjects";
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
        private void search_subname_auto()
        {
            textBoxX4.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBoxX4.AutoCompleteCustomSource = DataCollection;
        }
        private void getSubjects()
        {
            int wew = int.Parse(textBoxX2.Text);

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select count(teacher_id) as 'Count' from subjects where teacher_id = '"+wew+"'";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label8.Text = reader["Count"].ToString();
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
                
                textBoxX1.Text = row.Cells["Subject"].Value.ToString();
                comboBox2.Text = row.Cells["Section"].Value.ToString();
                comboBox1.Text = row.Cells["Year"].Value.ToString();
                txtID.Text = row.Cells["ID"].Value.ToString();
                simpleButton3.Enabled = true;
                simpleButton4.Enabled = true;




            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                textBoxX2.Text = row.Cells["Teacher ID"].Value.ToString();
                simpleButton3.Enabled = false;
                
                
              




            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string subnames = textBoxX1.Text;
            string profID = textBoxX2.Text;
            string sec = comboBox2.Text;
            string year = comboBox1.Text;
            string idsub = txtID.Text;
            string ids = textBoxX2.Text;
            int profids = Convert.ToInt32(label8.Text);

            if (profids >= 7)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The teacher reached the limit of the subject");
                return;
            }
            if (subnames == "" || profID == "" || sec == "" || year == "" || ids == "")
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

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * FROM subjects", connection);

            MySqlDataReader myReader;
            string idh = "";
            string subname = "";
            string profname = "";
            string sections = "";
            int gx;


            int x = 0;
            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {
                    subname = myReader.GetString("SubjectDesc");
                    profname = myReader.GetString("teacher_ID");
                    sections = myReader.GetString("SectionId");
                    idh = myReader.GetString("SubjectID");
                    gx = myReader.GetInt32("teacher_ID");

                    if (subnames == subname && sections == sec)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("The section have already subject that do you want to add");
                        x = 1;

                        if (subnames == subname && profID == profname)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("The teacher has already handle the subject do you want to add");
                            x = 1;
                        }
                    }
                    if (idh == idsub)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Subject ID is already Taken");
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
                string newuser_sql = "INSERT INTO subjects (SubjectDesc,SectionId,teacher_ID,YearLevelID) VALUES (@subdesc, @secID, @teacherID,@yearsd)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@subdesc", subnames);
                newuser.Parameters.AddWithValue("@secID", sec);
                newuser.Parameters.AddWithValue("@teacherID", profID);
                newuser.Parameters.AddWithValue("@yearsd", year);
                newuser.ExecuteNonQuery();
                {
                }
                string activity = "Add Subject";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label9.Text);
                newuser1.Parameters.AddWithValue("@levels", label10.Text);
                newuser1.Parameters.AddWithValue("@act1", txtID.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("New Subject Registered");
                subject_tbl();
                getName();
                getSubjects();
            }
            connection.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string sub = textBoxX1.Text;
            string yeart = comboBox1.Text;
            string sect = comboBox2.Text;
            string teacIDs = textBoxX2.Text;
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";

            
            DialogResult dialog = XtraMessageBox.Show("are you sure do you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from GradingSystem.subjects where subjectId='" + ID + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");
                    subject_tbl();
                    getSubjects();
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
                condatabase.Close();
                condatabase.Open();
                string activity = "Delete Subject";
                string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label9.Text);
                newuser1.Parameters.AddWithValue("@levels", label10.Text);
                newuser1.Parameters.AddWithValue("@act1", txtID.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                condatabase.Close();
                
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int profids = Convert.ToInt32(label8.Text);
            string subnamex = textBoxX1.Text;
            string yearx = comboBox1.Text;
            string section = comboBox2.Text;
            string teacheer = textBoxX2.Text;
            string idds = txtID.Text;
            if (profids >= 7)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The teacher reached the limit of the subject");
                return;
            }
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from subjects", connection);

            MySqlDataReader myReader;
            string subid = "";
            string year1 = "";
            string section1 = "";
            string prof1 = "";
            string subnamed = "";

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    subid = myReader.GetString("SubjectID");
                    subnamed = myReader.GetString("SubjectDesc");
                    section1 = myReader.GetString("SectionId");
                    teacheer = myReader.GetString("teacher_ID");
                    year1 = myReader.GetString("YearLevelID");

                    if (prof1 != teacheer)
                    {
                        string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                        string Query = "update subjects set SubjectDesc='" + textBoxX1.Text + "',SectionId='" + comboBox2.Text + "',YearLevelID='" + comboBox1.Text + "',teacher_ID='" + textBoxX2.Text + "' where SubjectID='" + txtID.Text + "' ;";

                        MySqlConnection condatabase = new MySqlConnection(constring);
                        MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);

                        try
                        {
                            condatabase.Open();
                            myReader = cmddatabase.ExecuteReader();
                            DevExpress.XtraEditors.XtraMessageBox.Show("Subject has been updated!");
                            while (myReader.Read())
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        subject_tbl();
                        return;
                    }

                    if (section1 == section && subnamed == subnamex && prof1 == idds)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cannot Update beacuse subject is already in the Section");
                        return;
                    }
                    if (year1 == yearx && subnamed == subnamex && prof1 == idds)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cannot Update beacuse subject is already in the year level");
                        return;
                    }
                    
                }
                if (subid != idds || subnamed != subnamex || section1 != section || prof1 != teacheer || year1 != yearx)
                {
                    string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query = "update subjects set SubjectDesc='" + textBoxX1.Text + "',SectionId='" + comboBox2.Text + "',YearLevelID='" + comboBox1.Text + "',teacher_ID='" + textBoxX2.Text + "' where SubjectID='" + txtID.Text + "' ;";

                    MySqlConnection condatabase = new MySqlConnection(constring);
                    MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);

                    try
                    {
                        condatabase.Open();
                        myReader = cmddatabase.ExecuteReader();
                        DevExpress.XtraEditors.XtraMessageBox.Show("Subject has been updated");
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
                    string activity = "Update Subject";
                    string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", label9.Text);
                    newuser1.Parameters.AddWithValue("@levels", label10.Text);
                    newuser1.Parameters.AddWithValue("@act1", txtID.Text);
                    newuser1.ExecuteNonQuery();
                    {
                    }
                    subject_tbl();
                    getSubjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "Grade 7")
            {
                load_g7();

            }
            if (comboBox1.SelectedItem.ToString() == "Grade 8")
            {
                load_g8();

            }
            if (comboBox1.SelectedItem.ToString() == "Grade 9")
            {
                load_g9();

            }
            if (comboBox1.SelectedItem.ToString() == "Grade 10")
            {
                load_g10();

            }
        }

        private void jk(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            textBoxX1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBoxX2.Text = "0";
            getName();
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            getSubjects();
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("Subject LIKE '%{0}%'", textBoxX4.Text);
            dataGridView1.DataSource = DV;
        }

      
    }
}