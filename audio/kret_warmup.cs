using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace tester_kierowcy
{
    public partial class kret_warmup : Form
    {
        private Timer timer;
        private int remainingSeconds;
        private int earnedPoints = 0;
        List<Button> buttons = new List<Button>();
        public int earnedcolorpoints;
        public kret_warmup(int colorpoints)
        {
            InitializeComponent();
            earnedcolorpoints = colorpoints;
            // Ustawienie początkowej wartości czasu
            remainingSeconds = 10;

            // Inicjalizacja i konfiguracja timera
            timer = new Timer();
            timer.Interval = 1000; // Interwał 1000 ms = 1 sekunda
            timer.Tick += Timer_Tick;

            // Rozpoczęcie timera
            timer.Start();

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    buttons.Add((Button)c);
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Odjęcie jednej sekundy od pozostałego czasu
            remainingSeconds--;

            // Aktualizacja wyświetlanego tekstu
            time.Text = "Czas: " + remainingSeconds.ToString();

            // Jeżeli czas się skończył, zatrzymaj timer
            if (remainingSeconds <= 0)
            {
                timer.Stop();
                //move to next form
                this.Hide();
                kret f6 = new kret(earnedcolorpoints);
                f6.ShowDialog();
                this.Close();
            }

            // Przypisanie obrazka krecik.png do dwóch losowych przycisków
            Random random = new Random();
            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16 };
            foreach (Button button in buttons)
            {
                // Usunięcie poprzedniego obrazka tła
                button.BackgroundImage = null;
            }

             int randomIndex = random.Next(buttons.Count);
            buttons[randomIndex].Enabled = true;
             buttons[randomIndex].BackgroundImage = Image.FromFile("C://Users//Tomek//source//repos//projekt2//krekik.png");
             buttons.RemoveAt(randomIndex);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.BackgroundImage != null)
            {
                clickedButton.Enabled = false;
                clickedButton.BackgroundImage = Image.FromFile("C://Users//Tomek//source//repos//projekt2//krekik_dead.png");
                earnedPoints++;
                // Aktualizuj wyświetlaną liczbę punktów (jeśli istnieje taki element)
                points.Text = "Punkty: " + earnedPoints.ToString();
            }
        }

        private void kret_warmup_Load(object sender, EventArgs e)
        {

        }
    }
}
