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
using WpfApp2.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            jelUlogovan();
            Data.Instance.UlogovanKorisnik = Data.Instance.UlogovanKorisnik;

            //uvlacim inicijalne test podatke - kada prvi put pokrecem
            //Data.Instance.Initialize();

            //inicijalne podatke citam iz fajlova - kada imam kreirane fajlove
            //Data.Instance.CitanjeEntiteta("korisnici.txt");
            //Data.Instance.CitanjeEntiteta("profesori.txt");
            //Data.Instance.CitanjeEntiteta("studenti.txt");
            //Data.Instance.CitanjeEntiteta("casovi.txt");



        }

        public void jelUlogovan()
        {
            if (Data.Instance.UlogovanKorisnik.JMBG != null)
            {
                if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.STUDENT)
                {
                    btnProfil.Visibility = Visibility.Visible;
                    btnLogout.Visibility = Visibility.Visible;
                    btnSkole.Visibility = Visibility.Visible;
                    btnProfe.Visibility = Visibility.Collapsed;
                    btnStudenti.Visibility = Visibility.Collapsed;
                    btnCasovi.Visibility = Visibility.Collapsed;
                    btnJezici.Visibility = Visibility.Collapsed;
                    btRegister.Visibility = Visibility.Collapsed;
                }
                else if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                {
                    btnProfe.Visibility = Visibility.Collapsed;
                    btnProfil.Visibility = Visibility.Visible;
                    btRegister.Visibility = Visibility.Collapsed;
                    btnLogout.Visibility = Visibility.Visible;
                    btnStudenti.Visibility = Visibility.Visible;
                    btnCasovi.Visibility = Visibility.Visible;
                    btnSkole.Visibility = Visibility.Collapsed;
                    btRegister.Visibility = Visibility.Collapsed;
                    btnLogin.Visibility = Visibility.Collapsed;
                    btnJezici.Visibility = Visibility.Collapsed;



                }
                else if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.ADMINISTRATOR)
                {
                    btnSkole.Visibility = Visibility.Visible;
                    btnProfil.Visibility = Visibility.Visible;
                    btnLogin.Visibility = Visibility.Collapsed;
                    btnLogout.Visibility = Visibility.Visible;
                    btnProfe.Visibility = Visibility.Visible;
                    btnStudenti.Visibility = Visibility.Visible;
                    btnCasovi.Visibility = Visibility.Visible;
                    btnJezici.Visibility = Visibility.Visible;
                    btRegister.Visibility = Visibility.Visible;
                }

            }
            else
            {
                btnProfil.Visibility = Visibility.Collapsed;
                btnProfe.Visibility = Visibility.Collapsed;
                btnStudenti.Visibility = Visibility.Collapsed;
                btnCasovi.Visibility = Visibility.Collapsed;
                btnJezici.Visibility = Visibility.Collapsed;
                btnProfe.Visibility = Visibility.Collapsed;
                btnLogout.Visibility = Visibility.Collapsed;
                btnLogin.Visibility = Visibility.Visible;
                btnSkole.Visibility = Visibility.Visible;
                btRegister.Visibility = Visibility.Visible;

            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.ADMINISTRATOR && Data.Instance.UlogovanKorisnik.JMBG != null)
            {
                var addEditProfessorWindow = new AddEditProfessorWindow();
                addEditProfessorWindow.ShowDialog();
            }
            else
            {
                var addEditStudentWindow = new AddEditStudentWindow();
                addEditStudentWindow.ShowDialog();
            }
        }

        private void btnProfe_Click(object sender, RoutedEventArgs e)
        {
            var allProfessorsWindow = new AllProfessorsWindow();    
            allProfessorsWindow.ShowDialog();
        }

        private void btnStudenti_Click(object sender, RoutedEventArgs e)
        {
            var allStudentsWindow = new AllStudentsWindow();
            allStudentsWindow.ShowDialog();
        }

        private void btnSkole_Click(object sender, RoutedEventArgs e)
        {
            if ((Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.ADMINISTRATOR && Data.Instance.UlogovanKorisnik.JMBG !=null))
                {
                    var adminSchoolWindow = new AdminSchoolWindow();
                    adminSchoolWindow.ShowDialog();
                }
            else
                {
                    var allSchoolWindow = new AllSchoolsWindow();
                    allSchoolWindow.ShowDialog();
                }
        }
            private void btnCasovi_Click(object sender, RoutedEventArgs e)
        {
            var allClassesWindow = new AllClassesWindow();
            allClassesWindow.ShowDialog();
        }

        private void btnJezici_Click(object sender, RoutedEventArgs e)
        {
            var allLanguageWindow = new AllLanguagesWindow();
            allLanguageWindow.ShowDialog();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            
                Data.Instance.UlogovanKorisnik = new RegistrovaniKorisnik();
                jelUlogovan();
            
        }

        private void btnProfil_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Instance.UlogovanKorisnik.JMBG != null) 
            { 
                if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
                {
                    var editKorisnikWidnow = new AddEditProfessorWindow(Data.Instance.UlogovanKorisnik);
                    editKorisnikWidnow.ShowDialog();
                }
                else if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.STUDENT)
                {
                    var dodajKorisnikWindow = new AddEditStudentWindow(Data.Instance.UlogovanKorisnik);
                    dodajKorisnikWindow.ShowDialog();
                }

                else
                {
                    var studentWindow = new AddEditStudentWindow(Data.Instance.UlogovanKorisnik);
                    studentWindow.ShowDialog(); 
                }
            }
        }   
    }
}





