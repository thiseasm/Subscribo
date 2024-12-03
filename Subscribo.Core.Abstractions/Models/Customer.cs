namespace Subscribo.Core.Abstractions.Models
{
    public record Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
