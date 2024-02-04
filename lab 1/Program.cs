
using System.ComponentModel.DataAnnotations;

class Account
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
            Notify(_balance);
        }
    }
}

class INotifyer : Account
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
            Console.WriteLine($"SMS: У вас мало средств на вашем балансе! Текущий баланс составляет {_phone}");
        }
    }
}

class EMailBalanceChangedNotifyer
{
    private string _email;

    public EMailBalanceChangedNotifyer(string email)
    {
        _email = email;
    }

    public void Notify(string _balance) 
    {
        Console.WriteLine("EMailBalanceChangedNotifyer");
        Console.WriteLine(_email);
    }


}

