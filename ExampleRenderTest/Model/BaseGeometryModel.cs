using OpenTK.Graphics.OpenGL4;
using System;

namespace ExampleRenderTest.Model
{
    public abstract class BaseGeometryModel : IGeometryModel
    {
        private int vertexArrayObject;
        private int vertexBufferObject;
        private int program;
        private bool disposed;

        public void Initialize()
        {
            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);

            var vertices = GetVertices();
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            string vertexShaderCode = @"#version 460 core
            layout (location = 0) in vec4 a_pos;
            layout (location = 1) in vec4 a_color;
      
            out vec4 v_color;

            void main()
            {
                v_color = a_color;
                gl_Position = a_pos; 
            }";
            int vertexShader = CreateShader(ShaderType.VertexShader, vertexShaderCode);
            
            string fragmentShaderCode = @"#version 460 core
            out vec4 frag_color;
            in  vec4 v_color;
      
            void main()
            {
                frag_color = v_color; 
            }";
            int fragmentShader = CreateShader(ShaderType.FragmentShader, fragmentShaderCode);

            program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);
            GL.LinkProgram(program);

            string infoLogProgram = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrEmpty(infoLogProgram))
            {
                Console.WriteLine(infoLogProgram);
            }

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
            GL.UseProgram(program);
        }

        protected abstract float[] GetVertices();

        private int CreateShader(ShaderType shaderType, string shaderCode)
        {
            int shader = GL.CreateShader(shaderType);
            GL.ShaderSource(shader, shaderCode);
            GL.CompileShader(shader);

            string infoLogFragment = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrEmpty(infoLogFragment))
            {
                Console.WriteLine(infoLogFragment);
            }

            return shader;
        }

        public void Render()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            DrawArrays();
        }

        protected abstract void DrawArrays();

        public void Destroy()
        {
            if (disposed)
            {
                return;
            }

            GL.DeleteProgram(program);
            GL.DeleteBuffer(vertexBufferObject);
            GL.DeleteVertexArray(vertexArrayObject);
            disposed = true;
        }
    }
}
