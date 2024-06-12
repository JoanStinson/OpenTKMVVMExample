﻿using ExampleRenderTest.ViewModel;
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

            CreateTriangleButton.Click += OnClickCreateTriangleButton;
            CreateRectangleButton.Click += OnClickCreateRectangleButton;
            CreateSquareButton.Click += OnClickCreateSquareButton;
            CreateCircleButton.Click += OnClickCreateCircleButton;
            ReorderButton.Click += OnClickReorderButton;
            RotateButton.Click += OnClickRotateButton;
        }

        private void OnClickCreateTriangleButton(object sender, RoutedEventArgs e)
        {
            Vector2 bottomLeft = new Vector2(float.Parse(TriangleBottomLeftXTextBox.Text), float.Parse(TriangleBottomLeftYTextBox.Text));
            Vector2 bottomRight = new Vector2(float.Parse(TriangleBottomRightXTextBox.Text), float.Parse(TriangleBottomRightYTextBox.Text));
            Vector2 topCenter = new Vector2(float.Parse(TriangleTopCenterXTextBox.Text), float.Parse(TriangleTopCenterYTextBox.Text));
            mainViewModel.UpdateSlot1Model(bottomLeft, bottomRight, topCenter);
        }

        private void OnClickCreateRectangleButton(object sender, RoutedEventArgs e)
        {
            Vector2 bottomLeft = new Vector2(float.Parse(RectangleBottomLeftXTextBox.Text), float.Parse(RectangleBottomLeftYTextBox.Text));
            Vector2 topRight = new Vector2(float.Parse(RectangleTopRightXTextBox.Text), float.Parse(RectangleTopRightYTextBox.Text));
            mainViewModel.UpdateSlot2Model(bottomLeft, topRight);
        }

        private void OnClickCreateSquareButton(object sender, RoutedEventArgs e)
        {

        }

        private void OnClickCreateCircleButton(object sender, RoutedEventArgs e)
        {

        }

        private void OnClickReorderButton(object sender, RoutedEventArgs e)
        {

        }

        private void OnClickRotateButton(object sender, RoutedEventArgs e)
        {

        }
    }
}