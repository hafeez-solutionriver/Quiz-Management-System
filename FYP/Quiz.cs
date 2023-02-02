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
    public partial class Quiz : Form
    {
        string []questions;
        string[] optionA;
        string[] optionB;
        string[] optionC;
        string[] optionD;
        string[] correctOption;
        string[] lines;

        int seconds;
        int currentQuestion;
        int displayMinutes, displaySeconds;
        int correctQuestions;
        string stdName, stdID;
        string startingTime, endingTime;
        StreamWriter stdRecords;
        string quizName;
        System.Media.SoundPlayer sp;

        private void Quiz_Load(object sender, EventArgs e)
        {

        }

        public Quiz(String quizName,string stdName,string stdID)
        {

            InitializeComponent();
            this.FormClosed += Quiz_FormClosed;

         
            this.quizName = quizName;
            

            this.stdName = stdName;
            this.stdID = stdID;
            stdRecords = new FileInfo("studentRecords.txt").AppendText();
            correctQuestions = 0;
            this.Visible = true;
         
            sp = new System.Media.SoundPlayer(@"quizMusic.wav");
            
       
            
           

            currentQuestion = 0;
            seconds = 0;
            displaySeconds = 60;
            

           lines = File.ReadLines(quizName+".txt").ToArray<string>();
            

            questions = new string[lines.Length/6];
            optionA = new string[lines.Length/6];
            optionB = new string[lines.Length / 6];
            optionC = new string[lines.Length / 6];
            optionD = new string[lines.Length / 6];
            correctOption = new string[lines.Length / 6];
            displayMinutes = questions.Length-1;


            int index = 0;
            int i = 0;
            while(i<lines.Length)
            {
                questions[index] = lines[i++];
               
                optionA[index] = lines[i++];
                optionB[index] = lines[i++];
                optionC[index] = lines[i++];
                optionD[index] = lines[i++];

  
                correctOption[index++] = lines[i++];
            }

            timerLabel.Text = displayMinutes + ":" + displaySeconds;
            this.label1.Text = "Q# " + (1 + currentQuestion);
            this.label6.Text = questions[currentQuestion];
            this.radioButton1.Text = optionA[currentQuestion];
            this.radioButton2.Text = optionB[currentQuestion];
            this.radioButton3.Text = optionC[currentQuestion];
            this.radioButton4.Text = optionD[currentQuestion];
            startingTime = System.DateTime.Now.ToString();
            timer1.Enabled = true;

        }

        private void Quiz_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(displaySeconds==0)
            {
                if(displayMinutes==0)
                {
                    if (radioButton1.Checked && correctOption[currentQuestion].Equals("Option A"))
                        correctQuestions++;

                    else if (radioButton2.Checked && correctOption[currentQuestion].Equals("Option B"))
                        correctQuestions++;
                    else if (radioButton3.Checked && correctOption[currentQuestion].Equals("Option C"))
                        correctQuestions++;
                    else if (radioButton4.Checked && correctOption[currentQuestion].Equals("Option D"))
                        correctQuestions++;
                    this.timer1.Enabled = false;
                    sp.Stop();

                    timerLabel.Text = displayMinutes + ":" + displaySeconds;
                    seconds++;

                    endingTime = System.DateTime.Now.ToString();
                    MessageBox.Show("Quiz is Ended\nYou have answered correctly "+correctQuestions+" out of "+questions.Length,"Time is UP!", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    //~ is being used here as a deliminator
                    stdRecords.WriteLine(quizName + "~" + stdName + "~" + stdID + "~" + startingTime + "~" + endingTime + "~" + correctQuestions + "~" + questions.Length);
                    stdRecords.Close();
                    this.Dispose();

                    new Welcome();
                }
                displayMinutes--;
                displaySeconds = 60;

            }

            if (displaySeconds == 30 && displayMinutes == 0)
            {
                timerLabel.ForeColor = Color.Red;
                sp.Play();
            }
            timerLabel.Text = displayMinutes + ":" + displaySeconds;
            seconds++;
            displaySeconds--;
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            if (radioButton1.Checked && correctOption[currentQuestion].Equals("Option A"))
                correctQuestions++;

            else if (radioButton2.Checked && correctOption[currentQuestion].Equals("Option B"))
                correctQuestions++;
            else if (radioButton3.Checked && correctOption[currentQuestion].Equals("Option C"))
                correctQuestions++;
            else if (radioButton4.Checked && correctOption[currentQuestion].Equals("Option D"))
                correctQuestions++;






            currentQuestion++;
            if (currentQuestion == questions.Length)
            {
                endingTime = System.DateTime.Now.ToString();
                sp.Stop();
                MessageBox.Show("Quiz is completed.\nYou have answered correctly " + correctQuestions + " out of " + questions.Length);

                stdRecords.WriteLine(quizName+"~"+stdName + "~" + stdID + "~" + startingTime + "~" + endingTime + "~" + correctQuestions + "~" + questions.Length);
                stdRecords.Close();

                this.Dispose();
                
                new Welcome();
                
              


            }
            else
            {

                this.label1.Text = "Q# " + (1 + currentQuestion);
                this.label6.Text = questions[currentQuestion];
                this.radioButton1.Text = optionA[currentQuestion];
                this.radioButton2.Text = optionB[currentQuestion];
                this.radioButton3.Text = optionC[currentQuestion];
                this.radioButton4.Text = optionD[currentQuestion];

            }
                                               
        }

      
    }
}
