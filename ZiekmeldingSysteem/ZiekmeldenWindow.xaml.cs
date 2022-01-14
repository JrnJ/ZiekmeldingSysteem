using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using ZiekmeldingSysteem.Classes;

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
                if (true)
                {
                    /*
                     * Please use this code once to create a password
                     * Never save your password in code!
                    */
                    //MailData dataToSave = new MailData()
                    //{
                    //    Mail = ""
                    //    Password = ""
                    //};
                    //FileHandler<MailData>.SaveToJSON(dataToSave, "C:/Dev/MailData.json");

                    MailData data = FileHandler<MailData>.LoadFromJSON("C:/Dev/MailData.json");

                    // Send mail
                    MailMessage mail = new MailMessage()
                    {
                        From = new MailAddress(data.Mail),
                        Subject = "Ziekmelding goedgekeurd",
                        Body = $"Beste {Employee.Fullname},\n" +
                            $"Uw ziekmelding die vanaf {Report.DateFrom} in gaat met de reden, '{Report.Description}', is goedgekeurd. Indien u zich weer beter voelt kan u dit melden in de app.\n" +
                            $"\n\n\nDeze mail is automatisch gestuurd, vragen moeten naar de desbetrefende projectleider!"
                    };
                    mail.To.Add(new MailAddress(tbConfirmEmail.Text));

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential()
                        {
                            UserName = data.Mail,
                            Password = data.Password
                        }
                    };
                    
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        // Please check line 63 before you debug this error
                        Console.WriteLine("EXCEPTION: " + ex);
                    }
                }

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
