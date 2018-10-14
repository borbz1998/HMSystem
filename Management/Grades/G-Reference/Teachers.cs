using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;

namespace Grades
{
    public partial class Teachers : DevExpress.XtraEditors.XtraForm
    {
        private string user;
        private string conn;
        private MySqlConnection connect;
        MySqlDataAdapter dp;
        MySqlCommand cmd;
        private string name;
        public Teachers()
        {
            InitializeComponent();
            
            student_tbl();
            firstQ();
            SecondQ();
            ThirdQ();
            fourthQ();
            finalQ();
          
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            getName();
        }
        DataTable dtable;
        double a, b, d, f, g, h, totalremarks, result, total;

        double c = 100;
        double bc = 50;
        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StudentID as 'Student ID',student_lname as 'Surname',student_fname as 'First Name',YearLevelID as 'Year',SectionId as 'Section' from students ", condatabase);


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
            label1.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
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
                dataGridView4.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void teacher_subject()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            string Query = "SELECT distinct SubjectDesc FROM subjects where teacher_ID = '" + ids.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("SubjectDesc");
                    
                }
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            private void teacher_year()
            {
                
                string constrings = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                string Query1 = "SELECT distinct YearLevelID FROM subjects where teacher_Id = '" + ids.Text + "'; ";

                MySqlConnection condatabases = new MySqlConnection(constrings);
                MySqlCommand cmddatabases = new MySqlCommand(Query1, condatabases);
                MySqlDataReader myReader1;
                try
                {
                    condatabases.Open();
                    myReader1 = cmddatabases.ExecuteReader();
                    while (myReader1.Read())
                    {

                        string x = myReader1.GetString("YearLevelID");
                       

                    }
                    condatabases.Close();
                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        private void teacher_section()
        {
            
                    string constringss = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                    string Query2 = "SELECT distinct sectionID FROM subjects where teacher_ID = '" + ids.Text + "';";

                    MySqlConnection condatabasess = new MySqlConnection(constringss);
                    MySqlCommand cmddatabasess = new MySqlCommand(Query2, condatabasess);
                    MySqlDataReader myReader2;
                    try
                    {
                        condatabasess.Open();
                        myReader2 = cmddatabasess.ExecuteReader();

                        while (myReader2.Read())
                        {
                            string s = myReader2.GetString("Sectionid");
                           
                        }

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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



            if (at == "" || qui == "" || fak == "" || ui == "" || haha == "" || noob == "")
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

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login wew = new Login();
            wew.Show();
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
                
            }
        }

        private void monthly(object sender, KeyEventArgs e)
        {
            Double.TryParse(textBoxX7.Text, out b);
            Double.TryParse(textBoxX1.Text, out a);
            Double.TryParse(textBox1.Text, out f);

            double o = Convert.ToDouble(30 / c);

            result = ((a / b) * bc + bc) * o;
            txtMT.Text = result.ToString();
            txtMT.Text = Math.Round(double.Parse(txtMT.Text), 2).ToString();
            total = result + f;
            textBox1.Text = total.ToString();
            textBox1.Text = Math.Round(double.Parse(textBox1.Text), 2).ToString();
        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            textBoxX1.Enabled = true;
        }

        private void textBoxX3_KeyUp(object sender, KeyEventArgs e)
        {
            Double.TryParse(textBox2.Text, out b);
            Double.TryParse(textBox3.Text, out a);
            Double.TryParse(textBox1.Text, out f);

            double o = Convert.ToDouble(70 / c);

            result = ((a / b) * bc + bc) * o;
            txtPT.Text = result.ToString();
            txtPT.Text = Math.Round(double.Parse(txtPT.Text), 2).ToString();
            total = result + f;
            textBox1.Text = total.ToString();
            textBox1.Text = Math.Round(double.Parse(textBox1.Text), 2).ToString();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(txtMT.Text, out a);
            Double.TryParse(txtPT.Text, out b);
            double textbox16 = Convert.ToDouble(textBoxX16.Text);
            double o = Convert.ToDouble(textbox16 / c);

            result = a + b;
            textBox1.Text = result.ToString();
            total = result * o;
            txtEXAM.Text = total.ToString();
        }
        private void AutoCalculateEXAM()
        {
            Double.TryParse(textBoxX16.Text, out d);
            Double.TryParse(textBox1.Text, out a);


            double o = d / c;
            total = a * o;
            txtEXAM.Text = total.ToString();
        }

        private void txtEXAM_TextChanged(object sender, EventArgs e)
        {
            AutoCalculateEXAM();
            double textbox16 = Convert.ToDouble(textBoxX16.Text);
            Double.TryParse(textBox1.Text, out a);


            double o = Convert.ToDouble(textbox16 / c);
            result = a * o;
            txtEXAM.Text = result.ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
        }

        private void frontPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintGrade gh = new PrintGrade();
            gh.passvalue1 = txtlname.Text + ", " + txtfname.Text;
            gh.passvalue2 = txtidnum.Text;
            gh.passvalue3 = txtsection.Text;
            gh.passvalue4 = names.Text;
            gh.passvalue5 = txtyear.Text;
            gh.ShowDialog();
        }

        private void reportCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackPagePrint well = new BackPagePrint();
            well.passvalue3 = txtidnum.Text;
            well.ShowDialog();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            double textbox14 = Convert.ToDouble(textBoxX14.Text);
            Double.TryParse(textBox12.Text, out b);
            Double.TryParse(textBox13.Text, out a);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox14 / c);

            result = ((a / b) * bc + bc) * o;
            textquiz.Text = result.ToString();
            textquiz.Text = Math.Round(double.Parse(textquiz.Text), 2).ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
            if (total >= 75)
            {
                textBox17.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox17.Text = "Failed";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            double textbox18 = Convert.ToDouble(textBoxX18.Text);
            Double.TryParse(textBox10.Text, out a);
            Double.TryParse(textBox9.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox18 / c);

            result = ((a / b) * bc + bc) * o;
            textseatwork.Text = result.ToString();
            textseatwork.Text = Math.Round(double.Parse(textseatwork.Text), 2).ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
            if (total >= 75)
            {
                textBox17.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox17.Text = "Failed";
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            double textbox13 = Convert.ToDouble(textBoxX13.Text);
            Double.TryParse(textBox16.Text, out a);
            Double.TryParse(textBox15.Text, out b);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox13 / c);

            result = ((a / b) * bc + bc) * o;
            txtattendance.Text = result.ToString();
            txtattendance.Text = Math.Round(double.Parse(txtattendance.Text), 2).ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
            if (total >= 75)
            {
                textBox17.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox17.Text = "Failed";
            }
        }
        private void AutoCalculateTotal()
        {
            Double.TryParse(txtattendance.Text, out a);
            Double.TryParse(textquiz.Text, out b);
            Double.TryParse(txtrecitation.Text, out d);
            Double.TryParse(txtEXAM.Text, out f);
            Double.TryParse(txtproject.Text, out g);
            Double.TryParse(textseatwork.Text, out h);

            total = a + b + d + f + g + h;
            TOTALTXT.Text = total.ToString();
        }

        private void TOTALTXT_TextChanged(object sender, EventArgs e)
        {
            AutoCalculateTotal();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double textbox15 = Convert.ToDouble(textBoxX15.Text);
            Double.TryParse(textBox5.Text, out a);
            Double.TryParse(TOTALTXT.Text, out f);

            double o = Convert.ToDouble(textbox15 / c);

            result = a * o;
            txtrecitation.Text = result.ToString();
            txtrecitation.Text = Math.Round(double.Parse(txtrecitation.Text), 2).ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
            if (total >= 75)
            {
                textBox17.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox17.Text = "Failed";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double textbox17 = Convert.ToDouble(textBoxX17.Text);
            Double.TryParse(textBox4.Text, out a);
            Double.TryParse(TOTALTXT.Text, out f);
            double o = Convert.ToDouble(textbox17 / c);

            result = a * o;
            txtproject.Text = result.ToString();
            txtproject.Text = Math.Round(double.Parse(txtproject.Text), 2).ToString();
            total = result + f;
            TOTALTXT.Text = total.ToString();
            TOTALTXT.Text = Math.Round(double.Parse(TOTALTXT.Text), 2).ToString();
            if (total >= 75)
            {
                textBox17.Text = "Passed";
            }
            if (total <= 75)
            {
                textBox17.Text = "Failed";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quiz")
            {

                string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select QuizNo,Score,Items from Quiz ", condatabase);


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
                    btnscore.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "Seatwork")
            {

                string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select SeatworkNo , Score , Items from Seatwork ", condatabase);


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
                    btnscore.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox1.Text == "Attendance")
            {

                string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select MonthDesc as 'Month' , PresentDays , AbsentDays from attendance ", condatabase);


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
                    btnscore.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {


          
            if (cmbquarter.Text == "First Quarter")
            {
                string st_ID = txtidnum.Text;
                string studfname = txtfname.Text;
                string studlname = txtlname.Text;
                string seatworks = txtseatwork.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = textquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtEXAM.Text;
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
                string seatworks = txtseatwork.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = textquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtEXAM.Text;
                string project = txtproject.Text;
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
                string seatworks = txtseatwork.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = textquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtEXAM.Text;
                string project = txtproject.Text;
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
                string seatworks = txtseatwork.Text;
                string section = txtsection.Text;
                string subname = cmbsubject.Text;
                string quizzes = textquiz.Text;
                string attendance = txtattendance.Text;
                string exam = txtEXAM.Text;
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
            gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
            gsdb.UserID = "root";
            gsdb.Password = ""; //yung builder ano to sa visual studio
            gsdb.Database = "GradingSystem"; // name ng database
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            string Query = "Delete FROM Quiz;";

            int x = Convert.ToInt32(txtQuiz.Text);
            int y = Convert.ToInt32(txtseatwork.Text);

            MySqlCommand newbook = new MySqlCommand(Query, connection);
            MySqlDataReader myReader;

            try
            {
                connection.Open();
                myReader = newbook.ExecuteReader();

                while (myReader.Read())
                {

                }
                connection.Close();
                connection.Open();

                for (int i = 1; i <= x; ++i)
                {
                    string query1 = "INSERT INTO Quiz(QuizNo,Score,Items) values ('" + i + "','" + '0' + "','" + '0' + "');";

                    MySqlCommand newquery = new MySqlCommand(query1, connection);

                    newquery.ExecuteNonQuery();


                }
                MessageBox.Show("Quiz has been added!");


                string Query1 = "Delete FROM Seatwork;";

                MySqlCommand newbook1 = new MySqlCommand(Query1, connection);
                MySqlDataReader myReader1;

                try
                {

                    myReader1 = newbook1.ExecuteReader();

                    while (myReader1.Read())
                    {

                    }
                    connection.Close();
                    connection.Open();


                    for (int j = 1; j <= y; ++j)
                    {
                        string query1 = "INSERT INTO Seatwork(SeatworkNo,Score,Items) values ('" + j + "','" + '0' + "','" + '0' + "');";

                        MySqlCommand newquery = new MySqlCommand(query1, connection);

                        newquery.ExecuteNonQuery();


                    }
                    MessageBox.Show("Seatwork has been added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Attendance hg = new Attendance();
            hg.passvalue1 = txtidnum.Text;
            hg.passvalue2 = txtsection.Text;
            hg.passvalue3 = txtlname.Text;
            hg.passvalue4 = txtfname.Text;
            hg.passvalue5 = txtyear.Text;
            hg.ShowDialog();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            firstQ();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            SecondQ();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            ThirdQ();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            fourthQ();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            finalQ();
        }

        private void cmbsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbyear.Text = "";
            cmbyear.Items.Clear();
            teacher_year();
        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbsection.Items.Clear();
            teacher_section();

            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StudentID as 'Student ID',student_lname as 'Surname',student_fname as 'First Name',YearLevelID as 'Year',SectionId as 'Section' from students where YearLevelID = '" + cmbyear.Text + "' ", condatabase);


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

        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StudentID as 'Student ID',student_lname as 'Surname',student_fname as 'First Name',YearLevelID as 'Year',SectionId as 'Section' from students where SectionId = '" + cmbsection.Text + "' ", condatabase);


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

        private void textBoxX31_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("Surname LIKE '%{0}%'", textBoxX31.Text);
            dataGridView1.DataSource = DV;
        }

        private void btnitems_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quiz")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);

                }
                textBox12.Text = sum.ToString();
                btnscore.Enabled = true;
            }
            else if (comboBox1.Text == "Seatwork")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);

                }
                textBox9.Text = sum.ToString();
                btnscore.Enabled = true;
            }
            else if (comboBox1.Text == "Attendance")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);

                }
                textBox15.Text = sum.ToString();
                btnscore.Enabled = true;
            }
        }

        private void btnscore_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quiz")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Columns.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);

                }
                textBox13.Text = sum.ToString();
            }

            else if (comboBox1.Text == "Seatwork")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Columns.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);

                }
                textBox10.Text = sum.ToString();

            }
            else if (comboBox1.Text == "Attendance")
            {
                int sum = 0;

                for (int i = 0; i < dataGridView2.Columns.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);

                }
                textBox16.Text = sum.ToString();

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        }
    }