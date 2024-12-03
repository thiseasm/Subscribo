namespace Subscribo.Data.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<SubscriptionDto> Subscriptions { get; } = new List<SubscriptionDto>();
    }
}
