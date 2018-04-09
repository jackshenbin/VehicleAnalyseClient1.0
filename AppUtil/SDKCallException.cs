using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppUtil
{
    public class SDKCallException : Exception
    {
        public uint ErrorCode { get; set; }

        public SDKCallException(uint errorCode, string msg) :
            base(msg)
        {
            this.ErrorCode = errorCode;
        }

        public override string ToString()
        {
            return string.Format("[{0}]{1}",ErrorCode,Message);
        }
    }
}
