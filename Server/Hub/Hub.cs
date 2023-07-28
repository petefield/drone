using blazor.signalr.Server;
using Drone;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs;



public class SignalRBridge : ISignalRBridge
{
    public event EventHandler<ControllerEventArgs> ControllerInputReceived;

    public void Update()
    {
        var c = ControllerInputReceived;
        c?.Invoke(this, new ControllerEventArgs(""));
    }


}

public class MessageHub : Hub
{
    private readonly ISignalRBridge _bridge;

    public MessageHub(ISignalRBridge bridge)
    {
        _bridge = bridge;
    }

    public async Task Update(DroneCommands.RemoteCommand command)
    {
        _bridge.Update();
    }
}