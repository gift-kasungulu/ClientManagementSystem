using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClientManagementSystem.Data
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public string? FirstName { get; set; }

		[Required]
		public string? LasstName { get; set; }

	

		[Required]
		public int Phone { get; set; }

		[Range(0, int.MaxValue, ErrorMessage ="Amount must be greater or equal to 0!")]
		public double? AmountGiven { get; set; }

        [Required]
        public double Rate { get; set; }

        [Required]
        public double AmmountToPay { get; set; }

        [Required]
        public DateTime? DateGiven { get; set; }

        [Required]
        public DateTime? DateDue { get; set; }

    }
}