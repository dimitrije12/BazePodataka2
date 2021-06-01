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
    /// Interaction logic for PohadjaView.xaml
    /// </summary>
    public partial class PohadjaView : Window
    {
        private PohadjaCRUD db;
        public BindingList<Pohadja> pohadjanja;
        public BindableCollection<Ucenik> ucenici;
        public BindableCollection<PrivatnaSkola> skole;

        public PohadjaView()
        {
            InitializeComponent();
            db = new PohadjaCRUD();
            pohadjanja = new BindingList<Pohadja>(db.GetAllPohadja().ToList());
            ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
            skole = new BindableCollection<PrivatnaSkola>(db.GetAllPSkole().ToList());
            UcenikSkola.ItemsSource = pohadjanja;
            ComboBoxUcenik.ItemsSource = ucenici;
            ComboBoxSkola.ItemsSource = skole;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Pohadja r = ((FrameworkElement)sender).DataContext as Pohadja;
            if (r != null)
            {
                db.DeletePohadja(r);
                pohadjanja = new BindingList<Pohadja>(db.GetAllPohadja().ToList());
                ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
                skole = new BindableCollection<PrivatnaSkola>(db.GetAllPSkole().ToList());
                UcenikSkola.ItemsSource = pohadjanja;
                ComboBoxUcenik.ItemsSource = ucenici;
                ComboBoxSkola.ItemsSource = skole;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pohadja p = new Pohadja
                {
                    UcenikJMBG_U = ComboBoxUcenik.Text,
                    PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)ComboBoxSkola.SelectedItem).RegBroj.ToString())
                };
                db.AddNewPohadja(p);
                pohadjanja = new BindingList<Pohadja>(db.GetAllPohadja().ToList());
                ucenici = new BindableCollection<Ucenik>(db.GetAllUcenici().ToList());
                skole = new BindableCollection<PrivatnaSkola>(db.GetAllPSkole().ToList());
                UcenikSkola.ItemsSource = pohadjanja;
                ComboBoxUcenik.ItemsSource = ucenici;
                ComboBoxSkola.ItemsSource = skole;
            }
            catch
            { 
}
        }
    }
}
