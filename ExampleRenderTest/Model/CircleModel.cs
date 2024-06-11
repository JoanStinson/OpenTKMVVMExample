using System;
using System.Windows;
using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class CircleModel : IGeometryModel
    {
        private bool disposed;
        private int vertexArrayObject;
        private int vertexBufferObject;
        private int program;
        private const int numVertices = 50; // Increase number of vertices for smoother circle
        private const float circleRadius = 0.5f; // Adjust the radius of the circle

        public void Create()
        {
            // Define circle vertices
            float[] circle = new float[(numVertices + 2) * 6]; // Each vertex has 6 components (x, y, z, r, g, b)

            // Center vertex (color: red)
            circle[0] = 0.0f; // x
            circle[1] = 0.0f; // y
            circle[2] = 0.0f; // z
            circle[3] = 1.0f; // Color: Red
            circle[4] = 0.0f; // Color: Green
            circle[5] = 0.0f; // Color: Blue

            // Calculate other vertices with gradient color from light to dark red
            for (int i = 0; i <= numVertices; i++)
            {
                float angle = (float)(2 * Math.PI * i / numVertices);
                float redComponent = 1.0f - Math.Abs((float)Math.Sin(angle)); // Red component gradient from light to dark
                circle[(i + 1) * 6] = circleRadius * (float)Math.Cos(angle);     // x
                circle[(i + 1) * 6 + 1] = circleRadius * (float)Math.Sin(angle); // y
                circle[(i + 1) * 6 + 2] = 0.0f;                                   // z
                circle[(i + 1) * 6 + 3] = redComponent;                            // Color: Red (gradient)
                circle[(i + 1) * 6 + 4] = 0.0f;                                   // Color: Green (constant)
                circle[(i + 1) * 6 + 5] = 0.0f;                                   // Color: Blue (constant)
            }

            // Generate buffers
            vertexArrayObject = GL.GenVertexArray();
            vertexBufferObject = GL.GenBuffer();

            // Bind vertex array object and buffer
            GL.BindVertexArray(vertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, circle.Length * sizeof(float), circle, BufferUsageHint.StaticDraw);

            // Set vertex attribute pointers
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            // Vertex shader code (same as previous)
            string vertexShaderCode = @"#version 460 core
                layout (location = 0) in vec3 aPos;
                layout (location = 1) in vec3 aColor;
                out vec3 color;
                void main()
                {
                    gl_Position = vec4(aPos, 1.0);
                    color = aColor;
                }";

            // Fragment shader code (same as previous)
            string fragmentShaderCode = @"#version 460 core
                out vec4 FragColor;
                in vec3 color;
                void main()
                {
                    FragColor = vec4(color, 1.0);
                }";

            // Compile shaders (same as previous)
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderCode);
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderCode);
            GL.CompileShader(fragmentShader);

            // Create program and link shaders (same as previous)
            program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);
            GL.LinkProgram(program);

            // Delete shaders (same as previous)
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            // Use the program (same as previous)
            GL.UseProgram(program);
        }

        public void Render()
        {
            // Clear the color buffer
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Draw the circle using triangle fan mode
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, numVertices + 2); // Include center and NumVertices
        }

        public void Resize(Size newSize)
        {
            // Set the viewport
            GL.Viewport(0, 0, (int)newSize.Width, (int)newSize.Height);
        }

        public void Dispose(bool dispose)
        {
            // Dispose resources (same as previous)
            if (dispose && !disposed)
            {
                disposed = true;
                GL.DeleteProgram(program);
                GL.DeleteBuffer(vertexBufferObject);
                GL.DeleteVertexArray(vertexArrayObject);
            }
        }
    }
}
