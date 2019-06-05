namespace Putn
{
    public interface IAccountRepository
    {
        void Debit(int memberID, decimal totalPayable);
    }
}