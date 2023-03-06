using Org.BouncyCastle.Asn1;
using System.ComponentModel.DataAnnotations;

namespace SeamLessCustomerOnboarding.Models
{
    public class Customer
    {

        public int CustomerId { get; set; } = 0;

        public string CustomerEthAddress { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string MotherName { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string ResidentialAddress { get; set; }

        [Required]
        public string Occupation { get; set; }

        public string Email { get; set; }


        [Required]
        public string SourceOfIncome { get; set;}

        [Required]
        public string PurposeOfAccount { get; set; }

        [Required]
        public string ExpectedNumberOfTransaction { get; set; }

        [Required]
        public string Signature { get; set; }

        [Required]
        public string NextOfKIN { get; set; }


        public Gender gender { get; set; }

        public string FatherName { get; set; }
        public string HusbandName { get; set; }

        List<Account> accounts { get; set; }
    }
}
