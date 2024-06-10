using ExampleRenderTest.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ExampleRenderTest.View
{
    public partial class Slot1View : UserControl
    {
        public Slot1View()
        {
            InitializeComponent();

            if (DataContext is Slot1ViewModel viewModel)
            {
                viewModel.View = this;
                viewModel.Window = Window.GetWindow(this);
            }
        }
    }
}
