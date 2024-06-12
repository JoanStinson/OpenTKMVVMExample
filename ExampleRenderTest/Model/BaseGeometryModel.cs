using ExampleRenderTest.Model.Helpers;
using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model
{
    public abstract class BaseGeometryModel : IGeometryModel
    {
        protected float[] vertices;
        private int vertexArrayObject;
        private int vertexBufferObject;
        private int program;
        private bool disposed;

        public void Initialize(IProgramBuilder programBuilder, IShaderCode shaderCode)
        {
            vertexArrayObject = GL.GenVertexArray();
            vertexBufferObject = GL.GenBuffer();
            GL.BindVertexArray(vertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            
            int vertexShader = programBuilder.BuildShader(ShaderType.VertexShader, shaderCode.GetVertexShaderCode());
            int fragmentShader = programBuilder.BuildShader(ShaderType.FragmentShader, shaderCode.GetFragmentShaderCode());
            program = programBuilder.BuildProgram(vertexShader, fragmentShader);
            disposed = false;
        }

        public void Render()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.UseProgram(program);
            GL.BindVertexArray(vertexArrayObject);
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
