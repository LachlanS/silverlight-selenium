using System.Windows;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    public partial class ModalWindow
    {
        public ModalWindow(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
            WindowTracker.Instance().Track(this);
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
