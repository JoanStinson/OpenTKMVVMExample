using System;
using System.Windows;
using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public class SquareModel : IGeometryModel
    {
        private bool disposed;
        private int vertexArrayObject;
        private int vertexBufferObject;
        private int program;

        public void Create()
        {
            // Define square vertices
            float[] square =
            {
                // Position          // Color
                -0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f, // Bottom-left
                 0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f, // Bottom-right
                 0.5f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f, // Top-right
                -0.5f,  0.5f, 0.0f,  1.0f, 1.0f, 0.0f  // Top-left
            };

            // Generate buffers
            vertexArrayObject = GL.GenVertexArray();
            vertexBufferObject = GL.GenBuffer();

            // Bind vertex array object and buffer
            GL.BindVertexArray(vertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, square.Length * sizeof(float), square, BufferUsageHint.StaticDraw);

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

            // Draw the square
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
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