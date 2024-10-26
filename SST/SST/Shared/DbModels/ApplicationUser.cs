using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VezaVI.Light.Shared;

namespace SST.Shared
{
    public enum TypeOfUser
    {
        SystemAdministrator,
        SystemEmployee,
        FirmAdministrator,
        FirmEmployee,
        ClientAdministrator,
        ClientUser
    }

    public class ApplicationUser : IdentityUser<Guid>, IVezaVIRecordBase
    {
        public override Guid Id { get => base.Id; set => base.Id = value; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public int TypeOfUser { get; set; }
        public Guid? FirmID { get; set; }
        public Guid? CustomerID { get; set; }

        public DateTime PasswordExpiryDate { get; set; }

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
