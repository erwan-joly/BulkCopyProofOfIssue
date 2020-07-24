using System.ComponentModel.DataAnnotations;

namespace BulkCopyProofOfIssue
{
    public class Account
    {
        [Key]
        public long Id { get; set; }

        public Currency DefaultCurrency { get; set; }
    }
}