using PrivatnaSkolaApp.CRUD;
using ProjekatBP;
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

namespace PrivatnaSkolaApp
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

        private void GradoviWindowButton(object sender, RoutedEventArgs e)
        {
            Views.GradoviWindow gw = new Views.GradoviWindow();
            gw.Show();
        }

        private void RoditeljWindow_Click(object sender, RoutedEventArgs e)
        {
            Views.RoditeljViews.RoditeljWindow RW = new Views.RoditeljViews.RoditeljWindow();
            RW.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Views.VlasnikWindow vw = new Views.VlasnikWindow();
            vw.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Views.PrivatnaSkolaWindow psw = new Views.PrivatnaSkolaWindow();
            psw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Views.UcenikWindow UW = new Views.UcenikWindow();
            UW.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Views.PohadjaView pv = new Views.PohadjaView();
            pv.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Views.ZiviWindow zw = new Views.ZiviWindow();
            zw.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Views.KabinetWindow kw = new Views.KabinetWindow();
            kw.Show();
        }
    }
}
