using EntityFrameworkCore.Procedure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace EntityFrameworkCore.Procedure
{
    public abstract class BaseSet
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

        protected readonly DbContext _context;

        internal BaseSet(DbContext context, string name, string schema = "dbo")
        {
            _context = context;
            ProcName = name;
            Schema = schema;
        }

        protected object GetSqlValue(DbType type, object value)
        {
            switch (type)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.Binary:
                case DbType.Boolean:
                case DbType.Byte:
                case DbType.Currency:
                    return value;
                case DbType.Date:
                    var tempValue = (DateTime)value;
                    return tempValue.ToString("yyyy-MM-dd");
                case DbType.DateTime:
                    var tempValue2 = (DateTime)value;
                    return tempValue2.ToString("yyyy-MM-ddThh:mm:ss");
                case DbType.DateTime2:
                    var tempValue3 = (DateTime)value;
                    return tempValue3.ToString("yyyy-MM-ddThh:mm:ss.FFFF");
                case DbType.DateTimeOffset:
                    var tempValue4 = (DateTime)value;
                    return tempValue4.ToString("o");
                case DbType.Decimal:
                case DbType.Double:
                case DbType.Guid:
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.SByte:
                case DbType.Single:
                case DbType.String:
                    return value;
                case DbType.StringFixedLength:
                    return value;
                case DbType.Time:
                    return value;
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                case DbType.VarNumeric:
                case DbType.Xml:
                    return value;
                default:
                    return value;

            }
        }

        protected TOut Execute<TData, TOut>(string procName,
       Func<DbDataReader, TOut> modelBinder,
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
                        return modelBinder(reader);
                    }
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        //protected TData Execute<TData>(string procName,
        //  Func<DbDataReader, TData> modelBinder,
        //  params SqlParameter[] parameters)
        //{
        //    var sqlConnection = _context.Database.GetDbConnection();
        //    try
        //    {
        //        using (var sqlCommand = sqlConnection.CreateCommand())
        //        {
        //            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            sqlCommand.CommandText = procName;
        //            if (parameters != null)
        //            {
        //                sqlCommand.Parameters.AddRange(parameters);
        //            }
        //            if (sqlConnection.State == System.Data.ConnectionState.Closed)
        //                sqlConnection.Open();

        //            using (var reader = sqlCommand.ExecuteReader())
        //            {
                        
        //                return modelBinder(reader);
        //            }
        //        }
        //    }
        //    catch (IndexOutOfRangeException ex)
        //    {
        //        throw new InvalidColumnException(procName, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        protected string GetParamName(string name)
        {
            name = name.Trim();
            if (name.StartsWith("@"))
                return name;
            return $"@{name}";
        }

        protected object GetSqlValue(object value)
        {
            if (value.GetType().Name == typeof(DateTime).Name)
            {
                var tempValue = (DateTime)value;
                return tempValue.ToString("yyyy-MM-ddThh:mm:ss");
            }
            return value;
        }
    }
}
