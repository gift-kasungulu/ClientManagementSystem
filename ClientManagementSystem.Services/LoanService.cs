using ClientManagementSystem.Domain;
using ClientManagementSystem.MyContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.Services
{
    public class LoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetLoansByCustomerIdAsync(int customerId)
        {
            return await _context.Loans.Include(l => l.Collaterals)
                                       .Where(l => l.CustomerId == customerId).ToListAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoanStatusAsync(int loanId, string status)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                loan.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }

}
