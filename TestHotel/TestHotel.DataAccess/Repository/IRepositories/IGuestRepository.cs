using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IGuestRepository
    {
        public int AddGuest(Guest guest);

        public Guest GetGuestById(int id);

        public List<Guest> GetAllGuests();

        public int UpdateGuest(Guest guest);

        public int DeleteGuest(Guest guest);
    }
}
