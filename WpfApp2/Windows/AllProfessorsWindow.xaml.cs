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
    /// Interaction logic for AllProfessorsWindow.xaml
    /// </summary>
    public partial class AllProfessorsWindow : Window
    {
        private KorisnikService korisnikService = new KorisnikService();
        private List<RegistrovaniKorisnik> listaProfesora = new List<RegistrovaniKorisnik>();
        public AllProfessorsWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            var addEditProfessoWindow = new AddEditProfessorWindow();

            var successeful = addEditProfessoWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgProfessors.SelectedIndex;

            if (selectedIndex >= 0)
            {
                List<RegistrovaniKorisnik> registrovaniKorisnici = korisnikService.GetByUserType("'PROFESOR'");
                RegistrovaniKorisnik index = registrovaniKorisnici[selectedIndex];

                var addEditProfessorWindow = new AddEditProfessorWindow(registrovaniKorisnici[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteProfessor_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ((RegistrovaniKorisnik)dgProfessors.SelectedItem);
            if (selectedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite da obrisete profesora" + selectedItem, "", MessageBoxButton.YesNo);
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
            listaProfesora = korisnikService.GetByUserType("'PROFESOR'");
            dgProfessors.ItemsSource = listaProfesora;
        }

        private void dgProfessors_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Error" || e.PropertyName == "IsValid" || e.PropertyName == "SchoolId")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dgProfessors.ItemsSource = listaProfesora.Where(p => p.IsDeleted == false && (p.FirstName.Contains(txtSearch.Text.ToLower())
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

