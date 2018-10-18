﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Project_D.ViewModels
{
    class DirectionConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var direction = (Direction)value;
            //SymbolIcon icon = new SymbolIcon(Symbol.Accept);
            //FontIcon icon = new FontIcon();
            string icon;
            switch(direction)
            {
                case Direction.Ascendant:
                    //icon.Glyph= "&#xE74B;";
                    icon = "\uE74B";
                    break;
                case Direction.Descendant:
                    //icon.Glyph= "&#xE74A;";
                    icon = "\uE74A";
                    break;
                default:
                    //icon.Glyph = null;
                    icon = null;
                    break;
            }
            return icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
