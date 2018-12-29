using EntityFrameworkCore.Procedure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EntityFrameworkCore.Procedure
{
    public class MultiSet<T> : SingleSet<T> where T : MultiResult, new()
    {
        protected Dictionary<int, Type> resultSetOrder = new Dictionary<int, Type>();
        public MultiSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        {

        }

        private void InitResultProperty()
        {
            var tempResult = new T();
            var properties = tempResult.GetProperties();
            properties.OrderBy(o => o.Order).ToList().ForEach(t =>
             {
                 resultSetOrder.Add(t.Order, t.Info.PropertyType);
             });            
        }

        public IEnumerable AsEnumerable(params SqlParameter[] parameters)
        {
            return Execute<MultiResult, IEnumerable<IEnumerable>>(ProcName, reader => reader.GetMultiResults(resultSetOrder), parameters);
        }


        public T MultiResult(params SqlParameter[] parameters)
        {
            T result = new T();
            return Execute<MultiResult, T>(ProcName, reader => reader.GetMultiResults(result.GetPropertyAsDictionary(), result), parameters);
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
