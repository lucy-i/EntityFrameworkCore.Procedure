using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procedure.XUnitTest
{
    class InstanceMaker
    {
        private static Lazy<DbContext> _context = new Lazy<DbContext>(() =>
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(Constants.ConnectionString);

            return new DbContext(builder.Options);
        });

        public static DbContext Context
        {
            get
            {
                return _context.Value;
            }
        }
    }
}
