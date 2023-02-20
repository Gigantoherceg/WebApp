using System.ComponentModel.DataAnnotations;

namespace Services.Models.ViewModels
{

    public class AddressViewModel
    {
        public int Id { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}
