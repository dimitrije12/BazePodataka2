using Caliburn.Micro;
using PrivatnaSkolaApp.CRUD;
using ProjekatBP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for PrivatnaSkolaWindow.xaml
    /// </summary>
    public partial class PrivatnaSkolaWindow : Window
    {
        public BindingList<PrivatnaSkola> Skolee { get; set; }
        private PrivatnaSkolaCRUD db;
        private int editNum = -1;
        public BindableCollection<Grad> Gradovi { get; set; }

        public PrivatnaSkolaWindow()
        {
            InitializeComponent();
            db = new PrivatnaSkolaCRUD();
            
            Skolee = new BindingList<PrivatnaSkola>(db.GetPrivatneSkole().ToList());
            Gradovi = new BindableCollection<Grad>(db.GetGradovi().ToList());
            PrivSkList.ItemsSource = Skolee;
            GradoviCB.ItemsSource = Gradovi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editNum == -1)
                {
                    PrivatnaSkola ps = new PrivatnaSkola
                    {
                        ImeSkole = TextBoxIme.Text,
                        RegBroj = Int32.Parse(TextBoxRegBr.Text),
                        BrojTelefon = TextBoxBrTel.Text,
                        GradPostanskiBroj = Int32.Parse(((Grad)GradoviCB.SelectedItem).PostanskiBroj.ToString())
                    };
                    db.AddPrivSk(ps);
                    Skolee = new BindingList<PrivatnaSkola>(db.GetPrivatneSkole().ToList());
                    PrivSkList.ItemsSource = Skolee;
                }
                else
                {
                    PrivatnaSkola ps = db.GetSkola(editNum);
                    ps.ImeSkole = TextBoxIme.Text;
                    ps.BrojTelefon = TextBoxBrTel.Text;
                    db.UpdateSkola();
                    Skolee = new BindingList<PrivatnaSkola>(db.GetPrivatneSkole().ToList());
                    PrivSkList.ItemsSource = Skolee;
                }
                ClearInput();
     
            }
            catch
            {

            }
        }
        private void ClearInput()
        {
            editNum = -1;
            TextBoxIme.Text = String.Empty;
            TextBoxBrTel.Text = String.Empty;
        }

        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            PrivatnaSkola r = ((FrameworkElement)sender).DataContext as PrivatnaSkola;
            if (r != null)
            {
                db.DeletePrivSk(r);
                Skolee = new BindingList<PrivatnaSkola>(db.GetPrivatneSkole().ToList());
                PrivSkList.ItemsSource = Skolee;
                GradoviCB.ItemsSource = Gradovi;
            }
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {
            PrivatnaSkola r = ((FrameworkElement)sender).DataContext as PrivatnaSkola;
            if (r != null)
            {
                TextBoxIme.Text = r.ImeSkole;
                TextBoxBrTel.Text = r.BrojTelefon;
                TextBoxRegBr.Text = r.RegBroj.ToString();

                this.editNum = r.RegBroj;

               
            }
        }

        private void Studenata_Click(object sender, RoutedEventArgs e)
        {
            PrivatnaSkola g = ((FrameworkElement)sender).DataContext as PrivatnaSkola;
            if (g != null)
            {

                var conString = ConfigurationManager.ConnectionStrings["ModelDBContext"].ConnectionString;
                if (conString.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
                    conString = efBuilder.ProviderConnectionString;
                }

                int ukupnoStudenata = 0;

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand com = new SqlCommand("UceniciUSkoli", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.Add("@REGBr", System.Data.SqlDbType.Int).Value = g.RegBroj;
                        com.Parameters.Add("@UkupnoUcenika", System.Data.SqlDbType.Int);
                        com.Parameters["@UkupnoUcenika"].Direction = System.Data.ParameterDirection.Output;

                        try
                        {
                            con.Open();
                            com.ExecuteNonQuery();

                            ukupnoStudenata = (Int32)com.Parameters["@UkupnoUcenika"].Value;
                            MessageBox.Show(String.Format("Ukupno ucenika: {0} .", ukupnoStudenata), "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Neka greska se desila", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }

            }
        }
    }
}
