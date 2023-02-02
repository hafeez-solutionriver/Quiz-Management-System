using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    
    public partial class ViewRecords : Form
    {

        Record []records;

        public ViewRecords()
        {
            
            InitializeComponent();
            this.FormClosed += ViewRecords_FormClosed;
            this.dataGridView1.ReadOnly = true;
            this.Visible = true;
            string[] lines = File.ReadAllLines("studentRecords.txt");
            records = new Record[lines.Length];
            
            for(int i =0;i<lines.Length;i++)
            {
                string[] temp = lines[i].Split(new char[] { '~' });
                records[i] = new Record();
                records[i].QuizName = temp[0];
                records[i].StdName = temp[1];
                records[i].StdID = temp[2];
                records[i].StartingTime = temp[3];
                records[i].EndingTime = temp[4];
                records[i].CorrectQuestions = temp[5];
                records[i].TotalQuestions = temp[6];


            }

            dataGridView1.DataSource = records;
        }

        private void ViewRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Welcome();
        }
    }
    class Record
    {

        string quizName, stdName, stdID, startingTime, endingTime, correctQuestions, totalQuestions;

        public string QuizName { get => quizName; set => quizName = value; }
        public string StdName { get => stdName; set => stdName = value; }
        public string StdID { get => stdID; set => stdID = value; }
        public string StartingTime { get => startingTime; set => startingTime = value; }
        public string EndingTime { get => endingTime; set => endingTime = value; }
        public string CorrectQuestions { get => correctQuestions; set => correctQuestions = value; }
        public string TotalQuestions { get => totalQuestions; set => totalQuestions = value; }
    }
}
