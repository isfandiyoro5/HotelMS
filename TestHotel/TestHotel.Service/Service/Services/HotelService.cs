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
    internal class HotelService:IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<int> AddHotelAsync(Hotel hotel)
        {
            return await _hotelRepository.AddHotelAsync(hotel);
        }

        public async Task<int> DeleteHotelAsync(int id)
        {
            var hotelResult = await GetHotelByIdAsync(id);
            if (hotelResult is not null)
            {
                return await _hotelRepository.DeleteHotelAsync(hotelResult);
            }
            else
            {
                throw new Exception("Delete uchun Hotel mavjud emas");
            }
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetHotelByIdAsync(id);
        }

        public async Task<int> UpdateHotelAsync(int id)
        {
            var hotelResult = await GetHotelByIdAsync(id);
            if (hotelResult is not null)
            {
                return await _hotelRepository.UpdateHotelAsync(hotelResult);
            }
            else
            {
                throw new Exception("Update uchun Hotel mavjud emas");
            }
        }
    }
}
