using System.Collections.ObjectModel;
using ColorPicker.ColorCore;
using Avalonia;
using Avalonia.Interactivity;
using DynamicData;

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

        public ObservableCollection<CoreColorsRGBA> CustomColor
        {
            get => _CustomColor;
            set { _CustomColor = value; OnPropertyChanged(nameof(CustomColor)); }
        }
        public ObservableCollection<CoreColorsRGBA> _CustomColor { get; set; } = [];

        public CoreColors SelectedColor { get; set; }

        private void StandInInit()
        {
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

        /// <summary>
        /// Реализация методов взаимодействия пользователя 
        /// </summary>

        private void LoadDefaultColor(object sender, RoutedEventArgs args)
        {

        }

        public void AddCustomColor()
        {
            CustomColor.Add(SelectedRGBA);
        }

        /// <summary>
        /// Реализация палитры
        /// </summary>

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

        private CoreColorsRGBA SelectedRGBA;

        private CoreColorsRGBA SetColor()
        {
            int r, g, b, brightness;

            brightness = (int)Pos.Y * 3;


            if (Pos.X < 85)
            {
                r = 255;
                g = (int)Pos.X * 3;
                b = 0;

                if (Pos.Y < 85)
                {
                    brightness = 255 - brightness;
                    g += brightness;
                    b += brightness;
                }
            }
            else if (Pos.X < 170)
            {
                r = 255 - ((int)Pos.X - 85) * 3;
                g = 255;
                b = ((int)Pos.X - 85) * 3;

                if (Pos.Y < 85)
                {
                    brightness = 255 - brightness;
                    r += brightness;
                    b += brightness;
                }
            }
            else
            {
                r = ((int)Pos.X - 170) * 3;
                g = 255 - ((int)Pos.X - 170) * 3;
                b = 255;

                if (Pos.Y < 85)
                {
                    brightness = 255 - brightness;
                    r += brightness;
                    g += brightness;
                }
            }

            if (Pos.Y > 85)
            {
                brightness = ((int)Pos.Y - 85) * 3;
                r -= brightness;
                g -= brightness;
                b -= brightness;
            }

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            return SelectedRGBA = new CoreColorsRGBA(r, g, b, 255);
        }

    }
}
