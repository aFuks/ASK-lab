using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace kalkulator
{
    enum TYPWSKAZOWKI { SEKUNDOWA, MINUTOWA, GODZINOWA }

    public partial class Form1 : Form
    {   
        int Lh, Lm, Ls;
        int x0;
        int y0;
        int tarczaSrednica = 0; // Średnica tarczy zegara
        int styl = 0;
        List<Button> listaprzyciskow = new List<Button>();
        List<double> liczby = new List<double>();
        List<string> znaki = new List<string>();
        private double result;
        private bool isNewCalculation = true; 


        public Form1()
        {
            InitializeComponent();
            listaprzyciskow.Add(button0);
            listaprzyciskow.Add(button1);
            listaprzyciskow.Add(button2);
            listaprzyciskow.Add(button3);
            listaprzyciskow.Add(button4);
            listaprzyciskow.Add(button5);
            listaprzyciskow.Add(button6);
            listaprzyciskow.Add(button7);
            listaprzyciskow.Add(button8);
            listaprzyciskow.Add(button9);
            listaprzyciskow.Add(buttonplus);
            listaprzyciskow.Add(buttonminus);
            listaprzyciskow.Add(buttonmnozenie);
            listaprzyciskow.Add(buttondzielenie);
            listaprzyciskow.Add(buttonplus);
            listaprzyciskow.Add(buttondot);
            listaprzyciskow.Add(buttonodwrotnosc);
            listaprzyciskow.Add(buttonbackspace);
            listaprzyciskow.Add(buttonwyczysc);
            listaprzyciskow.Add(buttonpotega);
            listaprzyciskow.Add(buttonpierwiastek);
            listaprzyciskow.Add(buttonzmianastylu);
            listaprzyciskow.Add(buttonzmianazegara);
            listaprzyciskow.Add(buttonrownosc);
            Przyciski_Zdarzenia();

        }

        public void ParametryZegara()
        {
            x0 = (int)(czasanalogowy.Width / 1.1f)-26;
            y0 = czasanalogowy.Height / 2;
            tarczaSrednica = czasanalogowy.Width - 20; // Wielkość tarczy zegara
            Lh = x0 / 3;
            Lm = (int)(x0 / 2.5f);
            Ls = x0 / 2;
        }

        void wskazowka(Graphics g, Color k, int grubosc, int wspX, int wspY, int dl, int czas, TYPWSKAZOWKI typ)
        {
            int wartoscNaTarczy = 0;
            switch (typ)
            {
                case TYPWSKAZOWKI.SEKUNDOWA: wartoscNaTarczy = (czas % 60) * 360 / 60; break;
                case TYPWSKAZOWKI.MINUTOWA: wartoscNaTarczy = (czas % 60) * 360 / 60; break;
                case TYPWSKAZOWKI.GODZINOWA: wartoscNaTarczy = (czas % 12) * 360 / 12; break;
            }
            float alfa = (float)(wartoscNaTarczy) - 90;
            float radiany = (float)(Math.PI * alfa / 180);
            int yk = (int)(dl * Math.Sin(radiany));
            int xk = (int)(dl * Math.Cos(radiany));
            g.DrawLine(new Pen(k, grubosc), wspX, wspY, wspX + xk, wspY + yk);
        }

        private void rysuj(IntPtr uchwytEkranuObiektu,Color c,Color d,Color e, int wspX, int wspY, int Lh, int Lm, int Ls)
        {
            string t = DateTime.Now.ToString("T");
            DateTime czas = DateTime.Now;
            czascyfrowy.Text = t;
            Graphics g = Graphics.FromHwnd(uchwytEkranuObiektu);
            g.Clear(c);
            // Rysowanie tarczy zegara
            g.DrawEllipse(new Pen(e, 2), wspX - tarczaSrednica / 2, wspY - tarczaSrednica / 2, tarczaSrednica, tarczaSrednica);

            // Rysowanie wskazówek
            wskazowka(g, d, 4, wspX, wspY, Lh, czas.Hour, TYPWSKAZOWKI.GODZINOWA);
            wskazowka(g, d, 2, wspX, wspY, Lm, czas.Minute, TYPWSKAZOWKI.MINUTOWA);
            wskazowka(g, d, 1, wspX, wspY, Ls, czas.Second, TYPWSKAZOWKI.SEKUNDOWA);

            g.Dispose();
        }

        private void czasanalogowy_Resize(object sender, EventArgs e)
        {
            ParametryZegara();
        }

        private void buttonzmianazegara_Click(object sender, EventArgs e)
        {
            ParametryZegara();
            czasanalogowy.Visible = !czasanalogowy.Visible;
            czascyfrowy.Visible = !czascyfrowy.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.LightSkyBlue)
            {
               rysuj(czasanalogowy.Handle, this.BackColor, Color.DarkBlue,Color.Black, x0, y0, Lh, Lm, Ls);
            }
            else if (this.BackColor == Color.Black)
            {
                rysuj(czasanalogowy.Handle, this.BackColor, buttonzmianazegara.BackColor, Color.White, x0, y0, Lh, Lm, Ls);

            }
            else
            {
                rysuj(czasanalogowy.Handle, this.BackColor, buttonzmianazegara.BackColor,Color.Black, x0, y0, Lh, Lm, Ls);

            }
        }
        private void buttonzmianastylu_Click(object sender, EventArgs e)
        {
            if (styl == 2)
            {
                styl = 0;
            }
            else
            {
                styl++;
            }
            if (styl == 0)
            {
                this.BackColor = Color.LightSkyBlue;
                foreach (Button przycisk in listaprzyciskow)
                {
                    przycisk.BackColor = Color.White;
                    przycisk.ForeColor = Color.Black;
                    wyswietlacz.ForeColor = Color.Black;
                    czascyfrowy.ForeColor = Color.Black;
                }

            }
            else if (styl == 1)
            {
                this.BackColor = Color.Black;
                foreach (Button przycisk in listaprzyciskow)
                {
                    przycisk.BackColor = Color.Gray;
                    przycisk.ForeColor = Color.White;
                    wyswietlacz.ForeColor = Color.White;
                    czascyfrowy.ForeColor = Color.White;
                }

            }
            else if (styl == 2)
            {
                this.BackColor = Color.Yellow;
                foreach (Button przycisk in listaprzyciskow)
                {
                    przycisk.BackColor = Color.Orange;
                    przycisk.ForeColor = Color.Black;
                    wyswietlacz.ForeColor = Color.Black;
                    czascyfrowy.ForeColor = Color.Black;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ParametryZegara();
            czasanalogowy.Visible = false;
            this.BackColor = Color.LightSkyBlue;

        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            string operatorSymbol;
            if (e is KeyPressEventArgs)
            {
                operatorSymbol = ((KeyPressEventArgs)e).KeyChar.ToString();
            }
            else
            {
                operatorSymbol = ((Button)sender).Text;
            }

            if (isNewCalculation)
            {
                wyswietlacz.Text = "0";
                isNewCalculation = false;
            }
            // Sprawdź, czy ostatnim znakiem jest operator
            if (!"+-*/".Contains(wyswietlacz.Text.Last()))
            {
                wyswietlacz.Text += operatorSymbol;
            }
        }



        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            string[] parts = wyswietlacz.Text.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.None);
            liczby.Clear();
            foreach (string part in parts)
            {
                double number;
                string partToParse = part.StartsWith(".") ? "0" + part : part;
                if (double.TryParse(partToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    liczby.Add(number);
                }
            }

            znaki.Clear();
            foreach (char c in wyswietlacz.Text)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    znaki.Add(c.ToString());
                }
            }
            // Obliczenia
            result = liczby[0];
            for (int i = 0; i < znaki.Count; i++)
            {
                switch (znaki[i])
                {
                    case "+":
                        result += liczby[i + 1];
                        break;
                    case "-":
                        result -= liczby[i + 1];
                        break;
                    case "*":
                        result *= liczby[i + 1];
                        break;
                    case "/":
                        if (liczby[i + 1] != 0)
                            result /= liczby[i + 1];
                        else
                            MessageBox.Show("Nie można dzielić przez zero");
                        break;
                    default:
                        break;
                }
            }
            wyswietlacz.Text = result.ToString();
            // Czyszczenie tablic
            liczby.Clear();
            znaki.Clear();
            isNewCalculation = true;
        }


        private void Buttonpierwiastek_Click(object sender, EventArgs e)
        {
            string[] parts = wyswietlacz.Text.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.None);
            liczby.Clear();
            foreach (string part in parts)
            {
                double number;
                string partToParse = part.StartsWith(".") ? "0" + part : part;
                if (double.TryParse(partToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    liczby.Add(number);
                }
            }

            znaki.Clear();
            foreach (char c in wyswietlacz.Text)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    znaki.Add(c.ToString());
                }
            }
            // Obliczenia
            result = liczby[0];
            for (int i = 0; i < znaki.Count; i++)
            {
                switch (znaki[i])
                {
                    case "+":
                        result += liczby[i + 1];
                        break;
                    case "-":
                        result -= liczby[i + 1];
                        break;
                    case "*":
                        result *= liczby[i + 1];
                        break;
                    case "/":
                        if (liczby[i + 1] != 0)
                            result /= liczby[i + 1];
                        else
                            MessageBox.Show("Nie można dzielić przez zero");
                        break;
                    default:
                        break;
                }
            }
            result = Math.Sqrt(result);
            wyswietlacz.Text = result.ToString();
            // Czyszczenie tablic
            liczby.Clear();
            znaki.Clear();
            isNewCalculation = true;

        }

        private void Buttonpotega_Click(object sender, EventArgs e)
        {
            string[] parts = wyswietlacz.Text.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.None);
            liczby.Clear();
            foreach (string part in parts)
            {
                double number;
                string partToParse = part.StartsWith(".") ? "0" + part : part;
                if (double.TryParse(partToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    liczby.Add(number);
                }
            }

            znaki.Clear();
            foreach (char c in wyswietlacz.Text)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    znaki.Add(c.ToString());
                }
            }
            // Obliczenia
            result = liczby[0];
            for (int i = 0; i < znaki.Count; i++)
            {
                switch (znaki[i])
                {
                    case "+":
                        result += liczby[i + 1];
                        break;
                    case "-":
                        result -= liczby[i + 1];
                        break;
                    case "*":
                        result *= liczby[i + 1];
                        break;
                    case "/":
                        if (liczby[i + 1] != 0)
                            result /= liczby[i + 1];
                        else
                            MessageBox.Show("Nie można dzielić przez zero");
                        break;
                    default:
                        break;
                }
            }
            result = Math.Pow(result, 2);
            wyswietlacz.Text = result.ToString();
            // Czyszczenie tablic
            liczby.Clear();
            znaki.Clear();
            isNewCalculation = true;

        }

        private void Buttonodwrotnosc_Click(object sender, EventArgs e)
        {
            string[] parts = wyswietlacz.Text.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.None);
            liczby.Clear();
            foreach (string part in parts)
            {
                double number;
                string partToParse = part.StartsWith(".") ? "0" + part : part;
                if (double.TryParse(partToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                {
                    liczby.Add(number);
                }
            }

            znaki.Clear();
            foreach (char c in wyswietlacz.Text)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    znaki.Add(c.ToString());
                }
            }
            // Obliczenia
            result = liczby[0];
            for (int i = 0; i < znaki.Count; i++)
            {
                switch (znaki[i])
                {
                    case "+":
                        result += liczby[i + 1];
                        break;
                    case "-":
                        result -= liczby[i + 1];
                        break;
                    case "*":
                        result *= liczby[i + 1];
                        break;
                    case "/":
                        if (liczby[i + 1] != 0)
                            result /= liczby[i + 1];
                        else
                            MessageBox.Show("Nie można dzielić przez zero");
                        break;
                    default:
                        break;
                }
            }
            result = 1 / result;
            wyswietlacz.Text = result.ToString();
            // Czyszczenie tablic
            liczby.Clear();
            znaki.Clear();
            isNewCalculation = true;

        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            string number;
            if (e is KeyPressEventArgs)
            {
                number = ((KeyPressEventArgs)e).KeyChar.ToString();
            }
            else
            {
                number = ((Button)sender).Text;
            }

            if (isNewCalculation)
            {
                wyswietlacz.Text = number != "." ? number : "0.";
                isNewCalculation = false;
            }
            else
            {
                if (wyswietlacz.Text == "0" && number != ".")
                {
                    wyswietlacz.Text = number;
                }
                else if (wyswietlacz.Text == "." && number != ".")
                {
                    wyswietlacz.Text = "0." + number;
                }
                else
                {
                    wyswietlacz.Text += number;
                }
            }
        }



        private void buttonwyczysc_Click(object sender, EventArgs e)
        {
            wyswietlacz.Text = "0";
            liczby.Clear();
            znaki.Clear();
        }

        private void buttonbackspace_Click(object sender, EventArgs e)
        {
            if (wyswietlacz.Text.Length > 0)
            {
                wyswietlacz.Text = wyswietlacz.Text.Substring(0, wyswietlacz.Text.Length - 1);
                if (wyswietlacz.Text == "")
                    wyswietlacz.Text = "0";

                if (liczby.Count > 0 && znaki.Count < liczby.Count) // Jeśli ostatni element w tablicy to liczba, usuń liczbe
                {
                    int lastIndex = liczby.Count - 1;
                    double newNumber;
                    if (double.TryParse(wyswietlacz.Text, out newNumber))
                    {
                        liczby[lastIndex] = newNumber;
                    }
                    else
                    {
                        liczby.RemoveAt(lastIndex);
                    }
                }
                else if (znaki.Count > 0) // Jeśli ostatni element w tablicy to znak, usuń ostatni znak
                {
                    znaki.RemoveAt(znaki.Count - 1);
                }
            }
        }

        private void buttonKropka_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy kropka jest już obecna w bieżącej liczbie
            string[] parts = wyswietlacz.Text.Split(new char[] { '+', '-', '*', '/' });
            string lastPart = parts[parts.Length - 1];

            if (!lastPart.Contains("."))
            {
                if (isNewCalculation)
                {
                    wyswietlacz.Text = "0.";
                    isNewCalculation = false;
                }
                else
                {
                    // Jeśli wyświetlacz jest pusty lub ostatnim znakiem jest operator, dodaj "0."
                    if (string.IsNullOrEmpty(wyswietlacz.Text) || "+-*/".Contains(wyswietlacz.Text.Last()))
                    {
                        wyswietlacz.Text += "0.";
                    }
                    else
                    {
                        wyswietlacz.Text += ".";
                    }
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sprawdź, czy naciśnięty klawisz to cyfra lub znak
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Wprowadź cyfrę
                ButtonNumber_Click(sender, e);
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                // Wprowadź operator
                ButtonOperator_Click(sender, e);
            }
            else if (e.KeyChar == '=')
            {
                // Wprowadź równość
                ButtonEquals_Click(sender, e);
            }
            else if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Wprowadź kropkę
                buttonKropka_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Wprowadź backspace
                buttonbackspace_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                // Wprowadź wyczyszczenie
                buttonwyczysc_Click(sender, e);
            }
        }



        // Wywołanie metod obsługi zdarzeń dla przycisków
        private void Przyciski_Zdarzenia()
        {
            // Przypisz metody obsługi zdarzeń do przycisków z cyframi
            button0.Click += new EventHandler(ButtonNumber_Click);
            button1.Click += new EventHandler(ButtonNumber_Click);
            button2.Click += new EventHandler(ButtonNumber_Click);
            button3.Click += new EventHandler(ButtonNumber_Click);
            button4.Click += new EventHandler(ButtonNumber_Click);
            button5.Click += new EventHandler(ButtonNumber_Click);
            button6.Click += new EventHandler(ButtonNumber_Click);
            button7.Click += new EventHandler(ButtonNumber_Click);
            button8.Click += new EventHandler(ButtonNumber_Click);
            button9.Click += new EventHandler(ButtonNumber_Click);

            // Przypisz metodę obsługi zdarzeń do przycisków operatorów (+, -, *, /)
            buttonplus.Click += new EventHandler(ButtonOperator_Click);
            buttonminus.Click += new EventHandler(ButtonOperator_Click);
            buttonmnozenie.Click += new EventHandler(ButtonOperator_Click);
            buttondzielenie.Click += new EventHandler(ButtonOperator_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku "="
            buttonrownosc.Click += new EventHandler(ButtonEquals_Click);

            // Przypisz metodę obsługi zdarzeń do przycisków "C"
            buttonwyczysc.Click += new EventHandler(buttonwyczysc_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku backspace
            buttonbackspace.Click += new EventHandler(buttonbackspace_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku kropka
            buttondot.Click += new EventHandler(buttonKropka_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku pierwiastek
            buttonpierwiastek.Click += new EventHandler(Buttonpierwiastek_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku potęga
            buttonpotega.Click += new EventHandler(Buttonpotega_Click);

            // Przypisz metodę obsługi zdarzeń do przycisku odwrotność
            buttonodwrotnosc.Click += new EventHandler(Buttonodwrotnosc_Click);
        }
    }
}
