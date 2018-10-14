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
    public partial class AuditTrail : DevExpress.XtraEditors.XtraForm
    {
        MySqlCommand cmd;
        private string conn;
        private MySqlConnection connect;
        public AuditTrail()
        {
            InitializeComponent();
            student_tbl();
            Load_activities();
            getName();
        }
        DataTable dtable;
        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=Management;Uid=root;Pwd=;";
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
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Login_id as 'Login ID',AccountName as 'Login Name',Login_username as 'Username',Login_pass as 'Password',userlevel as 'User Level',DateTimeIn as 'Login Time' from LOGIN", condatabase);


            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                gridControl1.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Admin' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void AuditTrail_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_activities()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("select ActId as 'Activity No',AccountName as 'Name',userlevel as 'User Level',ActName as 'Activity',ActDesc 'Item Name' from acty", condatabase);
            try
            {
                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                gridControl2.DataSource = bsource;
                loaddb.Update(dtable);

            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedItem.ToString() == "Login History")
            {
                gridControl2.Visible = false;
                gridControl1.Visible = true;
            }
            if (comboBoxEdit1.SelectedItem.ToString() == "Activity History")
            {
                gridControl1.Visible = false;
                gridControl2.Visible = true;
            }
        }
    }
}