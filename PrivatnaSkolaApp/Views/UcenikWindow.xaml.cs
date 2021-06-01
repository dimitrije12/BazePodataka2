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
    /// Interaction logic for UcenikWindow.xaml
    /// </summary>
    public partial class UcenikWindow : Window
    {

        private UcenikCRUD db;
        public BindingList<Ucenik> Ucenici;
        public BindableCollection<Roditelj> Roditelji;

        public UcenikWindow()
        {
            InitializeComponent();
            db = new UcenikCRUD();
            Ucenici = new BindingList<Ucenik>(db.GetAllUcenici().ToList());
            Roditelji = new BindableCollection<Roditelj>(db.GetAllRoditelji().ToList());
            UceniciList.ItemsSource = Ucenici;
            RoditeljCombBox.ItemsSource = Roditelji;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ucenik u = new Ucenik()
                {
                    Ime_U = TextBoxIme.Text,
                    Prezime_U = TextBoxPrezime.Text,
                    JMBG_U = TextBoxJMBG.Text,
                    Godine = TextBoxGodine.Text,
                    RoditeljJMBG_Rod = ((Roditelj)RoditeljCombBox.SelectedItem).JMBG_Rod

                };
                db.AddUcenik(u);
                Ucenici = new BindingList<Ucenik>(db.GetAllUcenici().ToList());
                Roditelji = new BindableCollection<Roditelj>(db.GetAllRoditelji().ToList());
                UceniciList.ItemsSource = Ucenici;
                RoditeljCombBox.ItemsSource = Roditelji;
            }
            catch
            {

            }
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Ucenik r = ((FrameworkElement)sender).DataContext as Ucenik;
            if (r != null)
            {
                db.DeleteUcenik(r);
                Ucenici = new BindingList<Ucenik>(db.GetAllUcenici().ToList());
                Roditelji = new BindableCollection<Roditelj>(db.GetAllRoditelji().ToList());
                UceniciList.ItemsSource = Ucenici;
                RoditeljCombBox.ItemsSource = Roditelji;
            }
        }
    }
}
