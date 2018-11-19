using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Procedure.Exceptions
{
    public class InvalidColumnException:Exception
    {   
        public InvalidColumnException(string procName,IndexOutOfRangeException exception):base($"{exception.Message} is not a valid column of {procName} procedure.", exception)
        {
            
        }
    }
}
