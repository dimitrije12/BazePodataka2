using Caliburn.Micro;
using PrivatnaSkolaApp.CRUD;
using ProjekatBP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PrivatnaSkolaApp.Views
{
    /// <summary>
    /// Interaction logic for ZiviWindow.xaml
    /// </summary>
    public partial class ZiviWindow : Window
    {
        public ZiviCRUD db;
        public BindingList<Zivi> Zivljenje;
        public BindableCollection<Ucenik> Ucenici;
        public BindableCollection<Grad> Gradovii;

        public ZiviWindow()
        {
            InitializeComponent();
            db = new ZiviCRUD();
            Zivljenje = new BindingList<Zivi>(db.GetAllZivi().ToList());
            Ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
            Gradovii = new BindableCollection<Grad>(db.GetAllPGrad().ToList());
            UcenikGrad.ItemsSource = Zivljenje;
            ComboBoxGrad.ItemsSource = Gradovii;
            ComboBoxUcenik.ItemsSource = Ucenici;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               Zivi zivi = new Zivi
               {
                    GradPostanskiBroj = Int32.Parse(((Grad)ComboBoxGrad.SelectedItem).PostanskiBroj.ToString()),
                    UcenikJMBG_U = ComboBoxUcenik.Text
               };
                db.AddNewZivi(zivi);
                Zivljenje = new BindingList<Zivi>(db.GetAllZivi().ToList());
                Ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
                Gradovii = new BindableCollection<Grad>(db.GetAllPGrad().ToList());
                UcenikGrad.ItemsSource = Zivljenje;
                ComboBoxGrad.ItemsSource = Gradovii;
                ComboBoxUcenik.ItemsSource = Ucenici;
            }
            catch
            {

            }
        }
        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Zivi r = ((FrameworkElement)sender).DataContext as Zivi;
            if (r != null)
            {
                db.DeleteZivi(r);
                Zivljenje = new BindingList<Zivi>(db.GetAllZivi().ToList());
                Ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
                Gradovii = new BindableCollection<Grad>(db.GetAllPGrad().ToList());
                UcenikGrad.ItemsSource = Zivljenje;
                ComboBoxGrad.ItemsSource = Gradovii;
                ComboBoxUcenik.ItemsSource = Ucenici;
            }
        }


    }
}
