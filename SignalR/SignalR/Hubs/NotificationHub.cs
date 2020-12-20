using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR.Hubs
{
    public class NotificationHub : Hub
    {
        public void NotifyAll(string title, string message, string alerttype) // send from SendNotify CSHTML
        {
            Clients.All.displayNotification(title, message, alerttype); // on layout
        }
    }
}