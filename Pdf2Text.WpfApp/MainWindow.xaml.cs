using Microsoft.Win32;
using Pdf2Text.Support;
using System;
using System.Collections.Generic;
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

namespace Pdf2Text.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "PDF files (*.pdf)|*.pdf"
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            try
            {
                textBox.Text = PdfUtils.Pdf2Text(openFileDialog.FileName);

                if (string.IsNullOrWhiteSpace(textBox.Text))
                    MessageBox.Show("The selected pdf file does not contain any text", "Info");
            }
            catch (Exception ex)
            {
                textBox.Text = string.Empty;
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
