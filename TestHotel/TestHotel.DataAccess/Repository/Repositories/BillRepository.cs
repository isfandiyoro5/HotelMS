using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly ILogger<BillRepository> _logger;
        private readonly HotelDbContext _context;
        private IValidator<Bill> _validator;

        public BillRepository(HotelDbContext context, ILogger<BillRepository> logger, IValidator<Bill> validator)
        {
            _logger = logger;
            _context = context;
            _validator = validator;
        }

        public async Task<int> AddBillAsync(Bill bill)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(bill);
                if (validationResult.IsValid)
                {
                    _context.Bills.Add(bill);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Bill muvaffaqiyatli qoshildi");
                    return bill.InvoiceNumber;
                }
                else
                {
                    throw new Exception("Kiritilgan Bill talabga javob bermaydi");
                }
            }
            catch
            {
                _logger.LogError("Billni yaratishda xatolik yuzaga keldi");
                throw new Exception("Invoice qo'shilmadi");
            }
        }

        public async Task<int> DeleteBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Bill muvaffaqiyatli o'chirildi");
                return bill.InvoiceNumber;
            }
            catch
            {
                _logger.LogError("Billni o'chirishda xatolik yuzaga keldi");
                throw new Exception("Invoiceda o'chirilmadi");
            }
        }

        public async Task<List<Bill>> GetAllBillsAsync() => await _context.Bills
            .Include(u => u.Guest)
            .Include(u => u.Booking)
            .ToListAsync();

        public async Task<Bill> GetBillByInvoiceNumberAsync(int invoiceNumber)
        {
            try
            {
                _logger.LogInformation("BillByInvoiceNumber muvaffaqiyatli topildi");
                return await _context.Bills
                    .Include(u => u.Guest)
                    .Include(u => u.Booking)
                    .FirstOrDefaultAsync(u => u.InvoiceNumber == invoiceNumber);
            }
            catch
            {
                _logger.LogError("BillByInvoiceNumberni qidirishda xatolik yuzaga keldi");
                throw new Exception("Invoice number topilmadi");
            }
        }
        public async Task<int> UpdateBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Bill muvaffaqiyatli yangilandi");
                return bill.InvoiceNumber;
            }
            catch
            {
                _logger.LogError("Billni yangilashda xatolik yuzaga keldi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
