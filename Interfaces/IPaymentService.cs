namespace Putn
{
    public interface IPaymentService
    {
        void Charge(int memberID, decimal totalPayable);
    }
}