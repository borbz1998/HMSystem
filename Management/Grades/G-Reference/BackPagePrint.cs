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
    public partial class BackPagePrint : DevExpress.XtraEditors.XtraForm
    {
        private string lname;
        public BackPagePrint()
        {
            InitializeComponent();
        }
        public string passvalue3
        {
            get { return lname; }
            set { lname = value; }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            printDialog1 = new PrintDialog();
            printDialog1.AllowCurrentPage = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackPagePrint_Load(object sender, EventArgs e)
        {
            txtidnum.Text = lname;
        }
    }
}