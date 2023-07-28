using Drone;

namespace blazor.signalr.Server
{

    public class ControllerEventArgs : EventArgs
    {
        public ControllerEventArgs(string controllerState)
        {
            ControllerState = controllerState;
        }

        public string ControllerState { get; }
    }


    public class XboxController : IXboxController
    {
        public event EventHandler<ControllerEventArgs> ControllerInputReceived;

        public XboxController()
        {
        }


        public void Start()
        {

            Task.Run(() => Poll());
        }

        private void Poll()
        {
            while (true)
            {
                Console.WriteLine("Poll");
                Thread.Sleep(1000);

                ControllerInputReceived?.Invoke(this, new ControllerEventArgs( "test"));

            }
        }
    }
}
