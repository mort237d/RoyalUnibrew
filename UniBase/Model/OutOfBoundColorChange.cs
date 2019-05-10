using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using UniBase.Annotations;
using UniBase.Model.K2;

namespace UniBase.Model
{
    class OutOfBoundColorChange
    {
        private Brush colorBrush;

        public Brush ChangeListViewColor(double textValue, double minValue, double maxValue)
        {
            if (textValue < minValue || textValue > maxValue)
            {
                colorBrush = new SolidColorBrush(Colors.LightSalmon);
                return colorBrush;
            }
            else
            {
                colorBrush = new SolidColorBrush(Colors.White);
                return colorBrush;
            }
        }

        
    }
}
