using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Management;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing;
using System.Media;
using WMPLib;

namespace liniaprodukcyjna
{
    public partial class MainForm : Form
    {
        Timer timer = new Timer();
        Timer failureTimer = new Timer();
        int countdownValue;
        int failureCountdownValue;
        bool isConfirmationPeriod = false;
        Random random = new Random();
        bool highPressure = false;
        bool highTemperature = false;
        Timer highPressureTimer = new Timer();
        Timer pressureTimer = new Timer();
        Timer fasterTimer = new Timer();
        bool fasterButtonClicked = false;
        Timer temperatureTimer = new Timer();
        Timer highTemptimer = new Timer();
        int fansNeeded;
        Timer turnOffFans = new Timer();
        bool coldPlastic = false;
        Timer wtryskTimer = new Timer();
        Timer nieWtryskTimer = new Timer();
        Timer lowTempTimer = new Timer();
        Timer sirenTimer = new Timer();
        bool slowWork = false;
        bool hasReceivedWarning = false;

        public MainForm()
        {
            InitializeComponent();

            countdownValue = 60; // Ustawia początkową wartość odliczania
            failureCountdownValue = random.Next(7, 15); // Ustawia początkową wartość odliczania

            timer.Interval = 1000; // ustawia interwał na 1 sekundę
            timer.Tick += Timer_Tick; // dodaje obsługę zdarzeń
            timer.Start(); // rozpoczyna odliczanie

            failureTimer.Interval = 1000; // ustawia interwał na 1 sekundę
            failureTimer.Tick += FailureTimer_Tick; // dodaje obsługę zdarzeń
            failureTimer.Start(); // rozpoczyna odliczanie do awarii

            highPressureTimer.Interval = 5000;
            highPressureTimer.Tick += highPressureTimer_Tick;
            button6.Click += button6_Click;
            button5.Click += button5_Click;

            pressureTimer.Interval = 1000;
            pressureTimer.Tick += Presssure_timer_Tick;
            pressureTimer.Start();

            fasterTimer.Interval = 5000;
            fasterTimer.Tick += FasterTimer_Tick;

            temperatureTimer.Interval = 1000;
            temperatureTimer.Tick += temperatureTimer_Tick;
            temperatureTimer.Start();

            highTemptimer.Interval = 7000;
            highTemptimer.Tick += HighTempTimer_Tick;

            turnOffFans.Interval = 7000;
            turnOffFans.Tick += TurnOffFans_Tick;

            buttonLogout.Click += buttonLogout_Click;

            wtryskTimer.Interval = 500;
            wtryskTimer.Tick += WtryskTimer_Tick;
            wtryskTimer.Start();

            nieWtryskTimer.Interval = 100;
            nieWtryskTimer.Tick += NieWtryskTimer_Tick;

            checkBox1.CheckedChanged += (s, e) => CheckFanStatus();
            checkBox2.CheckedChanged += (s, e) => CheckFanStatus();
            checkBox3.CheckedChanged += (s, e) => CheckFanStatus();
            checkBox4.CheckedChanged += (s, e) => CheckFanStatus();

            lowTempTimer.Interval = 1000;
            lowTempTimer.Tick += LowTempTimer_Tick;

            sirenTimer.Interval = 2000;
            sirenTimer.Tick += SirenTimer_Tick;

        }

        private void StartConfirmationPeriod()
        {
            // Rozpoczyna 5-sekundowy okres potwierdzenia
            isConfirmationPeriod = true;
            countdownValue = 5;
            DialogResult result = MessageBox.Show("Potwierdź obecność klikając guzik OK"); // Wyświetla komunikat
            if (result == DialogResult.OK)
            {
                countdownValue = 60; // Resetuje wartość odliczania
                isConfirmationPeriod = false; // Kończy okres potwierdzenia
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label3.Text = "Czas do wylogowania: " + countdownValue.ToString();
            countdownValue--; // Zmniejsza wartość odliczania
            if (countdownValue <= 0) // Jeśli odliczanie dobiegło końca
            {
                if (!isConfirmationPeriod)
                {
                    StartConfirmationPeriod();
                }
                else
                {
                    timer.Stop(); // Zatrzymuje timer
                    // Okres potwierdzenia dobiegł końca, przeniesienie do logowania
                    // przenies do innego form
                    Zaloguj loginForm = new Zaloguj();
                    loginForm.Show();
                    this.Hide();
                }
            }
        }

        private void temperatureTimer_Tick(object sender, EventArgs e)
        {
            label_temp.Text = "Temperatura: " + GetCpuTemperature(); // aktualizuje temperaturę procesora
        }

        private void LowTempTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            double temperature = random.Next(10,30) + random.NextDouble() * 2;
            label_temp.Text = "Temperatura: " + temperature.ToString("F2") + "°C"; 
        }

        private void Presssure_timer_Tick(object sender, EventArgs e)
        {
            double pressure = 10.0 + random.NextDouble() * 2;
            label2.Text = "Ciśnienie: " + pressure.ToString("F2") + " Ba"; // aktualizuje ciśnienie
        }

        public string GetCpuTemperature()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                Double temp = Convert.ToDouble(queryObj["CurrentTemperature"].ToString());
                Random random = new Random();
                int randomNumber = random.Next(-20, 21);
                temp = (temp / 10 - 273) * 4 + randomNumber;
                return temp.ToString("0.0") + "°C";
            }
            return "N/A";
        }

        private void FailureTimer_Tick(object sender, EventArgs e)
        {
            failureCountdownValue--; // Zmniejsza wartość odliczania do awarii
            if (failureCountdownValue <= 0) // Jeśli odliczanie do awarii dobiegło końca
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                int failureType = random.Next(0, 2); // Losuje 0 lub 1

                if (failureType == 0)
                {
                    sirenTimer.Start();
                    highTemperature = true; // Zbyt wysoka temperatura
                    listBox1.Items.Add("Awaria! Zbyt wysoka temperatura! " + currentTime); // Dodaje komunikat o awarii do ListBox
                    wtryskTimer.Stop();
                    nieWtryskTimer.Start();
                    temperatureTimer.Stop(); // Zatrzymuje timer odmierzający temperaturę
                    failureTimer.Stop(); // Zatrzymuje timer odmierzający czas do awarii

                    int randomTemperature = GenerateRandomteperature();
                    label_temp.Text = "Temperatura: " + randomTemperature + "°C";

                    // Sprawdza, ile wentylatorów jest potrzebnych
                    fansNeeded = randomTemperature / 500;
                    string fanMessage = "Włącz " + fansNeeded + " wentylator(y)!";
                    listBox1.Items.Add(fanMessage);

                    highTemptimer.Start(); // Rozpoczyna timer odmierzający 5 sekund
                }
                else
                {
                    sirenTimer.Start();
                    highPressure = true; // Zbyt wysokie ciśnienie
                    listBox1.Items.Add("Awaria! Zbyt wysokie ciśnienie! " + currentTime); // Dodaje komunikat o awarii do ListBox
                    wtryskTimer.Stop();
                    nieWtryskTimer.Start();
                    pressureTimer.Stop(); 
                    label2.Text = "Ciśnienie: 20 Ba"; // Ustawia wartość ciśnienia na mega wysoką
                    highPressureTimer.Start(); // Rozpoczyna timer odmierzający 5 sekund
                    failureTimer.Stop(); // Zatrzymuje timer odmierzający czas do awarii
                }

                failureCountdownValue = random.Next(7, 15); // Resetuje wartość odliczania do awarii
            }
        }

        private void highPressureTimer_Tick(object sender, EventArgs e)
        {
            if (highPressure)
            {
                highPressureTimer.Stop();
                MessageBox.Show("Wtryskarka wybuchła"); // Wyświetla komunikat
                Application.Exit(); // Zamyka aplikację
            }
            else
            {
                pressureTimer.Start();
                listBox1.Items.Add("Ciśnienie w normie. Można przyspieszyć pracę");
                fasterTimer.Start();
                nieWtryskTimer.Stop();
                wtryskTimer.Start();
                sirenTimer.Stop();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!highPressure && !hasReceivedWarning)
            {
                listBox1.Items.Add("Przyspiesz pracę, nie mamy czasu pracować tak wolno");
                slowWork = true;
            }
            else if (hasReceivedWarning)
            {
                listBox1.Items.Add("Wtryskarka pracuje normalnie");
            }
            highPressure = false;
            hasReceivedWarning = false; // Resetuje ostrzeżenie
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (slowWork)
            {
                listBox1.Items.Add("Wtryskarka pracuje normalnie");
                slowWork = false;
            }
            else if (highPressure)
            {
                MessageBox.Show("Zbyt szybka praca. Wtryskarka wybuchła");
                Application.Exit();
            }
            else
            {
                if (hasReceivedWarning)
                {
                    MessageBox.Show("Zbyt szybka praca. Wtryskarka wybuchła");
                    Application.Exit();
                }
                else
                {
                    listBox1.Items.Add("Ostrzeżenie: Praca jest zbyt szybka. Zwolnij, aby uniknąć awarii.");
                    hasReceivedWarning = true;
                }

                pressureTimer.Start();
                failureTimer.Start();
                fasterButtonClicked = true;
                highPressureTimer.Stop();
                sirenTimer.Stop();
            }
        }

        private void FasterTimer_Tick(object sender, EventArgs e)
        {     
            if(!fasterButtonClicked)
            {
                listBox1.Items.Add("Przyspiesz pracę, nie mamy czasu pracować tak wolno");  
            }
            else
            {
                fasterButtonClicked = false;
                listBox1.Items.Add("Wtryskarka pracuje normalnie");
                fasterTimer.Stop();
            }           
        }

        public int GenerateRandomteperature()
        {
            Random random = new Random();
            int randomTemperature = random.Next(1, 4) * 500;
            return randomTemperature;
        }

        private void HighTempTimer_Tick(object sender, EventArgs e)
        {
            // Sprawdza, czy odpowiednia liczba wentylatorów jest włączona
            int fansOn = (checkBox1.Checked ? 1 : 0) + (checkBox2.Checked ? 1 : 0) + (checkBox3.Checked ? 1 : 0) + (checkBox4.Checked ? 1 : 0);
            if (fansOn < fansNeeded)
            {
                MessageBox.Show("Zbyt wysoka temperatura! Wtryskarka wybuchła");
                Application.Exit();
            }
            else
            {
                listBox1.Items.Add("Temperatura w normie, możesz wyłączyć wentylatorty");
                highTemperature = false;
                temperatureTimer.Start();                
                highTemptimer.Stop();
                turnOffFans.Start();
                sirenTimer.Stop();

                nieWtryskTimer.Stop();
                wtryskTimer.Start();
            }
        }

        private void TurnOffFans_Tick(object sender, EventArgs e)
        {
            if (coldPlastic)
            {
                turnOffFans.Stop();
                MessageBox.Show("Plastik zbyt zimny! Wtryskarka wybuchła");
                Application.Exit();
            }

            //sprawdz czy wentylatory wyłączone, jeśli nie to napisz komunikat
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                temperatureTimer.Stop();
                lowTempTimer.Start();
                listBox1.Items.Add("Wyłącz wentylatory! Plastik ma zbyt niską temperaturę!");
                coldPlastic = true;

                wtryskTimer.Stop();
                nieWtryskTimer.Start();
                sirenTimer.Start();
            }
            else
            {
                lowTempTimer.Stop();    
                temperatureTimer.Start();
                listBox1.Items.Add("Plastik ma odpowiednią temperaturę");
                turnOffFans.Stop();
                failureTimer.Start();

                nieWtryskTimer.Stop();
                wtryskTimer.Start();
                sirenTimer.Stop();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Zaloguj loginForm = new Zaloguj();
            loginForm.Show();
            this.Hide();
        }

        private void WtryskTimer_Tick(object sender, EventArgs e)
        {
            labelWtrysk.ForeColor = Color.Black;
            if (labelWtrysk.Font.Size > 16)
            {
                labelWtrysk.Font = new Font(labelWtrysk.Font.FontFamily, 15);
            }
            else
            {
                labelWtrysk.Font = new Font(labelWtrysk.Font.FontFamily, 17);
            }
            labelWtrysk.Text = "Wtryskarka wtryskuje";
        }

        private void NieWtryskTimer_Tick(object sender, EventArgs e)
        {
            labelWtrysk.ForeColor = Color.Red;
            if (labelWtrysk.Font.Size > 21)
            {
                labelWtrysk.Font = new Font(labelWtrysk.Font.FontFamily, 20);
            }
            else
            {
                labelWtrysk.Font = new Font(labelWtrysk.Font.FontFamily, 24);
            }
            labelWtrysk.Text = "Wtryskarka nie wtryskuje";

        }

        private void CheckFanStatus()
        {
            if (!highTemperature)
            {
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
                {
                    temperatureTimer.Stop();
                    lowTempTimer.Start();
                    failureTimer.Stop();
                    wtryskTimer.Stop();
                    nieWtryskTimer.Start();
                    listBox1.Items.Add("Wyłącz wentylatory! Plastik ma zbyt niską temperaturę!");
                    turnOffFans.Start();
                    sirenTimer.Start();
                }
            }
        }

        private void SirenTimer_Tick(object sender, EventArgs e)
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = @"D:\projekty ASK\linia\liniaprodukcyjna\loud-boat-horn-47513.mp3";
            player.controls.play();
        }
    }
}
