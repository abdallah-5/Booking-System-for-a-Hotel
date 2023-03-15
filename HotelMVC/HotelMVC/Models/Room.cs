using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMVC.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public int Status { get; set; }
        public int Size { get; set; }
        public string Bed { get; set; }

        public string Picture { get; set; }

        public Branch Branch { get; set; }
       
    }
}
