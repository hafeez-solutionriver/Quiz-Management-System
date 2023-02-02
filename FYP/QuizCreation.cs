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
    public partial class QuizCreation : Form
    {
        int questionNumber;
        public QuizCreation()
        {
            questionNumber = 2;
            InitializeComponent();
            this.FormClosed += QuizCreation_FormClosed;
            this.Visible = true;
            this.comboBox1.SelectedIndex = 0;
        }

        private void QuizCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            FileInfo file = new FileInfo(textBox1.Text+".txt");
            StreamWriter sw = file.AppendText();
            sw.WriteLine(textBox2.Text);
            sw.WriteLine(textBox3.Text);
            sw.WriteLine(textBox4.Text);
            sw.WriteLine(textBox5.Text);
            sw.WriteLine(textBox6.Text);

            sw.WriteLine((string)comboBox1.SelectedItem);
            sw.Close();
            MessageBox.Show("Successfully Added the Question:");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            

            label2.Text = "Question #" + questionNumber++;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Welcome().Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                MessageBox.Show("Kindly, Do not Enter a space in quiz Name!", "QuizNameArgumentError!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
    }
}
