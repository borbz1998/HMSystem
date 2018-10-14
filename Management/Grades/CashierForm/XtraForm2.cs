using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Grades
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        MySqlDataAdapter eug;
        MySqlCommandBuilder boks;
        private string conn;
        private MySqlConnection connect;
        MySqlCommand cmd;
        public XtraForm2()
        {
            InitializeComponent();
            getName1();
        }
        DataTable dtable;
        private void getName1()
        {

            MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=Management;Uid=root;Pwd=;");
            string eug = "select (InvoiceNo) as InvoiceNo from transactiondetails order by InvoiceNo desc limit 1;";
            cmd = new MySqlCommand(eug, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["InvoiceNo"].ToString();
            reader.Read();
            reader.Dispose();
            reader.Close();
            con.Close();
        }
        private void btnload_Click(object sender, EventArgs e)
        {
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["management"].ConnectionString))
            //{
            //    if (db.State == ConnectionState.Closed)
            //        db.Open();
            //    string query = "Select Product_ID as ProductID,Prod_desc as ProductName,UnitPrice,Quantity,Price from transactiondetails $ where InvoiceNo='" + textBox1.Text + "'";


            //}

            string constring = "Server=localhost;Database=Management;Uid=root;Pwd=";
            MySqlConnection condatabase = new MySqlConnection(constring);
            MySqlCommand cmddatabase = new MySqlCommand("Select InvoiceNo,Product_ID as ProductID,Prod_desc as ProductName,UnitPrice,Quantity,Price from transactiondetails where InvoiceNo='" + textBox1.Text + "'", condatabase);

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

                double sum = 0;
                double x = 0.12;
                double vat = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);

                    vat = (sum * x);
                }

                //label15.Text = sum.ToString();
                //label15.Text = String.Format("{0:C}", double.Parse(label15.Text));

                //label14.Text = vat.ToString();
                //label14.Text = String.Format("{0:C}", double.Parse(label14.Text));
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          //  newBindingSource.DataSource = condatabase.Query<New>(cmddatabase, commandType: CommandType.Text);

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}