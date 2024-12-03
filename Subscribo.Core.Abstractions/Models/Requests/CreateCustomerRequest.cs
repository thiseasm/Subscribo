using System.ComponentModel.DataAnnotations;

namespace Subscribo.Core.Abstractions.Models.Requests
{
    public class CreateCustomerRequest
    {
        [MaxLength(100)]
        public required string Name {  get; init; }

        [EmailAddress]
        public required string Email { get; init; }
    }
}
