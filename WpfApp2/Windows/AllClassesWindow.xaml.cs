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
    /// Interaction logic for AllClassesWindow.xaml
    /// </summary>
    public partial class AllClassesWindow : Window
    {
        private CasoviService casoviService = new CasoviService();
        List<Casovi> listaCasova = new List<Casovi>();
        public AllClassesWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddClass_Click(object sender, RoutedEventArgs e)
        {
            var addEditClassWindow = new AddEditClassesWindow();

            var successeful = addEditClassWindow.ShowDialog();

            if ((bool)successeful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            Casovi selectedItem = (Casovi)dgClass.SelectedItem;
            if (selectedItem != null)
            {
                var addEditClassWindow = new AddEditClassesWindow(selectedItem);
                var successful = addEditClassWindow.ShowDialog();
                if ((bool)successful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Casovi)dgClass.SelectedItem;
            if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.PROFESOR && selectedItem.Status == EStatus.ZAUZET)
            {
                MessageBox.Show("Ne mozete da obrisete rezervisani cas");
            }
            else
            {
                if (selectedItem != null)
                {
                    MessageBoxResult ms = MessageBox.Show("Da li ste sigurni da zelite da obrisete cas" + selectedItem, "", MessageBoxButton.YesNo);
                    {
                        if (ms == MessageBoxResult.Yes)
                        {
                            casoviService.Delete(selectedItem.Id);
                            RefreshDataGrid();
                        }
                    }
                }
            }
        }

        private void RefreshDataGrid()
        {
            if (Data.Instance.UlogovanKorisnik.TipKorisnika == ETipKorisnika.PROFESOR)
            {
                listaCasova = casoviService.GetAll().Where(p => p.IsDeleted == false && p.Professor.JMBG == Data.Instance.UlogovanKorisnik.JMBG).ToList();
                dgClass.ItemsSource = listaCasova;
            }
            else
            {
                listaCasova = casoviService.GetAll().Where(p => p.IsDeleted == false).ToList();
                dgClass.ItemsSource = listaCasova;
            }
        }
        private void dgClass_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "StudentId" || e.PropertyName == "ProfessorId")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            //if (e.PropertyType == typeof(DateTime))
            //{
            //    (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            //}
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dgClass.ItemsSource = listaCasova.Where(p => p.IsDeleted == false && (p.Name.Contains(txtSearch.Text.ToLower())
            || p.Professor.FirstName.Contains(txtSearch.Text))).ToList();
        }

        private void dgClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgClassProfessor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void dgClassProfessor_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
