using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Request_Handlers
{
    /// <summary>
    /// Interface for all request Actions
    /// </summary>
    interface iAct
    {
         void recieve_request();
    }
}
