using ProjectAvtoPark.Forms.Controls;
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
using System.Windows.Markup;
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
            var carsData = AvtoParkEntities1.GetContext().View_Автомобили.ToList();
            var carModelsData = AvtoParkEntities1.GetContext().Марка_авто.ToList();

            List<RentalInfo> mergedData = new List<RentalInfo>();
            foreach (var car in carsData)
            {
                var model = carModelsData.FirstOrDefault(m => m.id_марка == car.id_автомобиля);
                if (model != null)
                {
                    RentalInfo rentalInfo = new RentalInfo
                    {
                        CarNumber = car.номерной_знак,
                        CarStatus = car.Статус, // Предполагая, что car.Статус имеет тип bool?
                        ModelName = car.Модель,
                        Markaname = model.название
                    };
                    mergedData.Add(rentalInfo);
                }
            }

            carDataGrid.ItemsSource = mergedData.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    FixedDocument document = new FixedDocument();
                    foreach (RentalInfo item in carDataGrid.ItemsSource)
                    {
                        // Создаем экземпляр UserControl, являющийся шаблоном для одной страницы для печати
                        UserControlCar printTemplate = new UserControlCar(); // Замените на вашу разметку

                        // Заполняем шаблон данными из объекта RentalInfo
                        ContentControl content = new ContentControl();
                        content.Content = printTemplate;
                        content.DataContext = item; // Устанавливаем DataContext для ContentControl

                        // Создаем и добавляем PageContent в документ FixedDocument
                        PageContent pageContent = new PageContent();
                        FixedPage fixedPage = new FixedPage();
                        fixedPage.Children.Add(content);
                        ((IAddChild)pageContent).AddChild(fixedPage);
                        document.Pages.Add(pageContent);
                    }
                    printDialog.PrintDocument(document.DocumentPaginator, "Имя документа");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
