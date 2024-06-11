using ExampleRenderTest.Model;
using ExampleRenderTest.View;
using OpenTK.Wpf;
using System;
using System.ComponentModel;
using System.Windows;

namespace ExampleRenderTest.ViewModel
{
    public class SlotViewModel
    {
        public GLWpfControl GLControl => View.glControl;
        public IGeometryModel Model { get; private set; }

        public SlotView View
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

        private SlotView view;
        private Window window;
        private bool disposed;

        public SlotViewModel(IGeometryModel model)
        {
            Model = model;
        }

        private void Initialize()
        {
            if (GLControl == null)
            {
                return;
            }

            GLControl.Render += GLWpfControlOnRender;
            GLControl.SizeChanged += new SizeChangedEventHandler(GLWpfControlOnSizeChanged);
            GLControl.Start
            (
                new GLWpfControlSettings()
                {
                    MajorVersion = 4,
                    MinorVersion = 6,
                    ContextFlags = OpenTK.Windowing.Common.ContextFlags.Default | OpenTK.Windowing.Common.ContextFlags.Debug,
                }
            );

            Model.Create();
        }

        protected void GLWpfControlOnRender(TimeSpan timeSpan)
        {
            Model?.Render();
        }

        protected void GLWpfControlOnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Model?.Resize(e.NewSize);
        }

        protected void GLWpfControlOnDestroy(object sender, EventArgs e)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            Model?.Dispose(true);
        }
    }
}
