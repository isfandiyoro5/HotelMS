﻿using System.ComponentModel.DataAnnotations;

namespace TestHotel.DataAccess.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int HotelId { get; set; }

        public int GuestId { get; set; }

        public int RoomNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }


        public Room Room { get; set; }

        public Hotel Hotel { get; set; }

        public List<Guest> Guests { get; set; }

        public List<Bill> Bills { get; set; }
    }
}
