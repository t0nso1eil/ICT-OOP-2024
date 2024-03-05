namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IUserService
{
    public void CreateUser(string firstName, string lastName, string email, string phoneNumber, string password, DateOnly birthday, string sex, string additionalInfo);

    public User GetUser(Guid userId);

    public void UpdateUser(Guid userId, string firstName, string lastName, string phoneNumber, string password, string additionalInfo);
}