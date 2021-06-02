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
    /// Interaction logic for VlasnikWindow.xaml
    /// </summary>
    public partial class VlasnikWindow : Window
    {
        private VlasnikCRUD db;
        private string EditID = "";
        private BindingList<Vlasnik> vlasnicii;
        public VlasnikWindow()
        {
            InitializeComponent();
            db = new VlasnikCRUD();
            vlasnicii = new BindingList<Vlasnik>(db.GetAllVlasnici().ToList());
            VlasniciList.ItemsSource = vlasnicii;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (EditID == "")
                {
                    Vlasnik v = new Vlasnik
                    {
                        Ime_V = ImeTextBox.Text,
                        Prezime_V = PrezimeTextBox.Text,
                        JMBG_V = JMBGtextBox.Text
                    };
                    db.AddVlasnik(v);
                    vlasnicii = new BindingList<Vlasnik>(db.GetAllVlasnici().ToList());
                    VlasniciList.ItemsSource = vlasnicii;
                }
                else
                {
                    Vlasnik v = db.GetVlasnik(EditID);
                    v.Ime_V = ImeTextBox.Text;
                    v.Prezime_V = PrezimeTextBox.Text;
                    db.UpdateVlasnik();
                    vlasnicii = new BindingList<Vlasnik>(db.GetAllVlasnici().ToList());
                    VlasniciList.ItemsSource = vlasnicii;

                }

            }
            catch
            {

            }
        }
        private void ClearInput()
        {
            ImeTextBox.Text = String.Empty;
            PrezimeTextBox.Text = String.Empty;
            JMBGtextBox.Text = String.Empty;
            this.EditID = "";
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Vlasnik r = ((FrameworkElement)sender).DataContext as Vlasnik;
            if (r != null)
            {
                db.DeleteVlasnik(r);
                vlasnicii = new BindingList<Vlasnik>(db.GetAllVlasnici().ToList());
                VlasniciList.ItemsSource = vlasnicii;
            }
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Vlasnik r = ((FrameworkElement)sender).DataContext as Vlasnik;
            if (r != null)
            {
                ImeTextBox.Text = r.Ime_V;
                PrezimeTextBox.Text = r.Prezime_V;
                JMBGtextBox.Text = r.JMBG_V;
                this.EditID = r.JMBG_V;
            }
        }
    }
}
