using System;
using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class CircleModel : BaseGeometryModel
    {
        private const int numberOfVertices = 50;
        private const float circleRadius = 0.5f;

        protected override float[] GetVertices()
        {
            float[] vertices = new float[(numberOfVertices + 2) * 6]; // Each vertex has 6 components (x, y, z, r, g, b)

            // Center vertex (color: red)
            vertices[0] = 0.0f; // x
            vertices[1] = 0.0f; // y
            vertices[2] = 0.0f; // z
            vertices[3] = 1.0f; // Color: Red
            vertices[4] = 0.0f; // Color: Green
            vertices[5] = 0.0f; // Color: Blue

            // Calculate other vertices with gradient color from light to dark red
            for (int i = 0; i <= numberOfVertices; i++)
            {
                float angle = (float)(2 * Math.PI * i / numberOfVertices);
                float redComponent = 1.0f - Math.Abs((float)Math.Sin(angle));      // Red component gradient from light to dark
                vertices[(i + 1) * 6] = circleRadius * (float)Math.Cos(angle);     // x
                vertices[(i + 1) * 6 + 1] = circleRadius * (float)Math.Sin(angle); // y
                vertices[(i + 1) * 6 + 2] = 0.0f;                                  // z
                vertices[(i + 1) * 6 + 3] = redComponent;                          // Color: Red (gradient)
                vertices[(i + 1) * 6 + 4] = 0.0f;                                  // Color: Green (constant)
                vertices[(i + 1) * 6 + 5] = 0.0f;                                  // Color: Blue (constant)
            }

            return vertices;
        }

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, numberOfVertices + 2);
        }
    }
}
