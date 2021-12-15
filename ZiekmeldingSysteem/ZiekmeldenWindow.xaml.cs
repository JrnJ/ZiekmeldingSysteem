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
using ZiekmeldingSysteem.Classes;
using ZiekmeldingSysteem.Models;

namespace ZiekmeldingSysteem
{
    /// <summary>
    /// Interaction logic for ZiekmeldenWindow.xaml
    /// </summary>
    public partial class ZiekmeldenWindow : Window
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        private Report _report;

        public Report Report
        {
            get { return _report; }
            set { _report = value; }
        }


        public ZiekmeldenWindow(Employee employee)
        {
            InitializeComponent();

            Employee = employee;
            Report = new Report()
            {
                EmployeeId = employee.Id,
            };

            DataContext = this;
        }

        private void MeldZiekClick(object sender, RoutedEventArgs e)
        {
            if (Db.AddReport(Report))
            {
                MessageBox.Show("Ziekmelding succesvol toegevoegd!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
            else
            {
                MessageBox.Show("Ziekmelding kon niet worden toegevoegd", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
