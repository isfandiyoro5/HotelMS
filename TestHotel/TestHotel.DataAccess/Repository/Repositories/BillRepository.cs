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
                _logger.LogInformation("AddBillAsync() Chaqirildi");
                return bill.InvoiceNumber;
            }
            catch
            {
                _logger.LogError("AddBillAsync() Qo'shilmadi");
                throw new Exception("Invoice qo'shilmadi");
            }
        }

        public async Task<int> DeleteBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DeleteBillAsync() Chaqirildi");
                return bill.InvoiceNumber;
            }
            catch
            {
                _logger.LogError("DeleteBillAsync() O'chirilmadi");
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
                _logger.LogInformation("GetBillByInvoceNumberAsync() Chaqirildi");
                return await _context.Bills
                    .Include(u => u.Guest)
                    .Include(u => u.Booking)
                    .FirstOrDefaultAsync(u => u.InvoiceNumber == invoiceNumber);
            }
            catch
            {
                _logger.LogError("GetBillByInvoceNumberAsync() Topilmadi");
                throw new Exception("Invoice number topilmadi");
            }
        }
        public async Task<int> UpdateBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
                _logger.LogInformation("UpdateBillAsync() Chaqirildi");
                return bill.InvoiceNumber;
            }
            catch
            {
                _logger.LogError("UpdateBillAsync() O'zgartirilmadi");
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
