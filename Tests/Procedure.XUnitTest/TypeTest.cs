using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Procedure.XUnitTest
{
    public class TypeTest
    {

        class Member
        {

        }

        [Fact]
        public void Test_For_ICollectionInitialization_Success()
        {
            ICollection<Member> members = new List<Member>();
            Type t=members.GetType();
            //t.
        }
    }
}
