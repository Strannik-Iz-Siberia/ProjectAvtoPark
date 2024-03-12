using ProjectAvtoPark.Controllers;
using ProjectAvtoPark.Models;
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

namespace ProjectAvtoPark.Forms
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        UserController userController = new UserController();
        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tboxUsername.Text) &&
                    !String.IsNullOrEmpty(tboxPassword.Text) &&
                    !String.IsNullOrEmpty(tboxNAme.Text) &&
                    !String.IsNullOrEmpty(txtPhone.Text))
                {
                    // Создание нового пользователя
                    var newUserAndClient = userController.CreateNewUserAndClient(tboxUsername.Text, tboxPassword.Text, tboxNAme.Text, txtPhone.Text);
                    Пользователи newUser = newUserAndClient.Item1;
                    Клиент newClient = newUserAndClient.Item2;

                    App.currentUser = newUser;
                    Window clientWindow = new ClientForm(); // Окно для клиента
                    clientWindow.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
