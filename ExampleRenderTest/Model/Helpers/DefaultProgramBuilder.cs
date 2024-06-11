using OpenTK.Graphics.OpenGL4;
using System;

namespace ExampleRenderTest.Model.Helpers
{
    public class DefaultProgramBuilder : IProgramBuilder
    {
        public int BuildProgram(params int[] shaders)
        {
            int program = GL.CreateProgram();

            foreach (var shader in shaders)
            {
                GL.AttachShader(program, shader);
            }
            GL.LinkProgram(program);

            string infoLogProgram = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrEmpty(infoLogProgram))
            {
                Console.WriteLine(infoLogProgram);
            }

            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }

            return program;
        }

        public int BuildShader(ShaderType shaderType, string shaderCode)
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
    }
}
