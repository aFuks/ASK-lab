using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Net.NetworkInformation;

namespace procesor_ASK
{
    public partial class Form1 : Form
    {
        static byte[] AX = new byte[2];
        static byte[] BX = new byte[2];
        static byte[] CX = new byte[2];
        static byte[] DX = new byte[2];
        static int currentstep = 0;
        static bool isImmediate = false;
        private string[] lines;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 1;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Visible = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.BackgroundColor = Color.White;
            AddRowNumbers();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            UpdateRegisters();
            GridCancel_DataBinding(dataGridView1, EventArgs.Empty);
        }
        private void AddRowNumbers()
        {
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn();
            numberColumn.Width = 20;
            numberColumn.Name = "Number";
            numberColumn.HeaderText = "#"; 
            numberColumn.ReadOnly = true; 
            dataGridView1.Columns.Insert(0, numberColumn);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Number"].Value = (i + 1).ToString();
            }
        }
        private void GridCancel_DataBinding(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection(); 
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dataGridView1.RowCount - 1 && e.ColumnIndex == dataGridView1.ColumnCount - 1)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;

                    using (Brush brush = new SolidBrush(e.CellStyle.ForeColor))
                    {
                        e.Graphics.DrawString("END", e.CellStyle.Font, brush, e.CellBounds, format);
                    }
                }

                e.Handled = true;
            }
        }
        private void MOVregister(byte[] destination, byte[] value)
        {
            destination[0] = value[0];
            destination[1] = value[1];
            UpdateRegisters();
        }
        private void ADDregister(byte[] destination, byte[] value)
        {
            int sum;
            if (isImmediate)
                sum = ((destination[0] << 8) | destination[1]) + value[0]; // Add parentheses
            else
                sum = ((destination[0] << 8) | destination[1]) + ((value[0] << 8) | value[1]); // Add parentheses

            if (sum > 0xFFFF)
            {
                MessageBox.Show("Przepełnienie rejestru.");
                return;
            }

            destination[0] = (byte)((sum >> 8) & 0xFF);
            destination[1] = (byte)(sum & 0xFF);

            UpdateRegisters();
        }

        private void SUBregister(byte[] destination, byte[] value)
        {
            int result;
            if (isImmediate)
                result = ((destination[0] << 8) | destination[1]) - value[0]; // Add parentheses
            else
                result = ((destination[0] << 8) | destination[1]) - ((value[0] << 8) | value[1]); // Add parentheses

            if (result < 0)
            {
                MessageBox.Show("Przepełnienie rejestru.");
                return;
            }

            destination[0] = (byte)((result >> 8) & 0xFF);
            destination[1] = (byte)(result & 0xFF);

            UpdateRegisters();
        }
        private void UpdateRegisters()
        {
            labelAH.Text = Convert.ToString(AX[0], 2).PadLeft(8, '0');
            labelAL.Text = Convert.ToString(AX[1], 2).PadLeft(8, '0');
            labelBH.Text = Convert.ToString(BX[0], 2).PadLeft(8, '0');
            labelBL.Text = Convert.ToString(BX[1], 2).PadLeft(8, '0');
            labelCH.Text = Convert.ToString(CX[0], 2).PadLeft(8, '0');
            labelCL.Text = Convert.ToString(CX[1], 2).PadLeft(8, '0');
            labelDH.Text = Convert.ToString(DX[0], 2).PadLeft(8, '0');
            labelDL.Text = Convert.ToString(DX[1], 2).PadLeft(8, '0');
        }
        private void ExecuteProgram(string program)
        {
            string[] lines = program.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                ExecuteInstruction(line);
            }
        }
        private void ExecuteInstruction(string line)
        {
            string[] parts = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                switch (parts[0])
                {
                    case "MOV":
                        if (parts.Length == 3)
                        {
                            int decimalNumber;
                            object register = GetRegister(parts[1]);

                            if (register is byte[])
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(16, '0');
                                    string firstEightBits = binaryString.Substring(0, 8);
                                    string secondEightBits = binaryString.Substring(8, 8);
                                    byte[] value = { Convert.ToByte(firstEightBits, 2), Convert.ToByte(secondEightBits, 2) };
                                    MOVregister((byte[])register, value);
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte[])
                                    {
                                        MOVregister((byte[])register, (byte[])value);
                                    }
                                    else if (value is byte)
                                    {
                                        byte[] x = (byte[])register;
                                        byte[] thing = { x[0], (byte)value };
                                        MOVregister(x, thing);

                                    }
                                }
                            }
                            else if (register is byte)
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(8, '0');
                                    if (parts[1][1] == 'L')
                                    {

                                        
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        byte[] x = (byte[])GetRegister(destination);
                                        byte[] value = { x[0], Convert.ToByte(binaryString, 2) };
                                        MOVregister(x, value);

                                    }
                                    else if (parts[1][1] == 'H')
                                    {
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        byte[] x = (byte[])GetRegister(destination);
                                        byte[] value = { Convert.ToByte(binaryString, 2), x[1] };
                                        MOVregister(x, value);
                                    }
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte)
                                    {
                                        if (parts[1][1] == 'L')
                                        {
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            byte[] x = (byte[])GetRegister(destination);
                                            byte[] thing = { x[0], (byte)value };
                                            MOVregister(x, thing);

                                        }
                                        else if (parts[1][1] == 'H') 
                                        { 
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            byte[] x = (byte[])GetRegister(destination);
                                            byte[] thing = { (byte)value, x[1] };
                                            MOVregister(x, thing);
                                        }
                                    }
                                    else if (value is byte[])
                                    {
                                        MessageBox.Show("Nieprawidłowy rozmiar dla rejestru wejściowego.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowa liczba argumentów dla MOV lub nieprawidłowe argumenty.");
                        }
                        break;
                    case "ADD":
                        if (parts.Length == 3)
                        {
                            int decimalNumber;
                            object register = GetRegister(parts[1]);

                            if (register is byte[])
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(16, '0');
                                    string firstEightBits = binaryString.Substring(0, 8);
                                    string secondEightBits = binaryString.Substring(8, 8);
                                    byte[] value = { Convert.ToByte(firstEightBits, 2), Convert.ToByte(secondEightBits, 2) };
                                    ADDregister((byte[])register, value);
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte[])
                                    {
                                        ADDregister((byte[])register, (byte[])value);
                                    }
                                    else if (value is byte)
                                    {
                                        byte[] thing = { 0, (byte)value };
                                        ADDregister((byte[])register, thing);

                                    }
                                }
                            }
                            else if (register is byte)
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(8, '0');
                                    if (parts[1][1] == 'L')
                                    {
                                        byte[] value = { 0, Convert.ToByte(binaryString, 2) };
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        ADDregister((byte[])GetRegister(destination), value);

                                    }
                                    else if (parts[1][1] == 'H')
                                    {
                                        byte[] value = { Convert.ToByte(binaryString, 2), 0 };
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        ADDregister((byte[])GetRegister(destination), value);
                                    }
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte)
                                    {
                                        if (parts[1][1] == 'L')
                                        {
                                            byte[] thing = { 0, (byte)value };
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            ADDregister((byte[])GetRegister(destination), thing);

                                        }
                                        else if (parts[1][1] == 'H')
                                        {
                                            byte[] thing = { (byte)value, 0 };
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            ADDregister((byte[])GetRegister(destination), thing);
                                        }
                                    }
                                    else if (value is byte[])
                                    {
                                        MessageBox.Show("Nieprawidłowy rozmiar dla rejestru wejściowego.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowa liczba argumentów dla ADD lub nieprawidłowe argumenty.");
                        }
                        break;
                    case "SUB":
                        if (parts.Length == 3)
                        {
                            int decimalNumber;
                            object register = GetRegister(parts[1]);

                            if (register is byte[])
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(16, '0');
                                    string firstEightBits = binaryString.Substring(0, 8);
                                    string secondEightBits = binaryString.Substring(8, 8);
                                    byte[] value = { Convert.ToByte(firstEightBits, 2), Convert.ToByte(secondEightBits, 2) };
                                    SUBregister((byte[])register, value);
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte[])
                                    {
                                        SUBregister((byte[])register, (byte[])value);
                                    }
                                    else if (value is byte)
                                    {
                                        byte[] thing = { 0, (byte)value };
                                        SUBregister((byte[])register, thing);

                                    }
                                }
                            }
                            else if (register is byte)
                            {
                                if (int.TryParse(parts[2], out decimalNumber))
                                {
                                    string binaryString = Convert.ToString(decimalNumber, 2).PadLeft(8, '0');
                                    if (parts[1][1] == 'L')
                                    {
                                        byte[] value = { 0, Convert.ToByte(binaryString, 2) };
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        SUBregister((byte[])GetRegister(destination), value);

                                    }
                                    else if (parts[1][1] == 'H')
                                    {
                                        byte[] value = { Convert.ToByte(binaryString, 2), 0 };
                                        string destination = parts[1].Substring(0, 1) + 'X';
                                        SUBregister((byte[])GetRegister(destination), value);
                                    }
                                }
                                else
                                {
                                    object value = GetRegister(parts[2]);
                                    if (value is byte)
                                    {
                                        if (parts[1][1] == 'L')
                                        {
                                            byte[] thing = { 0, (byte)value };
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            SUBregister((byte[])GetRegister(destination), thing);

                                        }
                                        else if (parts[1][1] == 'H')
                                        {
                                            byte[] thing = { (byte)value, 0 };
                                            string destination = parts[1].Substring(0, 1) + 'X';
                                            SUBregister((byte[])GetRegister(destination), thing);
                                        }
                                    }
                                    else if (value is byte[])
                                    {
                                        MessageBox.Show("Nieprawidłowy rozmiar dla rejestru wejściowego.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowa liczba argumentów dla SUB lub nieprawidłowe argumenty.");
                        }
                        break;
                    default:
                        MessageBox.Show("Nieznany rozkaz: " + parts[0]);
                        break;
                }
            }
        }
        private object GetRegister(string register)
        {
            switch (register)
            {
                case "AX":
                    return AX;
                case "AL":
                    return AX[1];
                case "AH":
                    return AX[0];
                case "BX":
                    return BX;
                case "BL":
                    return BX[1];
                case "BH":
                    return BX[0];
                case "CX":
                    return CX;
                case "CL":
                    return CX[1];
                case "CH":
                    return CX[0];
                case "DX":
                    return DX;
                case "DL":
                    return DX[1];
                case "DH":
                    return DX[0];
                default:
                    throw new ArgumentException("Nieprawidłowy rejestr: " + register);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                saveFileDialog.Title = "Zapisz plik tekstowy";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
                        MessageBox.Show("Zapisano do pliku tekstowego.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas zapisu do pliku: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
                openFileDialog.Title = "Wybierz plik tekstowy";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string text = File.ReadAllText(openFileDialog.FileName);
                        textBox1.Text = text;
                        MessageBox.Show("Wczytano zawartość z pliku tekstowego.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas wczytywania pliku: " + ex.Message);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                isImmediate = false;
            }
            else
            {
                isImmediate = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                string instruction = textBox1.Text;
                lines = instruction.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                textBox1.Visible = false;
                dataGridView1.Visible = true;
                DisplayCodeInDataGridView();
                GridCancel_DataBinding(dataGridView1, EventArgs.Empty);
                HighlightLine(currentstep);
                ExecuteInstruction(lines[currentstep]);
            }
            else
            {
                textBox1.Visible = false;
                dataGridView1.Visible = true;
                string instruction = textBox1.Text;
                lines = instruction.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                DisplayCodeInDataGridView();
                ExecuteProgram(textBox1.Text);
                textBox1.Visible = true;
                dataGridView1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearHighlighting();
            currentstep++;
            if (currentstep >= lines.Length)
            {
                MessageBox.Show("Koniec programu. Następuje powrót do jego początku.");
                currentstep = 0;
                textBox1.Visible = true;
                dataGridView1.Visible = false;
            }
            else
            {
                HighlightLine(currentstep);
                ExecuteInstruction(lines[currentstep]);
            }
        }
        private void DisplayCodeInDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = (i + 1).ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = lines[i];
            }
        }
        private void HighlightLine(int lineIndex)
        {
            dataGridView1.Rows[lineIndex].DefaultCellStyle.BackColor = Color.LightBlue;
        }
        private void ClearHighlighting()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;

            }
        }
    }
}