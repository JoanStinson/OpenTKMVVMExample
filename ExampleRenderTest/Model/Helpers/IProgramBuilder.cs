using OpenTK.Graphics.OpenGL4;

namespace ExampleRenderTest.Model.Helpers
{
    public interface IProgramBuilder
    {
        int BuildProgram(params int[] shaders);
        int BuildShader(ShaderType shaderType, string shaderCode);
    }
}