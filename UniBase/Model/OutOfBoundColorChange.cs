using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UniBase.Model
{
    public class OutOfBoundColorChange
    {
        private SolidColorBrush colorBrush;

        public SolidColorBrush ChangeListViewColor(double textValue, double minValue, double maxValue)
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
