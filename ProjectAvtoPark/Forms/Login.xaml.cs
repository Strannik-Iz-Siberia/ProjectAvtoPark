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
using ProjectAvtoPark.Controllers;

namespace ProjectAvtoPark.Forms
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserController usercontrollers = new UserController();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtLogin.Text) && !String.IsNullOrEmpty(txtPassword.Password))
                {
                    var user = usercontrollers.SignIn(txtLogin.Text.Trim().ToLower(), txtPassword.Password.Trim().ToLower());
                    App.currentUser = user;

                    string userRole = usercontrollers.GetUserRoleById(user.id_пользователь);

                    if (userRole == "client")
                    {
                        Window clientWindow = new ClientForm(); // Окно для клиента
                        clientWindow.Show();
                        this.Close();

                    }
                    else if (userRole == "employee")
                    {
                        Window employeeWindow = new Sotrudnik(); // Окно для сотрудника
                        employeeWindow.Show();
                        this.Close();

                    }
                    // Другие варианты обработки
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка системы", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка системы", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window Reg = new Registration();

            // Закрытие текущего окна
            this.Close();

            // Открытие окна регистрации
            Reg.Show();
        }
    }
}
