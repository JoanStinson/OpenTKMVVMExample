using System.Windows;
using OpenTK_hello_triangle_WPF.ViewModel;

namespace OpenTK_hello_triangle_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HelloTriangleView : Window
    {
        public HelloTriangleView()
        {
            InitializeComponent();
            if (DataContext is HelloTriangleViewModel view_model)
                view_model.View = this;
        }

        public void buttonSetBGColor_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new System.Windows.Forms.ColorDialog();

            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    GL.ClearColor(dialog.Color);
            //    glControl.Invalidate();
            //}

        }

        public void buttonSetTRColor_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new System.Windows.Forms.ColorDialog();

            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    float r = dialog.Color.R / 255f;
            //    float g = dialog.Color.G / 255f;
            //    float b = dialog.Color.B / 255f;
            //    GL.Uniform3(_uColorLocation, r, g, b);
            //    glControl.Invalidate();
            //}
        }
    }
}
