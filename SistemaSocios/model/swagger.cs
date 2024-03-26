namespace SistemaSocios.Webapi.model
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerTagAttribute : Attribute
    {
        public string Name { get; }

        public SwaggerTagAttribute(string name)
        {
            Name = name;
        }
    }
}
