using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Account
    {
        private decimal _balance;
        private List<INotifyer> _notifyer;

        public Account()
        {
            _balance = 0;
            _notifyer = [];

        }

        public Account(decimal balance)
        {
            _balance = balance;
            _notifyer = [];

        }

        public void AddNotifyer(INotifyer notifyer)
        {
            _notifyer.Add(notifyer);
        }

        public void ChangeBalance(decimal value)
        {
            _balance += value;
            Notification();
        }

        public decimal Balance()
        {
            return _balance;
        }

        private void Notification()
        {
            foreach (var INotifyer in _notifyer)
            {
                INotifyer.Notify(_balance);
            }
        }
    }

    public interface INotifyer
    {
        void Notify(decimal _balance);
    }

    class SMSLowBalanceNotifyer : INotifyer
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
            if (_balance < _lowBalanceValue)
            {
                Console.WriteLine("SMSLowBalanceNotifyer");
                Console.WriteLine(_phone);
                Console.WriteLine($"SMS: У вас мало средств на вашем балансе! Текущий баланс составляет {_balance}");
            }
        }
    }

    class EMailBalanceChangedNotifyer : INotifyer
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
            Console.WriteLine($"Алёрт! Стипендия пришла! Текущий баланс {_balance}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            EMailBalanceChangedNotifyer emailNotification = new EMailBalanceChangedNotifyer("work.kamysdev@gmail.com");
            SMSLowBalanceNotifyer smsNotification = new SMSLowBalanceNotifyer("+79832516744", 999);

            account.AddNotifyer(emailNotification);
            account.AddNotifyer(smsNotification);
            account.ChangeBalance(1000);
            account.ChangeBalance(1200);

        }
    }
}