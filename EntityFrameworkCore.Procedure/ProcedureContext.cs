using EntityFrameworkCore.Procedure.Schema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// Context to Handle SQL Stored Procedure
    /// </summary>
    public class ProcedureContext
    {
        private readonly DbContext _context;
        public ProcedureContext(DbContext context)
        {
            _context = context;
            InitProcedureSet();
        }

        private void InitProcedureSet()
        {
            var properties = this.GetType().GetProperties().Where(t => t.PropertyType.FullName.StartsWith("EntityFrameworkCore.Procedure.ProcedureSet") && t.PropertyType.IsPublic && t.CanWrite && t.CanWrite);
            foreach (var item in properties)
            {
                Type propType = item.PropertyType;
                try
                {
                    string tempName = item.Name;
                    string tempSchema = "dbo";
                    ProcedureAttribute attribute = item.GetCustomAttributes(typeof(ProcedureAttribute), false).FirstOrDefault() as ProcedureAttribute;
                    if (attribute != null)
                    {
                        tempName = attribute.Name;
                        tempSchema = attribute.Schema ?? tempSchema;
                    }
                    item.SetValue(this, Activator.CreateInstance(propType, _context, tempName, tempSchema));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        protected virtual void OnSetCreation()
        {

        }
    }
}
