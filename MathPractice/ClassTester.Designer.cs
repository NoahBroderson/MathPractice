namespace MathPractice
{
    partial class frmTablesTester
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFactor1 = new System.Windows.Forms.TextBox();
            this.txtFactor2 = new System.Windows.Forms.TextBox();
            this.lblFactor1 = new System.Windows.Forms.Label();
            this.lblFactor2 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblEquation = new System.Windows.Forms.Label();
            this.lblProblem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIncorrect = new System.Windows.Forms.TextBox();
            this.txtCorrect = new System.Windows.Forms.TextBox();
            this.lbCorrectProblems = new System.Windows.Forms.ListBox();
            this.lbIncorrectProblems = new System.Windows.Forms.ListBox();
            this.lblTables = new System.Windows.Forms.Label();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtFactor1
            // 
            this.txtFactor1.Location = new System.Drawing.Point(179, 6);
            this.txtFactor1.Name = "txtFactor1";
            this.txtFactor1.Size = new System.Drawing.Size(100, 20);
            this.txtFactor1.TabIndex = 0;
            // 
            // txtFactor2
            // 
            this.txtFactor2.Location = new System.Drawing.Point(179, 33);
            this.txtFactor2.Name = "txtFactor2";
            this.txtFactor2.Size = new System.Drawing.Size(100, 20);
            this.txtFactor2.TabIndex = 1;
            // 
            // lblFactor1
            // 
            this.lblFactor1.AutoSize = true;
            this.lblFactor1.Location = new System.Drawing.Point(119, 13);
            this.lblFactor1.Name = "lblFactor1";
            this.lblFactor1.Size = new System.Drawing.Size(46, 13);
            this.lblFactor1.TabIndex = 3;
            this.lblFactor1.Text = "Factor 1";
            // 
            // lblFactor2
            // 
            this.lblFactor2.AutoSize = true;
            this.lblFactor2.Location = new System.Drawing.Point(119, 41);
            this.lblFactor2.Name = "lblFactor2";
            this.lblFactor2.Size = new System.Drawing.Size(46, 13);
            this.lblFactor2.TabIndex = 4;
            this.lblFactor2.Text = "Factor 2";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(119, 70);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 5;
            this.lblOperator.Text = "Operator";
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "Add",
            "Subtract",
            "Multiply",
            "Divide"});
            this.cboOperator.Location = new System.Drawing.Point(179, 62);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(121, 21);
            this.cboOperator.TabIndex = 6;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(126, 313);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 20);
            this.txtAnswer.TabIndex = 0;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(49, 320);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(45, 13);
            this.lblAnswer.TabIndex = 8;
            this.lblAnswer.Text = "Answer:";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblFeedback.Location = new System.Drawing.Point(188, 363);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(52, 24);
            this.lblFeedback.TabIndex = 9;
            this.lblFeedback.Text = "       ";
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(245, 310);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(133, 23);
            this.btnAnswer.TabIndex = 10;
            this.btnAnswer.Text = "Check Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // lblEquation
            // 
            this.lblEquation.AutoSize = true;
            this.lblEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquation.Location = new System.Drawing.Point(28, 360);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(117, 29);
            this.lblEquation.TabIndex = 12;
            this.lblEquation.Text = "-------------";
            // 
            // lblProblem
            // 
            this.lblProblem.AutoSize = true;
            this.lblProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblem.Location = new System.Drawing.Point(127, 231);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Size = new System.Drawing.Size(200, 55);
            this.lblProblem.TabIndex = 13;
            this.lblProblem.Text = "-----------";
            this.lblProblem.Click += new System.EventHandler(this.lblProblem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Correct";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Incorrect";
            // 
            // txtIncorrect
            // 
            this.txtIncorrect.Enabled = false;
            this.txtIncorrect.Location = new System.Drawing.Point(693, 41);
            this.txtIncorrect.Name = "txtIncorrect";
            this.txtIncorrect.Size = new System.Drawing.Size(100, 20);
            this.txtIncorrect.TabIndex = 16;
            // 
            // txtCorrect
            // 
            this.txtCorrect.Enabled = false;
            this.txtCorrect.Location = new System.Drawing.Point(506, 41);
            this.txtCorrect.Name = "txtCorrect";
            this.txtCorrect.Size = new System.Drawing.Size(100, 20);
            this.txtCorrect.TabIndex = 17;
            // 
            // lbCorrectProblems
            // 
            this.lbCorrectProblems.FormattingEnabled = true;
            this.lbCorrectProblems.Location = new System.Drawing.Point(506, 92);
            this.lbCorrectProblems.Name = "lbCorrectProblems";
            this.lbCorrectProblems.Size = new System.Drawing.Size(157, 225);
            this.lbCorrectProblems.TabIndex = 18;
            // 
            // lbIncorrectProblems
            // 
            this.lbIncorrectProblems.FormattingEnabled = true;
            this.lbIncorrectProblems.Location = new System.Drawing.Point(693, 92);
            this.lbIncorrectProblems.Name = "lbIncorrectProblems";
            this.lbIncorrectProblems.Size = new System.Drawing.Size(157, 225);
            this.lbIncorrectProblems.TabIndex = 19;
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(1, 13);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(93, 13);
            this.lblTables.TabIndex = 20;
            this.lblTables.Text = "Tables to Practice";
            // 
            // cboTables
            // 
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboTables.Location = new System.Drawing.Point(4, 41);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(90, 21);
            this.cboTables.TabIndex = 21;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            // 
            // frmTablesTester
            // 
            this.AcceptButton = this.btnAnswer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 467);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.lbIncorrectProblems);
            this.Controls.Add(this.lbCorrectProblems);
            this.Controls.Add(this.txtCorrect);
            this.Controls.Add(this.txtIncorrect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProblem);
            this.Controls.Add(this.lblEquation);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.lblFactor2);
            this.Controls.Add(this.lblFactor1);
            this.Controls.Add(this.txtFactor2);
            this.Controls.Add(this.txtFactor1);
            this.Name = "frmTablesTester";
            this.Text = "Tables Tester";
            this.Load += new System.EventHandler(this.ClassTester_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFactor1;
        private System.Windows.Forms.TextBox txtFactor2;
        private System.Windows.Forms.Label lblFactor1;
        private System.Windows.Forms.Label lblFactor2;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblEquation;
        private System.Windows.Forms.Label lblProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIncorrect;
        private System.Windows.Forms.TextBox txtCorrect;
        private System.Windows.Forms.ListBox lbCorrectProblems;
        private System.Windows.Forms.ListBox lbIncorrectProblems;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.ComboBox cboTables;
    }
}