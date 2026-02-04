using PaymentManagementSystem.DTOs;
using PaymentManagementSystem.Models;

namespace PaymentManagementSystem.Repositories
{
    public interface IPaymentRepository
    {
        Task AddPayment(Payment payment);
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<Payment?> GetByIdPayment(int id);
        Task UpdatePayment(Payment payment);
        Task<bool> ExistsByReference(string reference);
        Task<PagedResultDto<Payment>> GetFiltered(PaymentQueryDto query);


    }
}
