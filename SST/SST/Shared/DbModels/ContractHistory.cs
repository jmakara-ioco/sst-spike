using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public enum  ContractHistoryStatus {
        Saved , 
        Confirmed ,
        Completed
    }

    [Table("ContractHistory")]
    public class ContractHistory : VezaVIGuidRecordBase
    {
        [Column("ContractHistory")]
        public ContractHistoryStatus ContractHistoryStatus { get; set; }

        [Column("FirmID")]
        public Guid FirmID { get; set; }

        [Column("ContractData")]
        public string ContractData { get; set; }

        [Column("UserID")]
        public Guid? UserID { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("CustomerID")]
        public Guid? CustomerID { get; set; }

        [Column("StoreCustomerID")]
        public Guid? StoreCustomerID { get; set; }
        public double TotalPrice { get; set; }

        [JsonIgnore]
        public Firm Firm { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

    }
}
