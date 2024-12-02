using Orleans;

namespace Subscribo.Grains.Interfaces;

public interface ISubscriptionGrain : IGrainWithIntegerKey
{
    Task GenerateInvoice();
    Task BeginSubscription();
}