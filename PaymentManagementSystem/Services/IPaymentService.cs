using PaymentManagementSystem.DTOs;
using PaymentManagementSystem.Enums;
using PaymentManagementSystem.Models;

namespace PaymentManagementSystem.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreatePayment(CreatePaymentDto dto);
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<Payment?> GetByIdPayment(int id);
        Task<bool> UpdateStatus(int id, PaymentStatus status);
        Task<PagedResultDto<Payment>> GetPayments(PaymentQueryDto query);



    }
}
