using Microsoft.EntityFrameworkCore;
using PaymentManagementSystem.Data;
using PaymentManagementSystem.DTOs;
using PaymentManagementSystem.Models;


namespace PaymentManagementSystem.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdPayment(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByReference(string reference)
        {
            return await _context.Payments
                .AnyAsync(p => p.Reference == reference);
        }

        public async Task<PagedResultDto<Payment>> GetFiltered(PaymentQueryDto query)
        {
            var paymentsQuery = _context.Payments.AsQueryable();

            if (query.Status.HasValue)
            {
                paymentsQuery = paymentsQuery
                    .Where(p => p.Status == query.Status.Value);
            }

            var totalItems = await paymentsQuery.CountAsync();

            var items = await paymentsQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResultDto<Payment>
            {
                TotalItems = totalItems,
                Page = query.Page,
                PageSize = query.PageSize,
                Items = items
            };
        }

    }
}
