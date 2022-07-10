using System.Windows.Controls;

namespace Crater.UI.Controls
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}