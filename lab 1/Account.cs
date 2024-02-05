using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Account
    {
        private decimal _balance;
        private List<INotifyer> _notifyer;

        public Account()
        {
            _balance = 0;
            _notifyer = new List<INotifyer>();
        }

        public Account(decimal balance)
        {
            _balance = balance;
            _notifyer = new List<INotifyer>();
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
}