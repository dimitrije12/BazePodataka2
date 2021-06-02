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
    /// Interaction logic for Direktor.xaml
    /// </summary>
    public partial class Direktor : Window
    {
        private DirektorCRUD db;
        public BindingList<ProjekatBP.Direktor> spremacice;
        private BindingList<Zaposleni> zap;
        public BindableCollection<PrivatnaSkola> skole;
        public Direktor()
        {
            InitializeComponent();
            db = new DirektorCRUD();
            UpdateData();
        }

        private void UpdateData()
        {
            zap = new BindingList<Zaposleni>(db.GetZaposleni().ToList());
            skole = new BindableCollection<PrivatnaSkola>(db.GetSkole().ToList());
            DirektorList.ItemsSource = zap.Where(x => x.Uloga == "Direktor");
            ComboBoxSkola.ItemsSource = skole;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjekatBP.Direktor s = new ProjekatBP.Direktor
                {
                    JMBG_R = TextBoxJMBG.Text,
                    Godine = GodineTB.Text,
                    Ime_R = TextBoxName.Text,
                    Prezime_R = TextBoxPrezime.Text,
                    PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)ComboBoxSkola.SelectedItem).RegBroj.ToString()),
                    //PredmetImePredmet = ((Predmet)ComboBoxPredmeti.SelectedItem).ImePredmet,
                    Uloga = "Direktor"
                };
                db.AddDirektor(s);
                UpdateData();
            }
            catch
            {

            }
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            ProjekatBP.Direktor r = ((FrameworkElement)sender).DataContext as ProjekatBP.Direktor;
            if (r != null)
            {
                db.DeleteDirektor(r);
                UpdateData();
            }
        }
    }
}
