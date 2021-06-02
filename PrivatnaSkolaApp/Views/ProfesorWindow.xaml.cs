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
    /// Interaction logic for ProfesorWindow.xaml
    /// </summary>
    public partial class ProfesorWindow : Window
    {

       
        private ProfesorCRUD db;
        private string id = "";
        private BindingList<Zaposleni> zap;
        public BindableCollection<Predmet> predmeti;
        public BindableCollection<PrivatnaSkola> skole;

        private void UpdateData()
        {
           
            predmeti = new BindableCollection<Predmet>(db.GetPredmeti().ToList());
            skole = new BindableCollection<PrivatnaSkola>(db.GetSkole().ToList());
            zap = new BindingList<Zaposleni>(db.GetZaposleni().ToList());
  
            ProfesoriList.ItemsSource = zap.Where(x => x.Uloga=="Prof");
            //ImePred.SetValue = 
            ComboBoxPredmeti.ItemsSource = predmeti;
            ComboBoxSkola.ItemsSource = skole;

            

        }
        public ProfesorWindow()
        {
            InitializeComponent();
            db = new ProfesorCRUD();
           
            
            UpdateData();
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Profesor r = ((FrameworkElement)sender).DataContext as Profesor;
            if (r != null)
            {
                db.DeleteProfesor(r);
                UpdateData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id == "")
                {
                    Profesor p = new Profesor()
                    {
                        JMBG_R = TextBoxJMBG.Text,
                        Godine = GodineTB.Text,
                        Ime_R = TextBoxName.Text,
                        Prezime_R = TextBoxPrezime.Text,
                        PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)ComboBoxSkola.SelectedItem).RegBroj.ToString()),
                        PredmetImePredmet = ((Predmet)ComboBoxPredmeti.SelectedItem).ImePredmet,
                        Uloga = "Prof"

                    };


                    db.AddProfesor(p);
                    UpdateData();
                }
                else
                {
                    Profesor p = ((Profesor)db.GetZaposleni(id));
                    p.Ime_R = TextBoxName.Text;
                    p.Prezime_R = TextBoxPrezime.Text;
                    p.Godine = GodineTB.Text;
                    p.Uloga = "Prof";
                    p.PredmetImePredmet = ((Predmet)ComboBoxPredmeti.SelectedItem).ImePredmet;
                    db.UpdateData();
                }
                UpdateData();
                DeleteInput();
            }
            catch
            {

            }
        }

        private void DeleteInput()
        {
            TextBoxJMBG.Text = String.Empty;
            TextBoxName.Text = String.Empty;
            TextBoxPrezime.Text = String.Empty;
            GodineTB.Text = String.Empty;
            ComboBoxPredmeti.SelectedItem = null;
            ComboBoxSkola.SelectedItem = null;
            id = "";
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Profesor r = ((FrameworkElement)sender).DataContext as Profesor;
            if (r != null)
            {
                id = r.JMBG_R;
                TextBoxJMBG.Text = r.JMBG_R;
                TextBoxName.Text = r.Ime_R;
                GodineTB.Text = r.Godine.ToString();
                TextBoxPrezime.Text = r.Prezime_R;
               

            }

        }
    }
}
