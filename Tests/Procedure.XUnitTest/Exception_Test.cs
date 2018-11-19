using EntityFrameworkCore.Procedure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Test.DbRepository;
using Test.DbRepository.Models;
using Xunit;

namespace Procedure.XUnitTest
{
    public class Exception_Test
    {
        readonly TestContext spContext;

        public Exception_Test()
        {
            spContext = new TestContext(InstanceMaker.Context);
        }

        [Fact]
        public void Invalid_Column_Exception_Success()
        {
            try
            {
                SimpleInValidColumnModel resultOne = spContext.Sp_SimpleResult_Without_Param_InValidColumn.FirstRow();
                Assert.False(true, "Exception 'InvalidColumnException' is not thrown.");
            }
            catch (InvalidColumnException ex)
            {
                Assert.True(ex != null, ex.Message);
            }
        }
    }
}
