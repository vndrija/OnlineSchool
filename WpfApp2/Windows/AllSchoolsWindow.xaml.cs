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
    /// Interaction logic for AllSchoolsWindow.xaml
    /// </summary>
    public partial class AllSchoolsWindow : Window
    {
        private SkolaService skolaService = new SkolaService();
        private List<Skola> listaSkola = new List<Skola>();
        private IKorisnikService korisnikService = new KorisnikService();
        private ICasoviService casoviService = new CasoviService();
        private Skola skola = new Skola();
        private RegistrovaniKorisnik professor = new RegistrovaniKorisnik();
        public AllSchoolsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
            jelUlogovan();
        }


        public void jelUlogovan()
        {
            if (Data.Instance.UlogovanKorisnik.JMBG != null)
            {
                if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.STUDENT)
                {
                    miAddSchool.Visibility = Visibility.Collapsed;
                    miUpdateSchool.Visibility = Visibility.Collapsed;
                    miDeleteSchool.Visibility = Visibility.Collapsed;


                }
            }
            else
            {
                miAddSchool.Visibility = Visibility.Collapsed;
                miUpdateSchool.Visibility = Visibility.Collapsed;
                miDeleteSchool.Visibility = Visibility.Collapsed;
            }
            
        }

        private void miAddSchool_Click(object sender, RoutedEventArgs e)
        {
            AddEditSchoolWindow addEditSchoolWindow = new AddEditSchoolWindow();
            var succesful = addEditSchoolWindow.ShowDialog();
            if ((bool)succesful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateSchool_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgSchool.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var skole = skolaService.GetActiveSchools();
                var addEditSchoolWindow = new AddEditSchoolWindow(skole[selectedIndex]);
                var succesful = addEditSchoolWindow.ShowDialog();
                if ((bool)succesful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteSchool_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Skola)dgSchool.SelectedItem;
            if (selected != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite da obrisete skolu" + selected, "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        skolaService.Delete(selected.Id);
                        RefreshDataGrid();
                    }
                }
            }
        }
        private void RefreshDataGrid()
        {
            listaSkola = skolaService.GetActiveSchools().ToList();
            dgSchool.ItemsSource = listaSkola;
        }
        private void dgClass_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dgSchool.ItemsSource = listaSkola.Where(p => p.IsDeleted == false && (p.Name.ToLower().Contains(txtSearch.Text.ToLower())
            || p.Street.ToLower().Contains(txtSearch.Text.ToLower())
            || p.City.ToLower().Contains(txtSearch.Text.ToLower())
            || p.StreetNumber.ToLower().Contains(txtSearch.Text.ToLower())
            || p.Country.ToLower().Contains(txtSearch.Text.ToLower()))).ToList();
        }   

        private void dgSchoolProfessor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void dgSchoolProfessor_Selected_1(object sender, RoutedEventArgs e)
        {
            skola = (Skola)dgSchool.SelectedItem;
            if (skola != null)
            {
                dgSchoolProfessor.ItemsSource = korisnikService.GetByUserType("'PROFESOR'").Where(p => p.Skola.Id == skola.Id);

            }
            else
            {
                dgSchoolProfessor.ItemsSource = korisnikService.GetByUserType("'PROFESOR'").Where(p => p.Skola.Id == skola?.Id);

            }
        }

        private void dgSchoolProfessor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Data.Instance.UlogovanKorisnik.JMBG != null)
            {
                professor = (RegistrovaniKorisnik)dgSchoolProfessor.SelectedItem;
                var casovi = casoviService.GetAll().Where(p => p.Professor.Id == professor.Id && p.IsDeleted == false).ToList();
                AllProfessorClasses allProfessorClasses = new AllProfessorClasses(casovi, professor);
                allProfessorClasses.ShowDialog();
            }
        }
    }
}
