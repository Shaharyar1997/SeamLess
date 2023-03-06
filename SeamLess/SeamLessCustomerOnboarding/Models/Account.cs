using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace SeamLessCustomerOnboarding.Models
{
    public class Account
    {
        public string Id { get; set; }

        [Required]
        public string Account_Type { get; set; }

        [Required]
        public string AccountCurrency { get; set; }

        [Required]
        public string AccountTitle { get; set; }

        public string AvailableBalance { get; set; }

        public string MailingAdress { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string AddressType { get; set; }

        public string NTN { get; set; }

    }
    public class CustomAttributes
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string bankAddress { get; set; }

        public string typeOfRecord { get; set; }

        public bool Optional { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
