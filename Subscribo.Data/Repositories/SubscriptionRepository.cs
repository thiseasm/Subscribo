using Microsoft.EntityFrameworkCore;
using Subscribo.Data.Context;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Data.Repositories;

public class SubscriptionRepository(SubscriboContext dbContext) : ISubscriptionRepository
{
    public async Task<SubscriptionDto?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken)
        => await dbContext.Subscriptions
            .AsNoTracking()
            .Include(s => s.Customer)
            .FirstOrDefaultAsync(s => s.Id == subscriptionId, cancellationToken);

    public async Task CreateSubscriptionAsync(SubscriptionDto subscription, CancellationToken cancellationToken)
    { 
        await dbContext.Subscriptions.AddAsync(subscription, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateSubscriptionAsync(SubscriptionDto subscription, CancellationToken cancellationToken)
    {
        dbContext.Attach(subscription);
        dbContext.Entry(subscription).Property(i => i.StatusId).IsModified = true;
        dbContext.Entry(subscription).Property(i => i.EndDate).IsModified = true;
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ActivateSubscriptionAsync(int subscriptionId, int statusId, CancellationToken cancellationToken)
    {
        SubscriptionDto subscription = new()
        {
            Id = subscriptionId,
            StatusId = statusId
        };

        dbContext.Attach(subscription);
        dbContext.Entry(subscription).Property(i => i.StatusId).IsModified = true;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}