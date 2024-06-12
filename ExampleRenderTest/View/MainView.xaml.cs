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

            BottomLeftXTextBox.Text = "-0.6";
            BottomLeftYTextBox.Text = "-0.525";
            BottomRightXTextBox.Text = "0.6";
            BottomRightYTextBox.Text = "-0.525";
            TopCenterXTextBox.Text = "0";
            TopCenterYTextBox.Text = "0.525";
            
            CreateTriangleButton.Click += CreateTriangleButton_Click;
        }

        private void CreateTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: error checking
            Vector2 bottomLeft = new Vector2(float.Parse(BottomLeftXTextBox.Text), float.Parse(BottomLeftYTextBox.Text));
            Vector2 bottomRight = new Vector2(float.Parse(BottomRightXTextBox.Text), float.Parse(BottomRightYTextBox.Text));
            Vector2 topCenter = new Vector2(float.Parse(TopCenterXTextBox.Text), float.Parse(TopCenterYTextBox.Text));
            mainViewModel.UpdateSlot1Model(bottomLeft, bottomRight, topCenter);
        }
    }
}