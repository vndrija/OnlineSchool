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
    /// Interaction logic for AllStudentsWindow.xaml
    /// </summary>
    public partial class AllStudentsWindow : Window
    {
        private KorisnikService korisnikService = new KorisnikService();
        private CasoviService casoviService = new CasoviService();
        private List<Casovi> casovi = new List<Casovi>();
        private List<RegistrovaniKorisnik> registrovaniKorisnika = new List<RegistrovaniKorisnik>();
        public AllStudentsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
            //StudentHide();
        }

        //public void StudentHide()
        //{
        //    if (Data.Instance.LoggedInUser.UserType == EUserType.PROFESSOR)
        //    {
        //        miAddStudent.Visibility = Visibility.Hidden;
        //        miUpdateStudent.Visibility = Visibility.Hidden;
        //        miDeleteStudent.Visibility = Visibility.Hidden;
        //        lblSearch.Visibility = Visibility.Collapsed;
        //        txtSearch.Visibility = Visibility.Collapsed;
        //    }
        //}

        private void miAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var addEditStudentWindow = new AddEditStudentWindow();

            var successeful = addEditStudentWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgStudents.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var Students = korisnikService.GetByUserType("'STUDENT'");

                var addEditStudentWindow = new AddEditStudentWindow(Students[selectedIndex]);

                var successeful = addEditStudentWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ((RegistrovaniKorisnik)dgStudents.SelectedItem);
            if (selectedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite da obrisete studenta" + selectedItem, "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        korisnikService.Delete(selectedItem.Id);
                        RefreshDataGrid();
                    }
                }
            }
        }

        private void RefreshDataGrid()
        {
            casovi = casoviService.GetAll();
            if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
            {
                foreach (Casovi cas in casovi)
                {
                    if (cas.ProfessorId == Data.Instance.UlogovanKorisnik.Id && cas.Student != null)
                    {
                        registrovaniKorisnika = korisnikService.GetByUserType("'STUDENT'").Where(p => p.FirstName == cas.Student.FirstName).ToList();
                    }
                }
                dgStudents.ItemsSource = registrovaniKorisnika;
            }
            else
            {
                registrovaniKorisnika = korisnikService.GetByUserType("'STUDENT'");
                dgStudents.ItemsSource = registrovaniKorisnika;

            }
            //else
            //{
            //dgStudents.ItemsSource = listUsers;
            //}
        }

        private void dgStudents_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid" || e.PropertyName == "SchoolId" || e.PropertyName == "School")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dgStudents.ItemsSource = registrovaniKorisnika.Where(p => p.IsDeleted == false && (p.FirstName.Contains(txtSearch.Text.ToLower())
            || p.LastName.Contains(txtSearch.Text.ToLower())
            || p.Email.Contains(txtSearch.Text.ToLower())
            || p.JMBG.Contains(txtSearch.Text.ToLower())
            || p.Street.Contains(txtSearch.Text.ToLower())
            || p.StreetNumber.Contains(txtSearch.Text.ToLower())
            || p.City.Contains(txtSearch.Text.ToLower())
            || p.Country.Contains(txtSearch.Text.ToLower())
            || p.FirstName.Contains(txtSearch.Text.ToLower()))).ToList();
        }
    }
}