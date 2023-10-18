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
    /// Interaction logic for AddEditProfessorWindow.xaml
    /// </summary>
    public partial class AddEditProfessorWindow : Window
    {
        //private Professor professor;
        private RegistrovaniKorisnik registrovaniKorisnik;
        private List<Skola> skole;
        private ISkolaService skolaService = new SkolaService();
        private IKorisnikService korisnikService = new KorisnikService();
        private RegistrovaniKorisnik ulogovanKorisnik = Data.Instance.UlogovanKorisnik;
        private bool isAddMode;

        public AddEditProfessorWindow(RegistrovaniKorisnik professor)
        {
            InitializeComponent();
            this.registrovaniKorisnik = professor.Clone() as RegistrovaniKorisnik;

            skole = skolaService.GetActiveSchools();
            cbSchool.ItemsSource = skole;
            if (professor.Skola != null)
            {
                cbSchool.SelectedValuePath = "Id"; //vidi da li je id ili schoolId 
                cbSchool.SelectedValue = this.registrovaniKorisnik.Skola.Id;
            }


            DataContext = this.registrovaniKorisnik;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
        }

        public AddEditProfessorWindow()
        {
            InitializeComponent();
            skole = skolaService.GetActiveSchools();
            cbSchool.ItemsSource = skole;
            //cbSchool.SelectedItem = schools[0]; 

            // ono sto prvo vidis pre nego sto bilo sta selektujes
            registrovaniKorisnik = new RegistrovaniKorisnik
            {
                TipKorisnika = ETipKorisnika.PROFESOR,
                IsDeleted = false
            };

            isAddMode = true;
            DataContext = registrovaniKorisnik;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (registrovaniKorisnik.IsValid)

            {
                registrovaniKorisnik.Skola = (Skola)cbSchool.SelectedItem;
                if (isAddMode)
                {
                    korisnikService.Add(registrovaniKorisnik);
                }
                else
                {
                    korisnikService.Update(registrovaniKorisnik.Id, registrovaniKorisnik);
                }
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Jedno od polja je prazno");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void txtStreet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
