using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;

namespace Grades
{
    public partial class BackupRestore : DevExpress.XtraEditors.XtraForm
    {
        public BackupRestore()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog dlg1 = new FolderBrowserDialog();
            DialogResult result = dlg1.ShowDialog();
            textBoxX1.Text = dlg1.SelectedPath + "\\backup.sql";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "Management";
            string file = textBoxX1.Text;
            if (file == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("No file Path");
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(builder.ToString()))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                        DevExpress.XtraEditors.XtraMessageBox.Show("Succesfully Backed up");
                    }
                }
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Text Files (*.sql)|*.sql";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                textBoxX2.Text = sFileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
            
           
           
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "Management";
                string file = textBoxX2.Text;
                using (MySqlConnection conn = new MySqlConnection(builder.ToString()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportInfo.TargetDatabase = "Management";
                            mb.ImportFromFile(file);
                            conn.Close();
                            DevExpress.XtraEditors.XtraMessageBox.Show("Succesfully Restored");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}