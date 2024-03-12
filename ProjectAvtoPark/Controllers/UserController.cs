using ProjectAvtoPark.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAvtoPark.Controllers
{
    internal class UserController
    {
        Connection connection = new Connection();

        public List<Пользователи> GetUsers()
        {

            try
            {
                var users = connection.auth.Пользователи.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public (Пользователи newUser, Клиент newClient) CreateNewUserAndClient(string username, string password, string name, string phone)
        {
            try
            {
                using (var context = new AvtoParkEntities1())
                {
                    // Генерация идентификатора пользователя
                    int newUserId = GenerateNewUserIdForUser();

                    // Создание нового пользователя
                    Пользователи newUser = new Пользователи
                    {
                        id_пользователь = newUserId,
                        Логин = username,
                        Пароль = password
                    };
                    context.Пользователи.Add(newUser);

                    // Генерация идентификатора клиента
                    int newClientId = GenerateNewUserIdForClient();

                    // Создание нового клиента
                    Клиент newClient = new Клиент
                    {
                        id_клиента = newClientId,
                        имя = name,
                        Номер_телефона = phone,
                        id_пользователь = newUserId
                    };
                    context.Клиент.Add(newClient);

                    context.SaveChanges();

                    return (newUser, newClient);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        private int GenerateNewUserIdForUser()
        {
            // Пример: поиск максимального идентификатора пользователя и увеличение его на 1
            using (var context = new AvtoParkEntities1())
            {
                int maxUserId = context.Пользователи.Max(u => u.id_пользователь);
                return maxUserId + 1;
            }
        }

        private int GenerateNewUserIdForClient()
        {
            // Пример: поиск максимального идентификатора клиента и увеличение его на 1
            using (var context = new AvtoParkEntities1())
            {
                int maxClientId = context.Клиент.Max(c => c.id_клиента);
                return maxClientId + 1;
            }
        }




        public Пользователи SignIn(string login, string password)
        {
            try
            {
                var user = connection.auth.Пользователи.Where(x => x.Логин == login && x.Пароль == password).First();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string GetUserRoleById(int userId)
        {
            try
            {
                if (IsUserAClient(userId))
                {
                    return "client";
                }
                else if (IsUserAnEmployee(userId))
                {
                    return "employee";
                }
                else
                {
                    throw new Exception("Роль пользователя не определена");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка определения роли пользователя: {ex.Message}");
            }
        }

        private bool IsUserAClient(int userId)
        {
            try
            {
                var client = connection.auth.Клиент.FirstOrDefault(c => c.id_пользователь == userId);
                return client != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка определения клиента: {ex.Message}");
            }
        }

        private bool IsUserAnEmployee(int userId)
        {
            try
            {
                var employee = connection.auth.Сотрудник.FirstOrDefault(e => e.id_пользователь == userId);
                return employee != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка определения сотрудника: {ex.Message}");
            }
        }
    }
}
