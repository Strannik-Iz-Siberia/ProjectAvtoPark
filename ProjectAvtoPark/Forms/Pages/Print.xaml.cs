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
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Page
    {
        public Print()
        {
            InitializeComponent();

            var query = from arenda in AvtoParkEntities1.GetContext().View_Аренды
                        join car in AvtoParkEntities1.GetContext().Автомобиль on arenda.id_автомобиля equals car.id_автомобиля
                        join model in AvtoParkEntities1.GetContext().Модель_авто on car.id_Модель equals model.id_Модель
                        join tariff in AvtoParkEntities1.GetContext().Тарифы on arenda.id_тарифа equals tariff.id_тарифа
                        select new RentalInfo
                        {
                            CarId = car.id_автомобиля,
                            CarNumber = model.Название,
                            Cost = arenda.стоимость + (tariff.цена_за_час * 1) + (tariff.цена_за_сутки * 31),
                            Kolvo = 97,
                            Kolvonearend = 3,
                            k = 100

                        };


            Otchet.ItemsSource = query.ToList();

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
                    // Создаем экземпляр UserControl, являющийся шаблоном для одной страницы для печати
                    UserControlPrint printTemplate = new UserControlPrint(); // Замените на вашу разметку
                                                                             // Заполняем шаблон данными из первого объекта RentalInfo
                    ContentControl content = new ContentControl();
                    content.Content = printTemplate;
                    content.DataContext = Otchet.ItemsSource; // Устанавливаем DataContext для ContentControl

                    // Создаем и добавляем PageContent в документ FixedDocument
                    PageContent pageContent = new PageContent();
                    FixedPage fixedPage = new FixedPage();
                    fixedPage.Children.Add(content);
                    ((IAddChild)pageContent).AddChild(fixedPage);
                    document.Pages.Add(pageContent);

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
