using System;

namespace Putn
{
    public class Membership
    {
        public string Name { get; set; }
        public MemberType Type { get; set; }
        public DateTime Birthday { get; set; }
    }

    public enum MemberType 
    {
        Diamond,
        Gold
    }
}