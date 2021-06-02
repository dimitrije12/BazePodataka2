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
        private string id = "";
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
            ProjekatBP.Obezbedjenje r = ((FrameworkElement)sender).DataContext as ProjekatBP.Obezbedjenje;
            if (r != null)
            {
                db.DeleteObezbedjenje(r);
                UpdateData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id == "")
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
                else
                {
                    ProjekatBP.Obezbedjenje p = ((ProjekatBP.Obezbedjenje)db.GetZaposleni(id));
                    
                    p.Ime_R = TextBoxName.Text;
                    p.Prezime_R = TextBoxPrezime.Text;
                    p.Godine = GodineTB.Text;
                    p.Uloga = "Obezbedjenje";
                
                    db.UpdateData();
                }
                UpdateData();
                DeleteInput();
            }
            catch
            {

            }
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            ProjekatBP.Obezbedjenje r = ((FrameworkElement)sender).DataContext as ProjekatBP.Obezbedjenje;
            if (r != null)
            {
                id = r.JMBG_R;
                TextBoxJMBG.Text = r.JMBG_R;
                TextBoxName.Text = r.Ime_R;
                GodineTB.Text = r.Godine.ToString();
                TextBoxPrezime.Text = r.Prezime_R;
            }
        }
        private void DeleteInput()
        {
            TextBoxJMBG.Text = String.Empty;
            TextBoxName.Text = String.Empty;
            TextBoxPrezime.Text = String.Empty;
            GodineTB.Text = String.Empty;
            id = "";
        }


    }
        
    
}
