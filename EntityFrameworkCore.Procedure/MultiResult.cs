using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// Abstract Class for Poco having Multi Result
    /// </summary>
    public abstract class MultiResult
    {
        private Dictionary<int, MultiResultProp> prop = null;
        private MultiResultProp[] propList = null;

        internal Dictionary<int, MultiResultProp> GetPropertyAsDictionary()
        {
            int i = 0;
            if (prop != null)
                return prop;

            var props = GetProperties();
            prop = new Dictionary<int, MultiResultProp>();
            props.OrderBy(o => o.Order).ToList().ForEach(each =>
              {
                  prop.Add(each.Order, each);
              });

            return prop;
        }

        internal MultiResultProp[] GetProperties()
        {
            if (propList != null)
                return propList;

            Type t = this.GetType();
            int i = 0;

            propList = t.GetProperties().Where(p => p.PropertyType.FullName.StartsWith("EntityFrameworkCore.Procedure.RCollection")).Select(each =>
                new MultiResultProp
                {
                    Name = each.Name,
                    Info = each,
                    Order = i++
                }).ToArray();

            return propList;
        }
    }
}
