namespace WebApplication1.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
