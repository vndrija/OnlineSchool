using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml.Linq;
using WpfApp2.Models;
using WpfApp2.Services;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Interaction logic for AddEditClassesWindow.xaml
    /// </summary>
    public partial class AddEditClassesWindow : Window
    {
        private Casovi casovi;
        private List<RegistrovaniKorisnik> profesori;
        private DateTime classDate;
        private IKorisnikService korisnikService = new KorisnikService();
        private ICasoviService casoviService = new CasoviService();
        private bool isAddMode;
        public AddEditClassesWindow(Casovi casovi)
        {
            InitializeComponent();
            txtDate.BlackoutDates.AddDatesInPast();
            profesori = korisnikService.GetByUserType("'PROFESOR'");
            cbProf.ItemsSource = profesori;
            this.casovi = casovi.Clone() as Casovi;

            DataContext = this.casovi;

            isAddMode = false;
            txtName.IsReadOnly = true;
        }

        public AddEditClassesWindow()
        {
            InitializeComponent();
            txtDate.BlackoutDates.AddDatesInPast();
            profesori = korisnikService.GetByUserType("'PROFESOR'");
            cbProf.ItemsSource = profesori;

            casovi = new Casovi()  
            {
                IsDeleted = false
            };

            isAddMode = true;
            DataContext = casovi;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var cultureInfo = new CultureInfo("de-DE");
            classDate = DateTime.ParseExact(TxtDateAndTime.Text, "dd.MM.yyyy HH:mm:ss", cultureInfo);
            casovi.Professor = (RegistrovaniKorisnik)cbProf.SelectedItem;
            casovi.DateOfClass = classDate;
            if (isAddMode)
            {
     
                casoviService.Add(casovi);
            }
            else
            {
                casoviService.Update(casovi.Id, casovi);
            }
            DialogResult = true;
            Close();
        }

        private void txtDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var cultureInfo = new CultureInfo("de-DE");
            TxtDateAndTime.Text = txtDate.SelectedDate.Value.ToString(cultureInfo);
        }
    }
}
