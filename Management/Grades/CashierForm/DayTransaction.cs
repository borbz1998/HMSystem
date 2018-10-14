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
    public partial class DayTransaction : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public DayTransaction()
        {
            InitializeComponent();
           // roomreservation();
            getName();
            timer1.Start();
            serviceregistration();
            roomreservation();
        }
        DataTable dtable;

        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Cashier' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label22.Text = reader["AccountName"].ToString();
            reader.Read();
            label20.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        void roomreservation()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,Date_Reserved as DateReserved,TimeArrival,AccountName from roomreservation ", condatabase);

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

        void serviceregistration()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNumber,Service_desc as ServiceName,Service_Category as ServiceCategory,GroomerName,AccountName from serviceregistration ", condatabase);

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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Room Reservation")
            {
                roomreservation();
                label35.Text = "Room Name";
            }
            else if (comboBox2.Text == "Service Registration")
            {
                serviceregistration();
                label35.Text = "Service Name";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void DayTransaction_Load(object sender, EventArgs e)
        {
            timer1.Start();
            roomreservation();
            serviceregistration();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Service Registration" || comboBox2.Text == "")
            {
                serviceregistration();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("ServiceName LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }
            if (comboBox2.Text == "Room Reservation")
            {
                roomreservation();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}