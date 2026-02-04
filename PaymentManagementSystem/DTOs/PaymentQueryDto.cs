using PaymentManagementSystem.Enums;

namespace PaymentManagementSystem.DTOs
{
    public class PaymentQueryDto
    {
        public PaymentStatus? Status { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
