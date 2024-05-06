using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.ObjectModel;
using ColorPicker.ColorCore;
using System;
using Avalonia;
using System.Collections.Generic;
using DynamicData;
using Avalonia.Interactivity;

namespace ColorPicker.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            StandInInit();
        }

        public ObservableCollection<CoreColors> BaseColor 
        { 
            get => _BaseColor;
            set { _BaseColor = value; OnPropertyChanged(nameof(BaseColor)); }
        }
        public ObservableCollection<CoreColors> _BaseColor { get; set; } = [];

        public ObservableCollection<CoreColors> BaseColorZero
        {
            get => _BaseColorZero;
            set { _BaseColorZero = value; OnPropertyChanged(nameof(BaseColorZero)); }
        }
        public ObservableCollection<CoreColors> _BaseColorZero { get; set; } = [];

        public CoreColors SelectedColor { get; set; }

        private void StandInInit()
        {
            BaseColor.Add(new CoreColors("rgb(255, 56, 80)"));
            BaseColor.Add(new CoreColors("#F08080"));
            BaseColor.Add(new CoreColors("#FA8072"));
            BaseColor.Add(new CoreColors("#E9967A"));
            BaseColor.Add(new CoreColors("#FF0000"));
            BaseColor.Add(new CoreColors("#8B0000"));
            BaseColor.Add(new CoreColors("#FFC0CB"));
            BaseColor.Add(new CoreColors("#FF69B4"));
            BaseColor.Add(new CoreColors("#C71585"));
            BaseColor.Add(new CoreColors("#FFA07A"));
            BaseColor.Add(new CoreColors("#FF7F50"));
            BaseColor.Add(new CoreColors("#FF4500"));
            BaseColor.Add(new CoreColors("#FFA500"));
            BaseColor.Add(new CoreColors("#FFFF00"));
            BaseColor.Add(new CoreColors("#FFFACD"));
            BaseColor.Add(new CoreColors("#FFEFD5"));
            BaseColor.Add(new CoreColors("#FFDAB9"));
            BaseColor.Add(new CoreColors("#F0E68C"));
            BaseColor.Add(new CoreColors("#D8BFD8"));
            BaseColor.Add(new CoreColors("#EE82EE"));
            BaseColor.Add(new CoreColors("#FF00FF"));
            BaseColor.Add(new CoreColors("#BA55D3"));
            BaseColor.Add(new CoreColors("#8A2BE2"));
            BaseColor.Add(new CoreColors("#9932CC"));
            BaseColor.Add(new CoreColors("#800080"));
            BaseColor.Add(new CoreColors("#6A5ACD"));
            BaseColor.Add(new CoreColors("#FFEBCD"));
            BaseColor.Add(new CoreColors("#FFDEAD"));
            BaseColor.Add(new CoreColors("#D2B48C"));
            BaseColor.Add(new CoreColors("#DAA520"));
            BaseColor.Add(new CoreColors("#CD853F"));
            BaseColor.Add(new CoreColors("#8B4513"));
            BaseColor.Add(new CoreColors("#A52A2A"));
            BaseColor.Add(new CoreColors("#ADFF2F"));
            BaseColor.Add(new CoreColors("#7CFC00"));
            BaseColor.Add(new CoreColors("#00FF00"));
            BaseColor.Add(new CoreColors("#32CD32"));
            BaseColor.Add(new CoreColors("#00FA9A"));
            BaseColor.Add(new CoreColors("#3CB371"));
            BaseColor.Add(new CoreColors("#006400"));
            BaseColor.Add(new CoreColors("#556B2F"));
            BaseColor.Add(new CoreColors("#808000"));
            BaseColor.Add(new CoreColors("#66CDAA"));
            BaseColor.Add(new CoreColors("#008B8B"));
            BaseColor.Add(new CoreColors("#00FFFF"));
            BaseColor.Add(new CoreColors("#E0FFFF"));
            BaseColor.Add(new CoreColors("#AFEEEE"));
            BaseColor.Add(new CoreColors("#40E0D0"));
            BaseColor.Add(new CoreColors("#5F9EA0"));
            BaseColor.Add(new CoreColors("#B0E0E6"));
            BaseColor.Add(new CoreColors("#1E90FF"));
            BaseColor.Add(new CoreColors("#7B68EE"));
            BaseColor.Add(new CoreColors("#0000FF"));
            BaseColor.Add(new CoreColors("#00008B"));
            BaseColor.Add(new CoreColors("#191970"));
            BaseColor.Add(new CoreColors("#FFFAFA"));
            BaseColor.Add(new CoreColors("#F0FFF0"));
            BaseColor.Add(new CoreColors("#F0FFFF"));
            BaseColor.Add(new CoreColors("#FFF5EE"));
            BaseColor.Add(new CoreColors("#FFFAF0"));
            BaseColor.Add(new CoreColors("#FAEBD7"));
            BaseColor.Add(new CoreColors("#FFF0F5"));
            BaseColor.Add(new CoreColors("#DCDCDC"));
            BaseColor.Add(new CoreColors("#D3D3D3"));
            BaseColor.Add(new CoreColors("#C0C0C0"));
            BaseColor.Add(new CoreColors("#A9A9A9"));
            BaseColor.Add(new CoreColors("#808080"));
            BaseColor.Add(new CoreColors("#696969"));
            BaseColor.Add(new CoreColors("#778899"));
            BaseColor.Add(new CoreColors("#708090"));
            BaseColor.Add(new CoreColors("#2F4F4F"));
            BaseColor.Add(new CoreColors("#2F4F4F"));
            BaseColor.Add(new CoreColors("#000000"));
        }

        private void LoadDefaultColor(object sender, RoutedEventArgs args)
        {

        }

        private Avalonia.Point _Pos;
        private Avalonia.Point Pos
        {
            get { return _Pos; }
            set
            {
                if (_Pos != value)
                {
                    _Pos = value;
                    OnPropertyChanged(nameof(Pos));
                }
            }
        }

        public CoreColorsRGBA UpdateRGBA(Point data)
        {
            Pos = data;
            
            return SetColor();
        }

        private CoreColorsRGBA SelectedRGBA = new CoreColorsRGBA(255, 0, 0, 255);

        public string _SelectedCoreColor = "#F256BC";
        public string SelectedCoreColor
        {
            get => _SelectedCoreColor;
            set
            {
                if (_SelectedCoreColor != value)
                {
                    _SelectedCoreColor = value;
                    OnPropertyChanged(nameof(SelectedCoreColor));
                }
            }
        }

        private CoreColorsRGBA SetColor()
        {
            int r, g, b;

            if (Pos.X < 85)
            {
                r = 255;

                g = (int)Pos.X * 3;

                b = 0;
            }
            else if (Pos.X < 170)
            {
                r = 255 - ((int)Pos.X - 85) * 3;

                g = 255;

                b = ((int)Pos.X - 85) * 3;
            }
            else
            {
                r = ((int)Pos.X - 170) * 3;

                g = 255 - ((int)Pos.X - 170) * 3;

                b = 255;
            }

            return SelectedRGBA = new CoreColorsRGBA(r, g, b, 255);
        }
    }
}
