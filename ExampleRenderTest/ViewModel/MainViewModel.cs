using ExampleRenderTest.Model;

namespace ExampleRenderTest.ViewModel
{
    public class MainViewModel
    {
        public Slot1ViewModel Slot1ViewModel { get; }

        public MainViewModel()
        {
            Slot1ViewModel = new Slot1ViewModel();
        }
    }
}
