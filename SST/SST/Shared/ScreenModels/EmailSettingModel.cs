using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    public class EmailSettingModel
    {
        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string HostAddress { get; set; }

        [Required]
        public bool UseSsl { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int Port { get; set; }
    }
}
