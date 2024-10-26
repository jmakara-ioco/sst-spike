using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    public class CustomerRegisterModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Online Store Charge %")]
        public string OnlineStoreCharge { get; set; }
        
        [Display(Name = "Comments")]
        public string Comment { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "pppppp";

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "pppppp";

        public List<CustomerPriceModel> Price { get; set; } = new List<CustomerPriceModel>() { 
            new CustomerPriceModel() { Description = "1 to 5 Users", PricePerMonth = 0, PricePerYear = 0 },
            new CustomerPriceModel() { Description = "6 to 10 Users", PricePerMonth = 0, PricePerYear = 0 },
            new CustomerPriceModel() { Description = "11 to 15 Users", PricePerMonth = 0, PricePerYear = 0 },
            new CustomerPriceModel() { Description = "15+ Users", PricePerMonth = 0, PricePerYear = 0 }
        };
    }

    public class CustomerPriceModel
    {
        public string Description { get; set; }
        public double PricePerMonth { get; set; }
        public double PricePerYear { get; set; }
    }
}
