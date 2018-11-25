using EntityFrameworkCore.Procedure.Exceptions;
using EntityFrameworkCore.Procedure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// SingleSet it reads only first result set of the Procedure,
    /// SQL Parameter List can be passed to execute the Procedure.
    /// </summary>
    /// <typeparam name="T">Poco Class to cast first result set of a Procedure.</typeparam>
    public class SingleSet<T> where T : class, new()
    {
        /// <summary>
        /// Procedure Name to be executed in Database.
        /// </summary>
        public string ProcName { get; private set; } = string.Empty;
        /// <summary>
        /// Schema of the Procedure
        /// </summary>
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
