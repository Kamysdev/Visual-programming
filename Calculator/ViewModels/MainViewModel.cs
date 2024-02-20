using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Calculator.Models;

namespace Calculator.ViewModels;

class Calculator
{
    private double? _lastVal = null;
    private Operators? _lastOp = null;

    Dictionary<Operators, Func<double, double, double>> _operators = new Dictionary<Operators, Func<double, double, double>>() {
        {Operators.MUL, (a, b) => a * b },
        {Operators.PLUS, (a, b) => a + b },
        {Operators.MINUS, (a, b) => b - a  },
        {Operators.DIV, (double a, double b) => {
            if(a == 0) throw new ArgumentException("Division By Zero");
            return ((double)b / a);
        } },
        {Operators.MOD, (a, b) => a % b },
        {Operators.FACTORIAL, (a, _) => CalculateFactorial(a) },
        {Operators.POW, (double a, double b) => Math.Pow((double)b, a)},
        {Operators.LG, (a, _) => Math.Log10(a) },
        {Operators.LN, (a, _) => Math.Log(a) },
        {Operators.SIN, (a, _) => Math.Sin(a) },
        {Operators.COS, (a, _) => Math.Cos(a) },
        {Operators.TAN, (a, _) => Math.Tan(a) },
        {Operators.FLOOR, (a, _) => Math.Floor(a) },
        {Operators.CEIL, (a, _) => Math.Ceiling(a) }
    };

    private static double CalculateFactorial(double n)
    {
        if (n == 0)
            return 1;
        else
            return n * CalculateFactorial(n - 1);
    }

    public bool HasOperand()
    {
        return _lastVal != null;
    }

    public void SetOperand(double val)
    {
        _lastVal = val;
    }

    public void SetOperator(Operators op)
    {
        if (_operators.ContainsKey(op) == false) throw new Exception("Operator not found");

        _lastOp = op;
    }

    public double Calculate(double val)
    {
        if (_lastOp is null) return 0;
        _lastVal = _operators[(Operators)_lastOp](val, _lastVal ?? 0);
        return _lastVal ?? 0;
    }

    public void Clear()
    {
        this._lastOp = null;
        this._lastVal = null;
    }
}

public class MainViewModel : INotifyPropertyChanged
{
    private readonly Calculator _calc;
    private string _lastOp = "";
    private string _valStr = "";
    private string _resultStr = "";

    private bool addDot = false;

    public string ValStr
    {
        get => _valStr;
        set { _valStr = value; OnPropertyChanged(nameof(ValStr)); }
    }

    public string ResultStr
    {
        get => _resultStr;
        set { _resultStr = value; OnPropertyChanged(nameof(ResultStr)); }
    }

    public string LastOp
    {
        get => _lastOp;
        set { _lastOp = value; OnPropertyChanged(nameof(LastOp)); }
    }

    public MainViewModel()
    {
        _calc = new Calculator();
    }

    public void Clear()
    {
        ValStr = "";
        ResultStr = "";
        _calc.Clear();
    }

    public void RemoveDigit(object? param)
    {
        if (param == null || param is not string) return;

        if (!string.IsNullOrEmpty(ValStr))
        {
            ValStr.Remove(ValStr.Length - 1);
        }
    }

    public void AppendDigit(object? param)
    {
        if (param == null || param is not string) return;
        string operand = (string)param;

        if (operand != ",")
        {
            ValStr += operand;
            return;
        }
        if (operand == "," && !addDot)
        {
            ValStr += operand;
            addDot = true;
        }

    }

    public void Calc(object? param)
    {
        if (param == null || param is not string) return;
        string operand = (string)param;

        bool parseResult = double.TryParse(ValStr, out double val);
        if (parseResult == false) return;

        if (_calc.HasOperand() == false)
            _calc.SetOperand(val);

        if (operand != "=") LastOp = operand;

        try
        {
            //Rewrite to switch case
            switch (operand)
            {
                case "*":
                    _calc.SetOperator(Operators.MUL);
                    ValStr = "";
                    addDot = false;
                    break;
                case "+":
                    _calc.SetOperator(Operators.PLUS);
                    ValStr = "";
                    addDot = false;
                    break;
                case "-":
                    _calc.SetOperator(Operators.MINUS);
                    ValStr = "";
                    addDot = false;
                    break;
                case "/":
                    _calc.SetOperator(Operators.DIV);
                    ValStr = "";
                    addDot = false;
                    break;
                case "mod":
                    _calc.SetOperator(Operators.MOD);
                    ValStr = "";
                    addDot = false;
                    break;
                case "x^y":
                    _calc.SetOperator(Operators.POW);
                    ValStr = "";
                    addDot = false;
                    break;
                case "n!": _calc.SetOperator(Operators.FACTORIAL); ValStr = ""; addDot = false; break;
                case "lg": _calc.SetOperator(Operators.LG); ValStr = ""; addDot = false; break;
                case "ln": _calc.SetOperator(Operators.LN); ValStr = ""; addDot = false; break;
                case "sin": _calc.SetOperator(Operators.SIN); ValStr = ""; addDot = false; break;
                case "cos": _calc.SetOperator(Operators.COS); ValStr = ""; addDot = false; break;
                case "tan": _calc.SetOperator(Operators.TAN); ValStr = ""; addDot = false; break;
                case "floor": _calc.SetOperator(Operators.FLOOR); ValStr = ""; addDot = false; break;
                case "ceil": _calc.SetOperator(Operators.CEIL); ValStr = ""; addDot = false; break;
                case "=":
                    {
                        ResultStr = _calc.Calculate(val).ToString();
                        ValStr = ResultStr;
                        addDot = false;
                        break;
                    }
                default:
                    ResultStr = "Invalid operation";
                    break;
            };
        }
        catch (Exception e)
        {
            ResultStr = e.Message;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}