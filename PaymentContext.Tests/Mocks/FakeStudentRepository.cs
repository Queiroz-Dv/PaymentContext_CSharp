using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
namespace PaymentContext.Tests.Mocks
{
  public class FakeStudentRepository : IStudentRepository
  {
    public void CreateSub(FakeStudentRepository student)
    {

    }

    public bool DocumentExists(string document)
    {
      if (document == "99999999999")
      {
        return true;
      }
      return false;
    }

    public bool EmailExists(string email)
    {
      if (document == "queiroz@eq.com")
      {
        return true;
      }
      return false;
    }
  }
}