using PaymentManagementSystem.Enums;

namespace PaymentManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Reference { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
