using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;

namespace EntityFrameworkCore.Procedure.Extensions
{
    public static class ProcedureSetExtension
    {

        private static bool IsPrimitive(this Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(Enum),
            typeof(String),
            typeof(Decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsPrimitive(type.GetGenericArguments()[0]))
                ;
        }



        internal static T GetResult<T>(this DbDataReader reader, out bool hasValue) where T : class, new()
        {
            T data = default(T);

            hasValue = false;

            if (reader.Read())
            {
                data = new T();
                hasValue = true;
                Type type = typeof(T);
                var props = type.GetProperties().Where(t => t.CanWrite && t.CanWrite && !t.PropertyType.IsArray && !t.PropertyType.IsEnum);

                foreach (var item in props)
                {
                    string columnName = item.Name;
                    Type propType = item.PropertyType;
                    var attr = item.GetCustomAttributes(typeof(ColumnAttribute), true);
                    if (attr != null && attr.Length > 0)
                    {
                        columnName = (attr[0] as ColumnAttribute).Name;
                    }
                    int ordinal = reader.GetOrdinal(columnName);
                    if (ordinal < 0)
                        continue;
                    if (!reader.IsDBNull(ordinal))
                        item.SetValue(data, reader.GetValue(item.Name, propType));
                }

            }
            return data;
        }

        internal static object GetResult(this DbDataReader reader, Type type, out bool hasValue)
        {
            Object data = null;

            hasValue = false;

            if (reader.Read())
            {
                data = Activator.CreateInstance(type);
                hasValue = true;
                var props = type.GetProperties().Where(t => t.CanWrite && t.CanWrite && !t.PropertyType.IsArray && !t.PropertyType.IsEnum);

                foreach (var item in props)
                {
                    Type propType = item.PropertyType;
                    int ordinal = reader.GetOrdinal(item.Name);
                    if (ordinal < 0)
                        continue;
                    if (!reader.IsDBNull(ordinal))
                        item.SetValue(data, reader.GetValue(item.Name, propType));
                }

            }
            return data;
        }

        internal static IList<T> GetResults<T>(this DbDataReader reader) where T : class, new()
        {
            List<T> list = new List<T>();
            bool hasValue;
            do
            {
                T item = reader.GetResult<T>(out hasValue);
                if (item != null)
                    list.Add(item);
            } while (hasValue);
            return list;
        }

        internal static T GetMultiResults<T>(this DbDataReader reader, Dictionary<int, MultiResultProp> resultSetOrder, T result)
        {
            Type t = typeof(T);
            int[] keys = resultSetOrder.Keys.OrderBy(o => o).ToArray();
            foreach (var item in keys)
            {
                var objResult = Activator.CreateInstance(resultSetOrder[item].Info.PropertyType);
                var method = objResult.GetType().GetMethod("Add");
                Type rr = objResult.GetType().GenericTypeArguments.First();
                bool hasValue;
                do
                {
                    object objectitem = reader.GetResult(rr, out hasValue);
                    if (objectitem != null)
                        method.Invoke(objResult, new object[] { objectitem });
                } while (hasValue);

                resultSetOrder[item].Info.SetValue(result, objResult);

                if (!reader.NextResult())
                    break;
            }
            return result;
        }

        internal static IEnumerable<IEnumerable> GetMultiResults(this DbDataReader reader, Dictionary<int, Type> resultSetOrder)
        {
            List<IEnumerable> list = new List<IEnumerable>();
            int[] keys = resultSetOrder.Keys.OrderBy(t => t).ToArray();
            List<object> onbjList = new List<object>();
            foreach (var item in keys)
            {
                Activator.CreateInstance(resultSetOrder[item]);
                bool hasValue;
                do
                {
                    object objectitem = reader.GetResult(resultSetOrder[item], out hasValue);
                    if (objectitem != null)
                        onbjList.Add(objectitem);
                } while (hasValue);

                list.Add(onbjList);

                if (!reader.NextResult())
                    break;
            }
            return list;
        }

        private static object GetValue(this DbDataReader reader, string name, Type type)
        {
            try
            {
                return Convert.ChangeType(reader[name], type);
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
