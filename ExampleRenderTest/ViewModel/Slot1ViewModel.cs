using ExampleRenderTest.Model;
using ExampleRenderTest.View;
using OpenTK.Wpf;
using System;
using System.ComponentModel;
using System.Windows;

namespace ExampleRenderTest.ViewModel
{
    public class Slot1ViewModel
    {
        public GLWpfControl Slot1Control => View.slot1Render;
        public IGeometryModel Model { get; } = new CircleModel();

        public Slot1View View
        {
            get => view;
            set
            {
                view = value;
                Initialize();
            }
        }

        public Window Window
        {
            get => window;
            set
            {
                window = value;
                if (window != null)
                {
                    window.Closing += new CancelEventHandler(GLWpfControlOnDestroy);
                }
            }
        }

        private Slot1View view;
        private Window window;
        private bool disposed;

        private void Initialize()
        {
            if (Slot1Control == null)
            {
                return;
            }

            Slot1Control.Render += GLWpfControlOnRender;
            Slot1Control.SizeChanged += new SizeChangedEventHandler(GLWpfControlOnSizeChanged);
            Slot1Control.Start
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

        protected void GLWpfControlOnRender(System.TimeSpan timeSpan)
        {
            Model.Render();
        }

        protected void GLWpfControlOnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Model.Resize(e.NewSize);
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
    }
}
