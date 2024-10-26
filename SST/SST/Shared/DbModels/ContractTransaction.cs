using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractTransaction : VezaVIGuidRecordBase
    {
        public string Name { get; set; }
        public string Information { get; set; }
        public bool ShowOnGenerateContracts { get; set; } = false;
        public bool ShowOnOnlineStore { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string Base64Background { get; set; }
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }

        [NotMapped]
        public double MinPrice
        {
            get
            {                
                if (ContractTransactionTemplates == null || ContractTransactionTemplates.Count == 0)
                    return 0;
                return ContractTransactionTemplates.Min(x => x.Price);
            }
        }

        [NotMapped]
        public double MaxPrice
        {
            get
            {
                if (ContractTransactionTemplates == null || ContractTransactionTemplates.Count == 0)
                    return 0;
                return ContractTransactionTemplates.Sum(x => x.Price);
            }
        }

        public List<ContractTransactionTemplate> ContractTransactionTemplates { get; set; }
    }
}
