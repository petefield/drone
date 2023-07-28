using DroneCommands;

namespace blazor.signalr.Server
{
    public class ControllerEventArgs : EventArgs
    {
        public ControllerEventArgs(RemoteCommand controllerState)
        {
            ControllerState = controllerState;
        }

        public RemoteCommand ControllerState { get; }
    }
    
}
