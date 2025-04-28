namespace tester_kierowcy
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(133, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test polega na kliknięcie w guzik \"Poprawne\" wtedy, gdy pojawi się nazwa koloru w" +
    " jego kolorze.\r\nW przeciwnym razie należy kliknąć guzik \"Nie poprawne\".\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(133, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "W przypadku niepoprawnej odpowiedzi osoba testowana dostaje 0 punktów.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.label3.Location = new System.Drawing.Point(282, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Test trwa 40 sekund";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.button1.Location = new System.Drawing.Point(78, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(738, 241);
            this.button1.TabIndex = 3;
            this.button1.Text = "ROZPOCZNIJ TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(133, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(635, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Przed testem jest krótsza, nieoceniana wersja szkoleniowa pozwalająca zapoznać si" +
    "ę z programem.\r\n";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Czas reakcji info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}