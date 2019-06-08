using System;

namespace Putn
{
    public class PaymentService : IPaymentService
    {
        public void Charge(int memberID, decimal totalPayable)
        {
            throw new InvalidOperationException($"{nameof(PaymentService)} I.O. is nice but not for tests");
        }
    }
}