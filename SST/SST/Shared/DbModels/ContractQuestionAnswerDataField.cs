using System;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionAnswerDataField : VezaVIGuidRecordBase
    {
        public Guid AnswerID { get; set; }
        public ContractQuestionAnswer Answer { get; set; }

        public Guid ContractTransactionDataFieldID { get; set; }
        public ContractTransactionDataField ContractTransactionDataField { get; set; }
    }
}
