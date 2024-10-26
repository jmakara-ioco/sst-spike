using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SST.Server.Data;
using SST.Shared;

namespace SST.Server.Controllers
{
    [ApiController]
    public class QuestionProcessController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionProcessController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private QuestionToken GenerateQuestionToken(ContractQuestion question)
        {
            List<QuestionAnswerToken> answers = new List<QuestionAnswerToken>();
            List<QuestionDataFieldToken> dataFields = new List<QuestionDataFieldToken>();
            List<QuestionEntityDataFieldToken> entityDataFields = new List<QuestionEntityDataFieldToken>();
            QuestionEntityToken entity = new QuestionEntityToken();
            if (question.TypeOfQuestion == (int)(QuestionType.Quantity))
            {
                entity = new QuestionEntityToken()
                {
                    EntityID = (Guid)question.ContractTransactionEntityID,
                    Name = question.ContractTransactionEntity.Name
                };
                entityDataFields = new List<QuestionEntityDataFieldToken>();
                var questionDataFields = _dbContext.ContractTransactionEntityDataFields.Where(q => q.ContractTransactionEntityID == question.ContractTransactionEntityID);
                foreach (var dataField in questionDataFields)
                {
                    entityDataFields.Add(new QuestionEntityDataFieldToken()
                    {
                        DataFieldID = dataField.ID,
                        FieldName = dataField.FieldName,
                        DisplayText = dataField.DisplayText,
                        FieldType = dataField.TypeOfField
                    });
                }
                entity.DataFields = entityDataFields;
            }
            else if (question.TypeOfQuestion == (int)(QuestionType.UserFieldsOnly))
            {
                dataFields = new List<QuestionDataFieldToken>();
                var questionDataFields = _dbContext.ContractQuestionDataFields.Include(x => x.ContractTransactionDataField).Where(q => q.QuestionID == question.ID);
                foreach (ContractQuestionDataField contractQuestionDataField in questionDataFields)
                {
                    dataFields.Add(new QuestionDataFieldToken()
                    {
                        DataFieldID = contractQuestionDataField.ContractTransactionDataFieldID,
                        FieldName = contractQuestionDataField.ContractTransactionDataField.FieldName,
                        DisplayText = contractQuestionDataField.ContractTransactionDataField.DisplayText
                    });
                }
            }
            else
            {
                var QuestionAnswers = _dbContext.ContractQuestionAnswers.Where(x => x.QuestionID == question.ID);
                foreach (ContractQuestionAnswer contractQuestionAnswer in QuestionAnswers)
                {
                    dataFields = new List<QuestionDataFieldToken>();
                    var questionDataFields = _dbContext.ContractQuestionAnswerDataFields.Include(x => x.ContractTransactionDataField).Where(q => q.AnswerID == contractQuestionAnswer.ID);
                    foreach (ContractQuestionAnswerDataField contractQuestionDataField in questionDataFields)
                    {
                        dataFields.Add(new QuestionDataFieldToken()
                        {
                            DataFieldID = contractQuestionDataField.ContractTransactionDataFieldID,
                            FieldName = contractQuestionDataField.ContractTransactionDataField.FieldName,
                            DisplayText = contractQuestionDataField.ContractTransactionDataField.DisplayText
                        });
                    }
                    QuestionAnswerToken questionAnswerToken = new QuestionAnswerToken()
                    {
                        AnswerID = contractQuestionAnswer.ID,
                        OptionText = contractQuestionAnswer.AnswerText,
                        NextQuestionID = contractQuestionAnswer.NextQuestionID,
                        DataFields = dataFields
                    };
                    questionAnswerToken.DataFields = dataFields;
                    answers.Add(questionAnswerToken);
                }
            }
            QuestionToken questionToken = new QuestionToken()
            {
                QuestionID = question.ID,
                QuestionText = question.QuestionText,
                QuestionType = question.TypeOfQuestion,
                NextQuestionID = question.NextQuestionID,
                Answers = answers,
                DataFields = dataFields,
                Entity = entity,
                EntityID = question.ContractTransactionEntityID,
                EntityName = question.ContractTransactionEntity?.Name,
                Info = question.Information
            };
            return questionToken;
        }

        [HttpGet]
        [Route("api/GetQuestion/{questionID}")]
        public async Task<IActionResult> GetQuestion(Guid questionID)
        {
            var question = _dbContext.ContractQuestions.Include(x => x.ContractTransactionEntity).FirstOrDefault(q => q.ID == questionID);
            if (question != null)
            {
                var questionToken = GenerateQuestionToken(question);
                return Ok(questionToken);
            }
            else
                return Ok();
        }

        [HttpGet]
        [Route("api/GetFirtsQuestion/{transactionID}")]
        public async Task<IActionResult> GetFirtsQuestion(Guid transactionID)
        {
            var question = _dbContext.ContractQuestions.Include(x => x.ContractTransactionEntity).FirstOrDefault(q => q.ContractTransactionID == transactionID && q.IsRoot);
            if (question != null)
            {
                var questionToken = GenerateQuestionToken(question);
                return Ok(questionToken);
            }
            else
                return Ok();
        }
    }
}
