using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UniBase.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkPage : Page
    {
    public WorkPage()
        {
            this.InitializeComponent();
            #region TitleBar

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.BackgroundColor = Color.FromArgb(1, 22, 80, 63);
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Color.FromArgb(1, 22, 80, 63);

            #endregion
        }

        
    }
}
