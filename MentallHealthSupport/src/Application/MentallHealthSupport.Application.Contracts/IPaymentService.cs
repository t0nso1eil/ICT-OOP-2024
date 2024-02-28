namespace MentallHealthSupport.Application.Contracts;

public interface IPaymentService
{
    public void UpdatePaymentStatus(Guid paymentId, string status);
}