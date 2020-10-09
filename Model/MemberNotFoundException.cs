using System;
using System.Runtime.Serialization;

namespace Putn
{
    [Serializable]
    internal class MemberNotFoundException : Exception
    {
        private int memberID;

        public MemberNotFoundException()
        {
        }

        public MemberNotFoundException(int memberID)
        {
            this.memberID = memberID;
        }

        public MemberNotFoundException(string message) : base(message)
        {
        }

        public MemberNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MemberNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}