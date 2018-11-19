using EntityFrameworkCore.Procedure;
using EntityFrameworkCore.Procedure.Schema;
using Microsoft.EntityFrameworkCore;
using System;
using Test.DbRepository.Models;
using Test.DbRepository.Models.Parameters;

namespace Test.DbRepository
{
    public class TestContext : ProcedureContext
    {
        public TestContext(DbContext context) : base(context)
        {
        }

        protected override void OnSetCreation()
        {
            this.Sp_With_Param_new.MapResultSet(0, t=>t.Strudents);
            this.Sp_With_Param_new.MapResultSet(0, typeof(Student));
            this.Sp_With_Param_new.MapResultSet(1, typeof(Subject));
            this.Sp_With_Param_new.MapResultSet(2, typeof(Mark));
            base.OnSetCreation();
        }

        public ProcSingleSet<SimpleModel> Sp_SimpleResult_Without_Param { get; set; }

        [Procedure("Sp_SimpleResult_Without_Param")]
        public ProcSingleSet<SimpleInValidColumnModel> Sp_SimpleResult_Without_Param_InValidColumn { get; set; }

        public ProcSingleSet<SimpleParamModel,object> Sp_With_Param { get; set; }

        public ProcMultiSet<SimpleParamModel, SubjectMarkYearReportMultiSet> Sp_With_Param_new { get; set; }
    }
}
