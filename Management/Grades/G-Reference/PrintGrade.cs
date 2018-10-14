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
    public partial class PrintGrade : DevExpress.XtraEditors.XtraForm
    {
        private string name;
        private string id;
        private string section;
        private string year;
        private string teacher;
        public PrintGrade()
        {
            InitializeComponent();
            label8.Text = name;
            label31.Text = id;
            label9.Text = section;
            label15.Text = year;
            label10.Text = teacher;
            load_studentrecord();
            student_tbl();
            
       
        }
        DataTable dtable;
        public string passvalue1
        {
            get { return name; }
            set { name = value; }
        }
        public string passvalue2
        {
            get { return id; }
            set { id = value; }
        }
        public string passvalue3
        {
            get { return section; }
            set { section = value; }
        }
        public string passvalue4
        {
            get { return year; }
            set { year = value; }
        }
        public string passvalue5
        {
            get { return teacher; }
            set { teacher = value; }
        }
        private void docu1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            printDialog1 = new PrintDialog();
            printDialog1.AllowCurrentPage = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        void load_studentrecord()
        {
            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("select SubjectDesc as 'Subject',firstqgrade as '1st Quarter',secondqgrade as '2nd Quarter',thirdqgrade as '3rd Quarter',fourthqgrade as '4th Quarter',finalgrade as 'Final Grade' from FinalGrade where studentID ='" + label31.Text + "' ", condatabase);


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
        void student_tbl()
        {


            string constring = "Server=localhost;Database=GradingSystem;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select attitude as 'Attitude',FirstQ as 'First Quarter',SecondQ as 'Second Quarter',ThirdQ as 'Third Quarter',fourthQ as 'Fourth Quarter' from Charformation where studentID = '"+label31.Text+"' ", condatabase);


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
        private void PrintGrade_Load(object sender, EventArgs e)
        {
            label8.Text = name;
            label31.Text = id;
            label9.Text = section;
            label15.Text = year;
            label10.Text = teacher;
            load_studentrecord();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}