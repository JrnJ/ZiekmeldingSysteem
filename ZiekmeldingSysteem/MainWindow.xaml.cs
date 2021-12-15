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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ZiekmeldingSysteem.Classes;
using ZiekmeldingSysteem.Models;

namespace ZiekmeldingSysteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            Employee = new Employee()
            {
                Fullname = "Roderick Jansen",
            };
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            // Check if its correct
            Employee temp = Db.Login(Employee.Fullname);

            if (temp != null)
            {
                switch (Db.GetRoleById(temp.RoleId))
                {
                    case "Admin":
                        // Open Admin Window
                        break;
                    case "Manager":
                        // Open Manager Window
                        ManagerWindow managerWindow = new ManagerWindow(temp);
                        managerWindow.Show();
                        break;
                    case "Worker":
                        // Open Worker Window
                        WorkerWindow workerWindow = new WorkerWindow(temp);
                        workerWindow.Show();
                        break;
                    default:
                        MessageBox.Show("Role not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Combination is invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
