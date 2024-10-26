using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    public class ForgotPasswordModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
