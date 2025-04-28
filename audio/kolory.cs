using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tester_kierowcy
{
    public partial class Form4 : Form
    {
        private Timer timer;
        private int remainingSeconds;
        public int earnedPoints = 0;
        List<Tuple<string, uint>> listaKolorow = new List<Tuple<string, uint>>()
        {
            Tuple.Create("Red", 0xFFFF0000),
            Tuple.Create("Red", 0xFFFF0000),
            Tuple.Create("Red", 0xFFFF0000),
            Tuple.Create("Red", 0xFF0000FF),
            Tuple.Create("Red", 0xFF00FF00),
            Tuple.Create("Red", 0xFFFFFF00),
            Tuple.Create("Red", 0xFFFFC0CB),
            Tuple.Create("Red", 0xFF000000),
            Tuple.Create("Blue", 0xFF0000FF),
            Tuple.Create("Blue", 0xFF0000FF),
            Tuple.Create("Blue", 0xFF0000FF),
            Tuple.Create("Blue", 0xFFFF0000),
            Tuple.Create("Blue", 0xFF00FF00),
            Tuple.Create("Blue", 0xFFFFFF00),
            Tuple.Create("Blue", 0xFFFFC0CB),
            Tuple.Create("Blue", 0xFF000000),
            Tuple.Create("Green", 0xFF00FF00),
            Tuple.Create("Green", 0xFF00FF00),
            Tuple.Create("Green", 0xFF00FF00),
            Tuple.Create("Green", 0xFFFF0000),
            Tuple.Create("Green", 0xFF0000FF),
            Tuple.Create("Green", 0xFFFFFF00),
            Tuple.Create("Green", 0xFFFFC0CB),
            Tuple.Create("Green", 0xFF000000),
            Tuple.Create("Yellow", 0xFFFFFF00),
            Tuple.Create("Yellow", 0xFFFFFF00),
            Tuple.Create("Yellow", 0xFFFFFF00),
            Tuple.Create("Yellow", 0xFFFF0000),
            Tuple.Create("Yellow", 0xFF0000FF),
            Tuple.Create("Yellow", 0xFF00FF00),
            Tuple.Create("Yellow", 0xFFFFC0CB),
            Tuple.Create("Yellow", 0xFF000000),
            Tuple.Create("Pink", 0xFFFFC0CB),
            Tuple.Create("Pink", 0xFFFFC0CB),
            Tuple.Create("Pink", 0xFFFFC0CB),
            Tuple.Create("Pink", 0xFFFF0000),
            Tuple.Create("Pink", 0xFF0000FF),
            Tuple.Create("Pink", 0xFF00FF00),
            Tuple.Create("Pink", 0xFFFFFF00),
            Tuple.Create("Pink", 0xFF000000),
            Tuple.Create("Black", 0xFF000000),
            Tuple.Create("Black", 0xFF000000),
            Tuple.Create("Black", 0xFF000000),
            Tuple.Create("Black", 0xFFFF0000),
            Tuple.Create("Black", 0xFF0000FF),
            Tuple.Create("Black", 0xFF00FF00),
            Tuple.Create("Black", 0xFFFFFF00),
            Tuple.Create("Black", 0xFFFFC0CB),
        };

        public Form4()
        {
            InitializeComponent();
            // Inicjalizacja timer2
            timer2 = new Timer();
            timer2.Interval = 1000; // Interwał 1000 ms (1 sekunda)
            timer2.Tick += timer2_Tick;

            // Ustawienie początkowego czasu
            remainingSeconds = 30; // Ustaw na dowolną wartość czasu w sekundach
            Time.Text = "Czas: " + remainingSeconds.ToString();

            // Uruchomienie timer2
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Odjęcie jednej sekundy od pozostałego czasu
            remainingSeconds--;

            // Aktualizacja wyświetlanego tekstu
            Time.Text = "Czas: " + remainingSeconds.ToString();

            // Jeżeli czas się skończył, zatrzymaj timer
            if (remainingSeconds <= 0)
            {
                timer2.Stop();
                //move to next form
                this.Hide();
                kret_info f5 = new kret_info(earnedPoints);
                f5.ShowDialog();
                this.Close();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void poprawne_Click(object sender, EventArgs e)
        {
            if (changecolor.Text == listaKolorow[0].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[0].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[8].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[8].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[16].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[16].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[24].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[24].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[32].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[32].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[40].Item1 && changecolor.ForeColor == Color.FromArgb((int)(listaKolorow[40].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else
            {
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
        }

        private void niepoprawne_Click(object sender, EventArgs e)
        {
            if (changecolor.Text == listaKolorow[0].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[0].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[8].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[8].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[16].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[16].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[24].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[24].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[32].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[32].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else if (changecolor.Text == listaKolorow[40].Item1 && changecolor.ForeColor != Color.FromArgb((int)(listaKolorow[40].Item2)))
            {
                points.Text = "Punkty: " + (++earnedPoints).ToString();
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }
            else
            {
                poprawne.Enabled = false;
                niepoprawne.Enabled = false;
            }

        }
        private Random random = new Random();

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        string text = "Black";
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Pobierz losowy wiersz z listy

            int randomIndex = random.Next(listaKolorow.Count);
            var randomColor = listaKolorow[randomIndex];

            if (text != randomColor.Item1)
            {
                text = randomColor.Item1;
                int c = (int)(randomColor.Item2);
                changecolor.Text = text;
                changecolor.ForeColor = Color.FromArgb(c);
                poprawne.Enabled = true;
                niepoprawne.Enabled = true;
            }
            else
            {
                timer1_Tick(sender, e);
            }
        }
    }
}
