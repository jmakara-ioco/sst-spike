using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class QuestionSimulation
    {
        [RequiredCustomer]
        public Guid? CustomerID { get; set; } = null;
        public StoreCustomer StoreCustomer { get; set; } = new StoreCustomer();

        public List<QuestionSimulationToken> Questions { get; set; } = new List<QuestionSimulationToken>();
        public List<QuestionSimulationDataToken> DataFields { get; set; } = new List<QuestionSimulationDataToken>();
        public List<QuestionSimulationEntityToken> Entities { get; set; } = new List<QuestionSimulationEntityToken>();

        [NotMapped]
        public string this[Guid dataFieldID]
        {
            get
            {
                var udf = DataFields.FirstOrDefault(x => x.DataFieldID == dataFieldID);
                if (udf == null)
                {
                    udf = new QuestionSimulationDataToken(dataFieldID);
                    DataFields.Add(udf);
                }
                return udf.Value;
            }
            set
            {
                var udf = DataFields.FirstOrDefault(x => x.DataFieldID == dataFieldID);
                if (udf == null)
                {
                    udf = new QuestionSimulationDataToken(dataFieldID);
                    DataFields.Add(udf);
                }
                udf.Value = value;
            }
        }
    }

    public class QuestionSimulationToken
    {
        public Guid QuestionID { get; set; }
        public Guid? AnswerID { get; set; }
        public int Answer { get; set; }
    }

    public class QuestionSimulationDataToken
    {
        public QuestionSimulationDataToken(Guid dataFieldID)
        {
            DataFieldID = dataFieldID;
        }

        public QuestionSimulationDataToken()
        {

        }

        public Guid DataFieldID { get; set; }
        public string Value { get;set; }
    }

    public class QuestionSimulationEntityToken
    {
        public Guid EntityID { get; set; }
        public string Name { get; set; }
        public int NrOfEntities { get; set; }

        public List<QuestionSimulationEntityDataToken> DataFields { get; set; } = new List<QuestionSimulationEntityDataToken>();

    }

    public class QuestionSimulationEntityDataToken
    {
        public QuestionSimulationEntityDataToken(Guid dataFieldID)
        {
            DataFieldID = dataFieldID;
        }

        public QuestionSimulationEntityDataToken()
        {

        }

        public Guid DataFieldID { get; set; }

        public string this[int level]
        {
            get
            {
                var value = Values.FirstOrDefault(x => x.Level == level);
                if (value != null)
                    return value.Value;
                return string.Empty;
            }
            set
            {
                var val = Values.FirstOrDefault(x => x.Level == level);
                if (val != null)
                    val.Value = value;
                else
                    Values.Add(new SimulationDictionaryValue() { Level = level, Value = value });
            }
        }

        public List<SimulationDictionaryValue> Values { get; set; } = new List<SimulationDictionaryValue>();
    }

    public class SimulationDictionaryValue
    {
        public int Level { get; set; }
        public string Value { get; set; }
    }

    public class QuestionToken
    {
        public int QuestionType { get; set; } = -1;
        public Guid QuestionID { get; set; }
        public string QuestionText { get; set; }
        public Guid? EntityID { get; set; }
        public string EntityName { get; set; }
        public string Info { get; set; }
        public Guid? NextQuestionID { get; set; }
        public List<QuestionDataFieldToken> DataFields { get; set; } = new List<QuestionDataFieldToken>();
        public List<QuestionAnswerToken> Answers { get; set; } = new List<QuestionAnswerToken>();
        public QuestionEntityToken Entity { get; set; }
    }

    public class QuestionAnswerToken
    {
        public Guid AnswerID { get; set; }
        public string OptionText { get; set; }
        public Guid? NextQuestionID { get; set; }
        public List<QuestionDataFieldToken> DataFields { get; set; } = new List<QuestionDataFieldToken>();
    }

    public class QuestionDataFieldToken
    {
        public Guid DataFieldID { get; set; }
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public int FieldType { get; set; }
    }

    public class QuestionEntityToken
    {
        public Guid EntityID { get; set; }
        public string Name { get; set; }

        public List<QuestionEntityDataFieldToken> DataFields { get; set; } = new List<QuestionEntityDataFieldToken>();
        
    }

    public class QuestionEntityDataFieldToken
    {
        public Guid DataFieldID { get; set; }
        public string FieldName { get; set; }
        public string DisplayText { get; set; }
        public int FieldType { get; set; }
    }

    public class QuestionSimulationDisplayModel
    {
        public DateTime Date { get; set; }
        public string GeneratedByUser { get; set; }
        public string CustomerName { get; set; }

        public List<QuestionSimulationDataFieldDisplayModel> DataFields { get; set; } = new List<QuestionSimulationDataFieldDisplayModel>();
        public List<QuestionSimulationQuestionDisplayModel> Questions { get; set; } = new List<QuestionSimulationQuestionDisplayModel>();
        public List<QuestionSimulationEntityDisplayModel> Entities { get; set; } = new List<QuestionSimulationEntityDisplayModel>();

        public ContractHistoryStatus Status { get; set; }

    }


    public class QuestionSimulationDataFieldDisplayModel
    {
        public string DataField { get; set; }
        public string Value { get; set; }
    }

    public class QuestionSimulationQuestionDisplayModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class QuestionSimulationEntityDisplayModel
    {
        public string Name { get; set; }
        public int NrOfEntities { get; set; }
        public List<QuestionSimulationEntityDataFieldDisplayModel> DataFields { get; set; } = new List<QuestionSimulationEntityDataFieldDisplayModel>();
    }

    public class QuestionSimulationEntityDataFieldDisplayModel
    {
        public string Name { get; set; }

        public string this[int level]
        {
            get
            {
                var value = Values.FirstOrDefault(x => x.Level == level);
                if (value != null)
                    return value.Value;
                return string.Empty;
            }
            set
            {
                var val = Values.FirstOrDefault(x => x.Level == level);
                if (val != null)
                    val.Value = value;
                else
                    Values.Add(new SimulationDictionaryValue() { Level = level, Value = value });
            }
        }

        public List<SimulationDictionaryValue> Values { get; set; } = new List<SimulationDictionaryValue>();
    }

}
