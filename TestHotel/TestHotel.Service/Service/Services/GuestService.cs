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
            _guestRepository= guestRepository;
        }

        public async Task<int> AddGuestAsync(Guest guest)
        {
            return await _guestRepository.AddGuestAsync(guest);
        }

        public async Task<int> DeleteGuestAsync(int id)
        {
            var guestExist = await GetGuestByIdAsync(id);
            if(guestExist != null)
            {
                return await _guestRepository.DeleteGuestAsync(guestExist);
            }
            else
            {
                return 0;
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

        public async Task<int> UpdateGuestAsync(Guest guest)
        {
            var guestExist = await GetGuestByIdAsync(guest.GuestId);
            if(guestExist != null)
            {
                return await _guestRepository.UpdateGuestAsync(guestExist);
            }
            else
            {
                return 0;
            }
        }
    }
}
