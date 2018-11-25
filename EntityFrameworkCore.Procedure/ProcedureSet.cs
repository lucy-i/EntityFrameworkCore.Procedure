using EntityFrameworkCore.Procedure.Exceptions;
using EntityFrameworkCore.Procedure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// Extended Type to store List Collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RCollection<T> : List<T> where T : class, new()
    {
        public readonly Type type;

        public RCollection()
        {
            type = typeof(T);
        }

        public RCollection(IEnumerable<T> collection) : base(collection)
        {
            type = typeof(T);
        }

        public RCollection(int capacity) : base(capacity)
        {
            type = typeof(T);
        }
    }

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

    internal class MultiResultProp
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public PropertyInfo Info { get; set; }
    }


    public class SingleSet<Input, T> : SingleSet<T> where T : class, new() where Input : ProcedureParam
    {
        public SingleSet(DbContext context, string name, string schema = "dbo") : base(context, name, schema)
        {

        }

        public T FirstRow(Input input)
        {
            return FirstRow(input.ToParam());
        }

        public ICollection<T> FirstResult(Input input)
        {
            return FirstResult(input.ToParam());
        }


    }

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

    public class SingleSet<T> where T : class, new()
    {
        public string ProcName { get; private set; } = string.Empty;
        public string Schema { get; private set; } = string.Empty;
        public string[] paramList { get; protected set; }

        private readonly DbContext _context;

        public SingleSet(DbContext context, string name, string schema = "dbo")
        {
            _context = context;
            ProcName = name;
            Schema = schema;
        }

        public T FirstRow(params SqlParameter[] parameters)
        {
            bool hasValue;
            return Execute($"{Schema}.{ProcName}", reader => reader.GetResult<T>(out hasValue), parameters);
        }

        public ICollection<T> FirstResult(params SqlParameter[] parameters)
        {
            return Execute($"{Schema}.{ProcName}", reader => reader.GetResults<T>(), parameters);
        }


        protected IList<TData> Execute<TData>(string procName,
         Func<DbDataReader, IList<TData>> modelBinder,
         params SqlParameter[] parameters)
        {
            var sqlConnection = _context.Database.GetDbConnection();

            try
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        IList<TData> elements;
                        elements = modelBinder(reader);
                        return elements;
                    }
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        protected TData Execute<TData>(string procName,
          Func<DbDataReader, TData> modelBinder,
          params SqlParameter[] parameters)
        {
            var sqlConnection = _context.Database.GetDbConnection();
            try
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    if (sqlConnection.State == System.Data.ConnectionState.Closed)
                        sqlConnection.Open();

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        elements = modelBinder(reader);
                        return elements;
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidColumnException(procName, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }


}
