using System.Windows;

namespace ExampleRenderTest.Model
{
    public interface IGeometryModel
    {
        void Initialize();
        void Render();
        void Destroy();
    }
}