namespace Putn
{
    public interface IMemberRepository
    {
        Membership FindMember(int memberID);
    }
}