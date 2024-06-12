using ExampleRenderTest.ViewModel;
using OpenTK.Mathematics;
using System.Windows;

namespace ExampleRenderTest.View
{
    public partial class MainView : Window
    {
        private readonly MainViewModel mainViewModel;

        public MainView()
        {
            InitializeComponent();
            mainViewModel = (MainViewModel)DataContext;

            Slot1ContentControl.Content = new SlotView(mainViewModel.Slot1ViewModel);
            Slot2ContentControl.Content = new SlotView(mainViewModel.Slot2ViewModel);
            Slot3ContentControl.Content = new SlotView(mainViewModel.Slot3ViewModel);
            Slot4ContentControl.Content = new SlotView(mainViewModel.Slot4ViewModel);

            TriangleBottomLeftXTextBox.Text = "-0.6";
            TriangleBottomLeftYTextBox.Text = "-0.525";
            TriangleBottomRightXTextBox.Text = "0.6";
            TriangleBottomRightYTextBox.Text = "-0.525";
            TriangleTopCenterXTextBox.Text = "0";
            TriangleTopCenterYTextBox.Text = "0.525";
            
            CreateTriangleButton.Click += OnClickCreateTriangleButton;
        }

        private void OnClickCreateTriangleButton(object sender, RoutedEventArgs e)
        {
            //TODO: error checking
            Vector2 bottomLeft = new Vector2(float.Parse(TriangleBottomLeftXTextBox.Text), float.Parse(TriangleBottomLeftYTextBox.Text));
            Vector2 bottomRight = new Vector2(float.Parse(TriangleBottomRightXTextBox.Text), float.Parse(TriangleBottomRightYTextBox.Text));
            Vector2 topCenter = new Vector2(float.Parse(TriangleTopCenterXTextBox.Text), float.Parse(TriangleTopCenterYTextBox.Text));
            mainViewModel.UpdateSlot1Model(bottomLeft, bottomRight, topCenter);
        }
    }
}