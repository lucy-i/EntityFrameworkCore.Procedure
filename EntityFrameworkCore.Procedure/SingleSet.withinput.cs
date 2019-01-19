using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntityFrameworkCore.Procedure
{
    public class SingleSet<Input, T> : SingleSet<T> where T : class, new() where Input : ProcedureParam
    {
        public SingleSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        {

        }

        public T FirstRow(Input input)
        {
            return FirstRow(input.ToParam());
        }

        public IEnumerable<T> FirstResult(Input input)
        {
            return FirstResult(input.ToParam());
        }


    }
}
