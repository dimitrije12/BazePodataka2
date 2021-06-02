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
    /// Interaction logic for SpremacicWindow.xaml
    /// </summary>
    public partial class SpremacicWindow : Window
    {
        private SpremacicaCRUD db;
        public BindingList<Spremacica> spremacice;
        private BindingList<Zaposleni> zap;
        public BindableCollection<PrivatnaSkola> skole;
        public SpremacicWindow()
        {
            InitializeComponent();
            db = new SpremacicaCRUD();
            UpdateData();
        }

        private void UpdateData()
        {
            zap = new BindingList<Zaposleni>(db.GetZaposleni().ToList());
            skole = new BindableCollection<PrivatnaSkola>(db.GetSkole().ToList());
            CistaciceList.ItemsSource = zap.Where(x => x.Uloga == "Spremacica");
            ComboBoxSkola.ItemsSource = skole;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                Spremacica s = new Spremacica
                {
                    JMBG_R = TextBoxJMBG.Text,
                    Godine = GodineTB.Text,
                    Ime_R = TextBoxName.Text,
                    Prezime_R = TextBoxPrezime.Text,
                    PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)ComboBoxSkola.SelectedItem).RegBroj.ToString()),
                    //PredmetImePredmet = ((Predmet)ComboBoxPredmeti.SelectedItem).ImePredmet,
                    Uloga = "Spremacica"
                };
                db.AddSpremacica(s);
                UpdateData();
            }
            catch
            {

            }
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Spremacica r = ((FrameworkElement)sender).DataContext as Spremacica;
            if (r != null)
            {
                db.DeleteSpremacica(r);
                UpdateData();
            }
        }
    }
}
