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

namespace Calculator.Controls
{
    public partial class ButtonNumber : UserControl
    {
        public int Number 
        {
            get
            {
                return Number;
            }
            set
            {
                Number = value;
                button.Content = value.ToString();
            } 
        }

        public ButtonNumber()
        {
            InitializeComponent();
        }
    }
}
