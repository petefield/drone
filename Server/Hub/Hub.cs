using blazor.signalr.Server;
using blazor.signalr.Shared;
using Drone;
using DroneCommands;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs;



public class SignalRBridge : ISignalRBridge
{
    public event EventHandler<ControllerEventArgs> ControllerInputReceived;

    public void Update()
    {
        var c = ControllerInputReceived;
        c?.Invoke(this, new ControllerEventArgs( new RemoteCommand(new Speed(0,0,0),0) ));
    }


}

public class MessageHub : Hub
{
    private readonly ISignalRBridge _bridge;

    public MessageHub(ISignalRBridge bridge)
    {
        _bridge = bridge;
    }

    public void Update(DroneCommands.RemoteCommand command)
    {
        _bridge.Update();
    }
}