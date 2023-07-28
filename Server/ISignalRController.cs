using blazor.signalr.Shared;

namespace blazor.signalr.Server
{
    public interface ISignalRController : IInputController
    {
        void Start();

        public void Refresh(DroneState droneState);
    }
}