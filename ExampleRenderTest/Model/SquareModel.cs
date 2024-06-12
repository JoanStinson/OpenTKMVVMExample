using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ExampleRenderTest.Model
{
    public class SquareModel : BaseGeometryModel
    {
        public SquareModel()
        {
            vertices = new float[]
            {
                // x     y     z       r    g     b    
                -0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f, // Bottom left
                 0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f, // Bottom right
                 0.5f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f, // Top right
                -0.5f,  0.5f, 0.0f,  1.0f, 1.0f, 0.0f  // Top left
            };
        }

        public SquareModel(Vector2 bottomLeft, Vector2 topRight)
        {
            vertices = new float[]
            {
                //   x             y         z      r     g     b    
                bottomLeft.X, bottomLeft.Y, 0.0f,  1.0f, 0.0f, 0.0f, // Bottom left
                topRight.X,   bottomLeft.Y, 0.0f,  0.0f, 1.0f, 0.0f, // Bottom right
                topRight.X,   topRight.Y,   0.0f,  0.0f, 0.0f, 1.0f, // Top right
                bottomLeft.X, topRight.Y,   0.0f,  1.0f, 1.0f, 0.0f  // Top left
            };
        }

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }
    }
}
