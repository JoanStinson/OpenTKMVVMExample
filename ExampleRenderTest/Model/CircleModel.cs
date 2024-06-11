using System;
using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class CircleModel : BaseGeometryModel
    {
        private const int numberOfVertices = 600;
        private const float circleRadius = 0.55f;

        protected override float[] GetVertices()
        {
            // Each vertex has x, y, z, r, g, b
            float[] vertices = new float[numberOfVertices * 6];
            const float angleIncrement = (float)(2 * Math.PI / numberOfVertices);

            for (int i = 0; i < numberOfVertices; i++)
            {
                float angle = i * angleIncrement;
                SetVertexPosition(angle, vertices, i);
                SetVertexColor(vertices, i, angle);
            }

            return vertices;
        }

        private void SetVertexPosition(float angle, float[] vertices, int i)
        {
            float xCoordinate = circleRadius * (float)Math.Cos(angle);
            float yCoordinate = circleRadius * (float)Math.Sin(angle);
            const float zCoordinate = 0.0f;

            vertices[i * 6] = xCoordinate;     // x
            vertices[i * 6 + 1] = yCoordinate; // y
            vertices[i * 6 + 2] = zCoordinate; // z
        }

        private void SetVertexColor(float[] vertices, int i, float angle)
        {
            float hue = angle / (2 * (float)Math.PI);
            const float saturation = 1.0f;
            const float value = 1.0f;
            int color = ConvertHSVtoRGB(hue, saturation, value);

            vertices[i * 6 + 3] = ((color >> 16) & 0xFF) / 255.0f; // r
            vertices[i * 6 + 4] = ((color >> 8) & 0xFF) / 255.0f;  // g
            vertices[i * 6 + 5] = (color & 0xFF) / 255.0f;         // b
        }

        private int ConvertHSVtoRGB(float hue, float saturation, float value)
        {
            int hueSector = (int)(hue * 6) % 6;
            float f = hue * 6 - hueSector;
            float p = value * (1 - saturation);
            float q = value * (1 - f * saturation);
            float t = value * (1 - (1 - f) * saturation);

            switch (hueSector)
            {
                case 0: return ((int)(value * 255) << 16) | ((int)(t * 255) << 8) | (int)(p * 255);
                case 1: return ((int)(q * 255) << 16) | ((int)(value * 255) << 8) | (int)(p * 255);
                case 2: return ((int)(p * 255) << 16) | ((int)(value * 255) << 8) | (int)(t * 255);
                case 3: return ((int)(p * 255) << 16) | ((int)(q * 255) << 8) | (int)(value * 255);
                case 4: return ((int)(t * 255) << 16) | ((int)(p * 255) << 8) | (int)(value * 255);
                default: return ((int)(value * 255) << 16) | ((int)(p * 255) << 8) | (int)(q * 255);
            }
        }

        protected override void DrawArrays()
        {
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, numberOfVertices + 2);
        }
    }
}
