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

namespace FYT_laba1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicialization();
            try
            {
                Analysis();
            }
            catch(MyLexicalException ex)
            {
                textBox_output.Text = ex.Message + ". Индекс строки " + (ex.LineIndex + 1) + ". Индекс символа " + ex.SymbolIndex;
            }
            catch(Exception exc)
            {
                textBox_errors.Text = exc.Message;
            }
        }

        private void Analysis()
        {
            var str = this.textBox_input.Text;
            MyRegularExpression.StartAnalysis(str);
            
        }

        private void Inicialization()
        {
            this.textBox_output.Text = "";
            this.textBox_errors.Text = "";

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                textBox_input.Text += Environment.NewLine;
        }
    }
}
