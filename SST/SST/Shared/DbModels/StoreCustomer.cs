using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class StoreCustomer : VezaVIGuidRecordBase
    {
        [EmailAddress]
        public string Email { get; set; }
     
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    }

 }