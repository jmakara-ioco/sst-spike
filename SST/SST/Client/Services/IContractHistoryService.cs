using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace SST.Client
{
    interface IContractHistoryService
    {
        Task<VezaAPISubmitResult> UpdateContentJson(QuestionSimulation contentAsJson);

        Task<List<SST.Shared.ContractHistory>> GetFirmContracts(Guid FirmID);
    }
}
