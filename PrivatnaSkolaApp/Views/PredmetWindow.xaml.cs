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
    /// Interaction logic for PredmetWindow.xaml
    /// </summary>
    public partial class PredmetWindow : Window
    {
        PredmetCRUD db;
        private string idd = "";
        public BindingList<Predmet> predmeti;
        public BindableCollection<Kabinet> kabineti;
        public PredmetWindow()
        {
            db = new PredmetCRUD();
            InitializeComponent();
            updateData();
            
        }

        private void updateData()
        {
            predmeti = new BindingList<Predmet>(db.GetPredmeti().ToList());
            kabineti = new BindableCollection<Kabinet>(db.GetKabineti().ToList());
            PredmetiList.ItemsSource = predmeti;
            ComboBoxKabinet.ItemsSource = kabineti;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Predmet r = ((FrameworkElement)sender).DataContext as Predmet;
            if (r != null)
            {
                db.DeletePredmet(r);
                updateData();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idd == "")
                {
                    Predmet p = new Predmet
                    {
                        ImePredmet = TextBoxImePredmeta.Text,
                        BrojCasova = Int32.Parse(TextBoxBrojCasova.Text),
                        KabinetBroj = Int32.Parse(((Kabinet)ComboBoxKabinet.SelectedItem).Broj.ToString())
                    };
                    db.AddPredmet(p);
                    updateData();

                }
                else
                {
                    Predmet p = db.GetPredmet(idd);
                    p.BrojCasova = Int32.Parse(TextBoxBrojCasova.Text);
                    p.KabinetBroj = Int32.Parse(((Kabinet)ComboBoxKabinet.SelectedItem).Broj.ToString());
                    db.UpdatePredmet();
                    DeleteInput();
                }
                updateData();
                DeleteInput();
            }
            catch
            {

            }
        }

        private void DeleteInput()
        {
            TextBoxBrojCasova.Text = String.Empty;
            TextBoxImePredmeta.Text = String.Empty;
            ComboBoxKabinet.SelectedIndex = 0;
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Predmet r = ((FrameworkElement)sender).DataContext as Predmet;
            if (r != null)
            {
                TextBoxImePredmeta.Text = r.ImePredmet;
                TextBoxBrojCasova.Text = r.BrojCasova.ToString();
                ComboBoxKabinet.SelectedItem = r.KabinetBroj;
                idd = r.ImePredmet;
            }
        }
    }
}
