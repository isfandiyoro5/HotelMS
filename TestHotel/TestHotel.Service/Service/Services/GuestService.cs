using System;
using System.Collections.Generic;
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

        public GuestService(GuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<int> AddGuestAsync(Guest guest)
        {
            return await _guestRepository.AddGuestAsync(guest);
        }

        public async Task<int> DeleteGuestAsync(int id)
        {
            var guestResult = await GetGuestByIdAsync(id);
            if(guestResult is not null)
            {
                return await _guestRepository.DeleteGuestAsync(guestResult);
            }
            else
            {
                throw new Exception("Delete uchun Guest mavjud emas");
            }
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllGuestsAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetGuestByIdAsync(id);
        }

        public async Task<int> UpdateGuestAsync(int id)
        {
            var guestResult = await GetGuestByIdAsync(id);
            if(guestResult is not null)
            {
                return await _guestRepository.UpdateGuestAsync(guestResult);
            }
            else
            {
                throw new Exception("Update uchun Guest mavjud emas");
            }
        }
    }
}
