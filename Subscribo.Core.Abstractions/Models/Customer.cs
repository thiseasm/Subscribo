namespace Subscribo.Core.Abstractions.Models
{
    public record Customer
    {
        public required int Id { get; init; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required ICollection<Subscription> Subscriptions { get; set; }
    }
}
