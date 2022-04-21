using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Commands
{
  [TestClass]
  public class CreateBoletoSubCommandTests
  {
    [TestMethod]
    public void TestNameIsInvalid()
    {
      var command = new CreateBoletoSubCommand();
      command.FirstName = "";
      
      command.Validate();
      Assert.AreEqual(false, command.Valid);
    }
  }
}
