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
   
    public partial class Admin : DevExpress.XtraEditors.XtraForm
    {
        private string conn;
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private MySqlConnection connect;
        MySqlCommand cmd;
        String MyConString = "SERVER=localhost;" +
                "DATABASE=Management;" +
                "UID=root;" +
                "PASSWORD=;";
        public Admin()
        {
            InitializeComponent();
            product_tbl();
            services_Tbl();
            Reserve_tbl();
            stocks_tbl();
            //Reserve_tbl();
            // label5.Parent = pictureBox1;
            //   label5.BackColor = Color.Transparent;
            //  label3.Parent = pictureBox1;
            // label3.BackColor = Color.Transparent;
            // label2.Parent = pictureBox1;
            // label2.BackColor = Color.Transparent;
            // label1.Parent = pictureBox1;
            // label1.BackColor = Color.Transparent;
            // label6.Parent = pictureBox1;
            //  label6.BackColor = Color.Transparent;
            // label7.Parent = pictureBox1;
            // label7.BackColor = Color.Transparent;
            // label4.Parent = pictureBox1;
            //label4.BackColor = Color.Transparent;
            // simpleButton2.Parent = pictureBox1;
            // simpleButton2.BackColor = Color.Transparent;
            // simpleButton3.Parent = pictureBox1;
            //simpleButton3.BackColor = Color.Transparent;
            // simpleButton5.Parent = pictureBox1;
            // simpleButton5.BackColor = Color.Transparent;
            //simpleButton4.Parent = pictureBox1;
            //simpleButton4.BackColor = Color.Transparent;
            //simpleButton7.Parent = pictureBox1;
            // simpleButton7.BackColor = Color.Transparent;
            // simpleButton8.Parent = pictureBox1;
            // simpleButton8.BackColor = Color.Transparent;
            // simpleButton6.Parent = pictureBox1;
            // simpleButton6.BackColor = Color.Transparent;
            //simpleButton1.Parent = pictureBox1;
            //simpleButton1.BackColor = Color.Transparent;
            // simpleButton9.Parent = pictureBox1;
            //simpleButton9.BackColor = Color.Transparent;
            //label8.Parent = pictureBox1;
            //label8.BackColor = Color.Transparent;
            //label9.Parent = pictureBox3;
            //label9.BackColor = Color.Transparent;
            //label10.Parent = pictureBox3;
            //label10.BackColor = Color.Transparent;
            //label11.Parent = pictureBox1;
            //label11.BackColor = Color.Transparent;
            // label12.Parent = pictureBox1;
            // label12.BackColor = Color.Transparent;
            // simpleButton10.Parent = pictureBox1;
            //simpleButton10.BackColor = Color.Transparent;
            // label13.Parent = pictureBox3;
            //label13.BackColor = Color.Transparent;
            //label14.Parent = pictureBox3;
            //label14.BackColor = Color.Transparent;

            //label16.Parent = pictureBox3;
            // label16.BackColor = Color.Transparent;
            ///pictureBox5.Parent = pictureBox3;
            //panel1.Parent = pictureBox1;

        }
        DataTable dtable;
        int xy = 0;
        int room = 0;
        int zy = 0;
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
            
        void services_Tbl()
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


                    // (Myrow.Cells[3].Value == "Not Available")
                    //{
                    //DateTime a = Convert.ToDateTime(Myrow.Cells[5].Value);
                    //DateTime b = Convert.ToDateTime(Myrow.Cells[6].Value);
                    //int x = DateTime.Compare(a, b);
                    //int x = DateTime.Compare(Convert.ToDateTime(Myrow.Cells[5].Value), Convert.ToDateTime(Myrow.Cells[6].Value));
                    //if (x < 0) // Or your condition 
                    //{
                    // MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //panel2.Visible = true;
                    //}
                    //else if (x < 0) // Or your condition 
                    //{
                    //    //MessageBox.Show("PPPPPPP!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    Myrow.DefaultCellStyle.BackColor = Color.White;
                    //}



                    //}

                    //Here 2 cell is target value and 1 cell is Volume

                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    var now = DateTime.Now;
                    //    var expirationDate = Convert.ToDateTime(row.Cells[5].Value.ToString());
                    //    var twoHoursBefore = expirationDate.AddHours(-2);

                    //    if (now > twoHoursBefore && now < expirationDate)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Yellow;
                    //    }
                    //    else if (now > expirationDate)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Red;
                    //    }
                    //}
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("are you sure do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
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
        private void getName()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Admin' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label9.Text = reader["AccountName"].ToString();
            reader.Read();
            label10.Text = reader["userlevel"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            
            this.KeyPreview = true;
            timer1.Start();
            timer2.Start();
            string x = Convert.ToString(DateTime.Now);
            label13.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            
            
            label16.Text = DateTime.Now.ToString("dddd");
            getName();
            simpleButton1.BackColor = Color.MidnightBlue;
            simpleButton2.BackColor = Color.MidnightBlue;
            simpleButton3.BackColor = Color.MidnightBlue;
            simpleButton4.BackColor = Color.MidnightBlue;
            simpleButton5.BackColor = Color.MidnightBlue;
            simpleButton10.BackColor = Color.MidnightBlue;
            simpleButton7.BackColor = Color.MidnightBlue;
            simpleButton8.BackColor = Color.MidnightBlue;
            simpleButton9.BackColor = Color.MidnightBlue;

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
            if (zy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                //DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                label21.Text = zy.ToString();
            }

            else if (zy == 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                label21.Text = "0";
            }


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
            Reserve_tbl();
            // int x = ab - 1;
            product_tbl();
            services_Tbl();
            stocks_tbl();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AddRooms wew = new AddRooms();
            wew.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            AddServices wewe = new AddServices();
            wewe.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PRODUCTS weww = new PRODUCTS();
            weww.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            CustomerForm gege = new CustomerForm();
            gege.ShowDialog();
        }

        

        private void analogClockControl1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
          
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            BackupRestore kk = new BackupRestore();
            kk.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Quarter ll = new Quarter();
            ll.ShowDialog();
        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {
            AuditTrail etis = new AuditTrail();
            etis.ShowDialog();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ACCOUNT hackers = new ACCOUNT();
            hackers.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label14.Text = DateTime.Now.ToString("hh:mm tt");
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            WAIVER er = new WAIVER();
            er.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
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
            label21.ForeColor = Color.FromArgb(A, R, G, B);
            label25.ForeColor = Color.FromArgb(A, R, G, B);
        }

        private void label30_Click(object sender, EventArgs e)
        {
            PRODUCTS weww = new PRODUCTS();
            weww.ShowDialog();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            RoomTransaction hackers = new RoomTransaction();
            hackers.ShowDialog();
        }

        private void Admin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                simpleButton10.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                simpleButton3.PerformClick();

            }
            if (e.KeyCode == Keys.F3)
            {
                simpleButton4.PerformClick();

            }
            if (e.KeyCode == Keys.F4)
            {
                simpleButton5.PerformClick();

            }
            if (e.KeyCode == Keys.F5)
            {
                simpleButton2.PerformClick();
                
            }
            if (e.KeyCode == Keys.F6)
            {
                simpleButton7.PerformClick();

            }
            if (e.KeyCode == Keys.F7)
            {
                simpleButton8.PerformClick();
            }
            if (e.KeyCode == Keys.F8)
            {
                simpleButton9.PerformClick();

            }
            if (e.KeyCode == Keys.F10)
            {
                simpleButton1.PerformClick();

            }
            if (e.KeyCode == Keys.F9)
            {
                simpleButton6.PerformClick();

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            ACCOUNT hackers = new ACCOUNT();
            hackers.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PRODUCTS weww = new PRODUCTS();
            weww.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AddServices wewe = new AddServices();
            wewe.ShowDialog();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            CustomerForm gege = new CustomerForm();
            gege.ShowDialog();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            AddRooms wew = new AddRooms();
            wew.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WAIVER er = new WAIVER();
            er.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            BackupRestore kk = new BackupRestore();
            kk.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AuditTrail etis = new AuditTrail();
            etis.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            DialogResult result1 = XtraMessageBox.Show("are you sure do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
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

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            AboutUs etis = new AboutUs();
            etis.ShowDialog();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            AboutUs etis = new AboutUs();
            etis.ShowDialog();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            product_tbl();
            services_Tbl();
            Reserve_tbl();
            stocks_tbl();
            DevExpress.XtraEditors.XtraMessageBox.Show("Refresh Notification!");
        }
    }
}