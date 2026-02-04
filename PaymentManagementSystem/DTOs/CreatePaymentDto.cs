namespace PaymentManagementSystem.DTOs
{
    public class CreatePaymentDto
    {
        public string Reference { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
