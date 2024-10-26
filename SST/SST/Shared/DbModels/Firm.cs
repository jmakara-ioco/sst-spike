using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public enum PaymentGateway
    {
        None,
        Paygate
    }

    [Table("Firms")]
    public class Firm : VezaVIGuidRecordBase
    {
        [Column("FirmName"), Required]
        public string FirmName { get; set; }

        [Column("AdminEmail")]
        public string AdminEmail { get; set; }

        [Column("ContactNumber"), Required]
        public string ContactNumber { get; set; } = string.Empty;

        [Column("RegistrationNumber"), Required]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Column("VatNumber")]
        public string VatNumber { get; set; }

        public bool AllowOnlineStore { get; set; } = false;
        public PaymentGateway PaymentGateway { get; set; } = PaymentGateway.None;
        public string PaygateKey { get; set; } = string.Empty;
        public string PaygatePassword { get; set; } = string.Empty;

        public Guid? AddressID { get; set; }
        public Address Address { get; set; }

        [Column("FirmEmailSettingID")]
        public Guid? FirmEmailSettingID { get; set; }

        [Column("FirmMeetingSetupID")]
        public Guid? FirmMeetingSetupID { get; set; }

        public List<FirmDocument> FirmDocuments { get; set; }

        public List<StyleVariableValue> StyleVariableValues { get; set; }

        public FirmEmailSetting FirmEmailSetting { get; set; }

        public List<Customer> FirmCustomers { get; set; }

        public List<ScreenField> ScreenFields { get; set; }

        public FirmMeetingSetup FirmMeetingSetups { get; set; }

        public List<PublicHoliday> PublicHolidays { get; set; }
    }
}
