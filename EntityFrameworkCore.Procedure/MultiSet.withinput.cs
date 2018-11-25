using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Procedure
{
    public sealed class MultiSet<Input, T> : MultiSet<T> where T : MultiResult, new() where Input : ProcedureParam
    {
        internal Dictionary<int, MultiResultProp> resultSetInfo = new Dictionary<int, MultiResultProp>();

        public MultiSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        {

        }

        private void InitResultProperty()
        {
            //resultSetInfo.Add()
        }

        public T FirstRow(Input input)
        {
            return FirstRow(input.ToParam());
        }

        public ICollection<T> FirstResult(Input input)
        {
            return FirstResult(input.ToParam());
        }

        public IEnumerable AsEnumerable(Input input)
        {
            return AsEnumerable(input.ToParam());
        }

        public T MultiResult(Input input)
        {
            return null;
        }

        public void MapResultSet<Type>(int order, Func<T, RCollection<Type>> type) where Type : class, new()
        {
            if (resultSetOrder.ContainsKey(order))
            {
                throw new Exception($"Key already exists");
            }
            resultSetOrder.Add(order, typeof(Type));
        }
    }
}
