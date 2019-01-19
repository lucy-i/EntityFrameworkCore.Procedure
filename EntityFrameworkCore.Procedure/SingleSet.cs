using EntityFrameworkCore.Procedure.Exceptions;
using EntityFrameworkCore.Procedure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// SingleSet it reads only first result set of the Procedure,
    /// SQL Parameter List can be passed to execute the Procedure.
    /// </summary>
    /// <typeparam name="T">Poco Class to cast first result set of a Procedure.</typeparam>
    public class SingleSet<T> : BaseSet where T : class, new()
    {
        public SingleSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        { }
        public T FirstRow()
        {
            bool hasValue;
            return Execute<T,T>($"{Schema}.{ProcName}", reader => reader.GetResult<T>(out hasValue));
        }

        public T FirstRow(params SqlParameter[] parameters)
        {
            bool hasValue;
            return Execute<T, T>($"{Schema}.{ProcName}", reader => reader.GetResult<T>(out hasValue), parameters);
        }

        public T FirstRow(Dictionary<string, object> parameters)
        {
            SqlParameter sd = new SqlParameter("", SqlDbType.DateTime);
            bool hasValue;
            return Execute<T, T>($"{Schema}.{ProcName}", reader => reader.GetResult<T>(out hasValue), parameters.Select(t => new SqlParameter(GetParamName(t.Key), GetSqlValue(t.Value))).ToArray());
        }

        public T FirstRow(params Tuple<string, DbType, object>[] parameters)
        {
            bool hasValue;
            return Execute<T, T>($"{Schema}.{ProcName}", reader => reader.GetResult<T>(out hasValue), parameters.Select(t => new SqlParameter(GetParamName(t.Item1), t.Item2)
            {
                Value = GetSqlValue(t.Item2, t.Item3)
            }).ToArray());
        }

        public IEnumerable<T> FirstResult(params SqlParameter[] parameters)
        {
            return Execute<T, IEnumerable<T>>($"{Schema}.{ProcName}", reader => reader.GetResults<T>(), parameters);
        }       

    }

}
