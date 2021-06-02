using PrivatnaSkolaApp.CRUD;
using PrivatnaSkolaApp.Interfaces;
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

namespace PrivatnaSkolaApp.Views.RoditeljViews
{
    /// <summary>
    /// Interaction logic for RoditeljWindow.xaml
    /// </summary>
    public partial class RoditeljWindow : Window
    {
        public BindingList<Roditelj> Roditeljii { get; set; }
        private String editString = "";
        private RoditeljCrud db;
        public RoditeljWindow()
        {
            InitializeComponent();
            db = new RoditeljCrud();
            Roditeljii = new BindingList<Roditelj>(db.GetRoditeljList().ToList());
            RoditeljList.ItemsSource = Roditeljii;

        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Roditelj r = ((FrameworkElement)sender).DataContext as Roditelj;
            if (r != null)
            {
                db.DeleteRoditelj(r);
                Roditeljii = new BindingList<Roditelj>(db.GetRoditeljList().ToList());
                RoditeljList.ItemsSource = Roditeljii;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editString == "")
                {
                    Roditelj r = new Roditelj
                    {
                        Ime_Rod = ImeR.Text,
                        Prezime_Rod = PrezimeR.Text,
                        JMBG_Rod = JMBGR.Text

                    };
                    db.AddRoditelj(r);
                    Roditeljii = new BindingList<Roditelj>(db.GetRoditeljList().ToList());
                    RoditeljList.ItemsSource = Roditeljii;
                }
                else
                {
                    Roditelj r = db.GetRoditelj(editString);
                    r.Ime_Rod = ImeR.Text;
                    r.Prezime_Rod = PrezimeR.Text;
                   
                    db.UpdateRoditelj();
                }
                Roditeljii = new BindingList<Roditelj>(db.GetRoditeljList().ToList());
                RoditeljList.ItemsSource = Roditeljii;
            }
            catch
            {

            }
            
        }
        private void ClearForm()
        {
            ImeR.Text = String.Empty;
            PrezimeR.Text = String.Empty;
            JMBGR.Text = String.Empty;
            this.editString = "";
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Roditelj r = ((FrameworkElement)sender).DataContext as Roditelj;
            if (r != null)
            {
                ImeR.Text = r.Ime_Rod;
                PrezimeR.Text = r.Prezime_Rod;
                JMBGR.Text = r.JMBG_Rod;
                this.editString = r.JMBG_Rod;
            }

            
        }
    }
}
