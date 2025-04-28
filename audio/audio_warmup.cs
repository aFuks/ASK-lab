using System;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace tester_kierowcy
{
    public partial class audio_warmup : Form
    {
        public int earnedcolorpoints;
        public int earnedkretpoints;

        private Stopwatch stopwatch;
        private int points = 0;
        private Timer timer;
        private int remainingSeconds;
        private int tries = 1;
        private readonly SoundPlayer _soundPlayer = new SoundPlayer("C://Users//Tomek//source//repos//projekt2//ping-82822.wav");

        public audio_warmup(int colorpoints, int kretpoints)
        {
            InitializeComponent();
            remainingSeconds = 10;
            earnedcolorpoints = colorpoints;
            earnedkretpoints = kretpoints;
            stopwatch = new Stopwatch();
            timer = new Timer();
            timer.Interval = 1000; // Interwał 1000 ms = 1 sekunda
            timer.Tick += Timer_Tick;

            // Rozpoczęcie timera
            timer.Start();
            reaction.Text = "Najlepszy czas: " + points + "ms";
            label2.Text = "Pozostałe próby: " + tries;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                int reactionMilliseconds = (int)stopwatch.ElapsedMilliseconds;

                if (points == 0 || reactionMilliseconds < points)
                {
                    points = reactionMilliseconds;
                }
                reaction.Text = "Najlepszy czas: " + points + "ms";
                if (tries == 1)
                {
                    tries--;
                    label2.Text = "Pozostałe próby: " + tries;
                    Task.Delay(1000).Wait();
                    this.Hide();
                    audio f9 = new audio(earnedcolorpoints,earnedkretpoints);
                    f9.ShowDialog();
                    this.Close();
                }
                else if (tries > 1)
                {
                    tries--;
                    label2.Text = "Pozostałe próby: " + tries;
                }
            }
        }
        Random random = new Random();

        private async Task PlaySoundAndStartTimerAsync()
        {
            // Delay before starting the stopwatch and playing the sound
            await Task.Delay(random.Next(500, 2000));

            // Start the stopwatch after the delay
            stopwatch.Restart();

            // Play the sound after the delay
            _soundPlayer.Play();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await PlaySoundAndStartTimerAsync();
        }
    }
}
