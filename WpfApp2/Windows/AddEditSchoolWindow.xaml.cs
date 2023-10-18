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
    /// Interaction logic for AddEditSchoolWindow.xaml
    /// </summary>
    public partial class AddEditSchoolWindow : Window
    {
        private Skola skola;
        private ISkolaService skolaService = new SkolaService();
        private bool isAddMode;
        public AddEditSchoolWindow(Skola skola)
        {
            InitializeComponent();
            this.skola = skola.Clone() as Skola;

            DataContext = this.skola;

            isAddMode = false;
        }

        public AddEditSchoolWindow()
        {
            InitializeComponent();

            skola = new Skola()   
            {
                IsDeleted = false,
            };

            isAddMode = true;
            DataContext = skola;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (isAddMode)
            {
                skolaService.Add(skola);
            }
            else
            {
                skolaService.Update(skola.Id, skola);
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
