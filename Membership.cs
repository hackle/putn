namespace Putn
{
    public class Membership
    {
        public MemberType Type { get; set; }
    }

    public enum MemberType 
    {
        Diamond,
        Gold
    }
}