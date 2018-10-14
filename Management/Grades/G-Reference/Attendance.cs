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
    public partial class Attendance : DevExpress.XtraEditors.XtraForm
    {
        private string user;
        private string conn;
        private MySqlConnection connect;
        MySqlDataAdapter dp;
        MySqlCommand cmd;
        private string id;
        private string fname;
        private string section;
        private string lname;
        private string year;
        public Attendance()
        {
            InitializeComponent();
            student_tbl();
            load_quarter();
        }
        DataTable dtable;

        double a, b, c, d, f, g, h, l, m, n, o, total;
        public string passvalue4
        {
            get { return fname; }
            set { fname = value; }
        }
        public string passvalue2
        {
            get { return section; }
            set { section = value; }
        }
        public string passvalue3
        {
            get { return lname; }
            set { lname = value; }
        }
        public string passvalue1
        {
            get { return id; }
            set { id = value; }
        }
        public string passvalue5
        {
            get { return year; }
            set { year = value; }
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
        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("select studentID,jun,july,aug,sept,oct,nov,decem,jan,feb,march,april,(jun+july+aug+sept+oct+nov+decem+jan+feb+march+april) as TOTAL from attendance where studentID = '"+txtidnum.Text+"';", condatabase);


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
        private void Attendance_Load(object sender, EventArgs e)
        {
            txtidnum.Text=id;
            txtsection.Text=section;
            txtlname.Text=lname;
            txtyear.Text=year;
            txtfname.Text=fname;
        }

        private void jun(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void july(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void aug(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void sept(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void oct(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void nov(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void dec(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void jan(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void feb(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void march(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void april(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string studID = txtidnum.Text;
            string jun = textBoxX12.Text;
            string jul = textBoxX1.Text;
            string aug = textBoxX2.Text;
            string sep = textBoxX5.Text;
            string oct = textBoxX4.Text;
            string nov = textBoxX3.Text;
            string dec = textBoxX8.Text;
            string jan = textBoxX7.Text;
            string feb = textBoxX6.Text;
            string mar = textBoxX11.Text;
            string april = textBoxX10.Text;
            string total = textBoxX9.Text;


            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "GradingSystem";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());


            MySqlCommand Cmd_Subj = new MySqlCommand("SELECT * from attendance", connection);

            MySqlDataReader myReader;
            string studentSHIT = "";


            int x = 0;

            try
            {
                connection.Open();
                myReader = Cmd_Subj.ExecuteReader();
                while (myReader.Read())
                {

                    studentSHIT = myReader.GetString("StudentID");

                    if (studentSHIT == studID)
                    {
                        string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
                        string Query = "update attendance set jun='" + jun + "',july='" + jul + "',aug='" + aug + "',sept='" + sep + "',oct='" + oct + "',nov='" + nov + "',decem='" + dec + "',jan='" + jan + "',feb='" + feb + "',march='" + mar + "',april='" + april + "',total='" + total + "' where StudentID='" + studID + "' ;";


                        MySqlConnection condatabase = new MySqlConnection(constring);
                        MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);

                        MySqlDataReader myReader1;
                        try
                        {
                            condatabase.Open();
                            myReader1 = cmddatabase.ExecuteReader();
                            DevExpress.XtraEditors.XtraMessageBox.Show("attendance has been updated");
                            while (myReader1.Read())
                            {

                            }
                            x = 1;
                            student_tbl();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        condatabase.Close();
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
                string newuser_sql = "INSERT INTO attendance (StudentID,jun,july,aug,sept,oct,nov,decem,jan,feb,march,april,total) VALUES (@id, @junex, @juyx, @augz, @sepo, @octo, @novo, @deco, @jano, @febo, @mars, @apro , @total)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@id", studID);
                newuser.Parameters.AddWithValue("@junex", jun);
                newuser.Parameters.AddWithValue("@juyx", jul);
                newuser.Parameters.AddWithValue("@augz", aug);
                newuser.Parameters.AddWithValue("@sepo", sep);
                newuser.Parameters.AddWithValue("@octo", oct);
                newuser.Parameters.AddWithValue("@novo", nov);
                newuser.Parameters.AddWithValue("@deco", dec);
                newuser.Parameters.AddWithValue("@jano", jan);
                newuser.Parameters.AddWithValue("@febo", feb);
                newuser.Parameters.AddWithValue("@mars", mar);
                newuser.Parameters.AddWithValue("@apro", april);
                newuser.Parameters.AddWithValue("@total", total);
                newuser.ExecuteNonQuery();
                x = 2;
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("Attendance Stored");
                student_tbl();
                connection.Close();
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
            gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
            gsdb.UserID = "root";
            gsdb.Password = ""; //yung builder ano to sa visual studio
            gsdb.Database = "GradingSystem"; // name ng database
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            string Query = "Delete FROM attendances;";

            int x = Convert.ToInt32(textBoxX13.Text);


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
                    string query1 = "INSERT INTO attendances(NumberDays,Attendance) values ('" + i + "','" + '0' + "');";

                    MySqlCommand newquery = new MySqlCommand(query1, connection);

                    newquery.ExecuteNonQuery();


                }
                MessageBox.Show("Days has been added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        void load_quarter()
        {
            string constringss = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            string Query2 = "SELECT distinct QuarterDesc FROM Quarters;";

            MySqlConnection condatabasess = new MySqlConnection(constringss);
            MySqlCommand cmddatabasess = new MySqlCommand(Query2, condatabasess);
            MySqlDataReader myReader2;
            try
            {
                condatabasess.Open();
                myReader2 = cmddatabasess.ExecuteReader();

                while (myReader2.Read())
                {
                    string Q = myReader2.GetString("QuarterDesc");
                    cmbquarter.Items.Add(Q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
            gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
            gsdb.UserID = "root";
            gsdb.Password = ""; //yung builder ano to sa visual studio
            gsdb.Database = "GradingSystem"; // name ng database
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());


            if (cmbmonth.Text == "June")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX12.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "July")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX1.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "August")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                simpleButton2.Enabled = true;
                textBoxX2.Text = Attendance.ToString();
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "September")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX5.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "October")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX4.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "November")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX3.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "December")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX8.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "January")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX7.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "February")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX6.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "March")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX11.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }

            else if (cmbmonth.Text == "April")
            {
                int Attendance = 0;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if ((string)dataGridView2.Rows[i].Cells[1].Value == "P") //try referring to cells by column names and not the index 
                        Attendance++;
                }
                textBoxX10.Text = Attendance.ToString();
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }
        }

        private void cmbquarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbmonth.Items.Clear();
            if (cmbquarter.Text == "First Quarter")
            {
                cmbmonth.Items.Add("June");
                cmbmonth.Items.Add("July");
                cmbmonth.Items.Add("Aug");
            }
            if (cmbquarter.Text == "Second Quarter")
            {
                cmbmonth.Items.Add("September");
                cmbmonth.Items.Add("October");
            }
            if (cmbquarter.Text == "Third Quarter")
            {
                cmbmonth.Items.Add("November");
                cmbmonth.Items.Add("December");
                cmbmonth.Items.Add("January");
            }
            if (cmbquarter.Text == "Fourth Quarter")
            {
                cmbmonth.Items.Add("Feb");
                cmbmonth.Items.Add("March");
                cmbmonth.Items.Add("April");
            }
        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select NumberDays as 'Day No.',Attendance from attendances ", condatabase);


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
            simpleButton4.Enabled = true;
        }

        private void textBoxX9_TextChanged(object sender, EventArgs e)
        {
            AutocalculateSum();
        }
        private void AutocalculateSum()
        {
            string jun = textBoxX12.Text;
            string jul = textBoxX1.Text;
            string aug = textBoxX2.Text;
            string sep = textBoxX5.Text;
            string oct = textBoxX4.Text;
            string nov = textBoxX3.Text;
            string dec = textBoxX8.Text;
            string jan = textBoxX7.Text;
            string feb = textBoxX6.Text;
            string mar = textBoxX11.Text;
            string april = textBoxX10.Text;

            Double.TryParse(jun, out a);
            Double.TryParse(jul, out b);
            Double.TryParse(aug, out d);
            Double.TryParse(sep, out f);
            Double.TryParse(oct, out g);
            Double.TryParse(nov, out h);
            Double.TryParse(dec, out c);
            Double.TryParse(jan, out l);
            Double.TryParse(feb, out m);
            Double.TryParse(mar, out n);
            Double.TryParse(april, out o);

            total = a + b + d + f + g + h;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX12_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX12.Text, out a);

            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX1.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX2.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX5.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX4.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX3.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX8.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX7.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX6_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX6.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX11_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX11.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void textBoxX10_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(textBoxX10.Text, out a);
            Double.TryParse(textBoxX13.Text, out f);
            total = a + f;
            textBoxX9.Text = total.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}