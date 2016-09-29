﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace MSniperService.Models
{
    public class LoggingPipelineModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            Debug.WriteLine($"=> Invoking {context.MethodDescriptor.Name} on hub {context.MethodDescriptor.Hub.Name}");
            return base.OnBeforeIncoming(context);
        }

        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            Debug.WriteLine($"<= Invoking {context.Invocation.Method} on client hub {context.Invocation.Hub}");
            return base.OnBeforeOutgoing(context);
        }
    }
}