using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EntityFrameworkCore.Procedure
{
    public class MultiSet<T> : SingleSet<T> where T : MultiResult, new()
    {
        protected Dictionary<int, Type> resultSetOrder = new Dictionary<int, Type>();
        public MultiSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        {

        }

        public IEnumerable AsEnumerable(params SqlParameter[] parameters)
        {
            return null;
        }

        public void MapResultSet(int order, Type type)
        {
            if (resultSetOrder.ContainsKey(order))
            {
                throw new Exception($"Key already exists");
            }

            resultSetOrder.Add(order, type);
        }
    }
}
