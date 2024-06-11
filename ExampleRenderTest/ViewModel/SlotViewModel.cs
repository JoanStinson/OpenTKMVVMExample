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
        public GLWpfControl GLControl => View.GLControl;
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

            var settings = new GLWpfControlSettings()
            {
                MajorVersion = 4,
                MinorVersion = 6,
                ContextFlags = OpenTK.Windowing.Common.ContextFlags.Default | OpenTK.Windowing.Common.ContextFlags.Debug,
            };
            GLControl.Start(settings);
            GLControl.Render += GLWpfControlOnRender;

            Model.Create();
        }

        protected void GLWpfControlOnRender(TimeSpan timeSpan)
        {
            Model.Render();
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
