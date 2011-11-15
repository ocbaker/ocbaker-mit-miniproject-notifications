using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Server.Interop
{
    public class SocketInformation
    {

        public readonly Guid id;
        public List<object> information = new List<object>();

        public SocketInformation()
        {
            id = Guid.NewGuid();
        }
        public SocketInformation(Guid id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
