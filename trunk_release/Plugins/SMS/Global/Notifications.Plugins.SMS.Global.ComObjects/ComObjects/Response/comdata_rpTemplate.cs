﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Response
{
    [Serializable]
    public class comdata_rpTemplate : Notifications.Global.Core.Communication.Base.BaseObjects.aBaseResponse
    {
            public comdata_rpTemplate(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest request) : base(request) { }
            public string retrieved_data;
            public bool successfulSave;
            public bool POST;
    }
}
