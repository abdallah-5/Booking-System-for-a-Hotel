using System.ComponentModel.DataAnnotations.Schema;

namespace HotelMVC.Models.ViewModels
{
    public class HomeVM
    {
        public List<Branch> Branchs { get; set; }
        public SearshInHome SearshInHome { get; set; }

    }
}
