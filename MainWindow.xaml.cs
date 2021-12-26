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

namespace WpfL7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int fontSize = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }




        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Документы Word (*.docx)|*.docx|Документы Word 97-2003 (*.doc)|*.doc|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Документы Word (*.docx)|*.docx|Документы Word 97-2003 (*.doc)|*.doc|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BoldExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Normal)
                {
                    textBox.FontWeight = FontWeights.Bold;
                    bold.Background = Brushes.LightBlue;
                }
                else
                {
                    textBox.FontWeight = FontWeights.Normal;
                    bold.Background = null;
                }
            }
        }

        private void ItalicExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Normal)
                {
                    textBox.FontStyle = FontStyles.Italic;
                    italic.Background = Brushes.LightBlue;
                }
                else
                {
                    textBox.FontStyle = FontStyles.Normal;
                    italic.Background = null;
                }
            }
        }

        private void UnderlineExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == TextDecorations.Underline)
                {
                    textBox.TextDecorations = null;
                    underline.Background = null;
                }
                else
                {
                    textBox.TextDecorations = TextDecorations.Underline;
                    underline.Background = Brushes.LightBlue;
                }
            }
        }
    }
}
