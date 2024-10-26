using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace SST.Client
{
    public interface ISubscriptionService
    {
        FirmSubscriptionPlan SubscriptionPlan { get; }
        bool IsActive { get; }
        int MaxUsers { get; }
        Task<FirmSubscriptionPlan> GetActivePlan();

        Task ActivateNow();
        event EventHandler Changed;

        Task<VezaAPISubmitResult> GenerateInvoice(SubscriptionToken token);
        Task<InvoiceHeader> GetInvoice(Guid id);
    }
}
