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
    /// Interaction logic for PotpisiUgovor.xaml
    /// </summary>
    public partial class PotpisiUgovor : Window
    {
        private PotpisiUgovorCRUD db;

        public BindingList<PraviUgovor> ugovori;
        public BindableCollection<Zaposleni> direktori;
        public BindableCollection<Roditelj> roditelji;

        public PotpisiUgovor()
        {
            InitializeComponent();
            db = new PotpisiUgovorCRUD();
            UpdateData();
        }

        private void UpdateData()
        {
            ugovori = new BindingList<PraviUgovor>(db.GetAllUgovori().ToList());
            UgovorList.ItemsSource = ugovori;
            roditelji = new BindableCollection<Roditelj>(db.GetRoditelj().ToList());
            direktori = new BindableCollection<Zaposleni>(db.GetZaposleni().ToList());
            ComboBoxRoditelj.ItemsSource = roditelji;
            ComboBoxDirektori.ItemsSource = direktori.Where(x => x.Uloga == "Direktor");
            
        }


        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            PraviUgovor r = ((FrameworkElement)sender).DataContext as PraviUgovor;
            if (r != null)
            {
                db.deleteUgovor(r);
                UpdateData();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PraviUgovor u = new PraviUgovor
                {
                    UgovorBrojUgovora = Int32.Parse(TextBoxBRUG.Text),
                    Nacin_Placanja = TextBoxNacinPl.Text,
                    RoditeljJMBG_Rod = ComboBoxRoditelj.Text,
                    DirektorJMBG_R = ComboBoxDirektori.Text
                };
                db.addNewPotpisiUgovor(u);
                UpdateData();
            }
            catch
            { }
        }
    }
}
