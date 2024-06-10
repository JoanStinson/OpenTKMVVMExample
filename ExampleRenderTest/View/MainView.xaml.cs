using ExampleRenderTest.ViewModel;
using System.Windows;

namespace ExampleRenderTest.View
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            var mainViewModel = (MainViewModel)DataContext;
            var slot1View = new Slot1View(mainViewModel.Slot1ViewModel);
            Slot1ContentControl.Content = slot1View;
            var slot2View = new Slot1View(mainViewModel.Slot2ViewModel);
            Slot2ContentControl.Content = slot2View;
            var slot3View = new Slot1View(mainViewModel.Slot3ViewModel);
            Slot3ContentControl.Content = slot3View;
            var slot4View = new Slot1View(mainViewModel.Slot4ViewModel);
            Slot4ContentControl.Content = slot4View;
        }

        public void buttonSetBGColor_Click(object sender, RoutedEventArgs e)
        {

        }

        public void buttonSetTRColor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
