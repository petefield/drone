using System.Security.AccessControl;
using blazor.signalr.Shared;
using DroneCommands;

namespace Drone
{


    public class Drone : IDrone
    {
        public event EventHandler<DroneStateChangedEventArgs> StateChanged;
        private Random random;
        public Drone()
        {
            random = new Random();
        }

        public void Start()
        {
            Task.Run(() =>
            {
                Thread.Sleep(500);
                var x = random.Next(-100, 100);
                notifyStateChange(new DroneState(0, 0, 0,
                        new Speed(x, 0, 0), 0, 0, 0, 0, 0, 0, TimeSpan.FromSeconds(0), 0, 0, 0));
            });
        }

        public void Kill()
        {
            Console.WriteLine("KILL");
        }

        public void SetState(DroneCommands.RemoteCommand cmd)
        {
            Console.WriteLine($"x : {cmd.Speed.X} y : {cmd.Speed.Y} z : {cmd.Speed.Z} yaw : {cmd.Yaw} ");
        }


        private void notifyStateChange(DroneState droneState)
        {
            var evt = StateChanged;

            if (evt != null)
            {
                StateChanged(this, new DroneStateChangedEventArgs(droneState));
            }
        }
    }
}