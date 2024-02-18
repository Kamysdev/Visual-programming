using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Calculator.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void MyClick(object sender, EventArgs e)
    {
        Console.WriteLine("123");
    }
}
