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
    public partial class RoomTransaction : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public RoomTransaction()
        {
            InitializeComponent();
            // Roomlist_tbl();
            timer2.Start();
            // transactdet_tbl();
            timer3.Start();
            timer1.Start();
            getName();
            getName2();
            //autocomplete();
            Reserve_tbl();
            transactdet_tbl();
            getName3();
            getName1();
            //fillcombo();
            // roomboarding();
            //  autocomplete2();
            //XtraTabControl.SelectedIndex += new EventHandler(XtraTabControl_SelectedIndexChanged);
        }
        DataTable dtable;

        int xy = 0;
        int zy = 0;

        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select distinct Pet_Name from petinfo  where Customer_Name='" + textBox2.Text + "'  ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Pet_Name");
                    // comboBox1.Items.Add(sname);
                    comboBox10.Items.Add(sname);
                }
                condatabase.Close();


                //condatabase.Open();

                //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                //newquery.ExecuteNonQuery();

                //account_tbl();
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();
            //string activity = "Delete Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }

            condatabase.Close();
        }
        private void getName3()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Pet_ID + 1) as PetID from PetInfo order by PetID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox23.Text = reader["PetID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        void autocomplete()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Customer";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Customer_Name");
                    coll.Add(sname);

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox2.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }

        void autocomplete2()
        {
            textBox11.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database =Management;Uid=root;Pwd=";


            string Query = "Select * from roomreservation";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Room_Name");
                    coll.Add(sname);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox11.AutoCompleteCustomSource = coll;


            {
            }

            condatabase.Close();


        }
        public void Roomlist_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Room_ID as RoomID,Room_Name as RoomName,Room_Type as RoomType,Room_Status as RoomStatus,CheckInDateTime,CheckOutDateTime from Rooms ", condatabase);



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

                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    DateTime a = Convert.ToDateTime(Myrow.Cells[5].Value);
                    DateTime b = Convert.ToDateTime(DateTime.Now);
                    TimeSpan diffResult = a.Subtract(b);
                    int days = (int)diffResult.TotalMinutes;
                    int x = DateTime.Compare(a, b);

                    if (Convert.ToDateTime(Myrow.Cells[5].Value) <= Convert.ToDateTime(DateTime.Now) && Convert.ToString(Myrow.Cells[5].Value) != "")
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Red;
                        Myrow.DefaultCellStyle.ForeColor = Color.White;
                        //Myrow.ReadOnly = true;
                        //MessageBox.Show("Times Up!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xy++;
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

        void Reserve_tbl()
        {
            string constring = "Server=localhost; Database =Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Reserve_ID as ReserveID, Room_Type as RoomType,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNo, Date_Reserved as DateReserved,TimeArrival, AccountName from roomreservation ", condatabase);



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

                    if (Convert.ToDateTime(Myrow.Cells[6].Value) == Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")) && Convert.ToString(Myrow.Cells[7].Value) != "")
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
        void transactdet_tbl()
        {
           
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as RoomID,Prod_desc as RoomName,Quantity,Price,TransactionDate from transactiondetails where InvoiceNo='" + textBox7.Text + "'", condatabase);

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

                double sum = 0;
                double x = 0.12;
                double vat = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);

                    vat = (sum * x);
                }
                label30.Text = sum.ToString();
                label22.Text = sum.ToString();
                label22.Text = String.Format("{0:C}", double.Parse(label22.Text));

                label31.Text = vat.ToString();
                label23.Text = vat.ToString();
                label23.Text = String.Format("{0:C}", double.Parse(label23.Text));
                dataGridView2.Columns[3].DefaultCellStyle.Format = "C";
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void roomboarding()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as RoomID,Prod_desc as RoomName,Quantity,Price,TransactionDate from transactiondetails where transaction_type='" + "Rooms" + "'", condatabase);

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

                double sum = 0;
                double x = 0.12;
                double vat = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);

                    vat = (sum * x);
                }
                label30.Text = sum.ToString();
                label22.Text = sum.ToString();
                label22.Text = String.Format("{0:C}", double.Parse(label22.Text));

                label31.Text = vat.ToString();
                label23.Text = vat.ToString();
                label23.Text = String.Format("{0:C}", double.Parse(label23.Text));
                dataGridView1.Columns[3].DefaultCellStyle.Format = "C";
                {
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
            string eug = "select * from LOGIN where userlevel= 'Cashier' order by Login_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            label17.Text = reader["AccountName"].ToString();
            reader.Read();
            label20.Text = reader["StaffID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Customer_ID + 1) as CustomerID from Customer order by CustomerID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["CustomerID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (InvoiceNo + 1) as InvoiceNo from transactiondetails order by InvoiceNo desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox7.Text = reader["InvoiceNo"].ToString();
            //label27.Text = reader["InvoiceNo"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string invoice = textBox7.Text;
            string ids = textBox6.Text;
            string desc = textBox11.Text;
            string roomtype = textBox10.Text;
            string quantity = comboBox3.Text;
            string price = textBox8.Text;
            string checkin = label16.Text;
            string checkout = label15.Text;
            string TDate = label33.Text;
            string unitprice = label48.Text;
            string aa = "Not Available";
            string transactype = "Rooms";
            string customer = textBox2.Text;
            int quan = 1;
            //int resquan = Convert.ToInt32(label16.Text);
            int x = 0;
            double y = 0;
            double z = 0;

            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == "" || quantity == "" || price == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            if (label52.Text == "Not Available")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("This Room is not available");
                return;
            }
            z = Convert.ToDouble(price);
            //x = resquan - quan;
            y = quan * z;
            string prices = y.ToString();
            string newquan = x.ToString();

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO transactiondetails (InvoiceNo,Product_ID,Prod_desc,UnitPrice,Quantity,Price,transaction_type,Customer_Name,TransactionDate) VALUES (@InvoiceNo,@Product_ID, @Prod_desc,@UnitPrice, @Quantity,@Price,@transaction_type,@Customer_Name,@TransactionDate)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@InvoiceNo", invoice);
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            newuser.Parameters.AddWithValue("@UnitPrice", unitprice);
            newuser.Parameters.AddWithValue("@Quantity", quantity);
            newuser.Parameters.AddWithValue("@Price", price);
            newuser.Parameters.AddWithValue("@transaction_type", transactype);
            newuser.Parameters.AddWithValue("@Customer_Name", customer);
            newuser.Parameters.AddWithValue("@TransactionDate", TDate);
            newuser.ExecuteNonQuery();



            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            string query1 = "update Management.Rooms set CheckInDateTime='" + checkin + "',CheckOutDateTime='" + checkout + "',Room_Status='" + aa + "',InvoiceNo='" + invoice + "'where Room_ID='" + ids + "' ;";

            MySqlCommand newquery = new MySqlCommand(query1, connection);
            //getName();
            newquery.ExecuteNonQuery();
            //connection.Close();
            //connection.Open();



            //string activity = "Add Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            //{
            //}
            Roomlist_tbl();
            //transaction_tbl();

            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
           // getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            //ProductClick.Visible = false;

            connection.Close();

        }

        private void RoomTransaction_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            timer2.Start();
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            //label15.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            //DataGridViewColumn column = dataGridView1.Columns[0];
            //column.Width = 80;
            //DataGridViewColumn column1 = dataGridView1.Columns[1];
            //column1.Width = 70;
            //DataGridViewColumn column2 = dataGridView1.Columns[2];
            //column2.Width = 70;
            if (xy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                DialogResult dialog = XtraMessageBox.Show("Room Transaction Has been Expired =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            }

            if (zy > 0)
            {
                //int dd = 0;
                //dataGridView3.RowCount = dd;
                int ab = 0;
                ab = xy - 1;
                DialogResult dialog = XtraMessageBox.Show("Number of  Reservation  =   " + zy, "Confirmation", MessageBoxButtons.OKCancel);
                // label4.Text = zy.ToString();
            }
            //else if (zy == 0)
            //{
            //    //int ab = 0;
            //    // ab = xy - 1;
            //    label4.Text = "0";
            //}
            // Reserve_tbl();
            // int x = ab - 1;
            //getName1();
            Roomlist_tbl();
            transactdet_tbl();
        }


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label33.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
            this.label38.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            this.label39.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Overnight")
            {
                comboBox3.Items.Clear();
                label4.Text = "Days:";
                comboBox3.Items.Add("1");
                comboBox3.Items.Add("2");
                comboBox3.Items.Add("3");
                comboBox3.Items.Add("4");
                comboBox3.Items.Add("5");
                textBox8.Text = "";
                label48.Text = "450.00";
            }
            else if (comboBox2.Text == "Daycare")
            {
                comboBox3.Items.Clear();
                label4.Text = "Hours:";
                comboBox3.Items.Add("1");
                comboBox3.Items.Add("2");
                comboBox3.Items.Add("3");
                comboBox3.Items.Add("4");
                comboBox3.Items.Add("5");
                comboBox3.Items.Add("6");
                comboBox3.Items.Add("7");
                comboBox3.Items.Add("8");
                comboBox3.Items.Add("9");
                comboBox3.Items.Add("10");
                comboBox3.Items.Add("11");
                comboBox3.Items.Add("12");
                comboBox3.Items.Add("13");
                comboBox3.Items.Add("14");
                comboBox3.Items.Add("15");
                comboBox3.Items.Add("16");
                comboBox3.Items.Add("17");
                comboBox3.Items.Add("18");
                comboBox3.Items.Add("19");
                comboBox3.Items.Add("20");
                comboBox3.Items.Add("21");
                comboBox3.Items.Add("22");
                comboBox3.Items.Add("23");
                textBox8.Text = "";
                label48.Text = "100.00";
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int x = 0;
            //int y = 0;

            //if (label4.Text == "Hours:")
            //{
            //    timer1.Start();
            //    int s = Convert.ToInt32(comboBox3.Text);
            //    DateTime myDateTime = Convert.ToDateTime(label16.Text);
            //    myDateTime = myDateTime.AddHours(s);
            //    label15.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            //    x = Convert.ToInt32(comboBox3.Text);
            //    y = x * 100;
            //    textBox8.Text = y.ToString();
            //}
            //if (label4.Text == "Days:")
            //{
            //    timer1.Start();
            //    int s = Convert.ToInt32(comboBox3.Text);
            //    int h = s * 24;
            //    DateTime myDateTime = Convert.ToDateTime(label16.Text);
            //    myDateTime = myDateTime.AddHours(h);
            //    label15.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            //    x = Convert.ToInt32(comboBox3.Text);
            //    y = x * 450;
            //    textBox8.Text = y.ToString();
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells["Room_ID"].Value.ToString();
                textBox5.Text = row.Cells["Room_Status"].Value.ToString();
                textBox10.Text = row.Cells["Room_Type"].Value.ToString();
                textBox11.Text = row.Cells["Room_Name"].Value.ToString();

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow dr in dataGridView1.Rows)
            //{

            //    if (Convert.ToString(dr.Cells[5].Value) != "")// Or your condition 
            //    {                                                                                          //    {
            //        dr.Cells[6].Value = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");

            //    }
            //    else if (Convert.ToString(dr.Cells[5].Value) == "")
            //    {
            //        dr.Cells[6].Value = "";
            //    }
            //}

            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label29.Text = DateTime.Now.ToString("hh:mm tt");
            this.label56.Text = DateTime.Now.ToString("hh:mm tt");
            this.dateTimePicker2.Text = DateTime.Now.ToString("hh:mm tt");
            label28.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string xy = label15.Text;
            //DateTime a = Convert.ToDateTime(xy);

            //label15.Text = a.ToString("MMMM dd,yyyy  hh:mm:ss tt");


            int x = 0;
            int y = 0;
            if (comboBox3.Text == "")
            {
                DateTime.Now.ToString("HH:mm tt");
                DateTime dateTime = DateTime.Now;
                this.label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            }
            else if (label4.Text == "Hours:" && comboBox3.Text != "")
            {
                timer1.Start();
                int s = Convert.ToInt32(comboBox3.Text);
                //DateTime myDateTime = Convert.ToDateTime(label16.Text);
                DateTime myDateTime = DateTime.Now;
                myDateTime = myDateTime.AddHours(s);
                label15.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                x = Convert.ToInt32(comboBox3.Text);
                y = x * 100;
                textBox8.Text = y.ToString();
            }
            else if (label4.Text == "Days:" && comboBox3.Text != "")
            {
                timer1.Start();
                int s = Convert.ToInt32(comboBox3.Text);
                int h = s * 24;
                //DateTime myDateTime = Convert.ToDateTime(label16.Text);
              
                DateTime myDateTime = DateTime.Now;
                myDateTime = myDateTime.AddHours(h);
                label15.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                x = Convert.ToInt32(comboBox3.Text);
                y = x * 450;
                textBox8.Text = y.ToString();
            }
            //////////////////////////////////////////
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" )
            {
                //textBox17.Text = textBox6.Text;
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select * from Customer where Customer_ID='" + textBox1.Text + "' ", condatabase);

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                int i = dtable.Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("The Customer has already added ");
                    //simpleButton22.Visible = true;
                    //simpleButton23.Visible = true;
                    string sname = "";
                    //textBox1.Text = sname2;
                    textBox2.Text = sname;
                    textBox9.Text = sname;
                    textBox12.Text = sname;
                    textBox3.Text = sname;
                    textBox4.Text = sname;
                    textBox6.Text = sname;
                    textBox13.Text = sname;
                    textBox11.Text = sname;
                    textBox8.Text = sname;
                    textBox10.Text = sname;
                    comboBox3.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    getName2();
                    //getName1();
                    dtable.Clear();
                    return;
                }

                else if (i == 0)
                { 


                string ids = textBox1.Text;
                string owner = textBox2.Text;
                string pet = textBox9.Text;
                string breed = textBox12.Text;
                string x = textBox3.Text;
                string contactno = label27.Text + x;
                string email = textBox4.Text;
                //string user = textBox6.Text;
                //string pass = textBox5.Text;
                //string userlevs = "Admin";

                if (ids == "" || owner == "" || contactno == "" || email == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                    return;
                }
                //if (quantity == "0")
                //{
                //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
                //    return;
                //}
                MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
                gsdb.Server = "localhost";
                gsdb.UserID = "root";
                gsdb.Password = "";
                gsdb.Database = "Management";
                MySqlConnection connection = new MySqlConnection(gsdb.ToString());

                connection.Open();
                string newuser_sql = "INSERT INTO Customer (Customer_ID,Customer_Name,Contact_No,Email_Address) VALUES (@Customer_ID, @Customer_Name,@Contact_No,@Email_Address)";
                MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
                newuser.CommandText = newuser_sql;
                newuser.Parameters.AddWithValue("@Customer_ID", ids);
                newuser.Parameters.AddWithValue("@Customer_Name", owner);
               // newuser.Parameters.AddWithValue("@Pet_Name", pet);
               // newuser.Parameters.AddWithValue("@Breed", breed);
                newuser.Parameters.AddWithValue("@Contact_No", contactno);
                newuser.Parameters.AddWithValue("@Email_Address", email);
                newuser.ExecuteNonQuery();
                {
                }
                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

                //string query1 = "INSERT INTO Account(adminID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

                //MySqlCommand newquery = new MySqlCommand(query1, connection);
                //getName();
                //newquery.ExecuteNonQuery();


                //textBoxX2.Text = "";
                //textBoxX3.Text = "";
                //textBoxX4.Text = "";
                //textBoxX5.Text = "";
                //textBoxX6.Text = "";
                //connection.Close();
                //connection.Open();
                string activity = "Add Customer";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                string sname = "";
                //textBox1.Text = sname2;
                textBox2.Text = sname;
                textBox9.Text = sname;
                textBox12.Text = sname;
                textBox3.Text = sname;
                textBox4.Text = sname;
                getName2();
                //getName1();
                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = -1;
                comboBox3.Items.Clear();
                comboBox4.SelectedIndex = -1;
                textBox14.Text = "";
                textBox15.Text = "";
                textBox18.Text = "";
                comboBox4.Enabled = true;
                label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                connection.Close();
            }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Customer where Customer_ID='" + textBox1.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                    while (myReader.Read())
                    {

                    }

                    condatabase.Close();

                    //condatabase.Open();

                    //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    //newquery.ExecuteNonQuery();

                    //account_tbl();
                    //getName();
                    condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();
                string activity = "Delete Customer";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                string sname = "";
                //textBox1.Text = sname2;
                textBox2.Text = sname;
                textBox9.Text = sname;
                textBox12.Text = sname;
                textBox3.Text = sname;
                textBox4.Text = sname;
                getName2();
                //getName1();
                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox8.Text = "";
                comboBox2.SelectedIndex = -1;
                comboBox3.Items.Clear();
                comboBox4.SelectedIndex = -1;
                textBox14.Text = "";
                textBox15.Text = "";
                textBox18.Text = "";
                comboBox4.Enabled = true;
                label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                condatabase.Close();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string owner = textBox2.Text;
            string pet = textBox9.Text;
            string breed = textBox12.Text;
            string x = textBox3.Text;
            string contactno = label27.Text + x;
            string email = textBox4.Text;
            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || owner == "" || contactno == "" || email == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
          
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Customer set Customer_ID='" + textBox1.Text + "',Customer_Name='" + textBox2.Text + "',Contact_No='" + contactno + "',Email_Address='" + textBox4.Text + "'where Customer_ID='" + textBox1.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Customer Info has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Customer Info";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels", level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
            //getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            condatabase.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
        
            if (textBox2.Text != "")
            {
                


                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select * from Customer where Customer_Name='" + textBox2.Text + "';";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();


                    while (myReader.Read())
                    {
                        string sname = myReader.GetString("Customer_Name");
                        string sname2 = myReader.GetInt32("Customer_ID").ToString();
                        //string sname3 = myReader.GetString("Pet_Name");
                        //string sname4 = myReader.GetString("Breed");
                        string sname5 = myReader.GetString("Contact_No");
                        string sname6 = myReader.GetString("Email_Address");

                        fillcombo();
                        textBox1.Text = sname2;
                        textBox2.Text = sname;
                        //textBox9.Text = sname3;
                        //textBox12.Text = sname4;
                        textBox3.Text = sname5;
                        textBox4.Text = sname6;

                    }
                    condatabase.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();

                {
                }

            condatabase.Close();
            }

            if (textBox2.Text == "")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox9.Text = "";
                textBox12.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                //getName1();
                simpleButton2.Enabled = true;
                comboBox10.Items.Clear();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            comboBox10.Items.Clear();
            getName2();
            getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";           
            comboBox4.Enabled = true;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string sname1 = textBox1.Text;
            string sname2 = textBox2.Text;
            string sname3 = textBox9.Text;
            string sname4 = textBox12.Text;
            string sname5 = textBox3.Text;
            string sname6 = textBox4.Text;

            if (sname1 == "" || sname2 == "" || sname5 == "" || sname6 == "")
            {
                simpleButton2.Enabled = false;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
            }

            else if (sname1 != "" && sname2 != "" && sname5 != "" && sname6 != "")
            {
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = true;
                simpleButton4.Enabled = true;
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox4.Text == "Check-In" || comboBox4.Text == "")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox6.Text = row.Cells["RoomID"].Value.ToString();
                    textBox5.Text = row.Cells["RoomStatus"].Value.ToString();
                    textBox10.Text = row.Cells["RoomType"].Value.ToString();
                    textBox11.Text = row.Cells["RoomName"].Value.ToString();

                    if (textBox5.Text == "Not Available")
                    {
                        label58.Text = row.Cells["RoomID"].Value.ToString();
                        textBox21.Text = row.Cells["RoomName"].Value.ToString();
                        textBox20.Text = row.Cells["CheckInDateTime"].Value.ToString();
                        textBox19.Text = row.Cells["CheckOutDateTime"].Value.ToString();
                    }
                }
            }
            else if (comboBox4.Text == "Reservation")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox6.Text = row.Cells["RoomID"].Value.ToString();
                    textBox5.Text = row.Cells["RoomStatus"].Value.ToString();
                    textBox15.Text = row.Cells["RoomType"].Value.ToString();
                    textBox14.Text = row.Cells["RoomName"].Value.ToString();

                    if (textBox5.Text == "Not Available")
                    {
                        label58.Text = row.Cells["RoomID"].Value.ToString();
                        textBox21.Text = row.Cells["RoomName"].Value.ToString();
                        textBox20.Text = row.Cells["CheckInDateTime"].Value.ToString();
                        textBox19.Text = row.Cells["CheckOutDateTime"].Value.ToString();
                    }
                }
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want new Transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Transactiondetails where InvoiceNo='" + textBox7.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    //DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                    while (myReader.Read())
                    {

                    }

                    condatabase.Close();

                    //condatabase.Open();

                    //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    //newquery.ExecuteNonQuery();

                    //account_tbl();
                    //getName();
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();
                //string activity = "Delete Product";
                //string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                //newuser1.CommandText = newuser_sql2;
                //newuser1.Parameters.AddWithValue("@act", activity);
                //newuser1.Parameters.AddWithValue("@namc", label4.Text);
                //newuser1.Parameters.AddWithValue("@levels", label5.Text);
                //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                //newuser1.ExecuteNonQuery();
                {
                }
                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog2 = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName1();
                //textBox1.Text = "";
                //textBox2.Text = "";
                //textBox4.Text = "";
                //textBox3.Text = "0";
                //comboBox1.Items.Clear();
                //textBox6.Text = "0";
                //textBox6.Enabled = false;
                //fillcombo();
                transactdet_tbl();
                Roomlist_tbl();

                condatabase.Close();
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label32.Text = row.Cells["RoomID"].Value.ToString();


            }
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            string invoice = textBox7.Text;
            string ids = textBox6.Text;
            string desc = textBox11.Text;
            string roomtype = textBox10.Text;
            string quantity = comboBox3.Text;
            string price = textBox8.Text;
            string checkin = label16.Text;
            string checkout = label15.Text;
            string unitprice = label48.Text;
            string aa = "Not Available";
            string transactype = "Rooms";
            string customer = textBox2.Text;
            if (ids == "" || desc == "" || roomtype == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }

            string status = "Available";
            string check = "";
            string date = "December 31, 2999 12:59 PM";
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Rooms set Room_Status='" + status + "',CheckInDateTime='" + check + "',CheckOutDateTime='" + date + "'where Room_ID='" + textBox6.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Room has been Updated!");
                while (myReader.Read())
                {

                }

                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
            getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            Roomlist_tbl();
            {
            }



        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == "Check-In")
            {
                groupControl1.Visible = true;
                groupControl3.Visible = false;
            }
            if (comboBox4.SelectedItem == "Reservation")
            {

                groupControl1.Visible = true;
                groupControl3.Visible = true;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want new Transaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.Transactiondetails where InvoiceNo='" + textBox7.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    //DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                    while (myReader.Read())
                    {

                    }

                    condatabase.Close();

                    //condatabase.Open();

                    //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    //newquery.ExecuteNonQuery();

                    //account_tbl();
                    //getName();
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();
                //string activity = "Delete Product";
                //string newuser_sql2 = "INSERT INTO acty (Actname,namex,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                //newuser1.CommandText = newuser_sql2;
                //newuser1.Parameters.AddWithValue("@act", activity);
                //newuser1.Parameters.AddWithValue("@namc", label4.Text);
                //newuser1.Parameters.AddWithValue("@levels", label5.Text);
                //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                //newuser1.ExecuteNonQuery();
                {
                }
                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog2 = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                getName1();
                //textBox1.Text = "";
                //textBox2.Text = "";
                //textBox4.Text = "";
                //textBox3.Text = "0";
                //comboBox1.Items.Clear();
                //textBox6.Text = "0";
                //textBox6.Enabled = false;
                //fillcombo();
                transactdet_tbl();
                Roomlist_tbl();

                condatabase.Close();
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(rowIndex);
            double sum = 0;
            double x = 0.12;
            double vat = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);

                vat = (sum * x);
            }

            label22.Text = sum.ToString();
            label22.Text = String.Format("{0:C}", double.Parse(label22.Text));

            label23.Text = vat.ToString();
            label23.Text = String.Format("{0:C}", double.Parse(label23.Text));

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to removed the Room to the cart?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.transactiondetails where Product_ID='" + label32.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("The Room has been removed to the cart");

                    while (myReader.Read())
                    {

                    }

                    //condatabase.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //condatabase.Open();

                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Daycare");
                comboBox2.Items.Add("Overnight");
                comboBox3.Items.Clear();
                textBox8.Text = "";

                condatabase.Close();
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "RoomList" || comboBox7.Text == "")
            {
                Roomlist_tbl();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox13.Text);
                dataGridView1.DataSource = DV;
            }
            if (comboBox7.Text == "ReservationList")
            {
                Reserve_tbl();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox13.Text);
                dataGridView3.DataSource = DV;
            }
            if (comboBox7.Text == "RoomBoarding" || comboBox7.Text == "")
            {
                Roomlist_tbl();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox13.Text);
                dataGridView1.DataSource = DV;
            }
            if (comboBox7.Text == "Transaction Table" || comboBox7.Text == "")
            {
                transactdet_tbl();
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("RoomName LIKE '%{0}%'", textBox13.Text);
                dataGridView2.DataSource = DV;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                Roomlist_tbl();
            }

            else {
                Roomlist_tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Room_ID,Room_Name,Room_Type,Room_Status from Rooms where Room_Type = '" + comboBox1.Text + "' ", condatabase);


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
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            string rname = textBox14.Text;
            string rtype = textBox15.Text;
            string customer = textBox2.Text;
            string petname = comboBox10.Text;
            string breed = textBox12.Text;
            string contactno = textBox3.Text;
            string DateReserved = dateTimePicker1.Text;
            string TimeArrival = dateTimePicker3.Text;
            string No_days = label15.Text;
            string AccountName = label17.Text;
            string aa = "Not Available";
            int quan = 1;
            //int resquan = Convert.ToInt32(label16.Text);
            int x = 0;
            double y = 0;
            double z = 0;

            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (rtype == "" || customer == "" || petname == "" || breed == "" || contactno == "" || DateReserved == "" || TimeArrival == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            //if (quantity == "0")
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
            //    return;
            //}
            //z = Convert.ToDouble(price);
            //x = resquan - quan;
            y = quan * z;
            string prices = y.ToString();
            string newquan = x.ToString();


            //string constring = "Server=thedogspaandhotel.x10host.com;Database =thedogsp_management;Uid=thedogsp;Pwd=";
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO roomreservation (Room_Type,Customer_Name,Pet_Name,Breed,Contact_Details,Date_Reserved,TimeArrival,AccountName) VALUES (@Room_Type, @Customer_Name, @Pet_Name,@Breed,@Contact_Details,@Date_Reserved,@TimeArrival,@AccountName)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            //newuser.Parameters.AddWithValue("@Room_Name", rname);
            newuser.Parameters.AddWithValue("@Room_Type", rtype);
            newuser.Parameters.AddWithValue("@Customer_Name", customer);
            newuser.Parameters.AddWithValue("@Pet_Name", petname);
            newuser.Parameters.AddWithValue("@Breed", breed);
            newuser.Parameters.AddWithValue("@Contact_Details", contactno);
            newuser.Parameters.AddWithValue("@Date_Reserved", DateReserved);
            newuser.Parameters.AddWithValue("@TimeArrival", TimeArrival);
            newuser.Parameters.AddWithValue("@AccountName", AccountName);

            newuser.ExecuteNonQuery();



            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Reserve!");

            //string query1 = "update Management.Rooms set CheckInDateTime='" + checkin + "',CheckOutDateTime='" + checkout + "',Room_Status='" + aa + "'where Room_ID='" + ids + "' ;";

            //MySqlCommand newquery = new MySqlCommand(query1, connection);
            //getName();
            //newquery.ExecuteNonQuery();
            //connection.Close();
            //connection.Open();



            //string activity = "Add Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            //{
            //}
            Roomlist_tbl();
            //transaction_tbl();

            transactdet_tbl();
            textBox14.Text = "";
            textBox15.Text = "";
            textBox11.Text = "";
            comboBox6.Items.Clear();
            comboBox6.Items.Add("Daycare");
            comboBox6.Items.Add("Overnight");
            comboBox5.Items.Clear();
            textBox8.Text = "";
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
           
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
            getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            //ProductClick.Visible = false;
            Reserve_tbl();
            connection.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "Overnight")
            {
                comboBox5.Items.Clear();
                label45.Text = "Days:";
                comboBox5.Items.Add("1");
                comboBox5.Items.Add("2");
                comboBox5.Items.Add("3");
                comboBox5.Items.Add("4");
                comboBox5.Items.Add("5");
                //    textBox8.Text = "";
            }
            else if (comboBox6.Text == "Daycare")
            {
                comboBox5.Items.Clear();
                label45.Text = "Hours:";
                comboBox5.Items.Add("1");
                comboBox5.Items.Add("2");
                comboBox5.Items.Add("3");
                comboBox5.Items.Add("4");
                comboBox5.Items.Add("5");
                comboBox5.Items.Add("6");
                comboBox5.Items.Add("7");
                comboBox5.Items.Add("8");
                comboBox5.Items.Add("9");
                comboBox5.Items.Add("10");
                comboBox5.Items.Add("11");
                comboBox5.Items.Add("12");
                comboBox5.Items.Add("13");
                comboBox5.Items.Add("14");
                comboBox5.Items.Add("15");
                comboBox5.Items.Add("16");
                comboBox5.Items.Add("17");
                comboBox5.Items.Add("18");
                comboBox5.Items.Add("19");
                comboBox5.Items.Add("20");
                comboBox5.Items.Add("21");
                comboBox5.Items.Add("22");
                comboBox5.Items.Add("23");
                // textBox8.Text = "";
            }
        }

        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            this.Close();
            //CashierMainform weww = new CashierMainform();          
            //weww.ShowDialog();
        }


        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "RoomList")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                Roomlist_tbl();
            }
            if (comboBox7.Text == "ReservationList")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
                Reserve_tbl();
            }
            if (comboBox7.Text == "RoomBoarding")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                roomboarding();
            }
            if (comboBox7.Text == "Transaction Table")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

                transactdet_tbl();

            }
        }

        private void dataGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView3.HitTest(e.X, e.Y);
                dataGridView3.Rows[hti.RowIndex].Selected = true;
                contextMenuStrip1.Show(dataGridView3, e.X, e.Y);
            }
        }

        private void confirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(label51.Text) > Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")) || Convert.ToDateTime(label51.Text) < Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The Date Reserved is not Today");
                return;
            }
            else if (Convert.ToDateTime(label51.Text) == Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The Reservation in Ready for transaction");
                groupControl3.Visible = false;
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string constring = "Server=localhost; Database =Management;Uid=justine;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.roomreservation where Reserve_ID='" + label50.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Reservation has been deleted");

                    while (myReader.Read())
                    {

                    }

                    condatabase.Close();

                    //condatabase.Open();

                    //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    //newquery.ExecuteNonQuery();

                    //account_tbl();
                    //getName();
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                {
                }


            }
            Reserve_tbl();

        }

        public void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox2.Text = row.Cells["CustomerName"].Value.ToString();
                comboBox10.Text = row.Cells["PetName"].Value.ToString();
                textBox12.Text = row.Cells["Breed"].Value.ToString();
                textBox3.Text = row.Cells["ContactNo"].Value.ToString();
                //textBox15.Text = row.Cells["RoomType"].Value.ToString();
                //label53.Text = "Confirm";
                //comboBox4.SelectedItem = "Reservation";
                //comboBox4.Enabled = false;
                //textBox14.Text = row.Cells["RoomName"].Value.ToString();
                //dateTimePicker1.Text = row.Cells["DateReserved"].Value.ToString();
            }

            if (groupControl3.Visible = false)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                    label50.Text = row.Cells["Reserve_ID"].Value.ToString();
                    label51.Text = row.Cells["DateReserved"].Value.ToString();
                    textBox10.Text = row.Cells["RoomType"].Value.ToString();
                    label53.Text = "Confirm";
                    comboBox4.SelectedItem = "Check-In";
                    comboBox4.Enabled = false;
                   // textBox11.Text = row.Cells["RoomName"].Value.ToString();
                    // dateTimePicker1.Text = row.Cells["DateReserved"].Value.ToString();
                }
            }
            else if (groupControl3.Visible = true)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                    label50.Text = row.Cells["ReserveID"].Value.ToString();
                    label51.Text = row.Cells["DateReserved"].Value.ToString();
                    textBox10.Text = row.Cells["RoomType"].Value.ToString();
                    label53.Text = "Confirm";
                    comboBox4.SelectedItem = "Reservation";
                    comboBox4.Enabled = false;
                 //   textBox14.Text = row.Cells["RoomName"].Value.ToString();
                    dateTimePicker1.Text = row.Cells["DateReserved"].Value.ToString();
                }
            }


        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            //textBox6.Text = row.Cells["Room_ID"].Value.ToString();
            //textBox5.Text = row.Cells["Room_Status"].Value.ToString();
            //textBox10.Text = row.Cells["Room_Type"].Value.ToString();
            //textBox11.Text = row.Cells["Room_Name"].Value.ToString();
            string constring = "Server=localhost;Database =management;Uid=root;Pwd=";


            string Query = "Select * from Rooms where Room_Name='" + textBox11.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Room_Name");
                    string sname2 = myReader.GetInt32("Room_ID").ToString();
                    string sname3 = myReader.GetString("Room_Status");
                    string sname4 = myReader.GetString("Room_Type");


                    textBox6.Text = sname2;
                    textBox11.Text = sname;
                    label52.Text = sname3;
                    textBox10.Text = sname4;


                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            {
            }

            condatabase.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(label51.Text) > Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")) || Convert.ToDateTime(label51.Text) < Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                groupControl3.Visible = true;

            }
            else if (Convert.ToDateTime(label51.Text) == Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The Reservation in Ready for transaction");
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database =management;Uid=root;Pwd=";


            string Query = "Select * from Rooms where Room_Name='" + textBox14.Text + "';";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Room_Name");
                    string sname2 = myReader.GetInt32("Room_ID").ToString();
                    // string sname3 = myReader.GetString("Room_Status");
                    string sname4 = myReader.GetString("Room_Type");


                    label54.Text = sname2;
                    textBox14.Text = sname;
                    // label52.Text = sname3;
                    textBox15.Text = sname4;


                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            {
            }

            condatabase.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimePicker1.Text) >= Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                simpleButton9.Enabled = true;
                return;
            }
            else if (Convert.ToDateTime(dateTimePicker1.Text) < Convert.ToDateTime(DateTime.Now.ToString("MMMM dd,yyyy")))
            {
                simpleButton9.Enabled = false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost; Database =Management;Uid=justine;Pwd=";
            string Query = "update Management.roomreservation set Room_Type='" + textBox15.Text + "',Customer_Name='" + textBox2.Text + "',Pet_Name='" + textBox9.Text + "',Breed='" + textBox12.Text + "',Contact_Details='" + textBox3.Text + "',Date_Reserved='" + dateTimePicker1.Text + "',AccountName='" + textBox4.Text + "'where Reserve_ID='" + label50.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Reservation has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                //    xy = 0;
                //  product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            //string activity = "Update Product";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label4.Text);
            //newuser1.Parameters.AddWithValue("@levels", label5.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            string sname = "";
            //textBox1.Text = sname2;
          
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
            getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            comboBox4.Enabled = true;
            textBox6.Enabled = false;
            simpleButton2.Enabled = true;
            Reserve_tbl();
            condatabase.Close();
        }

        private void simpleButton13_Click_1(object sender, EventArgs e)
        {
            DateTime time1 = dateTimePicker2.Value;
            DateTime time2 = dateTimePicker3.Value;

            TimeSpan diff = time1 - time2;

            textBox17.Text = diff.ToString("h'h 'm'm '");
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "ReservationList")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Reserve_ID, Room_Name as RoomName ,Room_Type as RoomType,Customer_Name as CustomerName,Pet_Name as PetName,Breed,Contact_Details as ContactNo, Date_Reserved as DateReserved, AccountName from roomreservation where Date_Reserved='" + dateTimePicker4.Text + "'", condatabase);

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
                    // dataGridView3.Rows[0].Cells[0].Value = false;




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (comboBox7.Text == "RoomBoarding")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as RoomID,Prod_desc as RoomName,Quantity,Price,TransactionDate from transactiondetails where TransactionDate='" + dateTimePicker4.Text + "'", condatabase);

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




                    //dataGridView2.DataSource = null;
                    //dataGridView2.DataSource = shoppingcart;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void sMSNotifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerNotif hackers = new CustomerNotif();
            hackers.ShowDialog();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox8.Text == "Overnight")
            {
                comboBox9.Items.Clear();
                label63.Text = "Days:";
                comboBox9.Items.Add("1");
                comboBox9.Items.Add("2");
                comboBox9.Items.Add("3");
                comboBox9.Items.Add("4");
                comboBox9.Items.Add("5");
                textBox18.Text = "";
                label66.Text = "450.00";
            }
            else if (comboBox8.Text == "Daycare")
            {
                comboBox9.Items.Clear();
                label63.Text = "Hours:";
                comboBox9.Items.Add("1");
                comboBox9.Items.Add("2");
                comboBox9.Items.Add("3");
                comboBox9.Items.Add("4");
                comboBox9.Items.Add("5");
                comboBox9.Items.Add("6");
                comboBox9.Items.Add("7");
                comboBox9.Items.Add("8");
                comboBox9.Items.Add("9");
                comboBox9.Items.Add("10");
                comboBox9.Items.Add("11");
                comboBox9.Items.Add("12");
                comboBox9.Items.Add("13");
                comboBox9.Items.Add("14");
                comboBox9.Items.Add("15");
                comboBox9.Items.Add("16");
                comboBox9.Items.Add("17");
                comboBox9.Items.Add("18");
                comboBox9.Items.Add("19");
                comboBox9.Items.Add("20");
                comboBox9.Items.Add("21");
                comboBox9.Items.Add("22");
                comboBox9.Items.Add("23");
                textBox18.Text = "";
                label66.Text = "100.00";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.Rows[hti.RowIndex].Selected = true;
                contextMenuStrip2.Show(dataGridView1, e.X, e.Y);
            }
        }

        private void extendTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "Available")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("There has no transaction in this room!");
                return;
            }
            if (textBox5.Text == "Not Available")
            {
                panel8.Visible = true;
            }
          
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            if (comboBox9.Text == "")
            {
                DateTime.Now.ToString("HH:mm tt");
                DateTime dateTime = DateTime.Now;
                this.label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            }
            else if (label63.Text == "Hours:" && comboBox9.Text != "")
            {
                timer1.Start();
                int s = Convert.ToInt32(comboBox9.Text);
                //DateTime myDateTime = Convert.ToDateTime(label16.Text);
                DateTime RmyDateTime = Convert.ToDateTime(textBox19.Text);
                DateTime myDateTime = DateTime.Now;
                myDateTime = RmyDateTime.AddHours(s);
                textBox19.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                x = Convert.ToInt32(comboBox9.Text);
                y = x * 100;
                textBox18.Text = y.ToString();
            }
            else if (label63.Text == "Days:" && comboBox9.Text != "")
            {
                timer1.Start();
                int s = Convert.ToInt32(comboBox9.Text);
                int h = s * 24;
                //DateTime myDateTime = Convert.ToDateTime(label16.Text);
                DateTime RmyDateTime = Convert.ToDateTime(textBox19.Text);
                DateTime myDateTime = DateTime.Now;
                myDateTime = RmyDateTime.AddHours(h);
                textBox19.Text = myDateTime.ToString("MMMM dd,yyyy  hh:mm:ss tt");
                x = Convert.ToInt32(comboBox9.Text);
                y = x * 450;
                textBox18.Text = y.ToString();
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            string sname = "";
            //textBox1.Text = sname2;
            textBox21.Text = sname;
            textBox20.Text = sname;
            textBox19.Text = sname;
            textBox18.Text = sname;
            comboBox8.SelectedItem = -1;
            comboBox9.SelectedItem = -1;
            panel8.Visible = false;

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            string invoice = textBox7.Text;
            string ids = label58.Text;
            string desc = textBox21.Text;
            string fromdate = textBox20.Text;
            string date = textBox19.Text;
            string type = comboBox8.Text;
            string hours = comboBox9.Text;
            string checkin = label16.Text;
            string checkout = label15.Text;
            string unitprice = label48.Text;
            string aa = "Not Available";
            string transactype = "Rooms";

            int y = Convert.ToInt32(textBox18.Text);
            int z = Convert.ToInt32(label67.Text);

            int x = y + z;

            string customer = textBox2.Text;
            if (ids == "" || desc == "" || fromdate == "" || date == "" || type == "" || hours == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }

            string status = "Available";
            string check = "";
           
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Rooms set CheckOutDateTime='" + date + "'where Room_ID='" + label58.Text + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Room has been Updated!");
                while (myReader.Read())
                {

                }
                condatabase.Close();
                condatabase.Open();

                string query1 = "update Management.Transactiondetails set Price='" + x + "'where InvoiceNo='" + textBox22.Text + "' ;";

                MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                newquery.ExecuteNonQuery();


                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            getName2();
            getName1();
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.SelectedIndex = -1;
            textBox14.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            comboBox4.Enabled = true;
            panel8.Visible = false;
            label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            Roomlist_tbl();
            {
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Rooms where Room_Name='" + textBox21.Text + "' ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("InvoiceNo");
                    // comboBox1.Items.Add(sname);
                    textBox22.Text = sname;
                }
                condatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();

            {
            }

            condatabase.Close();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from transactiondetails where InvoiceNo='" + textBox22.Text + "' ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Price");
                    // comboBox1.Items.Add(sname);
                    label67.Text = sname;
                }
                condatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();

            {
            }

            condatabase.Close();
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            textBox27.Text = textBox1.Text;
            textBox26.Text = textBox2.Text;
            groupControl4.Visible = true;
            groupControl3.Enabled = false;
            //simpleButton6.Visible = false;
            //simpleButton2.Visible = false;
            //simpleButton3.Visible = false;
            //simpleButton4.Visible = false;
            //simpleButton5.Visible = false;

        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            groupControl4.Visible = false;
          
            textBox27.Text = "";
            textBox26.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";
            getName3();
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            string petids = textBox23.Text;
            string cID = textBox27.Text;
            string cname = textBox26.Text;
            string pet = textBox25.Text;
            string breed = textBox24.Text;


            if (petids == "" || cID == "" || pet == "" || breed == "" || cname == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            //if (quantity == "0")
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
            //    return;
            //}
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO PetInfo (Pet_ID,Customer_ID,Customer_Name,Pet_Name,Breed) VALUES (@Pet_ID, @Customer_ID, @Customer_Name,@Pet_Name,@Breed)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@Pet_ID", petids);
            newuser.Parameters.AddWithValue("@Customer_ID", cID);
            newuser.Parameters.AddWithValue("@Customer_Name", cname);
            newuser.Parameters.AddWithValue("@Pet_Name", pet);
            newuser.Parameters.AddWithValue("@Breed", breed);

            newuser.ExecuteNonQuery();
            {
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            //string query1 = "INSERT INTO Account(adminID,AccountName,userlevel,Username,Passwords) values ('" + ids + "','" + lname + ',' + fname + "','" + userlevs + "','" + user + "','" + pass + "');";

            //MySqlCommand newquery = new MySqlCommand(query1, connection);
            //getName();
            //newquery.ExecuteNonQuery();


            //textBoxX2.Text = "";
            //textBoxX3.Text = "";
            //textBoxX4.Text = "";
            //textBoxX5.Text = "";
            //textBoxX6.Text = "";
            //connection.Close();
            //connection.Open();
            string activity = "Add PetInfo";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels", level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            textBox27.Text = "";
            textBox26.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";
            getName3();
            //Customer_tbl();
            connection.Close();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            string x = textBox3.Text;
            string contactno = label27.Text + x;

            string petids = textBox23.Text;
            string cID = textBox27.Text;
            string cname = textBox26.Text;
            string pet = textBox25.Text;
            string breed = textBox24.Text;

          


            if (petids == "" || cID == "" || pet == "" || breed == "" || cname == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            string Query = "update Management.Customer set Pet_ID='" + petids + "',Customer_ID='" + cID + "',Customer_Name='" + cname + "',Pet_Name='" + pet + "',Breed='" + breed + "'where Pet_ID='" + petids + "' ;";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();
                DevExpress.XtraEditors.XtraMessageBox.Show("Pet Info has been Updated!");
                while (myReader.Read())
                {

                }
                //condatabase.Close();
                //condatabase.Open();

                //string query1 = "update GradingSystem.account set AccountName='" + textBoxX2.Text + ',' + textBoxX3.Text + "', username='" + textBoxX6.Text + "',passwords='" + textBoxX5.Text + "'where adminID='" + textBoxX1.Text + "' ;";

                //MySqlCommand newquery = new MySqlCommand(query1, condatabase);
                //newquery.ExecuteNonQuery();

                //xy = 0;
                //product_tbl();
                //if (xy > 0)
                //{
                //    DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
                //}
                //getName();
                condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            condatabase.Open();
            string activity = "Update Pet Info";
            string name = "Borbe,Charlie";
            string level = "Admin";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", name);
            newuser1.Parameters.AddWithValue("@levels", level);
            newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
            newuser1.ExecuteNonQuery();
            {
            }
            //account_tbl();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "";
            textBox27.Text = "";
            textBox26.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";
            getName3();
            //  Customer_tbl();
            simpleButton2.Enabled = true;
            condatabase.Close();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            string petids = textBox23.Text;
            string cID = textBox27.Text;
            string cname = textBox26.Text;
            string pet = textBox25.Text;
            string breed = textBox24.Text;


            if (petids == "" || cID == "" || pet == "" || breed == "" || cname == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to delete selected record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.PetInfo where Pet_ID='" + textBox23.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Record has been deleted");

                    while (myReader.Read())
                    {

                    }

                    condatabase.Close();

                    //condatabase.Open();

                    //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                    //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                    //newquery.ExecuteNonQuery();

                    //account_tbl();
                    //getName();
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();
                string activity = "Delete PetInfo";
                string name = "Borbe,Charlie";
                string level = "Admin";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", name);
                newuser1.Parameters.AddWithValue("@levels", level);
                newuser1.Parameters.AddWithValue("@act1", textBox2.Text);
                newuser1.ExecuteNonQuery();
                {
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox9.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox12.Text = "";
                textBox27.Text = "";
                textBox26.Text = "";
                textBox25.Text = "";
                textBox24.Text = "";
                getName3();
                //  Customer_tbl();
                simpleButton2.Enabled = true;
                condatabase.Close();
            }
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {

            textBox27.Text = "";
            textBox26.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";
            getName3();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from petinfo where Pet_Name='" + comboBox10.Text + "' ; ";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Breed");
                    // comboBox1.Items.Add(sname);
                    textBox12.Text = sname;
                }
                condatabase.Close();


                //condatabase.Open();

                //string Query1 = "delete from GradingSystem.account where adminID='" + textBoxX1.Text + "' ;";
                //MySqlCommand newquery = new MySqlCommand(Query1, condatabase);
                //newquery.ExecuteNonQuery();

                //account_tbl();
                //getName();
                //condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            condatabase.Open();
            //string activity = "Delete Admmin";
            //string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,IdAct) VALUES (@act, @namc, @levels,@act1)";
            //MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            //newuser1.CommandText = newuser_sql2;
            //newuser1.Parameters.AddWithValue("@act", activity);
            //newuser1.Parameters.AddWithValue("@namc", label7.Text);
            //newuser1.Parameters.AddWithValue("@levels", label8.Text);
            //newuser1.Parameters.AddWithValue("@act1", textBoxX2.Text);
            //newuser1.ExecuteNonQuery();
            {
            }

            condatabase.Close();
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
  
    
        
       
    