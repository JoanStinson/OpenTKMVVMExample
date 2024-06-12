using ExampleRenderTest.Model;
using ExampleRenderTest.Model.Helpers;
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
                    window.Closing += new CancelEventHandler(Destroy);
                }
            }
        }

        private SlotView view;
        private Window window;
        private bool destroyed;

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
                ContextFlags = OpenTK.Windowing.Common.ContextFlags.Default | OpenTK.Windowing.Common.ContextFlags.Debug
            };
            GLControl.Start(settings);
            GLControl.Render += Render;
            Model.Initialize(new DefaultProgramBuilder(), new DefaultShaderCode());
        }

        private void Render(TimeSpan timeSpan)
        {
            Model.Render();
        }

        private void Destroy(object sender, EventArgs e)
        {
            if (destroyed)
            {
                return;
            }

            Model.Destroy();
            destroyed = true;
        }

        public void UpdateModel(IGeometryModel model)
        {
            GLControl.Render -= Render;
            Model.Destroy();
            Model = model;
            Model.Initialize(new DefaultProgramBuilder(), new DefaultShaderCode());
            GLControl.Render += Render;
            destroyed = false;
        }
    }
}
