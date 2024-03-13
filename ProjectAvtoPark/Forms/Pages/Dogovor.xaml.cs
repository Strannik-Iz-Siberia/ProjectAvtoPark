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
    /// Логика взаимодействия для Dogovor.xaml
    /// </summary>
    public partial class Dogovor : Page
    {

        public Dogovor()
        {
            InitializeComponent();

            var query = from arenda in AvtoParkEntities1.GetContext().View_Аренды
                        join car in AvtoParkEntities1.GetContext().Автомобиль on arenda.id_автомобиля equals car.id_автомобиля
                        join model in AvtoParkEntities1.GetContext().Модель_авто on car.id_Модель equals model.id_Модель
                        join tariff in AvtoParkEntities1.GetContext().Тарифы on arenda.id_тарифа equals tariff.id_тарифа
                        select new
                        {
                            Авто = model.Название,
                            Название_тарифа = arenda.Название_тарифа,
                            стоимость = arenda.стоимость,
                            Дата_начала_аренды = arenda.Дата_начала_аренды,
                            Дата_окончания_аренды = arenda.Дата_окончания_аренды,
                            Итоговая_цена = arenda.стоимость + (tariff.цена_за_час * 1) + (tariff.цена_за_сутки * 31)
                        };

            ArendaGrid.ItemsSource = query.ToList();


        }


    }
}
