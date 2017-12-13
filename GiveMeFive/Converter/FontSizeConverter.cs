using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GiveMeFive.Converter
{

    /// <summary>
    /// 用于动态转换中心字体大小
    /// </summary>
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double gridHeight = (double)value;
                double fontSize = 24d / 240d * gridHeight;
                return fontSize;
            }
            catch (System.Exception ex)
            {
                return 30;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int Cutoff { get; set; }
    }



    /// <summary>
    /// 用于动态转换左下角字体大小
    /// </summary>
    public class FontSizeConverterMini : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double gridHeight = (double)value;
                double fontSize = 10d / 240d * gridHeight;
                return fontSize;
            }
            catch (System.Exception ex)
            {
                return 30;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int Cutoff { get; set; }
    }


    /// <summary>
    /// 用于动态转换左下角字体大小
    /// </summary>
    public class FontSizeConverterMini8 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double gridHeight = (double)value;
                double fontSize = 6d / 240d * gridHeight;
                return fontSize;
            }
            catch (System.Exception ex)
            {
                return 30;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int Cutoff { get; set; }
    }
}
