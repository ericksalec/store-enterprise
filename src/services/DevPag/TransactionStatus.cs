using System;
using System.Collections.Generic;
using System.Text;

namespace SE.DevPag
{
    public enum TransactionStatus
    {
        Authorized = 1,
        Paid,
        Refused,
        Chargedback,
        Cancelled
    }
}
