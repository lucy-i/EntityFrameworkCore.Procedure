using System.Reflection;

namespace EntityFrameworkCore.Procedure
{
    internal class MultiResultProp
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public PropertyInfo Info { get; set; }
    }
}
