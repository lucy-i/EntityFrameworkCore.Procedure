using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Procedure.Schema
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StoredProcAttribute : Attribute
    {
        public string Name { private set; get; }
        public string Schema { private set; get; }
        public string[] Params { get; set; }

        public StoredProcAttribute(string name, string schema = "dbo")
        {
            Name = name;
            Schema = schema;
        }

        public StoredProcAttribute(string name, string schema = "dbo", params string[] paramList) : this(name, schema)
        {
            Params = paramList;
        }

    }
}
