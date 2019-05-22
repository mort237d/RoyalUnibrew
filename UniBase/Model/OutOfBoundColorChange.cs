using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UniBase.Model
{
    public static class OutOfBoundColorChange
    {
        private static SolidColorBrush colorBrush;
        
        /// <summary>
        /// Changes the color of the textboxes that are below the minimum or above the maximum.
        /// </summary>
        /// <param name="textValue"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static SolidColorBrush ChangeListViewColor(double textValue, double minValue, double maxValue)
        {
            //If the textbox value is out of the range, change color to lightSalmon
            if (textValue < minValue || textValue > maxValue)
            {
                colorBrush = new SolidColorBrush(Colors.LightSalmon);
                return colorBrush;
            }
            //Else set color to white.
            else
            {
                colorBrush = new SolidColorBrush(Colors.White);
                return colorBrush;
            }
        }

        
    }
}
