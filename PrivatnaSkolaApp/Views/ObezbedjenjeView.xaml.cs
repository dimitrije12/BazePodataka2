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
    /// Interaction logic for Obezbedjenje.xaml
    /// </summary>
    public partial class Obezbedjenje : Window
    {
        private ObezbedjenjCRUD db;
        public BindingList<Obezbedjenje> obezbedjenje;
        private BindingList<Zaposleni> zap;
        public BindableCollection<PrivatnaSkola> skole;
        public Obezbedjenje()
        {
            InitializeComponent();
            db = new ObezbedjenjCRUD();
            UpdateData();
        }
        private void UpdateData()
        {
            zap = new BindingList<Zaposleni>(db.GetZaposleni().ToList());
            skole = new BindableCollection<PrivatnaSkola>(db.GetSkole().ToList());
            ObezbedjenjeList.ItemsSource = zap.Where(x => x.Uloga == "Obezbedjenje");
            ComboBoxSkola.ItemsSource = skole;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjekatBP.Obezbedjenje s = new ProjekatBP.Obezbedjenje
                {
                    JMBG_R = TextBoxJMBG.Text,
                    Godine = GodineTB.Text,
                    Ime_R = TextBoxName.Text,
                    Prezime_R = TextBoxPrezime.Text,
                    PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)ComboBoxSkola.SelectedItem).RegBroj.ToString()),
                    //PredmetImePredmet = ((Predmet)ComboBoxPredmeti.SelectedItem).ImePredmet,
                    Uloga = "Obezbedjenje"
                };
                db.AddObezbedjenje(s);
                UpdateData();
            }
            catch
            {

            }
        }
    }
}
