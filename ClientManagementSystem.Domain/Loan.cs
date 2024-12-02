using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.Domain
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal Interest { get; set; }
        public decimal ProcessingFee { get; set; }
        public string Status { get; set; } // Pending, Active, Settled, Defaulted
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Collateral> Collaterals { get; set; }
    }

}
