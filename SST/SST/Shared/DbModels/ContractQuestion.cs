using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public enum QuestionType
    {
        Quantity,
        CustomOptions,
        UserFieldsOnly
    }

    public class ContractQuestion : VezaVIGuidRecordBase, INotifyPropertyChanged
    {
        public Guid ContractTransactionID { get; set; }
        public ContractTransaction ContractTransaction { get; set; }

        private string _information = string.Empty;
        public string Information
        {
            get
            {
                return _information;
            }
            set
            {
                if (_information == value)
                    return;
                _information = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Information"));
            }
        }

        private string _questionText = string.Empty;
        public string QuestionText {
            get
            {
                return _questionText;
            }
            set {
                if (_questionText == value)
                    return;
                _questionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QuestionText"));
            } 
        }
        
        private int _typeOfQuestion = (int)QuestionType.Quantity;
        public int TypeOfQuestion
        {
            get
            {
                return _typeOfQuestion;
            }
            set
            {
                if (_typeOfQuestion == value)
                    return;
                _typeOfQuestion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TypeOfQuestion"));
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
            set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    NextQuestionID = null;
                    return;
                }
                NextQuestionID = new Guid(value);
            }
        }

        private Guid? _nextQuestionID = null;
        public Guid? NextQuestionID { 
            get
            {
                return _nextQuestionID;
            }
            set {
                if (_nextQuestionID == value)
                    return;
                _nextQuestionID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NextQuestionID"));
            }
        }

        private bool _isRoot = false;
        public bool IsRoot {
            get
            {
                return _isRoot;
            }
            set
            {
                if (_isRoot == value)
                    return;
                _isRoot = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRoot"));
            }
        }
        
        [NotMapped]
        public string Status { get; set; }

        private Guid? _contractTransactionEntityID = null;
        public Guid? ContractTransactionEntityID
        {
            get
            {
                return _contractTransactionEntityID;
            }
            set
            {
                if (_contractTransactionEntityID == value)
                    return;
                _contractTransactionEntityID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContractTransactionEntityID"));
            }
        }

        public virtual List<ContractQuestionTemplate> Templates { get; set; }
        public virtual List<ContractQuestionIgnoredContractClause> IgnoredContractClauses { get; set; }

        public virtual ContractTransactionEntity ContractTransactionEntity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
