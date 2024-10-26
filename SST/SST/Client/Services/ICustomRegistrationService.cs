using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface ICustomRegistrationService
    {
        Task<ScreenSubmitResult> RegisterCustomer(CustomerRegisterModel customerRegisterModel);
    }
}
