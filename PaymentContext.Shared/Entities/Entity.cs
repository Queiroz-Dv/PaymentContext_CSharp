using System;

namespace PaymentContext.Shared.Entities
{
  public class Entity
  {
    public Entity()
    {
      Id = Guid.NewGuid();

    }
    public Guid Id { get; private set; }
  }
}