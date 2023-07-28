using blazor.signalr.Shared;

namespace Drone
{
    public class DroneStateChangedEventArgs : EventArgs
    {
        public DroneStateChangedEventArgs(DroneState state)
        {
            State = state;
        }

        public DroneState State {get ;}
    }
}