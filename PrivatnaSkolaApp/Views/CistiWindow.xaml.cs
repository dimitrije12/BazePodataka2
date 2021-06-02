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
    /// Interaction logic for CistiWindow.xaml
    /// </summary>
    public partial class CistiWindow : Window
    {
        private CistiCRUD db;
        public BindingList<Cisti> ciscenje;
        public BindableCollection<Zaposleni> spremacice;
        public BindableCollection<Kabinet> kabineti;
        public CistiWindow()
        {

            InitializeComponent();
            db = new CistiCRUD();
            UpdateData();
        }
        private void UpdateData()
        {
            ciscenje = new BindingList<Cisti>(db.GetCistis().ToList());
            CistiList.ItemsSource = ciscenje;
            kabineti = new BindableCollection<Kabinet>(db.GetKabinet().ToList());
            ComboBoxKabineti.ItemsSource = kabineti;
            spremacice = new BindableCollection<Zaposleni>(db.GetSpremacica().ToList());
            ComboBoxCistacice.ItemsSource = spremacice;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cisti c = new Cisti()
                {
                    SpremacicaJMBG_R = ComboBoxCistacice.Text,
                    KabinetBroj = Int32.Parse(ComboBoxKabineti.Text)
                };
                db.AddCisti(c);
                UpdateData();
            }
            catch
            {

            }
        }
    }
}
