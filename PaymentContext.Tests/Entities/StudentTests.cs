using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
      _name = new Name("Eduardo", "Queiroz");
      _document = new Document("12345678912", EDocumentType.CPF);
      _email = new Email("queiroz@qe.com");
      _address = new Address("Rua CSharp", "123456", "Bairro ASP", "DotNet", "MR", "OS", "1300000");
      _student = new Student(_name, _document, _email);
      _subscription = new Subscription(null);
    }
    [TestMethod]
    public void ActiveSubError()
    {
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "MX Target", document, address, email);

      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void SubWithNoPaymentError()
    {
      _student.AddSubscription(_subscription);
      Assert.IsTrue(_student.Invalid);

    }

    [TestMethod]
    public void ActiveSubSuccess()
    {
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "MX Target", document, address, email);
      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);
      Assert.IsTrue(_student.Valid);
    }

  }
}