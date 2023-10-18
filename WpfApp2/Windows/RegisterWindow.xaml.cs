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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegistrovaniKorisnik registrovaniKorisnik;
        private IKorisnikService korisnikService = new KorisnikService();
        public RegisterWindow()
        {
            InitializeComponent();

            registrovaniKorisnik = new RegistrovaniKorisnik
            {
                IsDeleted = false,
                //UserType = (EUserType)cbUserType.SelectedItem
            };

            DataContext = registrovaniKorisnik;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (registrovaniKorisnik.IsValid)
            {
                //user.UserType = (EUserType)cbGender.SelectedItem;
                korisnikService.Add(registrovaniKorisnik);
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
