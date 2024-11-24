﻿namespace Subscribo.Core.Models
{
    public record Invoice
    {
        public required int Id { get; init; }
        public required DateTime IssueDate { get; init; }
        public required decimal Amount { get; init; }
        public required string Status { get; init; }
    }

}
