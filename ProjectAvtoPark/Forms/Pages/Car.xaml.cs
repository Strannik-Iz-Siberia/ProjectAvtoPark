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
    /// Логика взаимодействия для Car.xaml
    /// </summary>
    public partial class Car : Page
    {

        public Car()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Connection connection = new Connection();

            var carsData = AvtoParkEntities1.GetContext().View_Автомобили.ToList();
            var carModelsData = AvtoParkEntities1.GetContext().Марка_авто.ToList();

            // Объединяем данные из двух таблиц
            var mergedData = from car in carsData
                             join model in carModelsData on car.id_автомобиля equals model.id_марка
                             select new
                             {
                                 CarNumber = car.номерной_знак,
                                 CarStatus = car.Статус,
                                 ModelName = car.Модель,
                                 Markaname = model.название
                             };

            carDataGrid.ItemsSource = mergedData;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


    }
}
