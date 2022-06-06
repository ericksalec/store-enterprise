using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SE.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
