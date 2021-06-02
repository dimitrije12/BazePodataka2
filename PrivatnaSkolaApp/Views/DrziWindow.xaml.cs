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
    /// Interaction logic for DrziWindow.xaml
    /// </summary>
    public partial class DrziWindow : Window
    {
        private DrziCRUD db;
        public BindingList<Drzi> veze { get; set; }
        public BindableCollection<Zaposleni> direktori;
        public BindableCollection<Vlasnik> vlasnici;

        public DrziWindow()
        {
            InitializeComponent();
            db = new DrziCRUD();
            UpdateData();
        }

        private void UpdateData()
        {
            veze = new BindingList<Drzi>(db.GetAllDrzi().ToList());
            direktori = new BindableCollection<Zaposleni>(db.GetAllZaposleni().ToList());
            vlasnici = new BindableCollection<Vlasnik>(db.GetAllVlasnik().ToList());
            ComboBoxVlasnici.ItemsSource = vlasnici;
            ComboBoxDirektori.ItemsSource = direktori.Where(x => x.Uloga == "Direktor");
            DrziList.ItemsSource = veze;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Drzi r = ((FrameworkElement)sender).DataContext as Drzi;
            if (r != null)
            {
                db.DeleteDrzi(r);
                UpdateData();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Drzi d = new Drzi()
                {
                    DirektorJMBG_R = ComboBoxDirektori.Text,
                    PrivatnaSkolaRegBroj = db.getRegBroj(ComboBoxDirektori.Text),
                    VlasnikJMBG_V = ComboBoxVlasnici.Text

                };
                db.AddDrzi(d);
                UpdateData();
            }
            catch
            {

            }
        }
    }
}
