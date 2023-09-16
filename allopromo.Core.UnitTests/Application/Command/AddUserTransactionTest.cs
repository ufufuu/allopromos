using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.UnitTests.Application.Command
{
    [NUnit.Framework.TestFixture]
    public class AddUserTransactionTest
    {
        public Services.Base.ICommand.AddUserTransaction addUserTransaction { get; set; }
        [NUnit.Framework.Test]
        public void AddUserTransaction_Test_Execute_SHOULD_CREATE_AND_RETURN_Created_User()
        {
            //return new
        }
    }
}
