using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class TriangleModel : BaseGeometryModel
    {
        protected override float[] GetVertices() => new float[]
        {
            // x        y      z      r     g     b    
            -0.866f, -0.75f, 0.0f,  1.0f, 0.0f, 0.0f,
             0.866f, -0.75f, 0.0f,  1.0f, 1.0f, 0.0f,
             0.0f,    0.75f, 0.0f,  0.0f, 0.0f, 1.0f,   
        };

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }
}
