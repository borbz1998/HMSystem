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
    public partial class Quarter : DevExpress.XtraEditors.XtraForm
    {
        public Quarter()
        {
            InitializeComponent();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
          

            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder gsdb = new MySqlConnectionStringBuilder();// yung bookdb
            gsdb.Server = "localhost"; //pangalan ng host ng workbench builder.UserID = "root"; 
            gsdb.UserID = "root";
            gsdb.Password = ""; //yung builder ano to sa visual studio
            gsdb.Database = "GradingSystem"; // name ng database
            MySqlConnection connection = new MySqlConnection(gsdb.ToString());

            string Query = "Delete FROM Quarters;";


            MySqlCommand newbook = new MySqlCommand(Query, connection);
            MySqlDataReader myReader;

            try
            {
                connection.Open();
                myReader = newbook.ExecuteReader();

                while (myReader.Read())
                {

                }
                connection.Close();
                connection.Open();

                foreach (string Q in checkedListBox1.CheckedItems)
                {
                    string query1 = "INSERT INTO Quarters(QuarterDesc) values ('" + Q + "');";

                    MySqlCommand newquery = new MySqlCommand(query1, connection);

                    newquery.ExecuteNonQuery();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Selected Quarter is unlock");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}