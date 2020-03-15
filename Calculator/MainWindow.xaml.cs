using Calculator.Controls;
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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private Counter counter = new Counter();
        private string cache = "";

        public MainWindow()
        {
            InitializeComponent();
            //ONP onp = new ONP(new string[] { "(", "1", "+", "2", "*", "3", "-", "4", ")", "/", "(", "5", "+", "6", ")", "=" });
            //ONP onp = new ONP(new string[] { "3", "*", "4", "/", "2" , "="});
            ONP onp = new ONP(new string[] { "8", "/", "4", "/", "2", "/", "2", "/", "2", "=" });
            onp.Count();
        }

        private void Clear()
        {
            counter.Clear();
            textBlockResult.Text = "";
            textBlockStack.Text = "";
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

        }

        private void ButtonOperand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            //counter.Back();
            //textBlockResult.Text = "";
            //cache = counter.GetLastIfDigit();
            //textBlockStack.Text = counter.GetSeries();
        }
    }
}
