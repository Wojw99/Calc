using Calculator.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private Timer timer = new Timer();
        private ONP counter = new ONP();
        private string cache = "";
        private bool end = false;
        private bool bracketOpen = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearIfEnd()
        {
            if (end)
            {
                Clear();
                end = false;
            }
        }

        private void Clear()
        {
            counter.Clear();
            cache = "";
            textBlockResult.Text = "";
            textBlockStack.Text = "";
        }

        private void ShowMessage(string message)
        {
            //textBlockMessage.Text = message;
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            ClearIfEnd();

            cache += button.Content.ToString();
            textBlockResult.Text = cache;
        }

        private void ButtonOperand_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            ClearIfEnd();

            try
            {
                if(cache != "" || counter.GetLast() == ")")
                {
                    counter.Add(cache);
                    counter.Add(button.Content.ToString());
                    textBlockStack.Text += cache;
                    textBlockStack.Text += button.Content.ToString();
                    textBlockResult.Text = "";
                    cache = "";
                }
            }
            catch(ArgumentException ex)
            {
                ShowMessage(ex.Message.ToString());
            }
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cache == "" && counter.GetLast() != ")")
                {
                    counter.Add("0");
                    textBlockStack.Text += "0";
                }
                counter.Add(cache);
                counter.Add("=");
                textBlockStack.Text += cache;
                textBlockStack.Text += "=";
                textBlockResult.Text = counter.Count().ToString();
                cache = "";
                end = true;
            }
            catch (ArgumentException ex)
            {
                ShowMessage(ex.Message.ToString());
            }
        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            ClearIfEnd();

            if(cache != "")
            {
                double cacheDouble = Double.Parse(cache);
                cache = (cacheDouble * (-1)).ToString();
            }
            else
            {
                cache = "-";
            }

            textBlockResult.Text = cache;
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ButtonBracket_Click(object sender, RoutedEventArgs e)
        {
            ClearIfEnd();

            try
            {
                if (cache != "")
                {
                    counter.Add(cache);
                    counter.Add(")");
                    textBlockStack.Text += cache;
                    textBlockStack.Text += ")";
                    textBlockResult.Text = "";
                    cache = "";
                }
                else
                {
                    counter.Add(cache);
                    counter.Add("(");
                    textBlockStack.Text += cache;
                    textBlockStack.Text += "(";
                    textBlockResult.Text = "";
                    cache = "";
                }
            }
            catch (ArgumentException ex)
            {
                ShowMessage(ex.Message.ToString());
            }
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            ClearIfEnd();
            cache = "";
            textBlockResult.Text = "";
        }
    }
}
