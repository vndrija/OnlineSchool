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
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        //private Student student;
        //private IStudentService studentService = new StudentService();
        private RegistrovaniKorisnik registrovaniKorisnik;
        private IKorisnikService korisnikService = new KorisnikService();
        private bool isAddMode;

        public AddEditStudentWindow(RegistrovaniKorisnik student)
        {
            InitializeComponent();
            this.registrovaniKorisnik = student.Clone() as RegistrovaniKorisnik;

            DataContext = this.registrovaniKorisnik;

            isAddMode = false;
            txtJMBG.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
        }

        public AddEditStudentWindow()
        {
            InitializeComponent();

            registrovaniKorisnik = new RegistrovaniKorisnik
            {
                TipKorisnika = ETipKorisnika.STUDENT,
                IsDeleted = false,
            };

            isAddMode = true;
            DataContext = registrovaniKorisnik;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (registrovaniKorisnik.IsValid)
            {
                if (isAddMode)
                {
                    korisnikService.Add(registrovaniKorisnik);
                }
                else
                {
                    if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.ADMINISTRATOR)
                    {
                        korisnikService.Update(registrovaniKorisnik.Id, registrovaniKorisnik);

                    }
                    else
                    {
                        korisnikService.Update(registrovaniKorisnik.Id, registrovaniKorisnik);
                        Data.Instance.UlogovanKorisnik = registrovaniKorisnik;


                    }
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
    }
}