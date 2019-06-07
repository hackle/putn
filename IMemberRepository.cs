namespace Putn
{
    public interface IMemberRepository
    {
        Membership FindByID(int memberID);
    }
}