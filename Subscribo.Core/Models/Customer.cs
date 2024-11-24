namespace Subscribo.Core.Models
{
    public record Customer
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }
    }
}
