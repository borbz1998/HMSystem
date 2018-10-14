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
    public partial class AboutUs : DevExpress.XtraEditors.XtraForm
    {
        public AboutUs()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {

         textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.WordWrap = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox7.Visible == true)
            {
                pictureBox7.Visible = false;
                pictureBox6.Visible = true;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox5.Visible = true;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox7.Visible = true;
            }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}