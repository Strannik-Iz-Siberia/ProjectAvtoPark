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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectAvtoPark.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Page
    {
        public Sotrudniki()
        {
            InitializeComponent();
           

            var clientsData = AvtoParkEntities1.GetContext().Клиент.ToList(); // Получаем данные из таблицы "Клиент"
            var usersData = AvtoParkEntities1.GetContext().Пользователи.ToList(); // Получаем данные из таблицы "Пользователи"
            var carsData = AvtoParkEntities1.GetContext().View_Автомобили.ToList(); // Получаем данные из представления "View_Автомобили"

            // Объединяем данные из разных источников
            var mergedData = from client in clientsData
                             join user in usersData on client.id_пользователь equals user.id_пользователь
                             join car in carsData on client.id_клиента equals car.id_автомобиля
                             select new
                             {
                                 Name = client.имя,
                                 PhoneNumber = client.Номер_телефона,
                                 Login = user.Логин,
                                 Password = user.Пароль,
                                 RentStatus = car.Статус
                             };
            clientdata.ItemsSource = mergedData; // Устанавливаем объединенные данные в качестве источника для DataGrid
        }
    }
}
