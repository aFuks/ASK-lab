namespace ascii_rs232
{
    partial class transceiver
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.enter_label = new System.Windows.Forms.Label();
            this.receiver_label = new System.Windows.Forms.Label();
            this.enter_button = new System.Windows.Forms.Button();
            this.textBox_enter = new System.Windows.Forms.TextBox();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enter_label
            // 
            this.enter_label.AutoSize = true;
            this.enter_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.enter_label.Location = new System.Drawing.Point(93, 74);
            this.enter_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enter_label.Name = "enter_label";
            this.enter_label.Size = new System.Drawing.Size(128, 30);
            this.enter_label.TabIndex = 0;
            this.enter_label.Text = "Enter text:";
            // 
            // receiver_label
            // 
            this.receiver_label.AutoSize = true;
            this.receiver_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.receiver_label.Location = new System.Drawing.Point(93, 480);
            this.receiver_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.receiver_label.Name = "receiver_label";
            this.receiver_label.Size = new System.Drawing.Size(174, 30);
            this.receiver_label.TabIndex = 1;
            this.receiver_label.Text = "Received text:";
            // 
            // enter_button
            // 
            this.enter_button.Location = new System.Drawing.Point(389, 240);
            this.enter_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(233, 60);
            this.enter_button.TabIndex = 2;
            this.enter_button.Text = "Send message";
            this.enter_button.UseVisualStyleBackColor = true;
            this.enter_button.Click += new System.EventHandler(this.enter_button_Click);
            // 
            // textBox_enter
            // 
            this.textBox_enter.Location = new System.Drawing.Point(100, 108);
            this.textBox_enter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_enter.Multiline = true;
            this.textBox_enter.Name = "textBox_enter";
            this.textBox_enter.Size = new System.Drawing.Size(820, 123);
            this.textBox_enter.TabIndex = 3;
            // 
            // textBox_receive
            // 
            this.textBox_receive.Location = new System.Drawing.Point(100, 514);
            this.textBox_receive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.Size = new System.Drawing.Size(820, 123);
            this.textBox_receive.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 339);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(820, 83);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(95, 305);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Coded string:";
            // 
            // transceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 724);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_receive);
            this.Controls.Add(this.textBox_enter);
            this.Controls.Add(this.enter_button);
            this.Controls.Add(this.receiver_label);
            this.Controls.Add(this.enter_label);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "transceiver";
            this.Text = "Transceiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enter_label;
        private System.Windows.Forms.Label receiver_label;
        private System.Windows.Forms.Button enter_button;
        private System.Windows.Forms.TextBox textBox_enter;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

