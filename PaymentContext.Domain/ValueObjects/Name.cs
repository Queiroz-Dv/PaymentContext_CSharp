using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Name : ValueObject
  {
    public Name(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
      AddNotifications(new Contract()
      .Requires()
      .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
      .HasMaxLen(LastName, 40, "Name.LastName", "Nome deve conter pelo menos 40 caracteres")
      );

    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public override string ToString()
    {
      return $"{FirstName} {LastName}";
    }
  }
}