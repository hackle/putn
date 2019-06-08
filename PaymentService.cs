using System;

namespace Putn
{
    public static class PaymentService
    {
        public static void Charge(int memberID, decimal totalPayable)
        {
            throw new InvalidOperationException($"{nameof(PaymentService)} I.O. is nice but not for tests");
        }
    }
}