
using System;

namespace MathPractice
{
    abstract class MathProblem
    {
        public int Factor1 { get; set; }
        public int Factor2 { get; set; }
        public double Result
        {
            get
            {
                switch (this.Operator)
                {
                    case MathOperator.Add:
                        return Factor1 + Factor2;
                    case MathOperator.Subtract:
                        return Factor1 - Factor2;
                    case MathOperator.Multiply:
                        return Factor1 * Factor2;
                    case MathOperator.Divide:
                        return Factor1 / Factor2;
                    default:
                        throw new System.Exception("Operator not set");
                }
            }

        }

        public MathOperator Operator { get; set; }

        public enum MathOperator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
        }

        public string DisplayOperator
        {
            get
            {
                string _displayOperator = "";
                switch (this.Operator)
                {
                    case MathOperator.Add:
                        _displayOperator = "+";
                        break;
                    case MathOperator.Subtract:
                        _displayOperator = "-";
                        break;
                    case MathOperator.Multiply:
                        _displayOperator = "X";
                        break;
                    case MathOperator.Divide:
                        _displayOperator = "/";
                        break;
                }

                return _displayOperator;
            }
        }
        
        public string Equation
        {
            get
            {
                return string.Format("{0} {1} {2} = {3}", this.Factor1, this.DisplayOperator, this.Factor2, this.Result);
            }
        }

        public override string ToString()
        {
            return this.Result.ToString();
        }

        private DateTime StartTime;
        public void StartTimer()
        {
            StartTime = DateTime.Now;
        }

        private DateTime EndTime;
        public void StopTimer()
        {
            EndTime = DateTime.Now;
        }

        public int TimeToSolve
        {
            get
            {
                return (EndTime - StartTime).Seconds;
            }
        }
    }


    class MultiplicationProblem : MathProblem
    {
        public MultiplicationProblem(int Factor1, int Factor2)
        {
            this.Operator = MathOperator.Multiply;
            this.Factor1 = Factor1;
            this.Factor2 = Factor2;
        }

    }
}

