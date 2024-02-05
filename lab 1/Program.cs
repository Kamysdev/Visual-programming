using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример без использования конструктора с полями\n");
            
            // Создаём аккаунт и базовые уведомления
            Account account = new Account();
            EMailBalanceChangedNotifyer emailNotification = new EMailBalanceChangedNotifyer("work.kamysdev@gmail.com");
            SMSLowBalanceNotifyer smsNotification = new SMSLowBalanceNotifyer("+79832516744", 999);

            // Отправляем уведомления в лист, меняем баланс
            account.AddNotifyer(emailNotification);
            account.AddNotifyer(smsNotification);
            account.ChangeBalance(15000);
            account.ChangeBalance(-10000);
            account.ChangeBalance(-4599);

            Console.WriteLine("\nПример с использованием конструктора с полями\n");

            // Всё то же самое, что и выше
            Account account1 = new Account(1500);
            account1.AddNotifyer(emailNotification);
            account1.AddNotifyer(smsNotification);
            account1.ChangeBalance(4300);
            account1.ChangeBalance(-1400);
            account1.ChangeBalance(-5000);
        }
    }
}