using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class SMSLowBalanceNotifyer : INotifyer
    {
        private string _phone;
        private decimal _lowBalanceValue;

        public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue)
        {
            _phone = phone;
            _lowBalanceValue = lowBalanceValue;
        }

        public void Notify(decimal _balance)
        {
            if (_balance <= _lowBalanceValue)
            {
                Console.WriteLine("SMSLowBalanceNotifyer");
                Console.WriteLine(_phone);
                Console.WriteLine($"SMS: У вас мало средств на вашем балансе! Текущий баланс составляет {_balance}");
            }
        }
    }
}