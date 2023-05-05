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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Billni databazaga qo'shishda xatolik bor: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni saqlashda xatolik bor. Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Billni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Billni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Billni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Bill>> GetAllBillsAsync()
        {
            try
            {
                return await _context.Bills
                    .Include(u => u.Guest)
                    .Include(u => u.Booking)
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Billarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha billarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
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
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan Billar boʻyicha Billni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan Billni olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Billni olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada {2} Billni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, bill.InvoiceNumber);
                throw new Exception("Billni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Billni {2} yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, bill.InvoiceNumber);
                throw new Exception("Billni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
