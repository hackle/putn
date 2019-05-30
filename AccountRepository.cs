using System;

namespace Putn
{
    public interface IAccountRepository
    {
        void Debit(int memberID, decimal totalPayable);
    }

    public class AccountRepository
    {
        public void Debit(int memberID, decimal totalPayable)
        {
            Console.WriteLine("Congratulations we've got your money!");
        }
    }
}