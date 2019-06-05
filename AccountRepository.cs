using System;

namespace Putn
{
    public class AccountRepository : IAccountRepository
    {
        public void Debit(int memberID, decimal totalPayable)
        {
            throw new InvalidOperationException($"{nameof(AccountRepository)} I.O. is nice but not for tests");
        }
    }
}