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
    public partial class ViewGradeAdmin : DevExpress.XtraEditors.XtraForm
    {
        private string conn;
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;

        MySqlCommand cmd;
        public ViewGradeAdmin()
        {
            InitializeComponent();
            student_tbl();
            search_lname_auto();
        }
        DataTable dtable;
        private MySqlConnection connect;
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
            MySqlCommand cmddatabase = new MySqlCommand("select * from FinalGrade", condatabase);


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
        private void search_lname_auto()
        {
            textBoxX1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            textBoxX1.AutoCompleteCustomSource = DataCollection;
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("student_lname LIKE '%{0}%'", textBoxX1.Text);
            dataGridView1.DataSource = DV;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}