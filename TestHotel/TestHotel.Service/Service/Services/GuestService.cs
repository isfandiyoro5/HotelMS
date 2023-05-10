using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class GuestService: IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<GuestService> _logger;

        public GuestService(GuestRepository guestRepository, ILogger<GuestService> logger)
        {
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task<int> AddGuestAsync(Guest guest)
        {
            try
            {
                return await _guestRepository.AddGuestAsync(guest);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazaga qoʻshishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni databazaga qoʻshishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni databazaga saqlashda kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni saqlashda kutilmagan xatolik. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<int> DeleteGuestAsync(int id)
        {
            try
            {
                var guestResult = await GetGuestByIdAsync(id);
                if (guestResult is not null)
                {
                    return await _guestRepository.DeleteGuestAsync(guestResult);
                }
                else
                {
                    throw new Exception("Delete uchun Guest mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Guestni databazadan o'chirishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda xatolik yuz berdi.Iltimos keyinroq qayta urinib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Guestni o'chirishda databazada kutilmagan xatolik: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni o'chirishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            try
            {
                return await _guestRepository.GetAllGuestsAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("SQL so'rovini bajarishda xatolik yuz berdi.", ex);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazada barcha Guestlarni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda xatolik yuz berdi. Iltimos, qaytadan xarakat qilib ko'ring");
            }
            catch (Exception ex)
            {
                _logger.LogError("Barcha Guestlarni databazadan olishda xatolik mavjud: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestlarni olishda kutilmagan xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            try
            {
                return await _guestRepository.GetGuestByIdAsync(id);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError("ArgumentNullException in GetGuestByIdAsync: {0}StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync boʻyicha Billni olishda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazadan GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("GetGuestByIdAsync olishda kutilmagan xatolik yuz berdi. Iltimos, keyinroq qayta urinib ko'ring");
            }
        }

        public async Task<int> UpdateGuestAsync(int id)
        {
            try
            {
                var guestResult = await GetGuestByIdAsync(id);
                if (guestResult is not null)
                {
                    return await _guestRepository.UpdateGuestAsync(guestResult);
                }
                else
                {
                    throw new Exception("Update uchun Guest mavjud emas");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Databazada Guestni yangilashda xatolik yuz berdi: {0} StackTrace: {1}", ex.Message, ex.StackTrace);
                throw new Exception("Guestni yangilashda xatolik yuz berdi. Iltimos keyinroq qayta urinib ko'ring.");
            }
        }
    }
}
