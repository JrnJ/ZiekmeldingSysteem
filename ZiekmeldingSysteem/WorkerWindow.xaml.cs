using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window, INotifyPropertyChanged
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        private ObservableCollection<Report> _reports;

        public ObservableCollection<Report> Reports
        {
            get { return _reports; }
            set { _reports = value; OnPropertyChanged(); }
        }

        public WorkerWindow(Employee employee)
        {
            Employee = employee;
            Reports = Db.GetReportsById(employee.Id);

            InitializeComponent();

            DataContext = this;
        }

        private void ZiekmeldenClick(object sender, RoutedEventArgs e)
        {
            ZiekmeldenWindow ziekmeldenWindow = new ZiekmeldenWindow(Employee);
            ziekmeldenWindow.ShowDialog();

            // So if code is done update records
            Reports = Db.GetReportsById(Employee.Id);
            DataContext = this;
        }

        private void BetermeldenClick(object sender, RoutedEventArgs e)
        {
            // Selecteer een ziekmelding en meld die beter
            // Get sender ID
            // ID zit in de Tag
            int id = int.Parse((sender as Button).Tag.ToString());
            if (Db.ChangeReportStatus(id))
            {
                Reports.Remove(Reports.FirstOrDefault(x => x.Id == id));
            }
            else
            {
                MessageBox.Show("Kon niet beter melden!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
