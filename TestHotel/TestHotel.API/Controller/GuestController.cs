using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        [HttpPost]
        public async Task<int> CreateGuestAsync(Guest guest)
        {
            return await _guestRepository.AddGuestAsync(guest);
        }

        [HttpGet("id")]
        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetGuestByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllGuestsAsync();
        }

        [HttpPut]
        public async Task<int> UpdateGuestAsync(Guest guest)
        {
            return await _guestRepository.UpdateGuestAsync(guest);
        }

        [HttpDelete]
        public async Task<int> DeleteGuestAsync(Guest guest)
        {
            return await _guestRepository.DeleteGuestAsync(guest);
        }
    }
}
