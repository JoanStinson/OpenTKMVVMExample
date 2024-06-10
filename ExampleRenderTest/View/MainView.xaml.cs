using System.Windows;
using ExampleRenderTest.ViewModel;

namespace ExampleRenderTest.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            if (DataContext is TriangleViewModel view_model)
            {
                view_model.View = this;
            }
        }

        public void buttonSetBGColor_Click(object sender, RoutedEventArgs e)
        {

        }

        public void buttonSetTRColor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
