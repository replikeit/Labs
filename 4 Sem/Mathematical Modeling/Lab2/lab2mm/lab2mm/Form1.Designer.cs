namespace lab2mm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GistagramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.FunctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BinomialButton = new System.Windows.Forms.Button();
            this.BernoulliButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelPearson = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelEmpExc = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LabelEmpAsym = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.LabelExpExc = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LabelExpAsym = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LabelEmpDis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LabelEmpAvg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelExpDis = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelExpAvg = new System.Windows.Forms.Label();
            this.TextBoxP = new System.Windows.Forms.TextBox();
            this.TextBoxM = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TextBoxN = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.GistagramChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // GistagramChart
            // 
            chartArea1.Name = "ChartArea1";
            this.GistagramChart.ChartAreas.Add(chartArea1);
            this.GistagramChart.Location = new System.Drawing.Point(14, 196);
            this.GistagramChart.Margin = new System.Windows.Forms.Padding(4);
            this.GistagramChart.Name = "GistagramChart";
            this.GistagramChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series2";
            this.GistagramChart.Series.Add(series1);
            this.GistagramChart.Series.Add(series2);
            this.GistagramChart.Size = new System.Drawing.Size(326, 291);
            this.GistagramChart.TabIndex = 23;
            this.GistagramChart.Visible = false;
            // 
            // FunctionChart
            // 
            chartArea2.Name = "ChartArea1";
            this.FunctionChart.ChartAreas.Add(chartArea2);
            this.FunctionChart.Location = new System.Drawing.Point(358, 196);
            this.FunctionChart.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionChart.Name = "FunctionChart";
            this.FunctionChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.FunctionChart.Series.Add(series3);
            this.FunctionChart.Size = new System.Drawing.Size(320, 291);
            this.FunctionChart.TabIndex = 24;
            this.FunctionChart.Visible = false;
            // 
            // BinomialButton
            // 
            this.BinomialButton.Location = new System.Drawing.Point(542, 140);
            this.BinomialButton.Name = "BinomialButton";
            this.BinomialButton.Size = new System.Drawing.Size(135, 39);
            this.BinomialButton.TabIndex = 25;
            this.BinomialButton.Text = "Binomial";
            this.BinomialButton.UseVisualStyleBackColor = true;
            this.BinomialButton.Click += new System.EventHandler(this.BinomialButton_Click);
            // 
            // BernoulliButton
            // 
            this.BernoulliButton.Location = new System.Drawing.Point(543, 98);
            this.BernoulliButton.Name = "BernoulliButton";
            this.BernoulliButton.Size = new System.Drawing.Size(135, 36);
            this.BernoulliButton.TabIndex = 26;
            this.BernoulliButton.Text = "Bernuolli";
            this.BernoulliButton.UseVisualStyleBackColor = true;
            this.BernoulliButton.Click += new System.EventHandler(this.BernoulliButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Experimental Avg = ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LabelPearson);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LabelEmpExc);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.LabelEmpAsym);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.LabelExpExc);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.LabelExpAsym);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.LabelEmpDis);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LabelEmpAvg);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LabelExpDis);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LabelExpAvg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 177);
            this.panel1.TabIndex = 28;
            this.panel1.Visible = false;
            // 
            // LabelPearson
            // 
            this.LabelPearson.AutoSize = true;
            this.LabelPearson.Location = new System.Drawing.Point(206, 73);
            this.LabelPearson.Name = "LabelPearson";
            this.LabelPearson.Size = new System.Drawing.Size(46, 17);
            this.LabelPearson.TabIndex = 44;
            this.LabelPearson.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Pearson\'s chi-squared test = ";
            // 
            // LabelEmpExc
            // 
            this.LabelEmpExc.AutoSize = true;
            this.LabelEmpExc.Location = new System.Drawing.Point(386, 137);
            this.LabelEmpExc.Name = "LabelEmpExc";
            this.LabelEmpExc.Size = new System.Drawing.Size(54, 17);
            this.LabelEmpExc.TabIndex = 42;
            this.LabelEmpExc.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(256, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 17);
            this.label14.TabIndex = 41;
            this.label14.Text = "Empirical Excess = ";
            // 
            // LabelEmpAsym
            // 
            this.LabelEmpAsym.AutoSize = true;
            this.LabelEmpAsym.Location = new System.Drawing.Point(371, 109);
            this.LabelEmpAsym.Name = "LabelEmpAsym";
            this.LabelEmpAsym.Size = new System.Drawing.Size(54, 17);
            this.LabelEmpAsym.TabIndex = 40;
            this.LabelEmpAsym.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(256, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 17);
            this.label16.TabIndex = 39;
            this.label16.Text = "Empirical Asym = ";
            // 
            // LabelExpExc
            // 
            this.LabelExpExc.AutoSize = true;
            this.LabelExpExc.Location = new System.Drawing.Point(404, 37);
            this.LabelExpExc.Name = "LabelExpExc";
            this.LabelExpExc.Size = new System.Drawing.Size(54, 17);
            this.LabelExpExc.TabIndex = 38;
            this.LabelExpExc.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Experimental Excess = ";
            // 
            // LabelExpAsym
            // 
            this.LabelExpAsym.AutoSize = true;
            this.LabelExpAsym.Location = new System.Drawing.Point(394, 10);
            this.LabelExpAsym.Name = "LabelExpAsym";
            this.LabelExpAsym.Size = new System.Drawing.Size(46, 17);
            this.LabelExpAsym.TabIndex = 36;
            this.LabelExpAsym.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "Experimental Asym = ";
            // 
            // LabelEmpDis
            // 
            this.LabelEmpDis.AutoSize = true;
            this.LabelEmpDis.Location = new System.Drawing.Point(121, 137);
            this.LabelEmpDis.Name = "LabelEmpDis";
            this.LabelEmpDis.Size = new System.Drawing.Size(46, 17);
            this.LabelEmpDis.TabIndex = 34;
            this.LabelEmpDis.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Empirical Dis  = ";
            // 
            // LabelEmpAvg
            // 
            this.LabelEmpAvg.AutoSize = true;
            this.LabelEmpAvg.Location = new System.Drawing.Point(121, 109);
            this.LabelEmpAvg.Name = "LabelEmpAvg";
            this.LabelEmpAvg.Size = new System.Drawing.Size(46, 17);
            this.LabelEmpAvg.TabIndex = 32;
            this.LabelEmpAvg.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Empirical Avg = ";
            // 
            // LabelExpDis
            // 
            this.LabelExpDis.AutoSize = true;
            this.LabelExpDis.Location = new System.Drawing.Point(145, 37);
            this.LabelExpDis.Name = "LabelExpDis";
            this.LabelExpDis.Size = new System.Drawing.Size(46, 17);
            this.LabelExpDis.TabIndex = 30;
            this.LabelExpDis.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Experimental Dis  = ";
            // 
            // LabelExpAvg
            // 
            this.LabelExpAvg.AutoSize = true;
            this.LabelExpAvg.Location = new System.Drawing.Point(145, 10);
            this.LabelExpAvg.Name = "LabelExpAvg";
            this.LabelExpAvg.Size = new System.Drawing.Size(46, 17);
            this.LabelExpAvg.TabIndex = 28;
            this.LabelExpAvg.Text = "label2";
            // 
            // TextBoxP
            // 
            this.TextBoxP.Location = new System.Drawing.Point(578, 12);
            this.TextBoxP.Name = "TextBoxP";
            this.TextBoxP.Size = new System.Drawing.Size(100, 22);
            this.TextBoxP.TabIndex = 29;
            this.TextBoxP.Text = "0,2013";
            // 
            // TextBoxM
            // 
            this.TextBoxM.Location = new System.Drawing.Point(578, 40);
            this.TextBoxM.Name = "TextBoxM";
            this.TextBoxM.Size = new System.Drawing.Size(100, 22);
            this.TextBoxM.TabIndex = 30;
            this.TextBoxM.Text = "8";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(555, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 17);
            this.label17.TabIndex = 43;
            this.label17.Text = "P";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(555, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 17);
            this.label18.TabIndex = 44;
            this.label18.Text = "M";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(556, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 17);
            this.label19.TabIndex = 46;
            this.label19.Text = "N";
            // 
            // TextBoxN
            // 
            this.TextBoxN.Location = new System.Drawing.Point(577, 68);
            this.TextBoxN.Name = "TextBoxN";
            this.TextBoxN.Size = new System.Drawing.Size(100, 22);
            this.TextBoxN.TabIndex = 45;
            this.TextBoxN.Text = "1000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 500);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TextBoxN);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TextBoxM);
            this.Controls.Add(this.TextBoxP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BernoulliButton);
            this.Controls.Add(this.BinomialButton);
            this.Controls.Add(this.FunctionChart);
            this.Controls.Add(this.GistagramChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GistagramChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GistagramChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart FunctionChart;
        private System.Windows.Forms.Button BinomialButton;
        private System.Windows.Forms.Button BernoulliButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelExpAsym;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LabelEmpDis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabelEmpAvg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelExpDis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelExpAvg;
        private System.Windows.Forms.Label LabelExpExc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LabelEmpExc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LabelEmpAsym;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBoxP;
        private System.Windows.Forms.TextBox TextBoxM;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TextBoxN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelPearson;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

