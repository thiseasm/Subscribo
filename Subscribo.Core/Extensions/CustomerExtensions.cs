using Subscribo.Core.Models;
using Subscribo.Data.DTOs;

namespace Subscribo.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerDTO ToDTO(this Customer customer)
        => new()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };

        public static Customer ToDomainObject(this CustomerDTO customerDto)
        => new()
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Email = customerDto.Email
        };
    }
}
