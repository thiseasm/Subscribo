using Orleans;

namespace Subscribo.Grains.Interfaces;

public interface ISubscriptionGrain : IGrainWithIntegerKey
{
    Task GenerateInvoiceAsync();
    Task BeginSubscriptionAsync();
    Task EndSubscriptionAsync();
}