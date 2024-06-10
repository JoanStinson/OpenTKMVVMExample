using ExampleRenderTest.ViewModel;
using System.Windows.Controls;

namespace ExampleRenderTest.View
{
    public partial class Slot1View : UserControl
    {
        public Slot1ViewModel ViewModel { get; }

        public Slot1View(Slot1ViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
            ViewModel.View = this;
        }
    }
}