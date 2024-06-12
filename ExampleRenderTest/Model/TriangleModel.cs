using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ExampleRenderTest.Model
{
    public class TriangleModel : BaseGeometryModel
    {
        public TriangleModel()
        {
            vertices = new float[]
            {
                // x     y      z     r     g     b    
               -0.6f, -0.525f, 0.0f, 1.0f, 0.0f, 0.0f, // Bottom left
                0.6f, -0.525f, 0.0f, 1.0f, 1.0f, 0.0f, // Bottom right
                0.0f,  0.525f, 0.0f, 0.0f, 0.0f, 1.0f  // Top center
            };
        }

        public TriangleModel(Vector2 bottomLeft, Vector2 bottomRight, Vector2 topCenter)
        {
            vertices = new float[]
            {
                //   x             y          z     r     g     b               
               bottomLeft.X,  bottomLeft.Y,  0.0f, 1.0f, 0.0f, 0.0f, // Bottom left
               bottomRight.X, bottomRight.Y, 0.0f, 1.0f, 1.0f, 0.0f, // Bottom right
               topCenter.X,   topCenter.Y,   0.0f, 0.0f, 0.0f, 1.0f  // Top center
            };
        }

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }
}
