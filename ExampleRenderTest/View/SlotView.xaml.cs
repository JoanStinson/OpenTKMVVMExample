using ExampleRenderTest.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ExampleRenderTest.View
{
    public partial class SlotView : UserControl
    {
        public SlotViewModel ViewModel { get; }

        public SlotView(SlotViewModel viewModel, Window window)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
            ViewModel.Window = window;
            ViewModel.View = this;
        }
    }
}