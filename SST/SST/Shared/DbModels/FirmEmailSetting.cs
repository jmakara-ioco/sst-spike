using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    [Table("FirmEmailSettings")]
    public class FirmEmailSetting : VezaVIGuidRecordBase
    {
        [Column("FromAddress")]
        public string FromAddress { get; set; }

        [Column("HostAddress")]
        public string HostAddress { get; set; }

        [Column("UseSsl")]
        public bool UseSsl { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Port")]
        public int Port { get; set; }


        public virtual Firm Firm { get; set; }
    }
}
