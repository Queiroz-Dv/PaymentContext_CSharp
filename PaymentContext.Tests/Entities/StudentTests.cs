using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void AdicionarAssinatura()
    {
      var name = new Name("Teste", "Teste");
      foreach (var not in name.Notifications)
      {
        
      }
    }
  }
}