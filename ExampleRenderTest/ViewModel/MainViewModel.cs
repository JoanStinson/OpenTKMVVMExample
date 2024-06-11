using ExampleRenderTest.Model;

namespace ExampleRenderTest.ViewModel
{
    public class MainViewModel
    {
        public SlotViewModel Slot1ViewModel { get; }
        public SlotViewModel Slot2ViewModel { get; }
        public SlotViewModel Slot3ViewModel { get; }
        public SlotViewModel Slot4ViewModel { get; }

        public MainViewModel()
        {
            Slot1ViewModel = new SlotViewModel(new TriangleModel());
            Slot2ViewModel = new SlotViewModel(new RectangleModel());
            Slot3ViewModel = new SlotViewModel(new SquareModel());
            Slot4ViewModel = new SlotViewModel(new CircleModel());
        }
    }
}
