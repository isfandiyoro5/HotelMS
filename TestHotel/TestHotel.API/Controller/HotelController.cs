using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpPost]
        public async Task<int> CreateHotelAsync(Hotel hotel)
        {
            return await _hotelRepository.AddHotelAsync(hotel);
        }

        [HttpGet("id")]
        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _hotelRepository.GetHotelByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }

        [HttpPut]
        public async Task<int> UpdateHotelAsync(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotelAsync(hotel);
        }

        [HttpDelete]
        public async Task<int> DeleteHotelAsync(Hotel hotel)
        {
            return await _hotelRepository.DeleteHotelAsync(hotel);
        }
    }
}
