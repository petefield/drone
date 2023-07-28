using blazor.signalr.Shared;
using Drone;
using DroneCommands;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace blazor.signalr.Server
{

    public class DroneController : IDroneController
    {
        private readonly IXboxController _xboxController;
        private readonly ISignalRController _signalRController;
        private readonly IDrone _drone;

        public DroneController(IXboxController xboxController, ISignalRController signalRController, IDrone drone)
        {
            _drone = drone;
            _xboxController = xboxController;
            _signalRController = signalRController;
            _drone.StateChanged += DroneStateChanged;
            _xboxController.ControllerInputReceived += ControllerInputReceived;
            _signalRController.ControllerInputReceived += ControllerInputReceived;
        }

        public void Start()
        {

            Console.WriteLine("START");
        }

        private void DroneStateChanged(object? sender, DroneStateChangedEventArgs e)
        {
            _signalRController.Refresh(e.State);
        }

        private void ControllerInputReceived(object? sender, ControllerEventArgs e)
        {
            RemoteCommand remoteCommand = new RemoteCommand(new Shared.Speed(0, 0, 0), 0);

            _drone.SetState(remoteCommand);
        }
    }
}
