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
    /// Interaction logic for AddEditLanguageWindow.xaml
    /// </summary>
    public partial class AddEditLanguageWindow : Window
    {
        private Jezik jezik;
        private IJezikService jezikService = new JezikService();
        private bool isAddMode;
        public AddEditLanguageWindow()
        {
            InitializeComponent();
            jezik = new Jezik
            {
                IsDeleted = false
            };

            isAddMode = true;
            DataContext = jezik;
        }

        public AddEditLanguageWindow(Jezik jezik)
        {
            InitializeComponent();
            this.jezik = jezik.Clone() as Jezik;
            DataContext = this.jezik;

            isAddMode = false;

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                jezikService.Add(jezik);
            }
            else
            {
                jezikService.Update(jezik.Id, jezik);
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
