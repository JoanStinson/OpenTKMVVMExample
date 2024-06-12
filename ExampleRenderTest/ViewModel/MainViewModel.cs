using ExampleRenderTest.Model;
using OpenTK.Mathematics;

namespace ExampleRenderTest.ViewModel
{
    public sealed class MainViewModel
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

        public void UpdateSlot1Model(Vector2 bottomLeft, Vector2 bottomRight, Vector2 topCenter)
        {
            var newTriangleModel = new TriangleModel(bottomLeft, bottomRight, topCenter);
            Slot1ViewModel.UpdateModel(newTriangleModel);
        }

        public void UpdateSlot2Model(Vector2 bottomLeft, Vector2 topRight)
        {
            var newRectangleModel = new RectangleModel(bottomLeft, topRight);
            Slot2ViewModel.UpdateModel(newRectangleModel);
        }
    }
}
