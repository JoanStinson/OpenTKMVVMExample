using ExampleRenderTest.View;
using ExampleRenderTest.Model;
using OpenTK.Wpf;
using System;
using System.ComponentModel;
using System.Windows;

namespace ExampleRenderTest.ViewModel
{
    public class TriangleViewModel
    {
        public GLWpfControl GLWpfControl => View.gl_control;
        public TriangleModel Model { get; } = new TriangleModel();
        public Slot1ViewModel Slot1ViewModel { get; set; }
        public Slot2ViewModel Slot2ViewModel { get; set; }
        public Slot3ViewModel Slot3ViewModel { get; set; }
        public Slot4ViewModel Slot4ViewModel { get; set; }

        public MainView View
        {
            get => view;
            set
            {
                view = value;
                Initialize();
            }
        }

        private bool disposed;
        private MainView view;

        public TriangleViewModel()
        {
            Slot1ViewModel = new Slot1ViewModel();
            Slot2ViewModel = new Slot2ViewModel();
            Slot3ViewModel = new Slot3ViewModel();
            Slot4ViewModel = new Slot4ViewModel();
        }

        private void Initialize()
        {
            if (GLWpfControl == null)
            {
                return;
            }

            Window window = Window.GetWindow(View);
            window.Closing += new CancelEventHandler(GLWpfControlOnDestroy);
            GLWpfControl.SizeChanged += new SizeChangedEventHandler(GLWpfControlOnSizeChanged);
            GLWpfControl.Render += GLWpfControlOnRender;

            GLWpfControl.Start
            (
                new GLWpfControlSettings()
                {
                    MajorVersion = 4,
                    MinorVersion = 6,
                    GraphicsContextFlags = OpenTK.Windowing.Common.ContextFlags.Default | OpenTK.Windowing.Common.ContextFlags.Debug,
                }
            );

            Model.Create();
        }

        protected void GLWpfControlOnDestroy(object sender, EventArgs e)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            Model.Dispose(true);
        }

        protected void GLWpfControlOnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Model.Resize(e.NewSize);
        }

        protected void GLWpfControlOnRender(System.TimeSpan timeSpan)
        {
            Model.Render();
        }
    }
}
