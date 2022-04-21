using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void InvalidCNPJ()
    {
      var document = new Document("1234567891234", EDocumentType.CNPJ);
      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    public void ValidCNPJ()
    {
      var document = new Document("12345678912345", EDocumentType.CNPJ);
      Assert.IsTrue(document.Valid);
    }

    [TestMethod]
    public void InvalidCPF()
    {
      var document = new Document("1234567891", EDocumentType.CPF);
      Assert.IsTrue(document.Invalid);
    }

    [TestMethod]
    public void ValidCPF()
    {
      var document = new Document("12345678912", EDocumentType.CPF);
      Assert.IsTrue(document.Valid);
    }
  }
}