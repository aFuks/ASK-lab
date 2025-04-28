using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace liniaprodukcyjna
{
    public partial class Zaloguj : Form
    {
        private Dictionary<string, string> credentials = new Dictionary<string, string>();

        public Zaloguj()
        {
            InitializeComponent();
            credentials.Add("admin", "admin");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pobierz dane wpisane przez użytkownika z textboxów
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Sprawdź, czy login istnieje w słowniku i czy hasło się zgadza
            if (credentials.ContainsKey(login) && credentials[login] == password)
            {
                // Jeśli dane są poprawne, otwórz nowy formularz
                // Tutaj otwórz nowy formularz, np. MainForm
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); // Ukryj bieżący formularz
            }
            else
            {
                // Jeśli dane są niepoprawne, wyświetl komunikat o błędzie
                MessageBox.Show("Błędne dane logowania. Spróbuj ponownie.");
                // Wyczyść pola tekstowe
                textBox1.Clear();
                textBox2.Clear();
                // Ustaw focus na polu loginu
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
