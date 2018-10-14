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
    public partial class CashierMainform : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public CashierMainform()
        {
            InitializeComponent();
            //getName();
            product_tbl();
            Roomlist_tbl();
            Reserve_tbl();
            stocks_tbl();
        }
        DataTable dtable;
        int xy = 0;
        int zy = 0;
        int room = 0;
        int ex = 0;

        void stocks_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select StockID,Product_ID as ProductID,Prod_desc as 'ProductName',StockOnHand,StockOnDelivery,DeliveryDate ,ExpirationDate,StockStatus from Stocks ORDER BY ExpirationDate ", condatabase);

            //MySqlDataAdapter loaddb = new MySqlDataAdapter();
            //loaddb.SelectCommand = cmddatabase;
            //dtable = new DataTable();
            //loaddb.Fill(dtable);
            //dataGridView3.Rows.Clear();

            // foreach (DataRow item in dtable.Rows)
            // {
            //    int n = dataGridView3.Rows.Add();
            //    dataGridView3.Rows[n].Cells[0].Value = false;
            //   dataGridView3.Rows[n].Cells[1].Value = item["Product_ID"].ToString();
            //   dataGridView3.Rows[n].Cells[2].Value = item["Prod_desc"].ToString();
            //    dataGridView3.Rows[n].Cells[3].Value = item["Quantity"].ToString();
            //    dataGridView3.Rows[n].Cells[4].Value = item["Price"].ToString();
            //}

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
                // dataGridView3.Rows[0].Cells[0].Value = false;
                //   dataGridView2.Columns[4].DefaultCellStyle.Format = "C";

                foreach (DataGridViewRow Myrow in dataGridView4.Rows)
                {
                    DateTime a = Convert.ToDateTime(Myrow.Cells[6].Value);
                    DateTime b = Convert.ToDateTime(DateTime.Now);
                    TimeSpan diffResult = a.Subtract(b);
                    int days = (int)diffResult.TotalMinutes;
                    int x = DateTime.Compare(a, b);

                    if (Convert.ToDateTime(Myrow.Cells[6].Value) <= Convert.ToDateTime(DateTime.Now) && Convert.ToString(Myrow.Cells[6].Value) != "")
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        //Myrow.ReadOnly = true;
                        //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ex++;
                    }
                    else if (Convert.ToDateTime(Myrow.Cells[6].Value) > Convert.ToDateTime(DateTime.Now))
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Reserve_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Room_Name as RoomName ,Room_Type as RoomType,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNo, Date_Reserved as DateReserved, AccountName from roomreservation ", condatabase);



            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView3.DataSource = bsource;
                loaddb.Update(dtable);



                foreach (DataGridViewRow Myrow in dataGridView3.Rows)
                {
                    DateTime a = Convert.ToDateTime(Myrow.Cells[6].Value);
                    DateTime b = Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy"));
                    int x = DateTime.Compare(a, b);
                    //if (x == 0)
                    //{
                    //    Myrow.DefaultCellStyle.BackColor = Color.Green;
                    //    Myrow.DefaultCellStyle.ForeColor = Color.White;
                    //    //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    zy++;
                    //}

                    if (Convert.ToDateTime(Myrow.Cells[6].Value) == Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")) && Convert.ToString(Myrow.Cells[6].Value) != "")
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Green;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        zy++;
                    }
                    else if (Convert.ToDateTime(Myrow.Cells[6].Value) < Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void product_tbl()
        {

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ProductID,Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products ", condatabase);

            //MySqlDataAdapter loaddb = new MySqlDataAdapter();
            //loaddb.SelectCommand = cmddatabase;
            //dtable = new DataTable();
            //loaddb.Fill(dtable);
            //dataGridView3.Rows.Clear();

            // foreach (DataRow item in dtable.Rows)
            // {
            //    int n = dataGridView3.Rows.Add();
            //    dataGridView3.Rows[n].Cells[0].Value = false;
            //   dataGridView3.Rows[n].Cells[1].Value = item["Product_ID"].ToString();
            //   dataGridView3.Rows[n].Cells[2].Value = item["Prod_desc"].ToString();
            //    dataGridView3.Rows[n].Cells[3].Value = item["Quantity"].ToString();
            //    dataGridView3.Rows[n].Cells[4].Value = item["Price"].ToString();
            //}

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
                // dataGridView3.Rows[0].Cells[0].Value = false;

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {

                    //Here 2 cell is target value and 1 cell is Volume
                    if (Convert.ToInt32(Myrow.Cells[3].Value) < 10 && Convert.ToString(Myrow.Cells[3].Value) != "")// Or your condition 
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Maroon;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        
                        xy++;
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Roomlist_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Room_ID,Room_Name,Room_Type,Room_Status,CheckInDateTime,CheckOutDateTime from Rooms ", condatabase);



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

                foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                {
                    DateTime a = Convert.ToDateTime(Myrow.Cells[5].Value);
                    DateTime b = Convert.ToDateTime(DateTime.Now);
                    int x = DateTime.Compare(a, b);
                    if (Convert.ToDateTime(Myrow.Cells[5].Value) <= Convert.ToDateTime(DateTime.Now) && Convert.ToString(Myrow.Cells[5].Value) != "")
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        room++;
                    }
                    else if (Convert.ToDateTime(Myrow.Cells[5].Value) > Convert.ToDateTime(DateTime.Now))
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Receptionist' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label9.Text = reader["AccountName"].ToString();
            reader.Read();
            label10.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ServiceTransaction hackers = new ServiceTransaction();
            hackers.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RoomTransaction hackers = new RoomTransaction();
            hackers.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutUs hackers = new AboutUs();
            hackers.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PRODUCTS hackers = new PRODUCTS();
            hackers.ShowDialog();
            
        }

        private void CashierMainform_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            Timer timer3 = new Timer();
            timer3.Interval = (5 * 1000); // 10 secs
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Start();
            timer1.Start();
            timer2.Start();
            string x = Convert.ToString(DateTime.Now);
            label13.Text = DateTime.Now.ToString("MMMM dd,yyyy");


            label16.Text = DateTime.Now.ToString("dddd");
            getName();
            
           

            if (xy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                //DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                label19.Text = xy.ToString();
            }
            else if (xy == 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label19.Text = "0";
            }
            product_tbl();
            if (room > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label20.Text = room.ToString();
            }
            else if (room == 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label20.Text = "0";
            }
            Roomlist_tbl();

            if (zy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                //DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                label4.Text = zy.ToString();
            }

            else if (zy == 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label4.Text = "0";
            }
            Reserve_tbl();

            if (ex > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                //DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                label25.Text = zy.ToString();
            }

            else if (ex == 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label25.Text = "0";
            }
            stocks_tbl();
            // int x = ab - 1;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label14.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("Are you sure do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Close();
                Login gg = new Login();
                gg.Show();
            }
            else if (result1 == DialogResult.No)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustomerNotif hackers = new CustomerNotif();
            hackers.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DayTransaction hackers = new DayTransaction();
            hackers.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WAIVER hackers = new WAIVER();
            hackers.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Inventory weww = new Inventory();
            weww.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            RoomTransaction hackers = new RoomTransaction();
            hackers.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            RoomTransaction hackers = new RoomTransaction();
            hackers.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 0);
            label19.ForeColor = Color.FromArgb(A, R, G, B);
            label20.ForeColor = Color.FromArgb(A, R, G, B);
            label4.ForeColor = Color.FromArgb(A, R, G, B);
            label25.ForeColor = Color.FromArgb(A, R, G, B);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            product_tbl();
            Roomlist_tbl();
            Reserve_tbl();
            //CashierMainform hackers = new CashierMainform();
            //hackers.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            product_tbl();
            Roomlist_tbl();
            Reserve_tbl();
            stocks_tbl();
            DevExpress.XtraEditors.XtraMessageBox.Show("Refresh Notification!");
          

        }

        private void CashierMainform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                button3.PerformClick();

            }
            if (e.KeyCode == Keys.F3)
            {
                button2.PerformClick();

            }
            if (e.KeyCode == Keys.F4)
            {
                button5.PerformClick();

            }
            if (e.KeyCode == Keys.F5)
            {
                button4.PerformClick();

            }
            if (e.KeyCode == Keys.F6)
            {
                button6.PerformClick();

            }
            if (e.KeyCode == Keys.F7)
            {
                button7.PerformClick();
            }
            if (e.KeyCode == Keys.F8)
            {
                button8.PerformClick();

            }
        }
    }
}