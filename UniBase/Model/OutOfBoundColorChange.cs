using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UniBase.Model
{
    public class OutOfBoundColorChange
    {
        private SolidColorBrush _colorBrush;

        public SolidColorBrush ChangeListViewColor(double textValue, double minValue, double maxValue)
        {
            if (textValue < minValue || textValue > maxValue)
            {
                _colorBrush = new SolidColorBrush(Colors.LightSalmon);
                return _colorBrush;
            }
            else
            {
                _colorBrush = new SolidColorBrush(Colors.White);
                return _colorBrush;
            }
        }

        
    }
}
