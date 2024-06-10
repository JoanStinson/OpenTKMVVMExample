using ExampleRenderTest.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ExampleRenderTest.View
{
    public partial class Slot1 : UserControl
    {
        public Slot1()
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
