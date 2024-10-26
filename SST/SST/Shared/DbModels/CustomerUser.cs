using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("CustomerUsers")]
    public class CustomerUser : VezaVIGuidRecordBase
    {
        [Column("UserID")]
        public Guid UserID { get; set; }

        [Column("CompanyID")]
        public Guid CompanyID { get; set; }
    }
}
