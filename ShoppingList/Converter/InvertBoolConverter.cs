﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace ShoppingList.Converter
{
    /// <summary>
    /// Инвертировать флага
    /// </summary>
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
