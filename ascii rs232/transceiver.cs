using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ascii_rs232
{
    public partial class transceiver : Form
    {
        public string[] dictionaryWords = File.ReadAllText("C:/Users/Tomek/source/repos/ascii rs232/slownik.txt").Split(',');

        public transceiver()

        {
            InitializeComponent();

        }

        private string ConvertToSerialFormat(string inputText)
        {
            StringBuilder serialData = new StringBuilder();

            foreach (char c in inputText)
            {
                // Dodaj bit startu (zawsze 1)
                serialData.Append("1");

                // Konwertuj znak ASCII na bity (LSB do MSB)
                for (int i = 0; i < 8; i++)
                {
                    serialData.Append((c & (1 << i)) == 0 ? "0" : "1");
                }

                // Dodaj dwa bity stopu (zawsze 1)
                serialData.Append("11");
            }

            return serialData.ToString();
        }
        private string DecodeSerialData(string serialData)
        {
            StringBuilder decodedText = new StringBuilder();

            // Przechodzimy przez ciąg danych z krokiem równym 11 (8 bitów danych + 1 bit startu + 2 bity stopu)
            for (int i = 0; i < serialData.Length; i += 11)
            {
                // Pomiń bity startu (pierwszy bit)
                string characterBits = serialData.Substring(i + 1, 8);

                // Konwertuj bity znaku na kod ASCII
                int charCode = 0;
                for (int j = 0; j < characterBits.Length; j++)
                {
                    if (characterBits[j] == '1')
                    {
                        charCode |= 1 << j;
                    }
                }

                // Dodaj znak do zdekodowanego tekstu
                decodedText.Append((char)charCode);
            }

            return decodedText.ToString();
        }

        private void enter_button_Click(object sender, EventArgs e)
        {
            string inputText = textBox_enter.Text;
            if (!inputText.All(c => c < 128))
            {
                // Wyświetlenie okna dialogowego w przypadku niepoprawnych znaków
                MessageBox.Show("Wprowadzony tekst zawiera znaki spoza zestawu ASCII.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (string word in dictionaryWords)
            {
                if (inputText.Contains(word))
                {
                    // Zastąpienie słowa gwiazdkami
                    inputText = inputText.Replace(word, new string('*', word.Length));
                }
            }
            string serialData = ConvertToSerialFormat(inputText);
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, serialData);
            string receivedData = File.ReadAllText(tempFilePath);
            string decodedData = DecodeSerialData(receivedData);

            
            textBox1.Text = serialData;  
            textBox_receive.Text = decodedData;
        }
    }
}
