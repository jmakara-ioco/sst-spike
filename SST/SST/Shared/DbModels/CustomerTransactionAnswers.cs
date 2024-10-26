using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SST.Shared
{
    [Table("CustomerTransactionAnswer")]
    public class CustomerTransactionAnswer
    {
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("QuestionID")]
        public Guid QuestionId { get; set; }

        [Column("QuestionText")]
        public string QuestionText { get; set; }

        [Column("ContractTransactionDataFieldID")]
        public Guid ContractTransactionDataFieldID { get; set; }

        [NotMapped]
        public List<string> Answers { get; set; } 

        [Column("Value")]
        public string Value { get; set; }

        [NotMapped]
        public double ValueAsDouble { get; set; }

        [NotMapped]
        public int ValueAsInt { get; set; }

        [NotMapped]
        public DateTime ValueAsDate { get; set; }
    }
}
