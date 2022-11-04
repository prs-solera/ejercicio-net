using System.ComponentModel.DataAnnotations;

namespace MvcCars.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
