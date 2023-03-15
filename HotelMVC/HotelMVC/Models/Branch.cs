using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMVC.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string BranchLocation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //public Hotel Hotel { get; set; }
    }
}
