using ExampleRenderTest.View;
using ExampleRenderTest.Model;
using OpenTK.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ExampleRenderTest.ViewModel
{
    public class TriangleViewModel
    {
        private bool disposed;
        TriangleView view;

        public TriangleView View
        {
            get => view;
            set
            {
                view = value;
                Initialize();
            }
        }

        public GLWpfControl GLWpfControl => View.gl_control;

        public TriangleModel Model { get; } = new TriangleModel();

        void Initialize()
        {
            if (GLWpfControl == null)
                return;

            Window window = Window.GetWindow(View);
            window.Closing += new CancelEventHandler(GLWpfControlOnDestroy);
            GLWpfControl.SizeChanged += new SizeChangedEventHandler(GLWpfControlOnSiceChanged);
            GLWpfControl.Render += GLWpfControlOnRendder;

            GLWpfControl.Start(
                new GLWpfControlSettings()
                {
                    MajorVersion = 4,
                    MinorVersion = 6,
                    GraphicsContextFlags = OpenTK.Windowing.Common.ContextFlags.Default | OpenTK.Windowing.Common.ContextFlags.Debug,
                });

            Model.Create();
        }

        protected void GLWpfControlOnDestroy(object sender, EventArgs e)
        {
            if (disposed)
                return;
            disposed = true;
            Model.Dispose(true);
        }

        protected void GLWpfControlOnSiceChanged(object sender, SizeChangedEventArgs e)
        {
            Model.Resize(e.NewSize);
        }

        protected void GLWpfControlOnRendder(System.TimeSpan timespawn)
        {
            Model.Render();
        }
    }
}
