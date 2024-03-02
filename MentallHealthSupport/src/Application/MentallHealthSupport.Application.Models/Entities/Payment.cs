namespace MentallHealthSupport.Application.Models.Entities;

public class Payment
{
    public Guid Id { get; set; }
    
    public Guid SessionId { get; set; }
    
    public Session? Session { get; set; }
    
    public Guid ClientId { get; set; }
    
    public Client? Client { get; set; }

    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public string Status { get; set; }
}