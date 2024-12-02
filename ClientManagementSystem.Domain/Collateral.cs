using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.Domain
{
    public class Collateral
    {
        public int CollateralId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; } // Pledged, Released
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }

}
