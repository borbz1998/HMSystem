using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.Mail;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;
using MySql.Data.MySqlClient;



namespace Grades
{
    public partial class CustomerNotif : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        SMS set = new SMS();
        public CustomerNotif()
        {
            InitializeComponent();
            timer1.Start();
            getName2();
            //autocomplete();
            Customer_tbl();
        }
        DataTable dtable;

        void fillcombo2()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select distinct Pet_Name from petinfo  where Customer_Name='" + tbxCustomer.Text + "'  ; ";

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
                    comboBox3.Items.Add(sname);
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
        void Customer_tbl()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select Customer_ID as CustomerID,Customer_Name as CustomerName,Contact_No as ContactNumber, Email_Address as Email from Customer ", condatabase);



            try
            {

                MySqlDataAdapter loaddb = new MySqlDataAdapter();
                loaddb.SelectCommand = cmddatabase;
                dtable = new DataTable();
                loaddb.Fill(dtable);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dtable;
                dataGridView7.DataSource = bsource;
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
        void autocomplete()
        {
            tbxCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            tbxCustomer.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }

        void autocomplete2()
        {
            tbxCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


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
                    string sname = myReader.GetString("Customer_Name");
                    coll.Add(sname);

                }
                condatabase.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tbxCustomer.AutoCompleteCustomSource = coll;
            condatabase.Open();

            {
            }

            condatabase.Close();


        }

        public void SendMail()
        {
            //try
            //{
            //    MailMessage message = new MailMessage
            //    {
            //        From = new MailAddress("charlieborbz@gmail.com", "SMS Bomber")
            //    };
               
            //    message.To.Add(new MailAddress(tbxContactnum.Text));
            //    string[] textArray1 = new string[] { textBox8.Text };
            //    message.Body = string.Concat(textArray1);
            //    new SmtpClient
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 0x24b,
            //        Credentials = new NetworkCredential("charlieborbz@gmail.com", "charlieborbe18"),
            //        EnableSsl = true
            //    }.Send(message);
            //}
            //catch
            //{

            //}
        }
        private void getName2()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Receptionist' order by Login_ID desc limit 1;";
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
        //public object itexmo(string Number, string Message, string API_CODE)
        //{
        //    //object functionReturnValue = null;
        //    //using (System.Net.WebClient client = new System.Net.WebClient())
        //    //{
        //    //    System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
        //    //    string url = "https://www.itexmo.com/php_api/api.php";
        //    //    parameter.Add(tbxContactnum.Text, Number);
        //    //    parameter.Add(textBox8.Text, Message);
        //    //    parameter.Add("TR-CHARL718655_95PEE ", API_CODE);
        //    //    dynamic rpb = client.UploadValues(url, "POST", parameter);
        //    //    functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
        //    //}
        //    //return functionReturnValue;

           
        //}
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //object functionReturnValue = null;
            //using (System.Net.WebClient client = new System.Net.WebClient())
            //{
            //    System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
            //    string url = "https://www.itexmo.com/php_api/api.php";
            //    string number = tbxContactnum.Text;
            //    string message = textBox8.Text;
            //    string apicode = "TR-CHARL718655_95PEE";
            //    dynamic rpb = client.UploadValues(url, "POST", parameter);
            //    functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);

            //    dynamic result = itexmo(number, message, apicode);
            //    if (result == "0")
            //    {
            //        MessageBox.Show("message sent");
            //    }
            //    else
            //    {
            //        MessageBox.Show("error num " + result + " was encountered");
            //    }


            //}

               

            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(textBox11.Text, textBox14.Text);
            client = new SmtpClient(textBox15.Text);
            client.Port = Convert.ToInt32(textBox13.Text);
            client.EnableSsl = checkBox1.Checked;
            client.Credentials = login;

            msg = new MailMessage { From = new MailAddress(textBox11.Text + textBox15.Text.Replace("smtp.", "@"), "Charlie", Encoding.UTF8) };
            msg.To.Add(new MailAddress(textBox10.Text));
            if (!string.IsNullOrEmpty(textBox7.Text))
                msg.To.Add(new MailAddress(textBox7.Text));
            msg.Subject = textBox6.Text;
            msg.Body = textBox5.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending . . .";
            client.SendAsync(msg, userstate);
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your Message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            set.SendMessage("billing", tbxContactnum.Text, "Thank you " + tbxCustomer.Text + ", Your reservation for your dog " + tbxPetname.Text + Environment.NewLine
                             + "Date Reserved: " + dateTimePicker1.Text + Environment.NewLine
                             + "Time Arrival: " + dateTimePicker3.Text + Environment.NewLine
                             + "Number of Days/Hours: " + tbxnumberofdays.Text + Environment.NewLine
                             + "Room Type: " + comboBox2.Text + Environment.NewLine
                             + "Sent By: The Dog Spa And Hotel", "CharlieBorbs18@gmail.com","charlieborbe18");
            MessageBox.Show("Message sent");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            set.email(tbxemail.Text);
            set.pass(tbxpassword.Text);
            MessageBox.Show(tbxemail.Text + " Credential Set!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DateTime.Now.ToString("HH:mm tt");
            //DateTime dateTime = DateTime.Now;
            //this.label33.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void CustomerNotif_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
                mail.To = txtTo.Text;
                mail.Subject = txtSubject.Text;
                mail.Body = txtMessage.Text;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook.MailItem)mail).Send();
                MessageBox.Show("Your Message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message Send Failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DataTable dt;
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook._Application _app = new Outlook.Application();
                Outlook._NameSpace _ns = _app.GetNamespace("MAPI");
                Outlook.MAPIFolder inbox = _ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                _ns.SendAndReceive(true);
                dt = new DataTable("Inbox");
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Sender", typeof(string));
                dt.Columns.Add("Body", typeof(string));
                dt.Columns.Add("Date", typeof(string));
                dataGridView1.DataSource = dt;
                foreach (Outlook.MailItem item in inbox.Items)
                    dt.Rows.Add(new object[] { item.Subject, item.SenderName, item.HTMLBody, item.SentOn.ToLongDateString() + " " + item.SentOn.ToLongTimeString() });
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dt.Rows.Count && e.RowIndex >= 0)
                webBrowser1.DocumentText = dt.Rows[e.RowIndex]["Body"].ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
    
        }

        private void tbxCustomer_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox1.Text == "CustomerInfo" || comboBox1.Text == "")
            {
                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select * from Customer where Customer_Name='" + tbxCustomer.Text + "';";

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
                        string sname5 = myReader.GetString("Contact_No").ToString(); ;
                        string sname6 = myReader.GetString("Email_Address").ToString(); ;

                        textBox1.Text = sname2;
                        tbxCustomer.Text = sname;
                        tbxContactnum.Text = sname5;
                        fillcombo2();
                        //tbxPetname.Text = sname3;
                        //textBox12.Text = sname4;
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

            if (comboBox1.Text == "ReservationList")
            {
                string constring = "Server=localhost; Database =Management;Uid=root;Pwd=";


                string Query = "Select * from roomreservation where Customer_Name='" + tbxCustomer.Text + "';";

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
                        string sname1 = myReader.GetString("Date_Reserved");
                        string sname2 = myReader.GetInt32("TimeArrival").ToString();
                        string sname3 = myReader.GetString("No_Days");
                        string sname4 = myReader.GetString("Room_Type");


                        tbxCustomer.Text = sname;
                        tbxTimearrival.Text = sname2;
                        tbxDatearrival.Text = sname1;
                        tbxnumberofdays.Text = sname3;
                        tbxRoomtype.Text = sname4;


                    }
                //    condatabase.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

              //  condatabase.Open();

                {
                }

                condatabase.Close();

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            set.SendMessage("billing", tbxContactnum.Text, "Mr./Miss " + tbxCustomer.Text + ",we would like to notify you that your reservation for your dog " + tbxPetname.Text + " is now ongoing " + Environment.NewLine
                           + "Your Date Reserved :" + tbxDatearrival.Text + Environment.NewLine
                           + "Expected Time Arrival :" + tbxTimearrival.Text + Environment.NewLine
                           + "Number of Days/Hours :" + tbxnumberofdays.Text + Environment.NewLine
                           + "Room Type :" + tbxRoomtype.Text + Environment.NewLine
                           + "We would like to remind you that this reservation will be cancelled at the end of the day. " + Environment.NewLine
                           + "Sent By : The Dog Spa And Hotel", "CharlieBorbs18@gmail.com", "charlieborbe18");
            MessageBox.Show("Message sent");
        }

        private void tbxContactnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-';
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
                tbxCustomer.Text = row.Cells["CustomerName"].Value.ToString();
                textBox1.Text = row.Cells["CustomerID"].Value.ToString();
                //tbxPetname.Text = row.Cells["PetName"].Value.ToString();
                //textBox12.Text = row.Cells["Breed"].Value.ToString();
                tbxContactnum.Text = row.Cells["ContactNumber"].Value.ToString();
                textBox4.Text = row.Cells["Email"].Value.ToString();
              
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "CustomerInfo")
            {
                Customer_tbl();
            }
           
        }

        private void tbxPetname_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            set.SendMessage("billing", tbxContactnum.Text, "We are sorry  " + tbxCustomer.Text + ", but your reservation for your dog " + tbxPetname.Text  + Environment.NewLine
                             + "Date Reserved: " + dateTimePicker1.Text + Environment.NewLine
                             + "Time Arrival: " + dateTimePicker3.Text + Environment.NewLine
                             + "Number of Days/Hours: " + tbxnumberofdays.Text + Environment.NewLine
                             + "Room Type: " + comboBox2.Text + Environment.NewLine
                             + " is cancelled due to our fully book dog hotel. I recommend you to reserve on other day.  Sent By: The Dog Spa And Hotel", "CharlieBorbs18@gmail.com", "charlieborbe18");
            MessageBox.Show("Message sent");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from petinfo where Pet_Name='" + comboBox3.Text + "' ; ";

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
           
            {
            }

            condatabase.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != "")
            {



                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


                string Query = "Select * from roomreservation where Customer_Name='" + textBox12.Text + "';";

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
                        string sname1 = myReader.GetString("Date_Reserved");
                        string sname2 = myReader.GetInt32("TimeArrival").ToString();
                        string sname3 = myReader.GetString("No_Days");
                        string sname4 = myReader.GetString("Room_Type");


                        tbxCustomer.Text = sname;
                        tbxTimearrival.Text = sname2;
                        tbxDatearrival.Text = sname1;
                        tbxnumberofdays.Text = sname3;
                        tbxRoomtype.Text = sname4;

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

          
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            set.SendMessage("billing", tbxContactnum.Text, "I would just like to inform you " + tbxCustomer.Text + ", that the transaction for your dog " + tbxPetname.Text + Environment.NewLine
                             + "End Date: " + dateTimePicker1.Text + Environment.NewLine
                             + "Time Arrival: " + dateTimePicker3.Text + Environment.NewLine
                             + "Number of Days/Hours: " + tbxnumberofdays.Text + Environment.NewLine
                             + "Room Type: " + comboBox2.Text + Environment.NewLine
                             + "has ended . Please proceed to the store and get your pet. Thankyou. " + comboBox2.Text + Environment.NewLine
                             + "Sent By: The Dog Spa And Hotel", "CharlieBorbs18@gmail.com", "charlieborbe18");
            MessageBox.Show("Message sent");
        }
    }
           
    }
    
        
        
