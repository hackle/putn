using System;

namespace Putn
{
    public class Membership
    {
        public MemberType Type { get; set; }
        public int ID { get; set; }
        public DateTime Birthday { get; set; }
    }

    public enum MemberType 
    {
        Diamond,
        Gold
    }
}