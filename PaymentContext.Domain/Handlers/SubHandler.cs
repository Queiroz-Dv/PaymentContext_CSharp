using System;

using Flunt.Notifications;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Command;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
  public class SubHandler :
  Notifiable,
  IHandler<CreateBoletoSubCommand>
  {
    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;
    public SubHandler(IStudentRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }
    public ICommandResult Handle(CreateBoletoSubCommand Command)
    {
      Command.Validate();
      if (Command.Invalid)
      {
        AddNotifications(Command);
        return new CommandResult(false, "Não foi possível realizar sua assinatura");
      }

      if (_repository.DocumentExists(Command.Document))
      {
        AddNotification("Document", "Este CPF já está incluso");
      }

      if (_repository.EmailExists(Command.Document))
      {
        AddNotification("Email", "Este e-mail já está incluso");
      }

      var name = new Name("Eduardo", "Queiroz");
      var document = new Document(Command.Document, EDocumentType.CPF);
      var email = new Email(Command.Email);
      var address = new Address(Command.Street, Command.Number, Command.Neighborhood, Command.City, Command.State, Command.Country, Command.ZipCode);

      var student = new Student(name, document, email);
      var subscription = new Subscription(DateTime.Now.AddMonths(1));
      var payment = new BoletoPayment(
        Command.BarCode,
        Command.BoletoNumber,
        Command.PaidDate,
        Command.ExpireDate,
        Command.Total,
        Command.TotalPaid,
        Command.Payer,
        new Document(Command.PayerDocument, Command.PayerDocumentType),
        address,
        email
      );
      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      AddNotifications(name, document, email, address, student, subscription, payment);

      _repository.CreateSub(student);

      _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo a MX-Target School", "Sua assinatura foi criada");

      return new CommandResult(true, "Assinatura realizada com sucesso");
    }
  }
}