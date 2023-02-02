using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    public partial class Welcome : Form
    {
        string msg = "WELCOME TO QUIZ MANAGEMENT SYSTEM";
        int index;
        public Welcome()
        {
            index = 0;
            InitializeComponent();
            this.Visible = true;
            pictureBox1.ImageLocation = "pic1.jpg";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

         
            timer1.Enabled=true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index != msg.Length)
            {
                label1.Text += msg[index++];
            }
            else
                timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new logInForInstructor();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new studentverification();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ViewRecords();
        }
    }
}
