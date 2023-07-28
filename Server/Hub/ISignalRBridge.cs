using blazor.signalr.Server;

namespace SignalRChat.Hubs
{
    public interface ISignalRBridge
    {
        event EventHandler<ControllerEventArgs> ControllerInputReceived;

        void Update();
    }
}