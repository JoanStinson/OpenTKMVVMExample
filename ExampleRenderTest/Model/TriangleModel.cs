using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class TriangleModel : BaseGeometryModel
    {
        protected override float[] GetVertices() => new float[]
        {
            // x        y       z      r     g     b    
            -0.6f, -0.525f, 0.0f,  1.0f, 0.0f, 0.0f, // Bottom-left
             0.6f, -0.525f, 0.0f,  1.0f, 1.0f, 0.0f, // Bottom-right
             0.0f,  0.525f, 0.0f,  0.0f, 0.0f, 1.0f  // Top-center
        };

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }
}
