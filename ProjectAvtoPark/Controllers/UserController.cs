using ProjectAvtoPark.Models;
using System;
using System.Collections.Generic;
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
        public Пользователи CreateNewUsers()
        {
            try
            {
                Пользователи users = new Пользователи
                {
                    Логин = string.Empty,
                    Пароль = string.Empty,

                };
                connection.auth.Пользователи.Add(users);
                connection.auth.SaveChanges();
                return users;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
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
