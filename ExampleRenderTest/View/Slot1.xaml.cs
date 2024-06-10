using ExampleRenderTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleRenderTest.View
{
    /// <summary>
    /// Interaction logic for Slot1.xaml
    /// </summary>
    public partial class Slot1 : UserControl
    {
        public Slot1()
        {
            InitializeComponent();
            DataContext = new Slot1ViewModel(); // Set DataContext to an instance of the view model
            (DataContext as Slot1ViewModel).View = this;
            (DataContext as Slot1ViewModel).Window = Window.GetWindow(this);
            //if (DataContext is Slot1ViewModel viewModel)
            //{
            //    viewModel.View = this; // Set the view property of Slot1ViewModel to this view
            //}
        }
    }
}
