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
            Slot1ContentControl.Content = new SlotView(mainViewModel.Slot1ViewModel);
            Slot2ContentControl.Content = new SlotView(mainViewModel.Slot2ViewModel);
            Slot3ContentControl.Content = new SlotView(mainViewModel.Slot3ViewModel);
            Slot4ContentControl.Content = new SlotView(mainViewModel.Slot4ViewModel);
        }
    }
}
