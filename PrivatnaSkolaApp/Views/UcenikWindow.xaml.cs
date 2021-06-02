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
        string editString = "";

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
                if (editString.Equals(""))
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
                else
                {
                    Ucenik u = db.GetUcenikByKey(editString);
                   
                    u.Godine = TextBoxGodine.Text;
                    u.Ime_U = TextBoxIme.Text;
                    u.Prezime_U = TextBoxPrezime.Text;
                    u.RoditeljJMBG_Rod = RoditeljCombBox.Text;

                    db.updateUcenik();
                    Ucenici = new BindingList<Ucenik>(db.GetAllUcenici().ToList());
                    Roditelji = new BindableCollection<Roditelj>(db.GetAllRoditelji().ToList());
                    UceniciList.ItemsSource = Ucenici;
                    RoditeljCombBox.ItemsSource = Roditelji;
                }
                ClearForm();
            }
            catch
            {
                MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearForm()
        {
            TextBoxIme.Text = String.Empty;
            TextBoxPrezime.Text = String.Empty;
            TextBoxGodine.Text = String.Empty;
            TextBoxJMBG.Text = String.Empty;
            this.editString = "";
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

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {

            Ucenik u = ((FrameworkElement)sender).DataContext as Ucenik;
            if (u != null)
            {
                TextBoxJMBG.Text = u.JMBG_U;
                TextBoxGodine.Text = u.Godine.ToString();
                TextBoxIme.Text = u.Ime_U;
                TextBoxPrezime.Text = u.Prezime_U;
                RoditeljCombBox.Text = u.RoditeljJMBG_Rod;
                this.editString = u.JMBG_U;
            }

          

        }
    }
}
