using System.Windows;

namespace ExampleRenderTest.Model
{
    public interface IGeometryModel
    {
        void Create();
        void Render();
        void Dispose(bool dispose);
    }
}