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
    
    public partial class logInForInstructor : Form
    {

        public logInForInstructor()
        {
            InitializeComponent();
            this.FormClosed += LogInForInstructor_FormClosed;
            this.Visible = true;
            
        }

        private void LogInForInstructor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instructor ID --> UGR-5
            //Instructor Password --> VP-2021

            if (textBox1.Text.Equals("UGR-5") && textBox2.Text.Equals("VP-2021"))
            {
                this.Hide();
                new QuizCreation();
            }

            else
                MessageBox.Show("Invalid Instructor ID Or Password!,The provided credentials do not exist in our dataset.", "Instructor ID or Password does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
