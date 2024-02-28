namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IClientService
{
    public void CreateClient(string firstName, string lastName, string email, string phoneNumber, string password, DateOnly birthday, string sex, string additionalInfo);

    public Client GetClient(Guid clientId);

    public void UpdateClient(Guid clientId, string firstName, string lastName, string phoneNumber, string password, string additionalInfo);

    public void UpdateClientFullName(Guid clientId, string firstName, string lastName);

    public void UpdateClientPassword(Guid clientId, string password);

    public void UpdateClientPhoneNumber(Guid clientId, string phoneNumber);

    public void UpdateClientAdditionalInfo(Guid clientId, string additionalInfo);

    public IEnumerable<Session> GetClientSessions(Guid clientId);
}