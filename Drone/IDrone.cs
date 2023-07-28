namespace Drone
{
    public interface IDrone
    {
        void Kill();
        void SetState(DroneCommands.RemoteCommand command);

        event EventHandler<DroneStateChangedEventArgs> StateChanged;


        void Start();
    }
}