namespace Subscribo.Core.Models
{
    public record Subscription
    {
        public required int Id { get; init; }
        public required string Plan { get; init; }
        public required decimal Price { get; init; }
        public required DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public required string Status { get; init; }
    }
}
