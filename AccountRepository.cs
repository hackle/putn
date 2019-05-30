using System;

namespace Putn
{
    public static class AccountRepository
    {
        public static void Debit(int memberID, decimal totalPayable)
        {
            Console.WriteLine("Congratulations we've got your money!");
        }
    }
}