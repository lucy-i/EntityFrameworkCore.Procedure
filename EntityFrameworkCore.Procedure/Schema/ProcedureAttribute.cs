using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Procedure.Schema
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ProcedureAttribute : Attribute
    {
        public string Name { private set; get; }
        public string Schema { private set; get; }
        public string[] Params { get; set; }
        public Type[] ResultTypes { get; set; }

        public ProcedureAttribute(string name, string schema = "dbo")
        {
            Name = name;
            Schema = schema;
        }

        public ProcedureAttribute(string name, string schema = "dbo", params string[] paramList) : this(name, schema)
        {
            Params = paramList;
        }

        public ProcedureAttribute(string name, string schema = "dbo", string[] paramList = null, params Type[] results) : this(name, schema, paramList)
        {
            ResultTypes = results;
        }


    }
}
