using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UniBase.Model
{
    public static class OutOfBoundColorChange
    {
        private static SolidColorBrush colorBrush;

        public static SolidColorBrush ChangeListViewColor(double textValue, double minValue, double maxValue)
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
