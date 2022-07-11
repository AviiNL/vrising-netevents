﻿using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.DeauthAdmin;

internal class DeauthAdminEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "DeauthAdminEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var deauthEvent = new DeauthAdminEventArgs();
        deauthEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(deauthEvent);
        cancelled = deauthEvent.Cancelled;
    }
}