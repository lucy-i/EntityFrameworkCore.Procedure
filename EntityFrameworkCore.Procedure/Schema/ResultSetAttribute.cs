using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Procedure.Schema
{
    public class ResultSetAttribute:Attribute
    {
        public int Order { get; private set; }
        public ResultSetAttribute(int order)
        {
            Order = order;
        }
    }
}
