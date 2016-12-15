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
using Organizr.ViewModels;

namespace Organizr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = new ImageFolder().Contents;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (listBox.SelectedItem as ImageFile).Save(textbox.Text);
            listBox.SelectedIndex++;
        }
    }
}
