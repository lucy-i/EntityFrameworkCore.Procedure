using System;
using System.Collections.Generic;
using System.Text;
using Test.DbRepository;
using Xunit;

namespace Procedure.XUnitTest
{
    public class ProcedureDataTypeTest
    {
        readonly TestContext spContext;
        public ProcedureDataTypeTest()
        {
            spContext = new TestContext(InstanceMaker.Context);
        }

        [Fact]
        public void Sp_With_All_SQL_DataType_As_Params_Success_3()
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                long big_int=023;
                int _int=1;
                short small_int=123;
                byte tiny_int=23;
                bool bit=true;
                decimal _decimal= 123123.2234M; ;
                decimal numeric= 123123.2234M; ;
                decimal money=123123.2234M;
                decimal small_money=123.1231M;
                double _float=463.23D;
                float real = 56.45F;
                DateTime date_time= DateTime.Now;
                DateTime date_timeUTC = TimeZoneInfo.ConvertTime(date_time, TimeZoneInfo.Utc);
                
                DateTime small_date_time =DateTime.Now;
                char _char='A';
                string varchar= "varchar";
                string text="text";
                string nchar= "nvarchar";
                string nvarchar= "nvarchar";
                string ntext="nText";
                byte[] binary= { 0, 2, 3, 4, 5, 2,  };
                byte[] varbinary= new byte[] { 0, 2, 3, 4};
                byte[] timestamp=new byte[8] {0,2,3,4,5,2,1,3 };
                Guid uniqueidentifier = Guid.NewGuid();

                param.Add("@big_int",big_int);
                param.Add("@int",_int);
                param.Add("@small_int",small_int);
                param.Add("@tiny_int",tiny_int);
                param.Add("@bit",bit);
                param.Add("@decimal",_decimal);
                param.Add("@numeric",numeric);
                param.Add("@money",money);
                param.Add("@small_money",small_money);
                param.Add("@float",_float);
                param.Add("@real",real);
                param.Add("@date_time", date_time);
                param.Add("@small_date_time", small_date_time);
                param.Add("@char", _char);
                param.Add("@varchar",varchar);
                param.Add("@text",text);
                param.Add("@nchar",nchar);
                param.Add("@nvarchar",nvarchar);
                param.Add("@ntext",ntext);
                param.Add("@binary",binary);
                param.Add("@varbinary",varbinary );
                //param.Add("@image",);
                param.Add("@timestamp",timestamp);
                param.Add("@uniqueidentifier",uniqueidentifier);
                spContext.Sp_With_All_SQL_DataType_As_Params.FirstRow(param);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }

        [Fact]
        public void Sp_With_All_SQL_DataType_As_Params_Success()
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();

                long big_int = 023;
                int _int = 1;
                short small_int = 123;
                byte tiny_int = 23;
                bool bit = true;
                decimal _decimal = 123123.2234M; ;
                decimal numeric = 123123.2234M; ;
                decimal money = 123123.2234M;
                decimal small_money = 123.1231M;
                double _float = 463.23D;
                float real = 56.45F;
                DateTime date_time = DateTime.Now;
                DateTime small_date_time = DateTime.Now;
                char _char = 'A';
                string varchar = "varchar";
                string text = "text";
                string nchar = "nvarchar";
                string nvarchar = "nvarchar";
                string ntext = "nText";
                byte[] binary = { 0, 2, 3, 4, 5, 2, };
                byte[] varbinary = new byte[] { 0, 2, 3, 4 };
                byte[] timestamp = new byte[8] { 0, 2, 3, 4, 5, 2, 1, 3 };
                Guid uniqueidentifier = Guid.NewGuid();

                param.Add("@big_int", big_int);
                param.Add("@int", _int);
                param.Add("@small_int", small_int);
                param.Add("@tiny_int", tiny_int);
                param.Add("@bit", bit);
                param.Add("@decimal", _decimal);
                param.Add("@numeric", numeric);
                param.Add("@money", money);
                param.Add("@small_money", small_money);
                param.Add("@float", _float);
                param.Add("@real", real);
                param.Add("@date_time", date_time.ToString("yyyy-mm-dd hh:MM:ss.fffzzz"));
                param.Add("@small_date_time", small_date_time.ToString("yyyy-mm-dd hh:MM:ss.fffzzz"));
                param.Add("@char", _char);
                param.Add("@varchar", varchar);
                param.Add("@text", text);
                param.Add("@nchar", nchar);
                param.Add("@nvarchar", nvarchar);
                param.Add("@ntext", ntext);
                param.Add("@binary", binary);
                param.Add("@varbinary", varbinary);
                //param.Add("@image",);
                param.Add("@timestamp", timestamp);
                param.Add("@uniqueidentifier", uniqueidentifier);
                spContext.Sp_With_All_SQL_DataType_As_Params.FirstRow(param);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }

    }
}
