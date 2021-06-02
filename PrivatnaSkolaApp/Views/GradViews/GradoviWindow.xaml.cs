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

namespace PrivatnaSkolaApp.Views
{
    /// <summary>
    /// Interaction logic for GradoviWindow.xaml
    /// </summary>
    public partial class GradoviWindow : Window
    {
        public BindingList<Grad> Gradovi { get; set; }
        private IGradCrud db;
        private int editID;

        public GradoviWindow()
        {
            InitializeComponent();
            db = new GradCRUD();
            Gradovi = new BindingList<Grad>(db.GetGradList().ToList());
            GradoviList.ItemsSource = Gradovi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Grad g;
                if (this.editID == -1)
                {
                    g = new Grad()
                    {
                        ImeGrada = IMEG.Text,
                        PostanskiBroj = Int32.Parse(PB.Text)
                    };
                    db.AddGrad(g);
                    Gradovi = new BindingList<Grad>(db.GetGradList().ToList());
                    GradoviList.ItemsSource = Gradovi;
                }
                else
                {
                    g = db.GetGrad(editID);
                    g.ImeGrada = IMEG.Text;
                    db.UpdateGrad(g);
                    Gradovi = new BindingList<Grad>(db.GetGradList().ToList());
                    GradoviList.ItemsSource = Gradovi;
                }
                ClearForm();
            }
            catch
            {
                ERR.Content = "Neuspesno dodat grad";
                //ERR.BorderBrush=SolidColorBrush.ColorProperty.
                
            }
        }
        private void ClearForm()
        {
            IMEG.Text = String.Empty;
            PB.Text = String.Empty;
            this.editID = -1;
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            Grad g = ((FrameworkElement)sender).DataContext as Grad;
            if (g != null)
            {
                IMEG.Text = g.ImeGrada.ToString();
                PB.Text = g.PostanskiBroj.ToString();
                this.editID = g.PostanskiBroj;
            }

        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Grad g = ((FrameworkElement)sender).DataContext as Grad;
            if (g != null)
            {
                db.DeleteGrad(g);
                Gradovi = new BindingList<Grad>(db.GetGradList().ToList());
                GradoviList.ItemsSource = Gradovi;
                
            }
        }
    }
}
