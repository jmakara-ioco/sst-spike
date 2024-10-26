using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SST.Shared
{
    public class QuestionAnswerResult : ScreenSubmitResult
    {
        public string Token { get; set; }

        public string QuestionText { get; set; }

        public QuestionType TypeOfQuestion { get; set; }

        public List<string> Answers { get; set; }
        public List<ContractQuestionAnswerDataField> ContractQuestionAnswerDataFields { get; set; }

        public List<ContractQuestionDataField> ContractQuestionDataFields { get; set; }
        public List<ContractTransactionDataField> ContractTransactionDataFields { get; set; }
    }
}
