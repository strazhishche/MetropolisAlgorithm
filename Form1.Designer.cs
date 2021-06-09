
namespace Thermodynamics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CalculationButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Show = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CalculationButton
            // 
            this.CalculationButton.Location = new System.Drawing.Point(360, 10);
            this.CalculationButton.Name = "CalculationButton";
            this.CalculationButton.Size = new System.Drawing.Size(100, 25);
            this.CalculationButton.TabIndex = 0;
            this.CalculationButton.Text = "Расчёт";
            this.CalculationButton.UseVisualStyleBackColor = true;
            this.CalculationButton.Click += new System.EventHandler(this.CalculationButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(784, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            // 
            // Show
            // 
            this.Show.Location = new System.Drawing.Point(225, 10);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(100, 25);
            this.Show.TabIndex = 2;
            this.Show.Text = "Показать";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.CalculationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритм Метрополиса";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CalculationButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Show;
    }
}

