using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("Customers")]
    public class Customer : VezaVIGuidRecordBase
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Address1")]
        public string Address1 { get; set; }

        [Column("Address2")]
        public string Address2 { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("ContactNumber")]
        public string ContactNumber { get; set; }
        [Column("FirmID")]
        public Guid FirmID { get; set; }
        public Firm Firm { get; set; }

        [NotMapped]
        public List<CustomerUdfToken> UserDefinedFields { get; set; } = new List<CustomerUdfToken>();

        public List<CustomerDocument> CustomerDocuments { get; set; }

        public bool AllowLogin { get; set; } = true;

        public bool AllowReceivingMails { get; set; } = true;

    }
}
