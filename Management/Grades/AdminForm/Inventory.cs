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
    public partial class Inventory : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public Inventory()
        {
            InitializeComponent();
            product_tbl();
            fillcombo();
            getName1();
            getName2();
            timer1.Start();
            this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        DataTable dtable;
        
        int xy= 0;
        void fillcombo()
        {
            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";


            string Query = "Select * from Category";

            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand(Query, condatabase);
            MySqlDataReader myReader;
            try
            {
                condatabase.Open();
                myReader = cmddatabase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("Prod_Category");
                    comboBox1.Items.Add(sname);
                    comboBox2.Items.Add(sname);
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
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (Product_ID + 1) as Product_ID from Products order by Product_ID desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["Product_ID"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void getName2()
        {
            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select * from LOGIN where userlevel= 'Admin' order by Login_ID desc limit 1;";
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
                dataGridView1.Columns[4].DefaultCellStyle.Format = "C";
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

    
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            if (xy > 0)
            {
                //int ab = 0;
                // ab = xy - 1;
                DialogResult dialog = XtraMessageBox.Show("Number of Critical Products =   " + xy, "Confirmation", MessageBoxButtons.OKCancel);
            }
            // int x = ab - 1;
            product_tbl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime.Now.ToString("HH:mm tt");
            DateTime dateTime = DateTime.Now;
            this.label6.Text = DateTime.Now.ToString("MMMM dd,yyyy  hh:mm:ss tt");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                comboBox1.Text = row.Cells["Category"].Value.ToString();
               // textBox6.Enabled = true;
               // simpleButton2.Enabled = false;
                //textBox3.Enabled = true;
                //  simpleButton3.Enabled = true;
                //  simpleButton4.Enabled = true;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "0";
            comboBox1.Items.Clear();
            //textBox6.Text = "0";
            ////textBox6.Enabled = false;
            //simpleButton2.Enabled = true;
           
            getName1();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            product_tbl();
            DataView DV = new DataView(dtable);
            DV.RowFilter = string.Format("ProductName LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = DV;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                product_tbl();
            }

            else {
                product_tbl();

                string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
                MySqlConnection condatabase = new MySqlConnection(constring);
                MySqlCommand cmddatabase = new MySqlCommand("Select Product_ID as 'ProductID',Prod_desc as 'ProductName',Prod_Category as 'Category',Quantity ,Price from Products where Prod_Category = '" + comboBox2.Text + "' ", condatabase);


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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
