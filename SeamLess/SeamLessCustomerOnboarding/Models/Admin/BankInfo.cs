using System.ComponentModel.DataAnnotations;

namespace SeamLessCustomerOnboarding.Models.Admin
{
    public class BankInfo
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name Must Be Of Length 100")]

        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email Format MisMatch")]
        public string Email { get; set; }
        [Required]
        public string MetaMaskKey { get; set; }


    }
}
