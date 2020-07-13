namespace Lab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.A11TextBox = new System.Windows.Forms.TextBox();
            this.A12TextBox = new System.Windows.Forms.TextBox();
            this.A13TextBox = new System.Windows.Forms.TextBox();
            this.A33TextBox = new System.Windows.Forms.TextBox();
            this.A32TextBox = new System.Windows.Forms.TextBox();
            this.A31TextBox = new System.Windows.Forms.TextBox();
            this.A23TextBox = new System.Windows.Forms.TextBox();
            this.A22TextBox = new System.Windows.Forms.TextBox();
            this.A21TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.F2TextBox = new System.Windows.Forms.TextBox();
            this.F3TextBox = new System.Windows.Forms.TextBox();
            this.F1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MonteCarloLabel = new System.Windows.Forms.Label();
            this.GaussLabel = new System.Windows.Forms.Label();
            this.GetSolutionButton = new System.Windows.Forms.Button();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.MarkovCountTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // A11TextBox
            // 
            this.A11TextBox.Location = new System.Drawing.Point(73, 81);
            this.A11TextBox.Name = "A11TextBox";
            this.A11TextBox.Size = new System.Drawing.Size(47, 22);
            this.A11TextBox.TabIndex = 0;
            this.A11TextBox.Text = " 1";
            // 
            // A12TextBox
            // 
            this.A12TextBox.Location = new System.Drawing.Point(126, 81);
            this.A12TextBox.Name = "A12TextBox";
            this.A12TextBox.Size = new System.Drawing.Size(47, 22);
            this.A12TextBox.TabIndex = 1;
            this.A12TextBox.Text = "-0,4";
            // 
            // A13TextBox
            // 
            this.A13TextBox.Location = new System.Drawing.Point(179, 81);
            this.A13TextBox.Name = "A13TextBox";
            this.A13TextBox.Size = new System.Drawing.Size(47, 22);
            this.A13TextBox.TabIndex = 2;
            this.A13TextBox.Text = "-0,1";
            // 
            // A33TextBox
            // 
            this.A33TextBox.Location = new System.Drawing.Point(179, 156);
            this.A33TextBox.Name = "A33TextBox";
            this.A33TextBox.Size = new System.Drawing.Size(47, 22);
            this.A33TextBox.TabIndex = 5;
            this.A33TextBox.Text = "1";
            // 
            // A32TextBox
            // 
            this.A32TextBox.Location = new System.Drawing.Point(126, 156);
            this.A32TextBox.Name = "A32TextBox";
            this.A32TextBox.Size = new System.Drawing.Size(47, 22);
            this.A32TextBox.TabIndex = 4;
            this.A32TextBox.Text = "0,2";
            // 
            // A31TextBox
            // 
            this.A31TextBox.Location = new System.Drawing.Point(73, 156);
            this.A31TextBox.Name = "A31TextBox";
            this.A31TextBox.Size = new System.Drawing.Size(47, 22);
            this.A31TextBox.TabIndex = 3;
            this.A31TextBox.Text = "0,3";
            // 
            // A23TextBox
            // 
            this.A23TextBox.Location = new System.Drawing.Point(179, 119);
            this.A23TextBox.Name = "A23TextBox";
            this.A23TextBox.Size = new System.Drawing.Size(47, 22);
            this.A23TextBox.TabIndex = 8;
            this.A23TextBox.Text = "-0,1";
            // 
            // A22TextBox
            // 
            this.A22TextBox.Location = new System.Drawing.Point(126, 119);
            this.A22TextBox.Name = "A22TextBox";
            this.A22TextBox.Size = new System.Drawing.Size(47, 22);
            this.A22TextBox.TabIndex = 7;
            this.A22TextBox.Text = "0,7";
            // 
            // A21TextBox
            // 
            this.A21TextBox.Location = new System.Drawing.Point(73, 119);
            this.A21TextBox.Name = "A21TextBox";
            this.A21TextBox.Size = new System.Drawing.Size(47, 22);
            this.A21TextBox.TabIndex = 6;
            this.A21TextBox.Text = "0,4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "A = ";
            // 
            // F2TextBox
            // 
            this.F2TextBox.Location = new System.Drawing.Point(315, 119);
            this.F2TextBox.Name = "F2TextBox";
            this.F2TextBox.Size = new System.Drawing.Size(47, 22);
            this.F2TextBox.TabIndex = 12;
            this.F2TextBox.Text = "5";
            // 
            // F3TextBox
            // 
            this.F3TextBox.Location = new System.Drawing.Point(315, 156);
            this.F3TextBox.Name = "F3TextBox";
            this.F3TextBox.Size = new System.Drawing.Size(47, 22);
            this.F3TextBox.TabIndex = 11;
            this.F3TextBox.Text = "-4";
            // 
            // F1TextBox
            // 
            this.F1TextBox.Location = new System.Drawing.Point(315, 81);
            this.F1TextBox.Name = "F1TextBox";
            this.F1TextBox.Size = new System.Drawing.Size(47, 22);
            this.F1TextBox.TabIndex = 10;
            this.F1TextBox.Text = "-1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(266, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "f = ";
            // 
            // MonteCarloLabel
            // 
            this.MonteCarloLabel.AutoSize = true;
            this.MonteCarloLabel.Location = new System.Drawing.Point(17, 234);
            this.MonteCarloLabel.Name = "MonteCarloLabel";
            this.MonteCarloLabel.Size = new System.Drawing.Size(31, 17);
            this.MonteCarloLabel.TabIndex = 28;
            this.MonteCarloLabel.Text = "das";
            // 
            // GaussLabel
            // 
            this.GaussLabel.AutoSize = true;
            this.GaussLabel.Location = new System.Drawing.Point(17, 263);
            this.GaussLabel.Name = "GaussLabel";
            this.GaussLabel.Size = new System.Drawing.Size(46, 17);
            this.GaussLabel.TabIndex = 29;
            this.GaussLabel.Text = "label4";
            // 
            // GetSolutionButton
            // 
            this.GetSolutionButton.Location = new System.Drawing.Point(12, 196);
            this.GetSolutionButton.Name = "GetSolutionButton";
            this.GetSolutionButton.Size = new System.Drawing.Size(120, 30);
            this.GetSolutionButton.TabIndex = 31;
            this.GetSolutionButton.Text = "Get Solution ";
            this.GetSolutionButton.UseVisualStyleBackColor = true;
            this.GetSolutionButton.Click += new System.EventHandler(this.GetSolutionButton_Click);
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(38, 21);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(47, 22);
            this.NTextBox.TabIndex = 32;
            this.NTextBox.Text = "1000";
            // 
            // MarkovCountTextBox
            // 
            this.MarkovCountTextBox.Location = new System.Drawing.Point(262, 19);
            this.MarkovCountTextBox.Name = "MarkovCountTextBox";
            this.MarkovCountTextBox.Size = new System.Drawing.Size(47, 22);
            this.MarkovCountTextBox.TabIndex = 33;
            this.MarkovCountTextBox.Text = "10000";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(10, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(18, 17);
            this.label.TabIndex = 34;
            this.label.Text = "N";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Markov Chains Count";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 287);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label);
            this.Controls.Add(this.MarkovCountTextBox);
            this.Controls.Add(this.NTextBox);
            this.Controls.Add(this.GetSolutionButton);
            this.Controls.Add(this.GaussLabel);
            this.Controls.Add(this.MonteCarloLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.F2TextBox);
            this.Controls.Add(this.F3TextBox);
            this.Controls.Add(this.F1TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.A23TextBox);
            this.Controls.Add(this.A22TextBox);
            this.Controls.Add(this.A21TextBox);
            this.Controls.Add(this.A33TextBox);
            this.Controls.Add(this.A32TextBox);
            this.Controls.Add(this.A31TextBox);
            this.Controls.Add(this.A13TextBox);
            this.Controls.Add(this.A12TextBox);
            this.Controls.Add(this.A11TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Lab5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox A11TextBox;
        private System.Windows.Forms.TextBox A12TextBox;
        private System.Windows.Forms.TextBox A13TextBox;
        private System.Windows.Forms.TextBox A33TextBox;
        private System.Windows.Forms.TextBox A32TextBox;
        private System.Windows.Forms.TextBox A31TextBox;
        private System.Windows.Forms.TextBox A23TextBox;
        private System.Windows.Forms.TextBox A22TextBox;
        private System.Windows.Forms.TextBox A21TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox F2TextBox;
        private System.Windows.Forms.TextBox F3TextBox;
        private System.Windows.Forms.TextBox F1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MonteCarloLabel;
        private System.Windows.Forms.Label GaussLabel;
        private System.Windows.Forms.Button GetSolutionButton;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.TextBox MarkovCountTextBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label7;
    }
}

