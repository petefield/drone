using blazor.signalr.Shared;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace blazor.signalr.Server
{
    public class SignalRController : ISignalRController
    {
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ISignalRBridge _bridge;

        public event EventHandler<ControllerEventArgs> ControllerInputReceived;

        public SignalRController(IHubContext<MessageHub> hubContext, ISignalRBridge bridge)
        {
            _hubContext = hubContext;
            _bridge = bridge;
            _bridge.ControllerInputReceived += _bridge_ControllerInputReceived;
        }

        private void _bridge_ControllerInputReceived(object? sender, ControllerEventArgs e)
        {
            var c = ControllerInputReceived;
            c?.Invoke(this, e);
        }

        public void Start()
        { }

        public async void Refresh(DroneState droneState) 
            => await _hubContext.Clients.All.SendAsync("refresh", droneState);
    }
}
