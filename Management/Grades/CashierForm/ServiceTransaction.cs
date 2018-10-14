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
    public partial class ServiceTransaction : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public ServiceTransaction()
        {
            InitializeComponent();
            getName();
            getName1();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            //autocomplete();
            services_Tbl();
            transactdet_tbl();
            getName2();
            fillcombo();
            getName3();
        }
        DataTable dtable;

        void fillcombo2()
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
                    comboBox1.Items.Add(sname);
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
        private void getName2()
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
        void services_Tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Services_ID as ServiceID, Service_desc as ServiceName,Service_Category as ServiceCategory,Price from Services ", condatabase);



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

                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                //{

                //    //Here 2 cell is target value and 1 cell is Volume
                //    if (Convert.ToDateTime(Myrow.Cells[5].Value) >= DateTime.Now && Convert.ToString(Myrow.Cells[5].Value) != "")// Or your condition 
                //    {
                //        panel1.Visible = true;
                //    }
                //    else
                //    {
                //        Myrow.DefaultCellStyle.BackColor = Color.White;
                //    }
                //}



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getName3()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Pet_ID + 1) as PetID from PetInfo order by PetID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox14.Text = reader["PetID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        void transactdet_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as ServiceID,Prod_desc as ServiceName,Quantity,Price from transactiondetails where InvoiceNo='" + textBox7.Text + "'", condatabase);



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
                label25.Text = sum.ToString();
                label17.Text = sum.ToString();
                label17.Text = String.Format("{0:C}", double.Parse(label17.Text));

                label25.Text = vat.ToString();
                label18.Text = vat.ToString();
                label18.Text = String.Format("{0:C}", double.Parse(label18.Text));
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Staffs where userlevel = 'Staff'";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Firstname");
                    string fname = myReader.GetString("Lastname");
                    comboBox3.Items.Add(sname + " " + fname);
                }
               // condatabase.Close();


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

            //condatabase.Open();
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
        private void getName1()
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string invoice = textBox7.Text;
            string ids = textBox6.Text;
            string desc = textBox11.Text;
            int quantity = 1; 
            string price = textBox8.Text;
            string transactype = "Services";
            string customer = textBox2.Text;
            string transactiondate = label16.Text;
           // string checkin = label16.Text;
           //string checkout = label15.Text;
           // string aa = "Not Available";
            //int quan = Convert.ToInt32(textBox3.Text);
            //int resquan = Convert.ToInt32(label16.Text);
            int x = 0;
            double y = 0;
            double z = 0;

            //string user = textBox6.Text;
            //string pass = textBox5.Text;
            //string userlevs = "Admin";

            if (ids == "" || desc == ""  || price == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Empty Fields Detected");
                return;
            }
            //if (quantity == "0")
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Please input the quantity");
            //    return;
            //}
            z = Convert.ToDouble(price);
            //x = resquan - quan;
            y = quantity * z;
            string prices = y.ToString();
            string newquan = x.ToString();
            string quani = quantity.ToString();

            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();
            gsdb.Server = "localhost";
            gsdb.UserID = "root";
            gsdb.Password = "";
            gsdb.Database = "Management";
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            connection.Open();
            string newuser_sql = "INSERT INTO transactiondetails (InvoiceNo,Product_ID,Prod_desc,UnitPrice,Quantity,Price,transaction_type,Customer_Name) VALUES (@InvoiceNo,@Product_ID, @Prod_desc,@UnitPrice, @Quantity,@Price,@transaction_type,@Customer_Name)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@InvoiceNo", invoice);
            newuser.Parameters.AddWithValue("@Product_ID", ids);
            newuser.Parameters.AddWithValue("@Prod_desc", desc);
            newuser.Parameters.AddWithValue("@UnitPrice", price);
            newuser.Parameters.AddWithValue("@Quantity", quani);
            newuser.Parameters.AddWithValue("@Price", prices);
            newuser.Parameters.AddWithValue("@transaction_type", transactype);
            newuser.Parameters.AddWithValue("@Customer_Name", customer);
            newuser.ExecuteNonQuery();



            DevExpress.XtraEditors.XtraMessageBox.Show("Successfully Added!");

            //string query1 = "update Management.Rooms set CheckInDateTime='" + checkin + "',CheckOutDateTime='" + checkout + "',Room_Status='" + aa + "'where Room_ID='" + ids + "' ;";

            //MySqlCommand newquery = new MySqlCommand(query1, connection);
            ////getName();
            //newquery.ExecuteNonQuery();
            ////connection.Close();
           



            //string activity = "Add Admmin";
            string newuser_sql2 = "INSERT INTO serviceregistration (Customer_Name,Pet_Name,Breed,Contact_Details,Service_desc,Service_Category,GroomerName,AccountName,TransactionDate) VALUES (@customername, @petname, @breed,@contactdetails,@service_desc,@Service_Category,@GroomerName,@AccountName,@TransactionDate)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@customername", textBox2.Text);
            newuser1.Parameters.AddWithValue("@petname", textBox9.Text);
            newuser1.Parameters.AddWithValue("@breed", textBox12.Text);
            newuser1.Parameters.AddWithValue("@contactdetails", textBox3.Text);
            newuser1.Parameters.AddWithValue("@service_desc", textBox11.Text);
            newuser1.Parameters.AddWithValue("@Service_Category", textBox13.Text);
            newuser1.Parameters.AddWithValue("@GroomerName", comboBox3.Text);
            newuser1.Parameters.AddWithValue("@AccountName", label22.Text);
            newuser1.Parameters.AddWithValue("@TransactionDate", transactiondate);
            newuser1.ExecuteNonQuery();
            {
            }
            //connection.Open();
            connection.Close();
            // services_Tbl();
            //transaction_tbl();

            //   transactdet_tbl();
            string sname = "";
            //textBox1.Text = sname2;
            textBox2.Text = sname;
            textBox9.Text = sname;
            textBox12.Text = sname;
            textBox3.Text = sname;
            textBox4.Text = sname;
            transactdet_tbl();
            getName1();
            getName2();
            textBox6.Text = sname;
            textBox13.Text = sname;
            textBox11.Text = sname;
            textBox11.Text = sname;
            textBox10.Text = sname;
            textBox8.Text = sname;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            //   label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
      
            //ProductClick.Visible = false;

            connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label29.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
         //   this.label17.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void ServiceTransaction_Load(object sender, EventArgs e)
        {
            timer1.Start();
       //     label15.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
            timer2.Start();
            label16.Text = DateTime.Now.ToString("MMMM dd,yyyy ");
            label26.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox9.Text != "")
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
                    getName1();
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
                    string contactno = label19.Text + x;
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
                    //newuser.Parameters.AddWithValue("@Pet_Name", pet);
                    //newuser.Parameters.AddWithValue("@Breed", breed);
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
                    string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                    MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, connection);
                    newuser1.CommandText = newuser_sql2;
                    newuser1.Parameters.AddWithValue("@act", activity);
                    newuser1.Parameters.AddWithValue("@namc", label22.Text);
                    newuser1.Parameters.AddWithValue("@levels", label5.Text);
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
                    //condatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                condatabase.Open();
                string activity = "Delete Customer";
                string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
                MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
                newuser1.CommandText = newuser_sql2;
                newuser1.Parameters.AddWithValue("@act", activity);
                newuser1.Parameters.AddWithValue("@namc", label22.Text);
                newuser1.Parameters.AddWithValue("@levels", label5.Text);
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
                getName1();
                getName2();
                textBox6.Text = sname;
                textBox13.Text = sname;
                textBox11.Text = sname;
                textBox11.Text = sname;
                textBox10.Text = sname;
                textBox8.Text = sname;
                comboBox3.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                condatabase.Close();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string ids = textBox1.Text;
            string owner = textBox2.Text;
            //string pet = textBox9.Text;
            //string breed = textBox12.Text;
            string x = textBox3.Text;
            string contactno = label19.Text + x;
            string email = textBox4.Text;

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
                condatabase.Close();
                condatabase.Open();

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
                //  condatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // condatabase.Open();
            string activity = "Update Customer Info";
            string newuser_sql2 = "INSERT INTO acty (Actname,AccountName,userlevel,ActDesc) VALUES (@act, @namc, @levels,@act1)";
            MySqlCommand newuser1 = new MySqlCommand(newuser_sql2, condatabase);
            newuser1.CommandText = newuser_sql2;
            newuser1.Parameters.AddWithValue("@act", activity);
            newuser1.Parameters.AddWithValue("@namc", label22.Text);
            newuser1.Parameters.AddWithValue("@levels", label5.Text);
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
            getName1();
            getName2();
            textBox6.Text = sname;
            textBox13.Text = sname;
            textBox11.Text = sname;
            textBox11.Text = sname;
            textBox10.Text = sname;
            textBox8.Text = sname;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            condatabase.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                        fillcombo2();
                        string sname5 = myReader.GetString("Contact_No");
                        string sname6 = myReader.GetString("Email_Address");

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
                getName1();
                simpleButton2.Enabled = true;
                comboBox1.Items.Clear();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells["ServiceID"].Value.ToString();
            //    textBox5.Text = row.Cells["Service_desc"].Value.ToString();
                textBox13.Text = row.Cells["ServiceCategory"].Value.ToString();
                textBox11.Text = row.Cells["ServiceName"].Value.ToString();
                textBox8.Text = row.Cells["Price"].Value.ToString();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                services_Tbl();
            }

            else {
                services_Tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select * from Services where Service_Category = '" + comboBox2.Text + "' ", condatabase);


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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                label28.Text = row.Cells["ServiceID"].Value.ToString();
                

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
            getName1();
            getName2();
            textBox6.Text = sname;
            textBox13.Text = sname;
            textBox11.Text = sname;
            textBox11.Text = sname;
            textBox10.Text = sname;
            textBox8.Text = sname;
            comboBox1.Items.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string sname1 = textBox1.Text;
            string sname2 = textBox2.Text;
            //string sname3 = textBox9.Text;
            //string sname4 = textBox12.Text;
            string sname5 = textBox3.Text;
            string sname6 = textBox4.Text;

            if (sname1 == "" || sname2 == "" || sname5 == "" || sname6 == "")
            {
                simpleButton2.Enabled = false;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
            }

            else if (sname1 != "" && sname2 != "" &&  sname5 != "" && sname6 != "")
            {
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = true;
                simpleButton4.Enabled = true;
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
                services_Tbl();

                condatabase.Close();
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
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

            label17.Text = sum.ToString();
            label17.Text = String.Format("{0:C}", double.Parse(label17.Text));

            label18.Text = vat.ToString();
            label18.Text = String.Format("{0:C}", double.Parse(label18.Text));


            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            DialogResult dialog = XtraMessageBox.Show("Are you sure you want to removed the Service to the cart?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                string Query = "delete from Management.transactiondetails where Product_ID='" + label28.Text + "' ;";

                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
                MySqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmddatabase.ExecuteReader();
                    DevExpress.XtraEditors.XtraMessageBox.Show("The Service has been removed to the cart");

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
                textBox11.Text = "";
                textBox13.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Daycare");
                comboBox2.Items.Add("Overnight");
                comboBox3.Items.Clear();
                comboBox3.Items.Add("Charlie Borbe");
                comboBox3.Items.Add("Justine Gonzalve");
                comboBox3.Items.Add("Babylyn Libay");
                comboBox3.Items.Add("Joel Negro");
                textBox8.Text = "";
                condatabase.Close();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm:ss tt");
            DateTime dateTime = DateTime.Now;
            this.label27.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            services_Tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("Service_desc LIKE '%{0}%'", textBox10.Text);
            dataGridView1.DataSource = DV;
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            string petids = textBox14.Text;
            string cID = textBox18.Text;
            string cname = textBox17.Text;
            string pet = textBox16.Text;
            string breed = textBox15.Text;


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
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            getName3();
            //Customer_tbl();
            connection.Close();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            getName3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from petinfo where Pet_Name='" + comboBox1.Text + "' ; ";

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

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            groupControl3.Visible = false;

           // groupControl3.Enabled = true; ;
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            getName3();
            simpleButton1.Enabled = true;
        }
    

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            textBox18.Text = textBox1.Text;
            textBox17.Text = textBox2.Text;
            groupControl3.Visible = true;
            // groupControl3.Enabled = false;
            simpleButton1.Enabled = false;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
    }
}