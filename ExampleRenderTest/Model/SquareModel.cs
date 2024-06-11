using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class SquareModel : BaseGeometryModel
    {
        protected override float[] GetVertices() => new float[]
        {
            // x     y     z       r    g     b    
            -0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f, // Bottom left
             0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f, // Bottom right
             0.5f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f, // Top right
            -0.5f,  0.5f, 0.0f,  1.0f, 1.0f, 0.0f  // Top left
        };

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }
    }
}
