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
    /// Interaction logic for AllLanguagesWindow.xaml
    /// </summary>
    public partial class AllLanguagesWindow : Window
    {
        private JezikService jezikService = new JezikService();
        private List<Jezik> listaJezika = new List<Jezik>();
        public AllLanguagesWindow()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void miAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            AddEditLanguageWindow addEditLanguageWindow = new AddEditLanguageWindow();
            var succesful = addEditLanguageWindow.ShowDialog();
            if ((bool)succesful)
            {
                RefreshDataGrid();
            }
        }

        private void miUpdateLanguage_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = dgLanguage.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var jezici = jezikService.GetActiveSchools();
                AddEditLanguageWindow addEditLanguageWindow = new AddEditLanguageWindow(jezici[selectedIndex]);
                var succesful = addEditLanguageWindow.ShowDialog();
                if ((bool)succesful)
                {
                    RefreshDataGrid();
                }
            }
        }

        private void miDeleteLanguage_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Jezik)dgLanguage.SelectedItem;
            if (selectedItem != null)
            {
                MessageBoxResult ms = MessageBox.Show("Da lis te sigurni da obrisete jezik" + selectedItem, "", MessageBoxButton.YesNo);
                {
                    if (ms == MessageBoxResult.Yes)
                    {
                        jezikService.Delete(selectedItem.Id);
                        RefreshDataGrid();
                    }
                }
            }
        }

        private void RefreshDataGrid()
        {
            listaJezika = jezikService.GetActiveSchools().ToList();
            dgLanguage.ItemsSource = listaJezika;
        }

        private void dgLanguage_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
    
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dgLanguage.ItemsSource = listaJezika.Where(p => p.IsDeleted && (p.LanguageName.Contains(txtSearch.Text.ToLower()))).ToList();
        }
    }
}