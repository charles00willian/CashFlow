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


namespace DesignMaterial
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

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btnShowHome(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Home();
        }

        private void btnShowCredit(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Credito();
        }

        private void btnShowDebit(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Debito();
        }

        private void btnShowRegistry(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Registro();
        }

        private void MainFrame_Initialized(object sender, EventArgs e)
        {
            MainFrame.Content = new Home();
        }
    }
}
