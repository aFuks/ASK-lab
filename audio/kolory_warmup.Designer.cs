namespace tester_kierowcy
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.Time = new System.Windows.Forms.Label();
            this.points = new System.Windows.Forms.Label();
            this.poprawne = new System.Windows.Forms.Button();
            this.niepoprawne = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.changecolor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Time.Location = new System.Drawing.Point(60, 41);
            this.Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(114, 30);
            this.Time.TabIndex = 0;
            this.Time.Text = "Czas: 10";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.points.Location = new System.Drawing.Point(900, 41);
            this.points.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(119, 30);
            this.points.TabIndex = 1;
            this.points.Text = "Punkty: 0";
            // 
            // poprawne
            // 
            this.poprawne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.poprawne.Location = new System.Drawing.Point(212, 543);
            this.poprawne.Margin = new System.Windows.Forms.Padding(4);
            this.poprawne.Name = "poprawne";
            this.poprawne.Size = new System.Drawing.Size(348, 75);
            this.poprawne.TabIndex = 2;
            this.poprawne.Text = "Poprawne";
            this.poprawne.UseVisualStyleBackColor = true;
            this.poprawne.Click += new System.EventHandler(this.poprawne_Click);
            // 
            // niepoprawne
            // 
            this.niepoprawne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.niepoprawne.Location = new System.Drawing.Point(629, 543);
            this.niepoprawne.Margin = new System.Windows.Forms.Padding(4);
            this.niepoprawne.Name = "niepoprawne";
            this.niepoprawne.Size = new System.Drawing.Size(348, 75);
            this.niepoprawne.TabIndex = 3;
            this.niepoprawne.Text = "Nie poprawne";
            this.niepoprawne.UseVisualStyleBackColor = true;
            this.niepoprawne.Click += new System.EventHandler(this.niepoprawne_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // changecolor
            // 
            this.changecolor.AutoSize = true;
            this.changecolor.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F);
            this.changecolor.Location = new System.Drawing.Point(389, 233);
            this.changecolor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.changecolor.Name = "changecolor";
            this.changecolor.Size = new System.Drawing.Size(393, 153);
            this.changecolor.TabIndex = 4;
            this.changecolor.Text = "Black";
            this.changecolor.Click += new System.EventHandler(this.changecolor_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 690);
            this.Controls.Add(this.changecolor);
            this.Controls.Add(this.niepoprawne);
            this.Controls.Add(this.poprawne);
            this.Controls.Add(this.points);
            this.Controls.Add(this.Time);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Czas reakcji szkolenie";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.Button poprawne;
        private System.Windows.Forms.Button niepoprawne;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label changecolor;
    }
}