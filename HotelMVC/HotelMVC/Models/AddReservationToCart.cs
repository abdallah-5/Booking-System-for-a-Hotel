using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelMVC.Models
{
    public class AddReservationToCart
    {
        
        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }

        public int PeopleInRoom { get; set; }

        public int RoomId { get; set; }

    }
}
