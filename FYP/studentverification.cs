using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FYP
{
    public partial class studentverification : Form
    {
        
        public studentverification()
        {
            InitializeComponent();
            this.FormClosed += Studentverification_FormClosed;
            this.Visible = true;
            FileInfo file = new FileInfo("pic1.jpg");
            DirectoryInfo di = new DirectoryInfo(file.FullName);
            FileInfo[] quizFiles = new DirectoryInfo(di.Parent.FullName).GetFiles("*.txt");
            

            foreach (FileInfo item in quizFiles)
            {

                if (!item.Name.Substring(0, item.Name.Length - 4).Equals("studentRecords"))
                {
                    comboBox1.Items.Add(item.Name.Substring(0, item.Name.Length - 4));
                    comboBox1.SelectedIndex = 0;
                }


            }
        }

        private void Studentverification_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                this.Hide();
                new Quiz((string)comboBox1.SelectedItem, textBox1.Text, textBox2.Text);
            }
            else
                MessageBox.Show("Student Name and Id must not be empty!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

       
    }
}
