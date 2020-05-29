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
using System.Windows.Shapes;

namespace TravelAgency
{
    /// <summary>
    /// Logika interakcji dla klasy Parameter.xaml
    /// </summary>
    public partial class Parameter : Window
    {
        public string parameter;

        public Parameter(string labelContent)
        {
            InitializeComponent();
            LabelParameter.Content = labelContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parameter = TextBoxParameter.Text;
            this.Close();
        }
    }
}
