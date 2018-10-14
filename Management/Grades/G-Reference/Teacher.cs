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
    public partial class Teacher : DevExpress.XtraEditors.XtraForm
    {
        private string user;
        private string conn;
        private MySqlConnection connect;
        MySqlDataAdapter dp;
        MySqlCommand cmd;
        private string name;
        public Teacher()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            student_tbl();
            firstQ();
            SecondQ();
            ThirdQ();
            fourthQ();
            finalQ();
            AutoCalculateTotal();
            AutoCalculateFinal();
            load_quarter();
            
            
        }
        DataTable dtable;
        
       
        double a, b, d, f, g , h ,  result , total;

        double c = 100;
        double bc = 50;
        private int GetA()
        {
            int a = Convert.ToInt32(ids.Text);
            return a;
        }

        void load_quarter()
        {
            MySqlConnectionStringBuilder builder1 = new MySqlConnectionStringBuilder();
            builder1.Server = "127.0.0.1";
            builder1.UserID = "root";
            builder1.Password = "";
            builder1.Database = "gradingsystem";
            MySqlConnection connection = new MySqlConnection(builder1.ToString());


            MySqlCommand Cmd_Dept = new MySqlCommand("SELECT * FROM Quarters ", connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = Cmd_Dept.ExecuteReader();
                while (myReader.Read())
                {
                    string x = myReader.GetString("QuarterDesc");

                    cmbquarter.Items.Add(x);

                }
                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void firstQ()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StudentID as 'Student ID',concat(student_fname,', ',student_lname) as Name,SectionId as 'Section',SubjectDesc as'Subject',quizzes as 'Quiz',attendance as 'Attendance',exam as 'Examination',project as 'Project',seatworks as 'Seatwork',recitation as 'Recitation',total_grade as 'Total Grade' FROM FirstQuarter", condatabase);


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
        void SecondQ()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * FROM SecondQuarter", condatabase);


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
        void ThirdQ()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * FROM ThirdQuarter", condatabase);


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
        void fourthQ()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * FROM FourthQuarter", condatabase);


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
        void finalQ()
        {

            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select * FROM FinalGrade", condatabase);


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
        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select a.StudentID as 'Student ID',a.student_lname as 'Surname',a.student_fname as 'First Name',a.YearLevelID as 'Year',a.SectionId as 'Section' from students as a", condatabase);


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
        private void db_connection()
        {
            try
            {
                conn = "Server=127.0.0.1; Database=Conekt;Uid=root;Pwd=thesis;";
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
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=gradingsystem;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Teacher' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            names.Text = reader["login_name"].ToString();
            reader.Read();
            ids.Text = reader["teacher_ID"].ToString();
            reader.Read();
            USER.Text = reader["login_username"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void Teacher_Load(object sender, EventArgs e)
        {
            getName();
            
            
            //-------------------------------------------------------------------
            
           


           
            //---------------------------------------------------------------------------
            txtattendance.Enabled = false;
            txtquiz.Enabled = false;
            txtrecitation.Enabled = false;
            txtseatwork.Enabled = false;
            txtexam.Enabled = false;
            txtproject.Enabled = false;
            TOTALTXT.Enabled = false;
            textBox2.Enabled = false;


            textBoxX13.Enabled = false;
            textBoxX14.Enabled = false;
            textBoxX15.Enabled = false;
            textBoxX16.Enabled = false;
            textBoxX17.Enabled = false;
            textBoxX18.Enabled = false;

            textBoxX13.Text = "10";
            textBoxX14.Text = "20";
            textBoxX15.Text = "10";
            textBoxX16.Text = "40";
            textBoxX17.Text = "10";
            textBoxX18.Text = "10";
            //--------------------------------------------------
            
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("are you sure do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Close();
                Login wew = new Login();
                wew.Show();
            }
            else if (result1 == DialogResult.No)
            {

            }   
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void attpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void quipress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void recitpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void express(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void projpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void seatpress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            string at = textBoxX13.Text;
            string qui = textBoxX14.Text;
            string fak = textBoxX15.Text;
            string ui = textBoxX16.Text;
            string haha = textBoxX17.Text;
            string noob = textBoxX18.Text;



            if (at == "" || qui == "" || fak == "" ||  ui== "" || haha == "" ||  noob== "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ooops! Empty Field/s Detected! Fill up to continue");
                return;
            }

            double txtbox13 = Convert.ToDouble(textBoxX13.Text);
            double txtbox14 = Convert.ToDouble(textBoxX14.Text);
            double txtbox15 = Convert.ToDouble(textBoxX15.Text);
            double txtbox16 = Convert.ToDouble(textBoxX16.Text);
            double txtbox17 = Convert.ToDouble(textBoxX17.Text);
            double txtbox18 = Convert.ToDouble(textBoxX18.Text);
                 
            double total = txtbox13 + txtbox14 + txtbox15 + txtbox16 + txtbox17 + txtbox18;



            if (total > 100)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cannot save because the percentage is greater than 100");
                textBoxX13.Text = "";
                textBoxX14.Text = "";
                textBoxX15.Text = "";
                textBoxX16.Text = "";
                textBoxX17.Text = "";
                textBoxX18.Text = "";
            }
            if (total < 100)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cannot save because the percentage is less than 100");
                textBoxX13.Text = "";
                textBoxX14.Text = "";
                textBoxX15.Text = "";
                textBoxX16.Text = "";
                textBoxX17.Text = "";
                textBoxX18.Text = "";
            }
            if (total == 100)
            {
                textBoxX13.Enabled = false;
                textBoxX14.Enabled = false;
                textBoxX15.Enabled = false;
                textBoxX16.Enabled = false;
                textBoxX17.Enabled = false;
                textBoxX18.Enabled = false;
                DevExpress.XtraEditors.XtraMessageBox.Show("Saved");
            }
            if (at == "0")
            {
                textBoxX1.Enabled = false;
                textBoxX7.Enabled = false;
                textBoxX2.Enabled = false;
                textBoxX3.Enabled = false;
                textBoxX4.Enabled = false;
                textBoxX5.Enabled = false;
                textBoxX6.Enabled = false;
            }
            if (qui == "0")
            {
                textBoxX2.Enabled = false;
                textBoxX9.Enabled = false;
                textBoxX1.Enabled = false;
                textBoxX3.Enabled = false;
                textBoxX4.Enabled = false;
                textBoxX5.Enabled = false;
                textBoxX6.Enabled = false;


            }
            if (fak == "0")
            {
                textBoxX3.Enabled = false;
                textBoxX8.Enabled = false;
                textBoxX1.Enabled = false;
                textBoxX2.Enabled = false;
                textBoxX4.Enabled = false;
                textBoxX5.Enabled = false;
                textBoxX6.Enabled = false;
            }
            if (ui == "0")
            {
                textBoxX4.Enabled = false;
                textBoxX12.Enabled = false;
                textBoxX1.Enabled = false;
                textBoxX2.Enabled = false;
                textBoxX3.Enabled = false;
                textBoxX5.Enabled = false;
                textBoxX6.Enabled = false;

            }
            if (haha == "0")
            {
                textBoxX5.Enabled = false;
                textBoxX11.Enabled = false;
                textBoxX1.Enabled = false;
                textBoxX2.Enabled = false;
                textBoxX3.Enabled = false;
                textBoxX4.Enabled = false;
                textBoxX6.Enabled = false;
            }
            if (noob == "0")
            {
                textBoxX6.Enabled = false;
                textBoxX10.Enabled = false;
                textBoxX1.Enabled = false;
                textBoxX2.Enabled = false;
                textBoxX3.Enabled = false;
                textBoxX4.Enabled = false;
                textBoxX5.Enabled = false;
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textBoxX13.Enabled = true;
            textBoxX14.Enabled = true;
            textBoxX15.Enabled = true;
            textBoxX16.Enabled = true;
            textBoxX17.Enabled = true;
            textBoxX18.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtidnum.Text = row.Cells["Student ID"].Value.ToString();
                txtlname.Text = row.Cells["Surname"].Value.ToString();
                txtfname.Text = row.Cells["First Name"].Value.ToString();
                txtsection.Text = row.Cells["Section"].Value.ToString();
                txtyear.Text = row.Cells["Year"].Value.ToString();

                txtidnum.Enabled = false;
                txtfname.Enabled = false;
                txtlname.Enabled = false;
                txtsection.Enabled = false;
                txtyear.Enabled = false;
                simpleButton6.Enabled = true;
                simpleButton14.Enabled = true;
             
            }
        }



        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            textBoxX3.Text = "";
            textBoxX4.Text = "";
            textBoxX5.Text = "";
            textBoxX6.Text = "";
            textBoxX7.Text = "";
            textBoxX8.Text = "";
            textBoxX9.Text = "";
            textBoxX10.Text = "";
            textBoxX11.Text = "";
            textBoxX12.Text = "";
            txtattendance.Text = "";
            txtquiz.Text = "";
            txtseatwork.Text = "";
            txtexam.Text = "";
            txtproject.Text = "";
            txtrecitation.Text = "";
        }
        private void att1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void att2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void qui14(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void qui3(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void recit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void recit2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void ex1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void ex2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void pro1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void pro2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void sea1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }
        private void sea2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {

        
                e.Handled = true;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {


            if (textBoxX1.Text == "" && textBoxX2.Text == "" && textBoxX3.Text == "" && textBoxX4.Text == "" && textBoxX5.Text == "" && textBoxX6.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Score fields detected!");
                return;
            }
            if (cmbquarter.Text == "First Quarter")
            {
                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string seatworks = txtseatwork.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = txtquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtexam.Text;
                string project = txtproject.Text;
                string total_grade = TOTALTXT.Text;
                string recitation = txtrecitation.Text;
                string remar = textBox2.Text;

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                gsdb.Server = "localhost";
                gsdb.UserID = "root";
                gsdb.Password = ""; 
                gsdb.Database = "GradingSystem"; 
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                if (st_ID == "" || studfname == "" || studlname == "" || section == "" || subname == "" || attendance == "" || quizzes == "" || exam == "" || project == "" || seatworks == "" || total_grade == "" || recitation == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ooops! Empty Field Detected");
                    return;
                }
                //inserting NEW book data into book_list table 
                string newbook_sql = "INSERT INTO FirstQuarter(StudentID,student_fname,student_lname,SectionId,SubjectDesc,quizzes,attendance,exam,project,seatworks,total_grade,recitation,remarks) values ('" + st_ID + "','" + studfname + "','" + studlname + "','" + section + "','" + subname + "','" + quizzes + "','" + attendance + "','" + exam + "','" + project + "','" + seatworks + "','" + total_grade + "','" + recitation + "','" + remar + "');";

                MySqlCommand newbook = new MySqlCommand(newbook_sql, connection);
                MySqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = newbook.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Grade Stored");
                    while (myReader.Read())
                    {

                    }
                    connection.Close();
                    connection.Open();


                    string newbook_sql1 = "INSERT INTO FinalGrade(StudentID,student_fname,student_lname,SectionId,SubjectDesc,firstqgrade,remarks) values ('" + st_ID + "','" + studfname + "','" + studlname + "','" + section + "','" + subname + "','" + total_grade + "','" + remar + "');";

                    MySqlCommand newbook1 = new MySqlCommand(newbook_sql1, connection);

                    newbook1.ExecuteNonQuery();

                    firstQ();

                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
            //=================================================================================
            else if (cmbquarter.Text == "Second Quarter")
            {

                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = txtquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtexam.Text;
                string project = txtproject.Text;
                string seatworks = txtseatwork.Text;
                string total_grade = TOTALTXT.Text;
                string recitation = txtrecitation.Text;
                string remar = textBox2.Text;

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
                gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
                gsdb.UserID = "root";
                gsdb.Password = ""; //yung builder ano to sa visual studio
                gsdb.Database = "GradingSystem"; // name ng database
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                if (st_ID == "" || studfname == "" || studlname == "" || section == "" || subname == "" || attendance == "" || quizzes == "" || exam == "" || project == "" || seatworks == "" || total_grade == "" || recitation == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ooops! Empty Field Detected");
                    return;
                }


                string newbook_sql = "INSERT INTO SecondQuarter(StudentID,student_fname,student_lname,SectionId,SubjectDesc,quizzes,attendance,exam,project,seatworks,total_grade,recitation,remarks) values ('" + st_ID + "','" + studfname + "','" + studlname + "','" + section + "','" + subname + "','" + quizzes + "','" + attendance + "','" + exam + "','" + project + "','" + seatworks + "','" + total_grade + "','" + recitation + "','" + remar + "');";

                MySqlCommand newbook = new MySqlCommand(newbook_sql, connection);
                MySqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = newbook.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Grade Stored");
                    while (myReader.Read())
                    {

                    }
                    connection.Close();
                    connection.Open();


                    string newbook_sql1 = "update GradingSystem.FinalGrade set StudentID='" + st_ID + "',student_fname='" + studfname + "',student_lname='" + studlname + "',SectionId='" + section + "',SubjectDesc='" + subname + "',secondqgrade='" + total_grade + "' where StudentID='" + st_ID + "'AND SubjectDesc='" + subname + "';";

                    MySqlCommand newbook1 = new MySqlCommand(newbook_sql1, connection);
                    newbook1.ExecuteNonQuery();

                    SecondQ();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            else if (cmbquarter.Text == "Third Quarter")
            {

                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = txtquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtexam.Text;
                string project = txtproject.Text;
                string seatworks = txtseatwork.Text;
                string total_grade = TOTALTXT.Text;
                string recitation = txtrecitation.Text;
                string remar = textBox2.Text;

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
                gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
                gsdb.UserID = "root";
                gsdb.Password = ""; //yung builder ano to sa visual studio
                gsdb.Database = "GradingSystem"; // name ng database
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());


                if (st_ID == "" || studfname == "" || studlname == "" || section == "" || subname == "" || attendance == "" || quizzes == "" || exam == "" || project == "" || seatworks == "" || total_grade == "" || recitation == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ooops! Empty Field Detected");
                    return;
                }


                //inserting NEW book data into book_list table 
                string newbook_sql = "INSERT INTO ThirdQuarter(StudentID,student_fname,student_lname,SectionId,SubjectDesc,quizzes,attendance,exam,project,seatworks,total_grade,recitation,remarks) values ('" + st_ID + "','" + studfname + "','" + studlname + "','" + section + "','" + subname + "','" + quizzes + "','" + attendance + "','" + exam + "','" + project + "','" + seatworks + "','" + total_grade + "','" + recitation + "','" + remar + "');";

                MySqlCommand newbook = new MySqlCommand(newbook_sql, connection);
                MySqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = newbook.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Grade Stored");
                    while (myReader.Read())
                    {

                    }
                    connection.Close();
                    connection.Open();


                    string newbook_sql1 = "update GradingSystem.FinalGrade set StudentID='" + st_ID + "',student_fname='" + studfname + "',student_lname='" + studlname + "',SectionId='" + section + "',SubjectDesc='" + subname + "',thirdqgrade='" + total_grade + "' where StudentID='" + st_ID + "'AND SubjectDesc='" + subname + "';";

                    MySqlCommand newbook1 = new MySqlCommand(newbook_sql1, connection);
                    newbook1.ExecuteNonQuery();

                    ThirdQ();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //==================================================================================================
            else if (cmbquarter.Text == "Fourth Quarter")
            {

                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = txtquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtexam.Text;
                string project = txtproject.Text;
                string seatworks = txtseatwork.Text;
                string total_grade = TOTALTXT.Text;
                string recitation = txtrecitation.Text;
                string remar = textBox2.Text;

                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                gsdb.Server = "localhost";
                gsdb.UserID = "root";
                gsdb.Password = "";
                gsdb.Database = "GradingSystem";
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                if (st_ID == "" || studfname == "" || studlname == "" || section == "" || subname == "" || attendance == "" || quizzes == "" || exam == "" || project == "" || seatworks == "" || total_grade == "" || recitation == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ooops! Empty Field Detected");
                    return;
                }

                string newbook_sql = "INSERT INTO FourthQuarter(StudentID,student_fname,student_lname,SectionId,SubjectDesc,quizzes,attendance,exam,project,seatworks,total_grade,recitation,remarks) values ('" + st_ID + "','" + studfname + "','" + studlname + "','" + section + "','" + subname + "','" + quizzes + "','" + attendance + "','" + exam + "','" + project + "','" + seatworks + "','" + total_grade + "','" + recitation + "','" + remar + "');";

                MySqlCommand newbook = new MySqlCommand(newbook_sql, connection);
                MySqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = newbook.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Grade Stored");
                    while (myReader.Read())
                    {

                    }
                    connection.Close();
                    connection.Open();


                    string newbook_sql1 = "update GradingSystem.FinalGrade set StudentID='" + st_ID + "',student_fname='" + studfname + "',student_lname='" + studlname + "',SectionId='" + section + "',SubjectDesc='" + subname + "',fourthqgrade='" + total_grade + "' where StudentID='" + st_ID + "'AND SubjectDesc='" + subname + "';";

                    MySqlCommand newbook1 = new MySqlCommand(newbook_sql1, connection);
                    newbook1.ExecuteNonQuery();

                    fourthQ();
                   connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //==================================================================================
            else if (cmbquarter.Text == "Final Grade")
            {
                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string total_grade = TOTALTXT.Text;

                string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";

                string Query = "update GradingSystem.FinalGrade set StudentID='" + st_ID + "',student_fname='" + studfname + "',student_lname='" + studlname + "',SectionId='" + section + "',SubjectDesc='" + subname + "',finalgrade='" + total_grade + "' where StudentID='" + st_ID + "'AND SubjectDesc='" + subname + "';";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Grade Stored ");
                    while (myReader.Read())
                    {

                    }
                    finalQ();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            //==================================================
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            PrintGrade mm = new PrintGrade();
            mm.passvalue1 = txtlname.Text +", " + txtfname.Text;
            mm.passvalue2 = txtidnum.Text;
            mm.passvalue3 = txtsection.Text;
            mm.passvalue4 = names.Text;
            mm.passvalue5 = txtyear.Text;
            mm.ShowDialog();
        }

        private void text_attendance(object sender, KeyEventArgs e)
        {
            double textbox13 = Convert.ToDouble(textBoxX13.Text);
            Double.TryParse(textBoxX1.Text, out a);
            Double.TryParse(textBoxX7.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox13 / c);

            result = ((a / b) * bc + bc) * o;
            total = result + f;
            txtattendance.Text = result.ToString();
            txtattendance.Text = Math.Round(double.Parse(txtattendance.Text), 2).ToString();

            
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.6)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.4)
            {
                textBox2.Text = "Failed";
            }
        }

        private void text_Quiz(object sender, KeyEventArgs e)
        {
            double textbox14 = Convert.ToDouble(textBoxX14.Text);
            Double.TryParse(textBoxX2.Text, out a);
            Double.TryParse(textBoxX9.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox14 / c);

            result = ((a / b) * bc + bc) * o;
            txtquiz.Text = result.ToString();
            txtquiz.Text = Math.Round(double.Parse(txtquiz.Text), 2).ToString();

            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.5)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.5)
            {
                textBox2.Text = "Failed";
            }
        }

        private void text_recitation(object sender, KeyEventArgs e)
        {
            double textbox15 = Convert.ToDouble(textBoxX15.Text);
            Double.TryParse(textBoxX3.Text, out a);
            Double.TryParse(textBoxX8.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox15 / c);

            result = ((a / b) * bc + bc) * o;
            txtrecitation.Text = result.ToString();
            txtrecitation.Text = Math.Round(double.Parse(txtrecitation.Text), 2).ToString();

            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.5)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.5)
            {
                textBox2.Text = "Failed";
            }
        }

        private void text_exam(object sender, KeyEventArgs e)
        {
            double textbox16 = Convert.ToDouble(textBoxX16.Text);
            Double.TryParse(textBoxX4.Text, out a);
            Double.TryParse(textBoxX12.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox16 / c);

            result = ((a / b) * bc + bc) * o;
            txtexam.Text = result.ToString();
            txtexam.Text = Math.Round(double.Parse(txtexam.Text), 2).ToString();

            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.5)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.5)
            {
                textBox2.Text = "Failed";
            }
        }

        private void text_project(object sender, KeyEventArgs e)
        {
            double textbox17 = Convert.ToDouble(textBoxX17.Text);
            Double.TryParse(textBoxX5.Text, out a);
            Double.TryParse(textBoxX11.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);
            double o = Convert.ToDouble(textbox17 / c);

            result = ((a / b) * bc + bc) * o;
            txtproject.Text = result.ToString();
            txtproject.Text = Math.Round(double.Parse(txtproject.Text), 2).ToString();

            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.5)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.5)
            {
                textBox2.Text = "Failed";
            }

        }

        private void text_seatwork(object sender, KeyEventArgs e)
        {
            double textbox18 = Convert.ToDouble(textBoxX18.Text);
            Double.TryParse(textBoxX6.Text, out a);
            Double.TryParse(textBoxX10.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox18 / c);

            result = ((a / b) * bc + bc) * o;
            txtseatwork.Text = result.ToString();
            txtseatwork.Text = Math.Round(double.Parse(txtseatwork.Text), 2).ToString();

            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();

            if (total >= 74.5)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 74.5)
            {
                textBox2.Text = "Failed";
            }
        }

        private void textBoxX7_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX1.Enabled = true;
        }

        private void textBoxX9_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX2.Enabled = true;
        }

        private void textBoxX8_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX3.Enabled = true;
        }

        private void textBoxX12_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX4.Enabled = true;
        }

        private void textBoxX11_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX5.Enabled = true;
        }

        private void textBoxX10_EditValueChanged(object sender, EventArgs e)
        {
            textBoxX6.Enabled = true;
        }

        private void TOTALTXT_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Attendance jj = new Attendance();
            jj.passvalue1 = txtidnum.Text;
            jj.passvalue2 = txtsection.Text;
            jj.passvalue3 = txtlname.Text;
            jj.passvalue4 = txtfname.Text;
            jj.passvalue5 = txtyear.Text;
            jj.ShowDialog();
        }


        private void AutoCalculateTotal()
        {
            Double.TryParse(txtattendance.Text, out a);
            Double.TryParse(txtquiz.Text, out b);
            Double.TryParse(txtrecitation.Text, out d);
            Double.TryParse(txtexam.Text, out f);
            Double.TryParse(txtproject.Text, out g);
            Double.TryParse(txtseatwork.Text, out h);

            total = a + b + d + f + g + h;
            TOTALTXT.Text = total.ToString();
        }

        private void T(object sender, EventArgs e)
        {
            AutoCalculateTotal();
        }

        private void cmbquarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbquarter.Text == "First Quarter")
            {
                simpleButton12.Enabled = true;
                simpleButton11.Enabled = false;
                simpleButton10.Enabled = false;
                simpleButton9.Enabled = false;
            }
            if (cmbquarter.Text == "Second Quarter")
            {
                simpleButton12.Enabled = false;
                simpleButton11.Enabled = true;
                simpleButton10.Enabled = false;
                simpleButton9.Enabled = false;
            }
            if (cmbquarter.Text == "Third Quarter")
            {
                simpleButton12.Enabled = false;
                simpleButton11.Enabled = false;
                simpleButton10.Enabled = true;
                simpleButton9.Enabled = false;
            }
            if (cmbquarter.Text == "Fourth Quarter")
            {
                simpleButton12.Enabled = false;
                simpleButton11.Enabled = false;
                simpleButton10.Enabled = false;
                simpleButton9.Enabled = true;
            }

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            finalQ();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            firstQ();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            SecondQ();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ThirdQ();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            fourthQ();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            CharacterFormation gago = new CharacterFormation();
            gago.passvalue7 = txtidnum.Text;
            gago.passvalue8 = txtsection.Text;
            gago.passvalue9 = txtlname.Text;
            gago.passvalue10 = txtfname.Text;
            gago.passvalue11 = txtyear.Text;
            gago.ShowDialog();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
            gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
            gsdb.UserID = "root";
            gsdb.Password = ""; //yung builder ano to sa visual studio
            gsdb.Database = "GradingSystem"; // name ng database
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());



            string Query = "update FinalGrade set finalgrade='" + txtfinal.Text + "'where FinalGrade_ID='" + labelID.Text + "' ;";


            MySqlCommand newbook = new MySqlCommand(Query, connection);
            MySqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = newbook.ExecuteReader();
                MessageBox.Show("Final Grade Has Been Updated");
                while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                txtfirst.Text = row.Cells["firstqgrade"].Value.ToString();
                txtsecond.Text = row.Cells["secondqgrade"].Value.ToString();
                txtthird.Text = row.Cells["thirdqgrade"].Value.ToString();
                txtfourth.Text = row.Cells["fourthqgrade"].Value.ToString();
                labelID.Text = row.Cells["FinalGrade_ID"].Value.ToString();


            }
        }

        private void txtfinal_TextChanged(object sender, EventArgs e)
        {
            AutoCalculateFinal();
        }
        private void AutoCalculateFinal()
        {
            Double.TryParse(txtfirst.Text, out a);
            Double.TryParse(txtsecond.Text, out b);
            Double.TryParse(txtthird.Text, out d);
            Double.TryParse(txtfourth.Text, out f);


            total = (a + b + d + f) / 4;

            txtfinal.Text = total.ToString();


        }

        private void txtfirst_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(txtfirst.Text, out a);
            Double.TryParse(txtfinal.Text, out f);

            total = a + f;
            txtfinal.Text = total.ToString();


            if (total >= 75)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox2.Text = "Failed";
            }
        }

        private void txtsecond_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(txtsecond.Text, out a);
            Double.TryParse(txtfinal.Text, out f);

            total = a + f;
            txtfinal.Text = total.ToString();

            if (total >= 75)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox2.Text = "Failed";
            }

        }

        private void txtthird_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(txtthird.Text, out a);
            Double.TryParse(txtfinal.Text, out f);

            total = a + f;
            txtfinal.Text = total.ToString();

            if (total >= 75)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox2.Text = "Failed";
            }
        }

        private void txtfourth_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(txtfourth.Text, out a);
            Double.TryParse(txtfinal.Text, out f);

            total = a + f;
            txtfinal.Text = total.ToString();

            if (total >= 75)
            {
                textBox2.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox2.Text = "Failed";
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
       

   

        }

       
    }