using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void AdicionarAssinatura()
    {
      var student = new Student
        (
            "Eduardo",
            "Queiroz",
            "123456789",
            "devqueiroz@devsharp.io"
        );
    }
  }
}