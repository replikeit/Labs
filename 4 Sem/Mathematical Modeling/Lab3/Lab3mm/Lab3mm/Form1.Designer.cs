namespace Lab3mm
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
            this.PanelValues = new System.Windows.Forms.Panel();
            this.LabelEmpDis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelEmpAvg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelExpDis = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelExpAvg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonNormal = new System.Windows.Forms.Button();
            this.ButtonLaplace = new System.Windows.Forms.Button();
            this.ButtonChiSquared = new System.Windows.Forms.Button();
            this.NormalNTextBox = new System.Windows.Forms.TextBox();
            this.NormalMTextBox = new System.Windows.Forms.TextBox();
            this.NormalDivialTextBox = new System.Windows.Forms.TextBox();
            this.LaplaceATextBox = new System.Windows.Forms.TextBox();
            this.ChiSquaredKTextBox = new System.Windows.Forms.TextBox();
            this.ExponentialLambdaTextBox = new System.Windows.Forms.TextBox();
            this.LogNormalMTextBox = new System.Windows.Forms.TextBox();
            this.LogNormalDivialTextBox = new System.Windows.Forms.TextBox();
            this.ButtonExponential = new System.Windows.Forms.Button();
            this.ButtonLogNormal = new System.Windows.Forms.Button();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PanelValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelValues
            // 
            this.PanelValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelValues.Controls.Add(this.LabelEmpDis);
            this.PanelValues.Controls.Add(this.label8);
            this.PanelValues.Controls.Add(this.LabelEmpAvg);
            this.PanelValues.Controls.Add(this.label6);
            this.PanelValues.Controls.Add(this.LabelExpDis);
            this.PanelValues.Controls.Add(this.label4);
            this.PanelValues.Controls.Add(this.LabelExpAvg);
            this.PanelValues.Controls.Add(this.label1);
            this.PanelValues.Location = new System.Drawing.Point(12, 12);
            this.PanelValues.Name = "PanelValues";
            this.PanelValues.Size = new System.Drawing.Size(261, 143);
            this.PanelValues.TabIndex = 29;
            this.PanelValues.Visible = false;
            // 
            // LabelEmpDis
            // 
            this.LabelEmpDis.AutoSize = true;
            this.LabelEmpDis.Location = new System.Drawing.Point(133, 111);
            this.LabelEmpDis.Name = "LabelEmpDis";
            this.LabelEmpDis.Size = new System.Drawing.Size(46, 17);
            this.LabelEmpDis.TabIndex = 34;
            this.LabelEmpDis.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Theoretical Dis  = ";
            // 
            // LabelEmpAvg
            // 
            this.LabelEmpAvg.AutoSize = true;
            this.LabelEmpAvg.Location = new System.Drawing.Point(133, 83);
            this.LabelEmpAvg.Name = "LabelEmpAvg";
            this.LabelEmpAvg.Size = new System.Drawing.Size(46, 17);
            this.LabelEmpAvg.TabIndex = 32;
            this.LabelEmpAvg.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Theoretical Avg = ";
            // 
            // LabelExpDis
            // 
            this.LabelExpDis.AutoSize = true;
            this.LabelExpDis.Location = new System.Drawing.Point(133, 37);
            this.LabelExpDis.Name = "LabelExpDis";
            this.LabelExpDis.Size = new System.Drawing.Size(46, 17);
            this.LabelExpDis.TabIndex = 30;
            this.LabelExpDis.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Experimental Dis  = ";
            // 
            // LabelExpAvg
            // 
            this.LabelExpAvg.AutoSize = true;
            this.LabelExpAvg.Location = new System.Drawing.Point(133, 10);
            this.LabelExpAvg.Name = "LabelExpAvg";
            this.LabelExpAvg.Size = new System.Drawing.Size(46, 17);
            this.LabelExpAvg.TabIndex = 28;
            this.LabelExpAvg.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Experimental Avg = ";
            // 
            // ButtonNormal
            // 
            this.ButtonNormal.Location = new System.Drawing.Point(12, 237);
            this.ButtonNormal.Name = "ButtonNormal";
            this.ButtonNormal.Size = new System.Drawing.Size(261, 36);
            this.ButtonNormal.TabIndex = 31;
            this.ButtonNormal.Text = "Normal Distribution";
            this.ButtonNormal.UseVisualStyleBackColor = true;
            this.ButtonNormal.Click += new System.EventHandler(this.ButtonNormal_Click);
            // 
            // ButtonLaplace
            // 
            this.ButtonLaplace.Location = new System.Drawing.Point(12, 323);
            this.ButtonLaplace.Name = "ButtonLaplace";
            this.ButtonLaplace.Size = new System.Drawing.Size(125, 39);
            this.ButtonLaplace.TabIndex = 30;
            this.ButtonLaplace.Text = "Laplace Distribution";
            this.ButtonLaplace.UseVisualStyleBackColor = true;
            this.ButtonLaplace.Click += new System.EventHandler(this.ButtonLaplace_Click);
            // 
            // ButtonChiSquared
            // 
            this.ButtonChiSquared.Location = new System.Drawing.Point(143, 326);
            this.ButtonChiSquared.Name = "ButtonChiSquared";
            this.ButtonChiSquared.Size = new System.Drawing.Size(125, 36);
            this.ButtonChiSquared.TabIndex = 33;
            this.ButtonChiSquared.Text = "Chi-squared Distribution";
            this.ButtonChiSquared.UseVisualStyleBackColor = true;
            this.ButtonChiSquared.Click += new System.EventHandler(this.ButtonChiSquared_Click);
            // 
            // NormalNTextBox
            // 
            this.NormalNTextBox.Location = new System.Drawing.Point(190, 209);
            this.NormalNTextBox.Name = "NormalNTextBox";
            this.NormalNTextBox.Size = new System.Drawing.Size(83, 22);
            this.NormalNTextBox.TabIndex = 34;
            this.NormalNTextBox.Text = "48";
            // 
            // NormalMTextBox
            // 
            this.NormalMTextBox.Location = new System.Drawing.Point(12, 209);
            this.NormalMTextBox.Name = "NormalMTextBox";
            this.NormalMTextBox.Size = new System.Drawing.Size(83, 22);
            this.NormalMTextBox.TabIndex = 35;
            this.NormalMTextBox.Text = "0";
            // 
            // NormalDivialTextBox
            // 
            this.NormalDivialTextBox.Location = new System.Drawing.Point(101, 209);
            this.NormalDivialTextBox.Name = "NormalDivialTextBox";
            this.NormalDivialTextBox.Size = new System.Drawing.Size(83, 22);
            this.NormalDivialTextBox.TabIndex = 36;
            this.NormalDivialTextBox.Text = "64";
            // 
            // LaplaceATextBox
            // 
            this.LaplaceATextBox.Location = new System.Drawing.Point(12, 295);
            this.LaplaceATextBox.Name = "LaplaceATextBox";
            this.LaplaceATextBox.Size = new System.Drawing.Size(124, 22);
            this.LaplaceATextBox.TabIndex = 38;
            this.LaplaceATextBox.Text = "2";
            // 
            // ChiSquaredKTextBox
            // 
            this.ChiSquaredKTextBox.Location = new System.Drawing.Point(144, 295);
            this.ChiSquaredKTextBox.Name = "ChiSquaredKTextBox";
            this.ChiSquaredKTextBox.Size = new System.Drawing.Size(124, 22);
            this.ChiSquaredKTextBox.TabIndex = 40;
            this.ChiSquaredKTextBox.Text = "4";
            // 
            // ExponentialLambdaTextBox
            // 
            this.ExponentialLambdaTextBox.Location = new System.Drawing.Point(148, 389);
            this.ExponentialLambdaTextBox.Name = "ExponentialLambdaTextBox";
            this.ExponentialLambdaTextBox.Size = new System.Drawing.Size(124, 22);
            this.ExponentialLambdaTextBox.TabIndex = 46;
            this.ExponentialLambdaTextBox.Text = "2";
            // 
            // LogNormalMTextBox
            // 
            this.LogNormalMTextBox.Location = new System.Drawing.Point(16, 389);
            this.LogNormalMTextBox.Name = "LogNormalMTextBox";
            this.LogNormalMTextBox.Size = new System.Drawing.Size(59, 22);
            this.LogNormalMTextBox.TabIndex = 44;
            this.LogNormalMTextBox.Text = "1";
            // 
            // LogNormalDivialTextBox
            // 
            this.LogNormalDivialTextBox.Location = new System.Drawing.Point(81, 389);
            this.LogNormalDivialTextBox.Name = "LogNormalDivialTextBox";
            this.LogNormalDivialTextBox.Size = new System.Drawing.Size(59, 22);
            this.LogNormalDivialTextBox.TabIndex = 43;
            this.LogNormalDivialTextBox.Text = "9";
            // 
            // ButtonExponential
            // 
            this.ButtonExponential.Location = new System.Drawing.Point(147, 420);
            this.ButtonExponential.Name = "ButtonExponential";
            this.ButtonExponential.Size = new System.Drawing.Size(125, 36);
            this.ButtonExponential.TabIndex = 42;
            this.ButtonExponential.Text = "Exponential Distribution";
            this.ButtonExponential.UseVisualStyleBackColor = true;
            this.ButtonExponential.Click += new System.EventHandler(this.ButtonExponential_Click);
            // 
            // ButtonLogNormal
            // 
            this.ButtonLogNormal.Location = new System.Drawing.Point(16, 417);
            this.ButtonLogNormal.Name = "ButtonLogNormal";
            this.ButtonLogNormal.Size = new System.Drawing.Size(125, 39);
            this.ButtonLogNormal.TabIndex = 41;
            this.ButtonLogNormal.Text = "Log-normal Distribution";
            this.ButtonLogNormal.UseVisualStyleBackColor = true;
            this.ButtonLogNormal.Click += new System.EventHandler(this.ButtonLogNormal_Click);
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(48, 161);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(225, 22);
            this.SizeTextBox.TabIndex = 47;
            this.SizeTextBox.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = " σ^2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "m";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 17);
            this.label7.TabIndex = 51;
            this.label7.Text = "N";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "m";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 52;
            this.label10.Text = " σ^2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "λ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(141, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 17);
            this.label12.TabIndex = 55;
            this.label12.Text = "K";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 275);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 56;
            this.label13.Text = "a";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 472);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.ExponentialLambdaTextBox);
            this.Controls.Add(this.LogNormalMTextBox);
            this.Controls.Add(this.LogNormalDivialTextBox);
            this.Controls.Add(this.ButtonExponential);
            this.Controls.Add(this.ButtonLogNormal);
            this.Controls.Add(this.ChiSquaredKTextBox);
            this.Controls.Add(this.LaplaceATextBox);
            this.Controls.Add(this.NormalDivialTextBox);
            this.Controls.Add(this.NormalMTextBox);
            this.Controls.Add(this.NormalNTextBox);
            this.Controls.Add(this.ButtonChiSquared);
            this.Controls.Add(this.ButtonNormal);
            this.Controls.Add(this.ButtonLaplace);
            this.Controls.Add(this.PanelValues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Lab3";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.PanelValues.ResumeLayout(false);
            this.PanelValues.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelValues;
        private System.Windows.Forms.Label LabelEmpDis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabelEmpAvg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelExpDis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelExpAvg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonNormal;
        private System.Windows.Forms.Button ButtonLaplace;
        private System.Windows.Forms.Button ButtonChiSquared;
        private System.Windows.Forms.TextBox NormalNTextBox;
        private System.Windows.Forms.TextBox NormalMTextBox;
        private System.Windows.Forms.TextBox NormalDivialTextBox;
        private System.Windows.Forms.TextBox LaplaceATextBox;
        private System.Windows.Forms.TextBox ChiSquaredKTextBox;
        private System.Windows.Forms.TextBox ExponentialLambdaTextBox;
        private System.Windows.Forms.TextBox LogNormalMTextBox;
        private System.Windows.Forms.TextBox LogNormalDivialTextBox;
        private System.Windows.Forms.Button ButtonExponential;
        private System.Windows.Forms.Button ButtonLogNormal;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

