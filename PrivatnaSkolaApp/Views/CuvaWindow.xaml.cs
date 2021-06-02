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
    /// Interaction logic for CuvaWindow.xaml
    /// </summary>
    public partial class CuvaWindow : Window

    {
        private CuvaCRUD db;
        public BindingList<Cuva> ciscenje;
        public BindableCollection<Zaposleni> obezb;
        public BindableCollection<Kabinet> kabineti;
        public CuvaWindow()
        {
            InitializeComponent();
            InitializeComponent();
            db = new CuvaCRUD();
            UpdateData();
        }
        private void UpdateData()
        {
            ciscenje = new BindingList<Cuva>(db.GetCuvas().ToList());
            CistiList.ItemsSource = ciscenje;
            kabineti = new BindableCollection<Kabinet>(db.GetKabinet().ToList());
            ComboBoxKabineti.ItemsSource = kabineti;
            obezb = new BindableCollection<Zaposleni>(db.GetObezbedjenje().ToList());
            ComboBoxObezbedjenje.ItemsSource = obezb;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cuva c = new Cuva()
                {
                    ObezbedjenjeJMBG_R = ComboBoxObezbedjenje.Text,
                    KabinetBroj = Int32.Parse(ComboBoxKabineti.Text)
                };
                db.AddCuva(c);
                UpdateData();
            }
            catch
            {

            }


        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
