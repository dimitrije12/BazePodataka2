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
    /// Interaction logic for KabinetWindow.xaml
    /// </summary>
    public partial class KabinetWindow : Window
    {
        private KabinetCRUD db;
        private int id = -1;
        public BindingList<Kabinet> Kabinetii;
        public BindableCollection<PrivatnaSkola> PrivatneSkole;
        public KabinetWindow()
        {
            InitializeComponent();
            db = new KabinetCRUD();
            Kabinetii = new BindingList<Kabinet>(db.GetAllKabinet().ToList());
            PrivatneSkole = new BindableCollection<PrivatnaSkola>(db.GetAllSkole().ToList());
            SkoleComboBox.ItemsSource = PrivatneSkole;
            Kabineti.ItemsSource = Kabinetii;


        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Kabinet r = ((FrameworkElement)sender).DataContext as Kabinet;
            if (r != null)
            {
                db.DeleteKabinet(r);
                Kabinetii = new BindingList<Kabinet>(db.GetAllKabinet().ToList());
                PrivatneSkole = new BindableCollection<PrivatnaSkola>(db.GetAllSkole().ToList());
                SkoleComboBox.ItemsSource = PrivatneSkole;
                Kabineti.ItemsSource = Kabinetii;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id == -1)
                {
                    Kabinet k = new Kabinet
                    {
                        Broj = Int32.Parse(TextBoxBroj.Text),
                        Sprat = Int32.Parse(TextBoxSprat.Text),
                        PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)SkoleComboBox.SelectedItem).RegBroj.ToString())
                    };
                    db.AddNewKabinet(k);
                    Kabinetii = new BindingList<Kabinet>(db.GetAllKabinet().ToList());
                    PrivatneSkole = new BindableCollection<PrivatnaSkola>(db.GetAllSkole().ToList());
                    SkoleComboBox.ItemsSource = PrivatneSkole;
                    Kabineti.ItemsSource = Kabinetii;
                }
                else
                {
                    Kabinet k = db.GetKabinet(id);
                    k.Sprat = Int32.Parse(TextBoxSprat.Text);
                    k.PrivatnaSkolaRegBroj = Int32.Parse(((PrivatnaSkola)SkoleComboBox.SelectedItem).RegBroj.ToString());
                    db.UpdateKabinet();
                    Kabinetii = new BindingList<Kabinet>(db.GetAllKabinet().ToList());
                    PrivatneSkole = new BindableCollection<PrivatnaSkola>(db.GetAllSkole().ToList());
                    SkoleComboBox.ItemsSource = PrivatneSkole;
                    Kabineti.ItemsSource = Kabinetii;
                }
                ResetInput();
            }
            catch
            {

            }
        }

        private void ResetInput()
        {
            TextBoxSprat.Text = String.Empty;
            TextBoxBroj.Text = String.Empty;
            id = -1;
        }
        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Kabinet r = ((FrameworkElement)sender).DataContext as Kabinet;
            if (r != null)
            {
                TextBoxBroj.Text = r.Broj.ToString() ;
                TextBoxSprat.Text = r.Sprat.ToString();
                SkoleComboBox.Text = r.PrivatnaSkolaRegBroj.ToString();
                id = r.Broj;
                
            }

        }
    }
}
