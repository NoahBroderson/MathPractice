﻿using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;


namespace MathPractice
{
    public partial class frmTablesTester : Form
    {
        List<MultiplicationProblem> ProblemList = new List<MultiplicationProblem>();
        List<MultiplicationProblem> RepeatList = new List<MultiplicationProblem>();
        MultiplicationProblem CurrentProblem = null;
        int CorrectlyAnswered = 0;
        int QuestionCount = 0;
        int IncorrectlyAnswered = 0;

        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();


        public frmTablesTester()
        {
            InitializeComponent();

        }
        private void ClassTester_Load(object sender, EventArgs e)
        {
            LoadFirstTest();
        }

        private void LoadFirstTest()
        {
            cboTables.SelectedIndex = new Random(DateTime.Now.Second).Next(10);
        }

        private void NewQuiz()
        {
            ClearOldQuiz();
            LoadProblemList();
            LoadSpeech();
            DisplayNextProblem();
        }

        private void ClearOldQuiz()
        {
            ProblemList.Clear();
            RepeatList.Clear();
            CorrectlyAnswered = 0;
            QuestionCount = 0;
            IncorrectlyAnswered = 0;
            lbCorrectProblems.Items.Clear();
            lbIncorrectProblems.Items.Clear();
            txtCorrect.Text = "";
            txtIncorrect.Text = "";
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "next")
            {
                DisplayNextProblem();
            }
            else
            {
                txtAnswer.Text = e.Result.Text;
                CheckAnswer();
            }
        }

        private void DisplayNextProblem()
        {
            InsureProblemsRemain();
            var NextProblem = GetNextProblem();

            lblFeedback.Text = "";
            txtAnswer.Text = "";
            lblEquation.Text = "";
            lblEquation.BackColor = Control.DefaultBackColor;
            txtFactor1.Text = NextProblem.Factor1.ToString();
            txtFactor2.Text = NextProblem.Factor2.ToString();
            lblProblem.Text = string.Format("{0} {1} {2}= ?", NextProblem.Factor1, NextProblem.DisplayOperator, NextProblem.Factor2);
            cboOperator.SelectedIndex = (int)NextProblem.Operator;
            CurrentProblem = NextProblem;
            txtAnswer.Focus();

            ReadProblemAloud();

            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;

            //GrammarBuilder grammerBuilder = new GrammarBuilder();
            //Choices commandChoices = new Choices("next");
            //for (int i = 1; i < 101; i++)
            //{
            //    commandChoices.Add(i.ToString());
            //}
            //grammerBuilder.Append(commandChoices);
            ////grammerBuilder.Append("1");

            //Grammar grammer = new Grammar(grammerBuilder);
            //_recognizer.LoadGrammarAsync(grammer);
            //_recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            //_recognizer.SpeechRecognitionRejected += _recognizer_SpeechRecognitionRejected;
            //_recognizer.SetInputToDefaultAudioDevice();
            //_recognizer.Recognize();
        }

        private void ReadProblemAloud(bool WithAnswer = false)
        {
            string Operator = "";
            string Answer = " ";

            if (WithAnswer)
            {
                Answer = "equals " + CurrentProblem.Result.ToString();
            }

            switch (CurrentProblem.Operator)
            {
                case MathProblem.MathOperator.Add:
                    Operator = "plus";
                    break;
                case MathProblem.MathOperator.Subtract:
                    Operator = "minus";
                    break;
                case MathProblem.MathOperator.Multiply:
                    Operator = "times";
                    break;
                case MathProblem.MathOperator.Divide:
                    Operator = "divided by";
                    break;
            }

            _synthesizer.Speak(string.Format("{0} {1} {2} {3}", CurrentProblem.Factor1, Operator, CurrentProblem.Factor2, Answer));
        }

        private void LoadSpeech()
        {
            GrammarBuilder grammerBuilder = new GrammarBuilder();
            Choices commandChoices = new Choices("next");
            for (int i = 1; i < 101; i++)
            {
                commandChoices.Add(i.ToString());
            }
            grammerBuilder.Append(commandChoices);
            //grammerBuilder.Append("1");

            Grammar grammer = new Grammar(grammerBuilder);
            _recognizer.LoadGrammarAsync(grammer);
            //_recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            _recognizer.SpeechRecognitionRejected += _recognizer_SpeechRecognitionRejected;
            _recognizer.SetInputToDefaultAudioDevice();
            // _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void InsureProblemsRemain()
        {
            if (ProblemList.Count == 0)
            {
                if (RepeatList.Count == 0)
                {
                    LoadProblemList();
                    DisplayNextProblem();
                }
                else
                {
                    for (int i = 0; i < RepeatList.Count; i++)
                    {
                        ProblemList.Add(RepeatList[i]);
                    }
                    RepeatList.Clear();
                }


            }
        }

        private MultiplicationProblem GetNextProblem()
        {
            var RandomGenerator = new Random();
            int NextIndex = RandomGenerator.Next(ProblemList.Count) - 1;
            if (NextIndex == -1)
            {
                NextIndex = 0;
            }
            var NextProblem = ProblemList[NextIndex];
            ProblemList.RemoveAt(NextIndex);
            return NextProblem;
        }



        private void LoadProblemList()
        {
            //var MultProb = new MultiplicationProblem() { Factor1 = 1, Factor2 = 2, Operator = MathProblem.MathOperator.Multiply };
            //var MultProb2 = new MultiplicationProblem() { Factor1 = 1, Factor2 = 3, Operator = MathProblem.MathOperator.Add };
            //MessageBox.Show(MultProb.Equation);
            //MessageBox.Show(MultProb2.Equation);
            ProblemList.Clear();

            for (int factor2 = 1; factor2 <= 10; factor2++)
            {
                for (int factor1 = Convert.ToInt16(cboTables.SelectedItem); factor1 <= Convert.ToInt16(cboTables.SelectedItem); factor1++)
                {

                    ProblemList.Add(new MultiplicationProblem(factor1, factor2));
                }
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        void _recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            lblFeedback.Text = e.Result.Alternates[0].Text;
        }

        private void btnNextProblem_Click(object sender, EventArgs e)
        {
            DisplayNextProblem();
        }

        private void CheckAnswer()
        {
            int Answer = 0;

            if ((!int.TryParse(txtAnswer.Text, out Answer)))
            {
                MessageBox.Show("You must enter a number for an answer!");
                txtAnswer.Text = "";
            }
            else
            {
                QuestionCount += 1;
                lblEquation.Text = CurrentProblem.Equation;
                //_recognizer.SpeechRecognized -= _recognizer_SpeechRecognized;

                bool AnswerCorrect = (Answer == CurrentProblem.Result);

                GiveUserFeedback(AnswerCorrect);
                UpDateScore(AnswerCorrect);

                btnNextProblem.Focus();
                if ((ProblemList.Count == 0) && (RepeatList.Count == 0))
                {
                    double PercentCorrect = ((double)CorrectlyAnswered / (double)QuestionCount) * 100;
 
                    if (MessageBox.Show(string.Format("Great job! You got {0:0.00}% right! Do you want to play again?", PercentCorrect), "Caption", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        NewQuiz();
                        return;
                    }
                }
                DisplayNextProblem();

                
                
            }

        }

        private void UpDateScore(bool AnsweredCorrectly)
        {
            if (AnsweredCorrectly)
            {
                lbCorrectProblems.Items.Add(CurrentProblem.Equation);
                CorrectlyAnswered += 1;
                txtCorrect.Text = CorrectlyAnswered.ToString();
            }
            else
            {
                lbIncorrectProblems.Items.Add(CurrentProblem.Equation);
                IncorrectlyAnswered += 1;
                txtIncorrect.Text = IncorrectlyAnswered.ToString();
            }
        }

        private void GiveUserFeedback(bool AnswerCorrect)
        {
            if (AnswerCorrect)
            {
                lblFeedback.Text = "Great job! On to the next one!";
                lblEquation.BackColor = System.Drawing.Color.Green;
                _synthesizer.Speak("Great job!");
                ReadProblemAloud(true);
            }
            else
            {
                lblFeedback.Text = "Ooops, we'll have to try that one again";
                lblEquation.BackColor = System.Drawing.Color.Red;
                _synthesizer.Speak("Ooops, we'll have to try that one again");
                ReadProblemAloud(true);
                RepeatList.Add(CurrentProblem);
            }
        }

        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewQuiz();
        }

        private void lblProblem_Click(object sender, EventArgs e)
        {

        }

    }
}