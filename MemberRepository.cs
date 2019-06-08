using System;

namespace Putn
{
    public class MemberRepository
    {
        public static Member FindByID(int memberID)
        {
            throw new InvalidOperationException($"{nameof(MemberRepository)} I.O. is nice but not for tests");
        }
    }
}