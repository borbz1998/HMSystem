using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Grades
{
    public partial class AdminButtons : DevExpress.XtraEditors.XtraForm
    {
        public AdminButtons()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin hackers = new Admin();
            hackers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierMainform hackers = new CashierMainform();
            hackers.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            POSFORM hackers = new POSFORM();
            hackers.Show();
        }

        private void AdminButtons_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void AdminButtons_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}