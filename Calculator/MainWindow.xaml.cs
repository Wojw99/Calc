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
            textBlockStack.Text += button.Content.ToString();
            cache += button.Content.ToString();
        }

        private void ButtonOperand_Click(object sender, RoutedEventArgs e)
        {
            if(cache != "")
            {
                var button = sender as Button;
                textBlockStack.Text += button.Content.ToString();

                counter.Add(cache);
                counter.Add(button.Content.ToString());

                cache = "";
            }
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if(cache == "" && textBlockResult.Text == "")
            {
                counter.Add("0");
                textBlockStack.Text += "0";
            }
            else
            {
                counter.Add(cache);
                cache = "";
            }

            textBlockResult.Text = $"{counter.Count()}";
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            Clear();    
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
