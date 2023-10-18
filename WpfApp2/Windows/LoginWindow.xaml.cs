using System;
using System.Collections.Generic;
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
using WpfApp2.Models;
using WpfApp2.Services;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private RegistrovaniKorisnik registrovaniKorisnik;
        private IKorisnikService korisnikService = new KorisnikService();
        private List<RegistrovaniKorisnik> registrovaniKorisnici = new List<RegistrovaniKorisnik>();
        string s = "";
        public LoginWindow()
        {
            InitializeComponent();
        }

        public RegistrovaniKorisnik login(string jmbg, string password)
        {
            registrovaniKorisnici = korisnikService.GetActiveUsers();
            if (jmbg != null && password != null)
            {
                foreach (RegistrovaniKorisnik registrovaniKorisnik in registrovaniKorisnici)
                {
                    if (registrovaniKorisnik.Password == password && registrovaniKorisnik.JMBG == jmbg)
                    {
                        return registrovaniKorisnik;
                    }
                }
            }
            return null;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtJmbg.Text == s || txtPassword.Password == s)
            {
                MessageBox.Show("Polje ne sme da bude prazno");
            }
            else
            {
                registrovaniKorisnik = login(txtJmbg.Text, txtPassword.Password);
                if (registrovaniKorisnik != null)
                {
                    Data.Instance.UlogovanKorisnik = registrovaniKorisnik;
                    HomeWindow homeWidnow = new HomeWindow();
                    this.Close();
                    homeWidnow.ShowDialog(); 
                    
                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji");
                }
            }
        }
    }
}