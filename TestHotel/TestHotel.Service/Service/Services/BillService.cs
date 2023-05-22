using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogger<BillService> _logger;

        public BillService(IBillRepository billRepository, ILogger<BillService> logger)
        {
            _billRepository = billRepository;
            _logger = logger;
        }

        public async Task<int> AddBillAsync(Bill bill)
        {
            try
            {
                return await _billRepository.AddBillAsync(bill);
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

        public async Task<int> UpdateBillAsync(int invoiceNumber)
        {
            try
            {
                var billResult = await GetBillByIdAsync(invoiceNumber);
                if (billResult is not null)
                {
                    return await _billRepository.UpdateBillAsync(billResult);
                }
                else
                {
                    throw new Exception("Update uchun Bill mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada {2} Billni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, invoiceNumber);
                throw new Exception("Billni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Billni {2} yangilanishida kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace, invoiceNumber);
                throw new Exception("Billni yangilashda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteBillAsync(int invoiceNumber)
        {
            try
            {
                var billResult = await GetBillByIdAsync(invoiceNumber);
                if (billResult is not null)
                {
                    return await _billRepository.DeleteBillAsync(billResult);
                }
                else
                {
                    throw new Exception("Delete uchun bunday Bill mavjud emas");
                }
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
                return await _billRepository.GetAllBillsAsync();
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

        public async Task<Bill> GetBillByIdAsync(int invoiceNumber)
        {
            try
            {
                return await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber);
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
    }
}
