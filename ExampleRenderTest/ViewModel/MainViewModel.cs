using ExampleRenderTest.Model;

namespace ExampleRenderTest.ViewModel
{
    public class MainViewModel
    {
        public Slot1ViewModel Slot1ViewModel { get; }
        public Slot1ViewModel Slot2ViewModel { get; }
        public Slot1ViewModel Slot3ViewModel { get; }
        public Slot1ViewModel Slot4ViewModel { get; }

        public MainViewModel()
        {
            Slot1ViewModel = new Slot1ViewModel();
            Slot2ViewModel = new Slot1ViewModel();
            Slot3ViewModel = new Slot1ViewModel();
            Slot4ViewModel = new Slot1ViewModel();
        }
    }
}
