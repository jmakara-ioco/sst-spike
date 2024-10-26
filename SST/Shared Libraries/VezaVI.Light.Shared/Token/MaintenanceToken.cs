using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VezaVI.Light.Shared

{
    public class MaintenanceToken
    {
        public string DisplayName { get; set; }
        public Guid? MaintenanceID { get; set; }

        public Guid ID { get; set; }
        public bool IsSelected { get; set; }

    }
}
