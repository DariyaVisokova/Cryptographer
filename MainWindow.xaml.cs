using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptographer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static OpenFileDialog openfile;
        public static bool? _isFile;
        public static StreamReader sr;
        public static String keyInputText;
        public static string textResult;


        public MainWindow()
        {
            InitializeComponent();
        }


        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            openfile = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "(.txt)|*.txt"
            };
            _isFile = openfile.ShowDialog();
            inputText.Text = openfile.FileName;
            if (inputText.Text == "")
            {
                MessageBox.Show("Файл не выбран. Попробуйте еще раз.");
            }
            else
            {
                using (StreamReader reader = new StreamReader(inputText.Text, Encoding.UTF8))
                {
                    textResult = await reader.ReadToEndAsync();
                }
                inputText.Text = textResult;
            }
        }


        private void Сipher_Click(object sender, RoutedEventArgs e)
        {
            if(inputText.Text == null)
            {
                MessageBox.Show("То что пусто, зашифрованным быть не может.");
                return;
            }
            if (keyInputText == null)
            {
                MessageBox.Show("Без ключа зашифровать нельзя.");
                return;
            }
            textResult = (EncoderVigener.Encode(inputText.Text, keyInputText));
            outputText.Text = textResult;
        }

        private void Decipher_Click(object sender, RoutedEventArgs e)
        {
            if (inputText.Text == null)
            {
                MessageBox.Show("То что пусто, расшифрованным быть не может.");
                return;
            }
            if (keyInputText == null)
            {
                MessageBox.Show("Без ключа расшифровать нельзя.");
                return;
            }
            textResult = (EncoderVigener.Decode(inputText.Text, keyInputText));
            outputText.Text = textResult;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (textResult == null)
            {
                MessageBox.Show("То чего нет, сохраненным быть не может!");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(saveFileDialog.FileName, true, Encoding.UTF8);
                file.WriteLine(textResult);
                file.Close();
            }
            
        }

        private void KeyValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            keyInputText = KeyValue.Text;
        }

    }
}
