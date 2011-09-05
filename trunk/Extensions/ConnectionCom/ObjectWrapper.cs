using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions.ConnectionCom
{
    /// <summary>
    /// ObjectWrapper is used to raise an event to whoever made the request, could also be used by the server
    /// 
    /// Allows for Aysnc without giving the 'requesting object' access to all transporting data.
    /// </summary>
    /// <typeparam name="rqt">Request Type</typeparam>
    /// <typeparam name="rst">Response Type</typeparam>
    public class ObjectWrapper<rqt,rst>
    {
        public delegate void DataRecievedHandler(object sender, rst ResponseObject);
        
        public event DataRecievedHandler ResponseRecieved;

        public rqt RequestObject;
        public rst ResponseObject;

        public ObjectWrapper(rqt RequestObject)
        {
            this.RequestObject = RequestObject;
        }

        public void submitQuery()
        {
            
        }

        /// <summary>
        /// This is used by the Connection Class to notify/return a Response from the server.
        /// </summary>
        /// <param name="Response"></param>
        public void giveResponse(rst Response)
        {
            ResponseObject = Response;
            if (ResponseRecieved != null)
                ResponseRecieved(this, Response);
        }
    }
}
