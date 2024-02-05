using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class EMailBalanceChangedNotifyer : INotifyer
    {
        private string _email;

        public EMailBalanceChangedNotifyer(string email)
        {
            _email = email;
        }

        public void Notify(decimal _balance)
        {
            Console.WriteLine("EMailBalanceChangedNotifyer");
            Console.WriteLine(_email);
            Console.WriteLine($"Алёрт! Баланс поменялся! Текущий баланс {_balance}\n");
        }
    }
}
