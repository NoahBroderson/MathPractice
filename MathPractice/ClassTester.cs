using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;


namespace MathPractice
{
    public partial class frmTablesTester : Form
    {
        List<MultiplicationProblem> ProblemList = new List<MultiplicationProblem>();
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
            txtAnswer.Text = e.Result.Text;
            CheckAnswer(txtAnswer.Text);
        }

        private void DisplayNextProblem()
        {
            CurrentProblem = GetNextProblem();
            UpdateUIWithNewProblem(CurrentProblem);
            CurrentProblem.StartTimer();
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

        private void UpdateUIWithNewProblem(MultiplicationProblem NextProblem)
        {
            lblFeedback.Text = "";
            txtAnswer.Text = "";
            lblEquation.Text = "";
            lblEquation.BackColor = Control.DefaultBackColor;
            txtFactor1.Text = NextProblem.Factor1.ToString();
            txtFactor2.Text = NextProblem.Factor2.ToString();
            lblProblem.Text = string.Format("{0} {1} {2}= ?", NextProblem.Factor1, NextProblem.DisplayOperator, NextProblem.Factor2);
            cboOperator.SelectedIndex = (int)NextProblem.Operator;
            txtAnswer.Focus();
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

        private MultiplicationProblem GetNextProblem()
        {
            var RandomGenerator = new Random();
            int NextIndex = RandomGenerator.Next(0,ProblemList.Count -1);
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

            //for (int factor2 = 1; factor2 <= 10; factor2++)
            //{
            //    for (int factor1 = Convert.ToInt16(cboTables.SelectedItem); factor1 <= Convert.ToInt16(cboTables.SelectedItem); factor1++)
            //    {
            //        ProblemList.Add(new MultiplicationProblem(factor1, factor2));
            //    }
            //}
            int factor1 = Convert.ToInt16(cboTables.SelectedItem);
            for (int factor2 = 1; factor2 <= 10; factor2++)
            {
                    ProblemList.Add(new MultiplicationProblem(factor1, factor2));
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (AnswerIsInteger(txtAnswer.Text))
            {
                CurrentProblem.StopTimer();
                QuestionCount += 1;
                //_recognizer.SpeechRecognized -= _recognizer_SpeechRecognized;
                bool IsCorrectAnswer = CheckAnswer(txtAnswer.Text);
                UpdateUI(IsCorrectAnswer);
                CheckIfQuizFinished();
                DisplayNextProblem();
            }
            else
            {
                MessageBox.Show("You must enter a number for an answer!");
                txtAnswer.Text = "";
            }
        }

        private void UpdateUI(bool IsCorrectAnswer)
        {
            GiveUserFeedback(IsCorrectAnswer);
            UpDateScoreAndAnswerList(IsCorrectAnswer);
            lblEquation.Text = CurrentProblem.Equation;
        }

        private void CheckIfQuizFinished()
        {
            if ((ProblemList.Count == 0))
            {
                FinishQuiz();
            }
        }

        private bool CheckAnswer(string text)
        {
            return (int.Parse(txtAnswer.Text) == CurrentProblem.Result);
        }

        void _recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            lblFeedback.Text = e.Result.Alternates[0].Text;
        }

        private void FinishQuiz()
        {
            double PercentCorrect = ((double)CorrectlyAnswered / (double)QuestionCount) * 100;

            if (MessageBox.Show(string.Format("Great job! You got {0:0.00}% right! Do you want to play again?", PercentCorrect), "Caption", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Hide();
                this.Close();
            }
            else
            {
                NewQuiz();
            }
        }

        private bool AnswerIsInteger(string text)
        {
            int Answer;
            if ((!int.TryParse(txtAnswer.Text, out Answer)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpDateScoreAndAnswerList(bool AnsweredCorrectly)
        {
            if (AnsweredCorrectly)
            {
                CorrectlyAnswered += 1;
                txtCorrect.Text = CorrectlyAnswered.ToString();
                UpdateAnswerList(lbCorrectProblems);
            }
            else
            {
                IncorrectlyAnswered += 1;
                txtIncorrect.Text = IncorrectlyAnswered.ToString();
                UpdateAnswerList(lbIncorrectProblems);
            }
        }

        private void UpdateAnswerList(ListBox ListBoxToUpdate)
        {
            ListBoxToUpdate.Items.Add(string.Format("{0} : {1} seconds", CurrentProblem.Equation, CurrentProblem.TimeToSolve));
        }

        private void GiveUserFeedback(bool AnswerCorrect)
        {
            if (AnswerCorrect)
            {
                lblEquation.BackColor = System.Drawing.Color.Green;
                lblEquation.Text = CurrentProblem.Equation;
                lblFeedback.Text = "Great job! On to the next one!";
                _synthesizer.Speak("Great job!");
                ReadProblemAloud(true);
            }
            else
            {
                lblEquation.BackColor = System.Drawing.Color.Red;
                lblEquation.Text = CurrentProblem.Equation;
                lblFeedback.Text = "Ooops, we'll have to try that one again";
                _synthesizer.Speak("Ooops, we'll have to try that one again");
                ReadProblemAloud(true);
                ProblemList.Add(CurrentProblem);
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
