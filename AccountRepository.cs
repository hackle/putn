using System;

namespace Putn
{
    public class AccountRepository : IAccountRepository
    {
        public void Debit(int memberID, decimal totalPayable)
        {
            Console.WriteLine("Congratulations we've got your money!");
        }
    }
    
    public interface IAccountRepository
    {
        void Debit(int memberID, decimal totalPayable);
    }
}