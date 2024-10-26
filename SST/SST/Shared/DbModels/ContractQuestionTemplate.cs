using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionTemplate : VezaVIGuidRecordBase
    {
        public Guid QuestionID { get; set; }
        public ContractQuestion Question { get; set; }

        public Guid ContractTransactionTemplateID { get; set; }
        public ContractTransactionTemplate ContractTransactionTemplate { get; set; }

        public int SequenceNumber { get; set; }
    }
}
