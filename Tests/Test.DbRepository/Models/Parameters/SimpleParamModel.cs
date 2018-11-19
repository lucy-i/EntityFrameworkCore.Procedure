using EntityFrameworkCore.Procedure;
using EntityFrameworkCore.Procedure.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace Test.DbRepository.Models.Parameters
{
    public class SimpleParamModel : ProcedureParam
    {
        [Param("@Id", Type = SqlDbType.Int)]
        public int Id { get; set; }
        [Param("Name", Type = SqlDbType.VarChar)]
        public string Name { get; set; }
        [Param("UpdatedDate", Type = SqlDbType.DateTime)]
        public DateTime UpdatedDate { get; set; }
    }
}
