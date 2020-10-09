namespace Putn
{
    public interface IMemberRepository
    {
        Member FindByID(int memberID);
    }
}