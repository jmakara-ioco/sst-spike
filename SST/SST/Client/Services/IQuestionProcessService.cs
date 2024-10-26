using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SST.Client
{
    public interface IQuestionProcessService
    {
        public Task<QuestionAnswerResult> FindQuestionToShow(CurrentQuestionModel currentQuestionModel);

        public Task<QuestionToken> GetQuestion(Guid id);

        public Task<QuestionToken> GetRootQuestion(Guid transactionID);
    }
}
