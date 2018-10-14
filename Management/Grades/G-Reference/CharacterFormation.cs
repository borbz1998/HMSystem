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
    public partial class CharacterFormation : DevExpress.XtraEditors.XtraForm
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
        public CharacterFormation()
        {
            InitializeComponent();
            student_tbl();

        }
        DataTable dtable;
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
        public string passvalue9
        {
            get { return fname; }
            set { fname = value; }
        }
        public string passvalue7
        {
            get { return section; }
            set { section = value; }
        }
        public string passvalue8
        {
            get { return lname; }
            set { lname = value; }
        }
        public string passvalue11
        {
            get { return id; }
            set { id = value; }
        }
        public string passvalue10
        {
            get { return year; }
            set { year = value; }
        }

        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select attitude as 'Attitude',FirstQ as 'First Quarter',SecondQ as 'Second Quarter',ThirdQ as 'Third Quarter',fourthQ as 'Fourth Quarter' from Charformation ", condatabase);


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
        private void CharacterFormation_Load(object sender, EventArgs e)
        {
            txtidnum.Text = id;
            txtsection.Text = section;
            txtlname.Text = lname;
            txtyear.Text = year;
            txtfname.Text = fname;
        }

        private void lnamsss(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void qwe(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void wer(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void jk(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void hh(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void dd(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void ty(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void asd(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void ratbu(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar.ToString() != "\b")
            {
                e.Handled = true;
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            string court = textBoxX1.Text;
            string honest = textBoxX2.Text;
            string gg = textBoxX3.Text;
            string ww = textBoxX4.Text;
            string er = textBoxX5.Text;
            string hh = textBoxX6.Text;
            string yy = textBoxX7.Text;
            if (court != "A" && court != "B" && court != "C" && court != "D" && court != "E" && honest != "A" && honest != "B" && honest != "C" && honest != "D" && honest != "E" && gg != "A" && gg != "B" && gg != "C" && gg != "D" && gg != "E" && ww != "A" && ww != "B" && ww != "C" && ww != "D" && ww != "E" && er != "A" && er != "B" && er != "C" && er != "D" && er != "E" && hh != "A" && hh != "B" && hh != "C" && hh != "D" && hh != "E" && yy != "A" && yy != "B" && yy != "C" && yy != "D" && yy != "E")
            {
                textBoxX1.Text = "";
                 DevExpress.XtraEditors.XtraMessageBox.Show("ERROR, the choices ranged A-E only");
                 return;
                     
            }
        }
    }
}