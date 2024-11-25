namespace Subscribo.Data.DTOs
{
    public class CustomerDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<SubscriptionDTO> Subscriptions { get; set; }
    }
}
