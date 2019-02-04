using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.DbRepository;
using Test.DbRepository.Models;
using Xunit;

namespace Procedure.XUnitTest
{
    public class CustomerTest
    {

        readonly TestContext spContext;
        public CustomerTest()
        {
            spContext = new TestContext(InstanceMaker.Context);
        }

        [Fact]
        public void CustomerOrderDetail_Success()
        {
            try
            {
                IEnumerable<CustomerOrderDetail> result = spContext.CustomerOrderDetails.FirstResult();
                Assert.False(result == null || result.Count() == 0);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }
        [Fact]
        public void GetCustomers_Success()
        {
            try
            {
                IEnumerable<Customer> result = spContext.GetCustomers.FirstResult();
                Assert.False(result == null || result.Count() == 0);
            }
            catch (Exception ex)
            {
                Assert.False(ex != null, ex.Message);
            }
        }
    }
}
