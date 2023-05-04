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

        public BillRepository(HotelDbContext context, ILogger<BillRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> AddBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Add(bill);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Bill muvaffaqiyatli qoshildi");
                return bill.InvoiceNumber;
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

        public async Task<List<Bill>> GetAllBillsAsync()
        {
            var allBillsExist = await _context.Bills
                .Include(u => u.Guest)
                .Include(u => u.Booking)
                .ToListAsync();
            if (allBillsExist is not null)
            {
                return allBillsExist;
            }
            else
            {
                throw new Exception();
            }
        }

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
