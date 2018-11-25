using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// Abstract Class for Poco having Multi Result
    /// </summary>
    public abstract class MultiResult
    {
        internal List<MultiResultProp> GetProperties()
        {
            Type t = this.GetType();
            List<PropertyInfo> props = t.GetProperties().Where(p => p.PropertyType.FullName.StartsWith("EntityFrameworkCore.Procedure.RCollection")).ToList();

            return null;
        }
    }
}
