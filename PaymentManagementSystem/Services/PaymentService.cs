using PaymentManagementSystem.DTOs;
using PaymentManagementSystem.Enums;
using PaymentManagementSystem.Models;
using PaymentManagementSystem.Repositories;
using PaymentManagementSystem.Exceptions;


namespace PaymentManagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResponseDto> CreatePayment(CreatePaymentDto dto)
        {
            if (dto.Amount <= 0)
                throw new BusinessException("El monto debe ser mayor a cero");

            if (string.IsNullOrWhiteSpace(dto.Currency))
                throw new BusinessException("La moneda es obligatoria");

            var exists = await _repository.ExistsByReference(dto.Reference);
            if (exists)
                throw new BusinessException("La referencia ya existe");


            var payment = new Payment
            {
                Reference = dto.Reference,
                Amount = dto.Amount,
                Currency = dto.Currency,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddPayment(payment);

            return new PaymentResponseDto
            {
                Id = payment.Id,
                Reference = payment.Reference,
                Amount = payment.Amount,
                Currency = payment.Currency,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt
            };
        }

        // ✅ GET ALL
        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            return await _repository.GetAllPayment();
        }

        // ✅ GET BY ID
        public async Task<Payment?> GetByIdPayment(int id)
        {
            return await _repository.GetByIdPayment(id);
        }

        public async Task<bool> UpdateStatus(int id, PaymentStatus newStatus)
        {
            var payment = await _repository.GetByIdPayment(id);

            if (payment == null)
                throw new BusinessException("Pago no encontrado");

            if (payment.Status != PaymentStatus.Pending)
                throw new BusinessException("El estado del pago no puede modificarse");

            payment.Status = newStatus;
            await _repository.UpdatePayment(payment);

            return true;
        }

        public async Task<PagedResultDto<Payment>> GetPayments(PaymentQueryDto query)
        {
            var payments = await _repository.GetFiltered(query);

            return payments;
        }

    }
}
