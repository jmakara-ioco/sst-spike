using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public class StoreModel : IdentityUser<Guid>, IVezaVIRecordBase
    {
        public string Caption { get; set; }
        public bool IsEnabled { get; set; }

        public StoreCustomer StoreCustomer { get; set; }

        public Guid? StoreCustomerID { get; set; }
        public Guid GetID()
        {
            return Id;
        }
        public List<string> GetValues()
        {
            return new List<string>();
        }

    }
}
