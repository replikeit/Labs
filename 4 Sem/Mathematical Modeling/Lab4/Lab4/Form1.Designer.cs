namespace Lab4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FunctionChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exactFunc1Label = new System.Windows.Forms.Label();
            this.experimFunc1Label = new System.Windows.Forms.Label();
            this.task1Button = new System.Windows.Forms.Button();
            this.task2Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionChart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FunctionChart1);
            this.panel1.Location = new System.Drawing.Point(12, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 337);
            this.panel1.TabIndex = 0;
            // 
            // FunctionChart1
            // 
            chartArea1.Name = "ChartArea1";
            this.FunctionChart1.ChartAreas.Add(chartArea1);
            this.FunctionChart1.Location = new System.Drawing.Point(4, 13);
            this.FunctionChart1.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionChart1.Name = "FunctionChart1";
            this.FunctionChart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.FunctionChart1.Series.Add(series1);
            this.FunctionChart1.Size = new System.Drawing.Size(673, 320);
            this.FunctionChart1.TabIndex = 26;
            this.FunctionChart1.Text = "с";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exact Value = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Experimental value = ";
            // 
            // exactFunc1Label
            // 
            this.exactFunc1Label.AutoSize = true;
            this.exactFunc1Label.Location = new System.Drawing.Point(109, 9);
            this.exactFunc1Label.Name = "exactFunc1Label";
            this.exactFunc1Label.Size = new System.Drawing.Size(46, 17);
            this.exactFunc1Label.TabIndex = 3;
            this.exactFunc1Label.Text = "label3";
            // 
            // experimFunc1Label
            // 
            this.experimFunc1Label.AutoSize = true;
            this.experimFunc1Label.Location = new System.Drawing.Point(151, 43);
            this.experimFunc1Label.Name = "experimFunc1Label";
            this.experimFunc1Label.Size = new System.Drawing.Size(46, 17);
            this.experimFunc1Label.TabIndex = 4;
            this.experimFunc1Label.Text = "label4";
            // 
            // task1Button
            // 
            this.task1Button.Location = new System.Drawing.Point(614, 6);
            this.task1Button.Name = "task1Button";
            this.task1Button.Size = new System.Drawing.Size(75, 23);
            this.task1Button.TabIndex = 5;
            this.task1Button.Text = "Task 1";
            this.task1Button.UseVisualStyleBackColor = true;
            this.task1Button.Click += new System.EventHandler(this.task1Button_Click);
            // 
            // task2Button
            // 
            this.task2Button.Location = new System.Drawing.Point(614, 35);
            this.task2Button.Name = "task2Button";
            this.task2Button.Size = new System.Drawing.Size(75, 23);
            this.task2Button.TabIndex = 6;
            this.task2Button.Text = "Task 2";
            this.task2Button.UseVisualStyleBackColor = true;
            this.task2Button.Click += new System.EventHandler(this.task2Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 412);
            this.Controls.Add(this.task2Button);
            this.Controls.Add(this.task1Button);
            this.Controls.Add(this.experimFunc1Label);
            this.Controls.Add(this.exactFunc1Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FunctionChart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label exactFunc1Label;
        private System.Windows.Forms.Label experimFunc1Label;
        private System.Windows.Forms.DataVisualization.Charting.Chart FunctionChart1;
        private System.Windows.Forms.Button task1Button;
        private System.Windows.Forms.Button task2Button;
    }
}

