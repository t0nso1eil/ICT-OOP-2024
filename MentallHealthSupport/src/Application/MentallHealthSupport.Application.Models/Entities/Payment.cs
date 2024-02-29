namespace MentallHealthSupport.Application.Models.Entities;

public class Payment
{
    public Guid Id { get; }
    
    public Guid SessionId { get;  }
    
    public Guid ClientId { get; }

    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public string Status { get; set; }
}