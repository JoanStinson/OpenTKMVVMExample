using ExampleRenderTest.View;
using OpenTK.Wpf;
using System;
using System.ComponentModel;
using System.Windows;

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
