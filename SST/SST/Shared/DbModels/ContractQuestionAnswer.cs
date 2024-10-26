using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class ContractQuestionAnswer : VezaVIGuidRecordBase, INotifyPropertyChanged
    {
        public Guid QuestionID { get; set; }
        public ContractQuestion Question { get; set; }

        private string _answerText = "";
        public string AnswerText
        {
            get
            {
                return _answerText;
            }
            set
            {
                if (_answerText == value)
                    return;
                _answerText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnswerText"));
            }
        }

        [NotMapped]
        public string NextQuestionIDBindable
        {
            get
            {
                if (NextQuestionID == null)
                    return " ";
                return NextQuestionID.ToString();
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    NextQuestionID = null;
                    return;
                }
                NextQuestionID = new Guid(value);
            }
        }

        private Guid? _nextQuestionID = null;
        public Guid? NextQuestionID
        {
            get
            {
                return _nextQuestionID;
            }
            set
            {
                if (_nextQuestionID == value)
                    return;
                _nextQuestionID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NextQuestionID"));
            }
        }

        [NotMapped]
        public string ContractTemplateIDBindable
        {
            get
            {
                if (ContractTemplateID == null)
                    return " ";
                return ContractTemplateID.ToString();
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    ContractTemplateID = null;
                    return;
                }
                ContractTemplateID = new Guid(value);
            }
        }

        private Guid? _contractTemplateID = null;
        public Guid? ContractTemplateID
        {
            get
            {
                return _contractTemplateID;
            }
            set
            {
                if (_contractTemplateID == value)
                    return;
                _contractTemplateID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContractTemplateID"));
            }
        }
        public ContractTransactionTemplate ContractTemplate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotMapped]
        public string Status { get; set; }

        public List<ContractQuestionAnswerIgnoredClause> IgnoredContractClauses { get; set; }
    }
}
