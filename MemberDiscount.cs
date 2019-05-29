namespace Putn
{
    public static class MemberDiscount 
    {
        public static int GetInPercentage(Membership member)
        {
            switch (member.Type)
            {
                case MemberType.Diamond: return 10;
                case MemberType.Gold: return 5;
                default: return 0;
            }
        }
    }
}