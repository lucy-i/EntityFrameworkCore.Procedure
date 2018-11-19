using EntityFrameworkCore.Procedure.Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EntityFrameworkCore.Procedure
{
    public abstract class ProcedureParam
    {
        List<SqlParameter> _parameters = new List<SqlParameter>();

        internal SqlParameter[] ToParam()
        {
            if (_parameters.Count > 0)
                return _parameters.ToArray();

            var properties = this.GetType().GetProperties().Where(t => (t.PropertyType.IsPrimitive || t.PropertyType == typeof(string) || t.PropertyType == typeof(DateTime)) && t.PropertyType.IsPublic && t.CanWrite && t.CanWrite);
            foreach (var item in properties)
            {
                Type propType = item.PropertyType;
                try
                {
                    SqlParameter param = null;
                    if ((param = GetParam(item)) != null)
                        _parameters.Add(param);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return _parameters.ToArray();
        }

        private SqlParameter GetParam(PropertyInfo property)
        {
            SqlParameter param;
            string tempName = property.Name;
            SqlDbType tempType = SqlDbType.NVarChar;
            IgnoreAttribute ignoreattribute = property.GetCustomAttributes(typeof(IgnoreAttribute), false).FirstOrDefault() as IgnoreAttribute;
            if (ignoreattribute != null)
                return null;
            ParamAttribute attribute = property.GetCustomAttributes(typeof(ParamAttribute), false).FirstOrDefault() as ParamAttribute;
            if (attribute != null)
            {
                tempName = attribute.Name;
                tempType = attribute.Type;
            }
            if (!tempName.StartsWith("@"))
                tempName = $"@{tempName}";
            param = new SqlParameter(tempName, tempType);

            var objVal = property.GetValue(this);
                param.Value = objVal;

            if (param.Value == null)
                param.SqlValue = DBNull.Value;
            return param;
        }
    }
}
