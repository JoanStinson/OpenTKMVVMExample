using ExampleRenderTest.Model.Helpers;

namespace ExampleRenderTest.Model
{
    public interface IGeometryModel
    {
        void Initialize(IProgramBuilder programBuilder, IShaderCode shaderCode);
        void Render();
        void Destroy();
    }
}