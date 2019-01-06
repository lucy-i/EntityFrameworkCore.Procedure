using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Test.DbRepository;
using Test.DbRepository.Models;
using Test.DbRepository.Models.Parameters;
using Xunit;

namespace Procedure.XUnitTest
{
    public class ProcedureTest
    {   
        readonly TestContext spContext;
        public ProcedureTest()
        {
            spContext = new TestContext(InstanceMaker.Context);
        }

        [Fact]
        public void Sp_SimpleResult_Without_Param_Success()
        {
            try
            {
                SimpleModel resultOne = spContext.Sp_SimpleResult_Without_Param.FirstRow();
                Assert.False(resultOne == null);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }

        [Fact]
        public void Sp_SimpleResult_Without_Param_List_Success()
        {
            try
            {
                IEnumerable<SimpleModel> result = spContext.Sp_SimpleResult_Without_Param.FirstResult();
                Assert.False(result == null || result.Count() == 0);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }

        [Fact]
        public void Sp_With_Param_Success()
         {
            try
            {
                spContext.Sp_With_Param.FirstRow(new Test.DbRepository.Models.Parameters.SimpleParamModel() {
                    Id = 1,
                    Name = "Ram Test" + Guid.NewGuid().ToString(),
                    UpdatedDate=DateTime.Now
                });
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }


        [Fact]
        public void Sp_With_Param_Multi_Success()
        {
            try
            {
                SubjectMarkYearReportMultiSet result= spContext.Sp_With_Param_AnReturnList.MultiResult(new SimpleParamModel() {
                    Id=1,
                    Name="Ram",
                    UpdatedDate=DateTime.Now
                });                
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }
    }
}
