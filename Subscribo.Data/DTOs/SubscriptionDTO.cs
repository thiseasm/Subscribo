namespace Subscribo.Data.DTOs
{
    public class SubscriptionDTO
    {
        public required int Id { get; set; }
        public required string Plan { get; set; }
        public required decimal Price { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required int StatusId { get; set; }
    }
}
