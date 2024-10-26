using System;
using System.Collections.Generic;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionDataField : VezaVIGuidRecordBase
    {
        public Guid QuestionID { get; set; }
        public ContractQuestion Question { get; set; }

        public Guid ContractTransactionDataFieldID { get; set; }
        public ContractTransactionDataField ContractTransactionDataField { get; set; }
    }
}
