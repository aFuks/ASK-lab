using System.Windows.Forms;

namespace kalkulator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button0 = new System.Windows.Forms.Button();
            this.buttondot = new System.Windows.Forms.Button();
            this.buttonrownosc = new System.Windows.Forms.Button();
            this.buttonplus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonminus = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonbackspace = new System.Windows.Forms.Button();
            this.buttonwyczysc = new System.Windows.Forms.Button();
            this.buttondzielenie = new System.Windows.Forms.Button();
            this.buttonpierwiastek = new System.Windows.Forms.Button();
            this.buttonpotega = new System.Windows.Forms.Button();
            this.buttonodwrotnosc = new System.Windows.Forms.Button();
            this.buttonmnozenie = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.wyswietlacz = new System.Windows.Forms.Label();
            this.buttonzmianastylu = new System.Windows.Forms.Button();
            this.czascyfrowy = new System.Windows.Forms.Label();
            this.czasanalogowy = new System.Windows.Forms.PictureBox();
            this.buttonzmianazegara = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.czasanalogowy)).BeginInit();
            this.SuspendLayout();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            // 
            // button0
            // 
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button0.Location = new System.Drawing.Point(96, 565);
            this.button0.Margin = new System.Windows.Forms.Padding(1);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(87, 62);
            this.button0.TabIndex = 1;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            // 
            // buttondot
            // 
            this.buttondot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttondot.Location = new System.Drawing.Point(185, 565);
            this.buttondot.Margin = new System.Windows.Forms.Padding(1);
            this.buttondot.Name = "buttondot";
            this.buttondot.Size = new System.Drawing.Size(87, 62);
            this.buttondot.TabIndex = 2;
            this.buttondot.Text = ".";
            this.buttondot.UseVisualStyleBackColor = true;
            // 
            // buttonrownosc
            // 
            this.buttonrownosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonrownosc.Location = new System.Drawing.Point(274, 565);
            this.buttonrownosc.Margin = new System.Windows.Forms.Padding(1);
            this.buttonrownosc.Name = "buttonrownosc";
            this.buttonrownosc.Size = new System.Drawing.Size(87, 62);
            this.buttonrownosc.TabIndex = 3;
            this.buttonrownosc.Text = "=";
            this.buttonrownosc.UseVisualStyleBackColor = true;
            // 
            // buttonplus
            // 
            this.buttonplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonplus.Location = new System.Drawing.Point(274, 501);
            this.buttonplus.Margin = new System.Windows.Forms.Padding(1);
            this.buttonplus.Name = "buttonplus";
            this.buttonplus.Size = new System.Drawing.Size(87, 62);
            this.buttonplus.TabIndex = 7;
            this.buttonplus.Text = "+";
            this.buttonplus.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button3.Location = new System.Drawing.Point(185, 501);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 62);
            this.button3.TabIndex = 6;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button2.Location = new System.Drawing.Point(96, 501);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 62);
            this.button2.TabIndex = 5;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button1.Location = new System.Drawing.Point(7, 501);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonminus
            // 
            this.buttonminus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonminus.Location = new System.Drawing.Point(274, 437);
            this.buttonminus.Margin = new System.Windows.Forms.Padding(1);
            this.buttonminus.Name = "buttonminus";
            this.buttonminus.Size = new System.Drawing.Size(87, 62);
            this.buttonminus.TabIndex = 11;
            this.buttonminus.Text = "-";
            this.buttonminus.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button6.Location = new System.Drawing.Point(185, 437);
            this.button6.Margin = new System.Windows.Forms.Padding(1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 62);
            this.button6.TabIndex = 10;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button5.Location = new System.Drawing.Point(96, 437);
            this.button5.Margin = new System.Windows.Forms.Padding(1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 62);
            this.button5.TabIndex = 9;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button4.Location = new System.Drawing.Point(7, 437);
            this.button4.Margin = new System.Windows.Forms.Padding(1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 62);
            this.button4.TabIndex = 8;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonbackspace
            // 
            this.buttonbackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonbackspace.Location = new System.Drawing.Point(273, 245);
            this.buttonbackspace.Margin = new System.Windows.Forms.Padding(1);
            this.buttonbackspace.Name = "buttonbackspace";
            this.buttonbackspace.Size = new System.Drawing.Size(87, 62);
            this.buttonbackspace.TabIndex = 23;
            this.buttonbackspace.Text = "⌫";
            this.buttonbackspace.UseVisualStyleBackColor = true;
            // 
            // buttonwyczysc
            // 
            this.buttonwyczysc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonwyczysc.Location = new System.Drawing.Point(184, 245);
            this.buttonwyczysc.Margin = new System.Windows.Forms.Padding(1);
            this.buttonwyczysc.Name = "buttonwyczysc";
            this.buttonwyczysc.Size = new System.Drawing.Size(87, 62);
            this.buttonwyczysc.TabIndex = 22;
            this.buttonwyczysc.Text = "C";
            this.buttonwyczysc.UseVisualStyleBackColor = true;
            // 
            // buttondzielenie
            // 
            this.buttondzielenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttondzielenie.Location = new System.Drawing.Point(273, 309);
            this.buttondzielenie.Margin = new System.Windows.Forms.Padding(1);
            this.buttondzielenie.Name = "buttondzielenie";
            this.buttondzielenie.Size = new System.Drawing.Size(87, 62);
            this.buttondzielenie.TabIndex = 19;
            this.buttondzielenie.Text = "/";
            this.buttondzielenie.UseVisualStyleBackColor = true;
            // 
            // buttonpierwiastek
            // 
            this.buttonpierwiastek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonpierwiastek.Location = new System.Drawing.Point(184, 309);
            this.buttonpierwiastek.Margin = new System.Windows.Forms.Padding(1);
            this.buttonpierwiastek.Name = "buttonpierwiastek";
            this.buttonpierwiastek.Size = new System.Drawing.Size(87, 62);
            this.buttonpierwiastek.TabIndex = 18;
            this.buttonpierwiastek.Text = "√x";
            this.buttonpierwiastek.UseVisualStyleBackColor = true;
            // 
            // buttonpotega
            // 
            this.buttonpotega.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonpotega.Location = new System.Drawing.Point(95, 309);
            this.buttonpotega.Margin = new System.Windows.Forms.Padding(1);
            this.buttonpotega.Name = "buttonpotega";
            this.buttonpotega.Size = new System.Drawing.Size(87, 62);
            this.buttonpotega.TabIndex = 17;
            this.buttonpotega.Text = "x²";
            this.buttonpotega.UseVisualStyleBackColor = true;
            // 
            // buttonodwrotnosc
            // 
            this.buttonodwrotnosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonodwrotnosc.Location = new System.Drawing.Point(6, 309);
            this.buttonodwrotnosc.Margin = new System.Windows.Forms.Padding(1);
            this.buttonodwrotnosc.Name = "buttonodwrotnosc";
            this.buttonodwrotnosc.Size = new System.Drawing.Size(87, 62);
            this.buttonodwrotnosc.TabIndex = 16;
            this.buttonodwrotnosc.Text = "1/x";
            this.buttonodwrotnosc.UseVisualStyleBackColor = true;
            // 
            // buttonmnozenie
            // 
            this.buttonmnozenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonmnozenie.Location = new System.Drawing.Point(273, 373);
            this.buttonmnozenie.Margin = new System.Windows.Forms.Padding(1);
            this.buttonmnozenie.Name = "buttonmnozenie";
            this.buttonmnozenie.Size = new System.Drawing.Size(87, 62);
            this.buttonmnozenie.TabIndex = 15;
            this.buttonmnozenie.Text = "*";
            this.buttonmnozenie.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button9.Location = new System.Drawing.Point(184, 373);
            this.button9.Margin = new System.Windows.Forms.Padding(1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 62);
            this.button9.TabIndex = 14;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button8.Location = new System.Drawing.Point(95, 373);
            this.button8.Margin = new System.Windows.Forms.Padding(1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 62);
            this.button8.TabIndex = 13;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.button7.Location = new System.Drawing.Point(6, 373);
            this.button7.Margin = new System.Windows.Forms.Padding(1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 62);
            this.button7.TabIndex = 12;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // wyswietlacz
            // 
            this.wyswietlacz.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.wyswietlacz.Location = new System.Drawing.Point(12, 160);
            this.wyswietlacz.Name = "wyswietlacz";
            this.wyswietlacz.Size = new System.Drawing.Size(344, 44);
            this.wyswietlacz.TabIndex = 24;
            this.wyswietlacz.Text = "0";
            // 
            // buttonzmianastylu
            // 
            this.buttonzmianastylu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonzmianastylu.Location = new System.Drawing.Point(12, 12);
            this.buttonzmianastylu.Name = "buttonzmianastylu";
            this.buttonzmianastylu.Size = new System.Drawing.Size(119, 29);
            this.buttonzmianastylu.TabIndex = 26;
            this.buttonzmianastylu.Text = "Zmień styl";
            this.buttonzmianastylu.UseVisualStyleBackColor = true;
            this.buttonzmianastylu.Click += new System.EventHandler(this.buttonzmianastylu_Click);
            // 
            // czascyfrowy
            // 
            this.czascyfrowy.AutoSize = true;
            this.czascyfrowy.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.czascyfrowy.Location = new System.Drawing.Point(257, 23);
            this.czascyfrowy.Name = "czascyfrowy";
            this.czascyfrowy.Size = new System.Drawing.Size(0, 29);
            this.czascyfrowy.TabIndex = 25;
            // 
            // czasanalogowy
            // 
            this.czasanalogowy.BackColor = System.Drawing.Color.Transparent;
            this.czasanalogowy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.czasanalogowy.Location = new System.Drawing.Point(273, 12);
            this.czasanalogowy.Name = "czasanalogowy";
            this.czasanalogowy.Size = new System.Drawing.Size(68, 72);
            this.czasanalogowy.TabIndex = 27;
            this.czasanalogowy.TabStop = false;
            this.czasanalogowy.Resize += new System.EventHandler(this.czasanalogowy_Resize);
            // 
            // buttonzmianazegara
            // 
            this.buttonzmianazegara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonzmianazegara.Location = new System.Drawing.Point(184, 12);
            this.buttonzmianazegara.Name = "buttonzmianazegara";
            this.buttonzmianazegara.Size = new System.Drawing.Size(72, 50);
            this.buttonzmianazegara.TabIndex = 28;
            this.buttonzmianazegara.Text = "Zmień zegar";
            this.buttonzmianazegara.UseVisualStyleBackColor = true;
            this.buttonzmianazegara.Click += new System.EventHandler(this.buttonzmianazegara_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(368, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 654);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonzmianazegara);
            this.Controls.Add(this.czasanalogowy);
            this.Controls.Add(this.buttonzmianastylu);
            this.Controls.Add(this.czascyfrowy);
            this.Controls.Add(this.wyswietlacz);
            this.Controls.Add(this.buttonbackspace);
            this.Controls.Add(this.buttonwyczysc);
            this.Controls.Add(this.buttondzielenie);
            this.Controls.Add(this.buttonpierwiastek);
            this.Controls.Add(this.buttonpotega);
            this.Controls.Add(this.buttonodwrotnosc);
            this.Controls.Add(this.buttonmnozenie);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonminus);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonplus);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonrownosc);
            this.Controls.Add(this.buttondot);
            this.Controls.Add(this.button0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.czasanalogowy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttondot;
        private System.Windows.Forms.Button buttonrownosc;
        private System.Windows.Forms.Button buttonplus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonminus;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonbackspace;
        private System.Windows.Forms.Button buttonwyczysc;
        private System.Windows.Forms.Button buttondzielenie;
        private System.Windows.Forms.Button buttonpierwiastek;
        private System.Windows.Forms.Button buttonpotega;
        private System.Windows.Forms.Button buttonodwrotnosc;
        private System.Windows.Forms.Button buttonmnozenie;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label wyswietlacz;
        private System.Windows.Forms.Button buttonzmianastylu;
        private System.Windows.Forms.Label czascyfrowy;
        private System.Windows.Forms.PictureBox czasanalogowy;
        private System.Windows.Forms.Button buttonzmianazegara;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
    }
}

