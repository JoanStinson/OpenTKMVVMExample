namespace ExampleRenderTest.Model.Helpers
{
    public class DefaultShaderCode : IShaderCode
    {
        public string GetVertexShaderCode()
        {
            return @"#version 460 core
            layout (location = 0) in vec4 a_pos;
            layout (location = 1) in vec4 a_color;
            out vec4 v_color;

            void main()
            {
                v_color = a_color;
                gl_Position = a_pos; 
            }";
        }

        public string GetFragmentShaderCode()
        {
            return @"#version 460 core
            out vec4 frag_color;
            in  vec4 v_color;
      
            void main()
            {
                frag_color = v_color; 
            }";
        }
    }
}
