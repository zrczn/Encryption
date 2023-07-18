using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //obsługa plików

using System.Security.Cryptography;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        AlgorytmAES Algo = new AlgorytmAES();

        //dana metoda generuje klucz, oraz wektor
        private Aes aesMain = Aes.Create();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                label3.Text = openFileDialog1.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.textbox.charactercasing?view=windowsdesktop-6.0
            textBox2.CharacterCasing = CharacterCasing.Lower;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.savefiledialog?view=windowsdesktop-6.0
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                label4.Text = saveFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = ROT13.Szyfrowanie(textBox1.Text);
        }

        //Szyfrowanie 
        private void button5_Click(object sender, EventArgs e)
        {

            //do metody wchodzi wygenerowany klucz i wektor ze zmiennej globalnej Aes.Create()
            string Zaszyfrowane = Algo.Zaszyfruj(textBox1.Text, aesMain.Key, aesMain.IV);

            textBox2.Text = Zaszyfrowane;

            textBox3.Text = Convert.ToBase64String(aesMain.Key);
            textBox4.Text = Convert.ToBase64String(aesMain.IV);

        }

        //Rozszyfrowanie
        private void button6_Click(object sender, EventArgs e)
        {

            string Odszyfrowane = Algo.Odszyfruj(textBox1.Text, textBox3.Text, textBox4.Text);

            textBox2.Text = Odszyfrowane;


        }
    }
}
