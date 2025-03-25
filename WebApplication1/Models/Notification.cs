namespace WebApplication1.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
