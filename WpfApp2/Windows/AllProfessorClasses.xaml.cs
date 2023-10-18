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
    /// Interaction logic for AllProfessorClasses.xaml
    /// </summary>
    public partial class AllProfessorClasses : Window
    {
        private CasoviService casoviService = new CasoviService();
        private List<Casovi> listaCasova = new List<Casovi>();
        private RegistrovaniKorisnik professor;
        private Casovi casovi;
        public AllProfessorClasses(List<Casovi> casovi, RegistrovaniKorisnik professor)
        {
            InitializeComponent();
            listaCasova = casovi;
            this.professor = professor;
            RefreshDataGrid();
        }
        private void miReservateClass_Click(object sender, RoutedEventArgs e)
        {
            casovi = (Casovi)dgClass.SelectedItem;
            if (casovi != null)
            {
                if (casovi.Status != EStatus.ZAUZET)
                {
                    casovi.Status = EStatus.ZAUZET;
                    casovi.Student = Data.Instance.UlogovanKorisnik;
                    casoviService.Update2(casovi.Id, casovi);
                }
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Nema selektovanih casova");
            }
        }

        private void miUnreservateClass_Click(object sender, RoutedEventArgs e)
        {
            casovi = (Casovi)dgClasss.SelectedItem;
            if (casovi != null)
            {
                if (casovi.Status == EStatus.ZAUZET)
                {
                    casovi.Status = EStatus.SLOBODAN;
                    casovi.Student = null;
                    casoviService.Update2(casovi.Id, casovi);
                }
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Nema selektovanih casova");
            }
        }

        private void dgClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgClass_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "StudentId" || e.PropertyName == "ProfessorId")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        public void RefreshDataGrid()
        {
            listaCasova = casoviService.GetAll().Where(p => p.Professor.Id == this.professor.Id && p.IsDeleted == false && p.Status == EStatus.SLOBODAN).ToList();
            dgClass.ItemsSource = listaCasova;
            listaCasova = casoviService.GetAll().Where(p => p.Professor.Id == this.professor.Id && p.IsDeleted == false && p.Status == EStatus.ZAUZET).ToList();
            dgClasss.ItemsSource = listaCasova;
        }

        private void dgClasss_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "StudentId" || e.PropertyName == "ProfessorId")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void dgClasss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
