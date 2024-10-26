using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SST.Server.Data;
using SST.Shared;
using VezaVI.Light.Shared;

namespace SST.Server
{
    [ApiController]
    public class ContractHistoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public ContractHistoryController(IConfiguration configuration,
                               SignInManager<ApplicationUser> signInManager,
                               ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("api/UpdateContentJson")]
        public async Task<IActionResult> UpdateContentJson([FromBody] QuestionSimulation contentAsJson)
        {
            var companyID = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);
            var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            ContractHistory contractHistory = new ContractHistory();
            if (!string.IsNullOrEmpty(contentAsJson.StoreCustomer.Email))
            {
                var storeCustomer = _dbContext.Set<StoreCustomer>().FirstOrDefault(x => x.Email.ToUpper() == contentAsJson.StoreCustomer.Email.ToUpper());
                if (storeCustomer != null)
                    contractHistory.StoreCustomerID = storeCustomer.ID;
                else
                {
                    _dbContext.Set<StoreCustomer>().Add(contentAsJson.StoreCustomer);
                    contractHistory.StoreCustomerID = contentAsJson.StoreCustomer.ID;
                }
                contractHistory.ContractHistoryStatus = ContractHistoryStatus.Confirmed;
            }
            else
            {
                contractHistory.ContractHistoryStatus = ContractHistoryStatus.Completed;
            }
            contractHistory.FirmID = companyID;
            contractHistory.UserID = userId;
            contractHistory.DateCreated = DateTime.Now;
            if (contentAsJson.CustomerID.HasValue)
            {
                contractHistory.CustomerID = contentAsJson.CustomerID.Value;
            }
            contractHistory.ContractData = JsonSerializer.Serialize(contentAsJson);
            contractHistory.ContractHistoryStatus = new ContractHistoryStatus();
            var price = contractHistory.TotalPrice = CalculatePrice(contentAsJson);


            _dbContext.ContractHistories.Add(contractHistory);
            _dbContext.SaveChanges();
            return Ok(new VezaAPISubmitResult { Successful = true, EntityID = contractHistory.ID, AdditionalValue = (price * 100).ToString("f0") });
        }

        private double CalculatePrice(QuestionSimulation questionSimulation)
        {
            Dictionary<Guid, double> _templates = new Dictionary<Guid, double>();
            foreach (var q in questionSimulation.Questions)
            {
                var question = _dbContext.ContractQuestions.Include(x => x.Templates).ThenInclude(x => x.ContractTransactionTemplate).FirstOrDefault(x => x.ID == q.QuestionID);
                foreach (var t in question.Templates)
                {
                    if (!_templates.ContainsKey(t.ContractTransactionTemplateID))
                        _templates.Add(t.ContractTransactionTemplateID, t.ContractTransactionTemplate.Price);
                }
                if (q.AnswerID != null)
                {
                    var answer = _dbContext.ContractQuestionAnswers.Include(x => x.ContractTemplate).FirstOrDefault(x => x.ID == q.AnswerID);
                    if (answer != null)
                    {
                        if (answer.ContractTemplate != null)
                        {
                            if (!_templates.ContainsKey((Guid)answer.ContractTemplateID))
                                _templates.Add((Guid)answer.ContractTemplateID, answer.ContractTemplate.Price);
                        }
                    }
                }

            }
            return _templates.Sum(x => x.Value);
        }

        [HttpGet]
        [Route("api/GetContractSummary/{id}")]
        public async Task<IActionResult> GetContractSummary(Guid id)
        {
            var history = _dbContext.ContractHistories.Include(x => x.Customer).Include(x => x.User).Include(x => x.Firm).FirstOrDefault(x => x.ID == id);
            QuestionSimulationDisplayModel model = new QuestionSimulationDisplayModel();
            if (history != null)
            {
                var sim = JsonSerializer.Deserialize<QuestionSimulation>(history.ContractData);
                if (history.Customer != null)
                    model.CustomerName = history.Customer.CompanyName;
                model.Date = history.DateCreated;
                model.Status = history.ContractHistoryStatus;
                model.GeneratedByUser = $"{history.User.FirstName} {history.User.LastName}";
                foreach (var question in sim.Questions)
                {
                    QuestionSimulationQuestionDisplayModel q = new QuestionSimulationQuestionDisplayModel();
                    var dbQ = _dbContext.ContractQuestions.FirstOrDefault(x => x.ID == question.QuestionID);
                    if (dbQ != null) {
                        var dbAnswer = _dbContext.ContractQuestionAnswers.FirstOrDefault(x => x.ID == question.AnswerID);
                        if (dbAnswer != null)
                            q.Answer = dbAnswer.AnswerText;
                        else
                            q.Answer = question.Answer.ToString();
                        q.Question = dbQ.QuestionText;
                        model.Questions.Add(q);
                    }
                }

                foreach (var dataField in sim.DataFields)
                {
                    QuestionSimulationDataFieldDisplayModel udf = new QuestionSimulationDataFieldDisplayModel();
                    var dbUDF = _dbContext.ContractTransactionDataFields.FirstOrDefault(x => x.ID == dataField.DataFieldID);
                    if (dbUDF != null)
                    {
                        udf.DataField = dbUDF.FieldName;
                        udf.Value = sim[dataField.DataFieldID];
                        model.DataFields.Add(udf);
                    }
                    var dbEntityUDF = _dbContext.ContractTransactionEntityDataFields.FirstOrDefault(x => x.ID == dataField.DataFieldID);
                    if (dbEntityUDF != null)
                    {
                        udf.DataField = dbEntityUDF.FieldName;
                        udf.Value = sim[dataField.DataFieldID];
                        model.DataFields.Add(udf);
                    }
                }

                foreach (var simEntity in sim.Entities)
                {
                    QuestionSimulationEntityDisplayModel entity = new QuestionSimulationEntityDisplayModel();
                    var dbEntity = _dbContext.ContractTransactionEntities.FirstOrDefault(x => x.ID == simEntity.EntityID);
                    if (dbEntity != null)
                    {
                        entity.Name = dbEntity.Name;
                        entity.NrOfEntities = simEntity.NrOfEntities;
                        foreach (var simDataField in simEntity.DataFields)
                        {
                            var dbDataField = _dbContext.ContractTransactionEntityDataFields.FirstOrDefault(x => x.ID == simDataField.DataFieldID);
                            if (dbDataField != null) {
                                entity.DataFields.Add(new QuestionSimulationEntityDataFieldDisplayModel()
                                {
                                    Name = dbDataField.FieldName,
                                    Values = simDataField.Values
                                });
                            }
                        }
                        model.Entities.Add(entity);
                    }
                }
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("api/GetFirmContracts/{FirmID}")]
        public async Task<IActionResult> GetFirmContracts(Guid FirmID)
        {
            List<ContractHistory> contractHistories = new List<ContractHistory>();
            var FirmContracts = _dbContext.ContractHistories.Where(x => x.FirmID == FirmID);
            if (FirmContracts.Count() > 0)
            {
                foreach (ContractHistory contractHistory in FirmContracts)
                {
                    contractHistories.Add(contractHistory);
                }
            }
            return Ok(contractHistories);
        }
    }
}
