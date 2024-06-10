using System.Windows;

namespace ExampleRenderTest.Model
{
    public interface IGeometryModel
    {
        void Create();
        void Render();
        void Resize(Size newSize);
        void Dispose(bool dispose);
    }
}