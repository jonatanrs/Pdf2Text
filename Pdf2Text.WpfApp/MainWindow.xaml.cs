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
            var openFileDialog = new OpenFileDialog() {
                Filter = "PDF files (*.pdf)|*.pdf"
            };

            openFileDialog.FileOk += Dial_FileOk;

            openFileDialog.ShowDialog();
        }

        private void Dial_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textBox.Text = PdfUtils.Pdf2Text((sender as OpenFileDialog).FileName);
        }
    }
}
