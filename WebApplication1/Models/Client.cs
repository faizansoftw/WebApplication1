using static WebApplication1.Common.Constants;

namespace WebApplication1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public Plans? Plan { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Fee { get; set; }
    }
}
