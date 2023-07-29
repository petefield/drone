using Drone;
using DroneCommands;
using Gamepad;

namespace blazor.signalr.Server
{

    public class XboxController : IXboxController
    {
        public event EventHandler<ControllerEventArgs> ControllerInputReceived;
        GamepadController _gamepadController;
        RemoteCommand _command = new RemoteCommand(new Shared.Speed(0,0,0),0);

        public XboxController()
        {
            _gamepadController = new GamepadController("/dev/input/js0");
        }

        private void Update()
        {
            ControllerInputReceived?.Invoke(this, new ControllerEventArgs(_command));
        }


        public void Start()
        {
      
                Console.WriteLine("Start pushing the buttons/axis of your gamepad/joystick to see the output");

                // Configure this if you want to get events when the state of a button changes
                _gamepadController.ButtonChanged += (object sender, ButtonEventArgs e) =>
                {
                    Console.WriteLine($"Button {e.Button} Changed: {e.Pressed}");
                    Update();
                };

                // Configure this if you want to get events when the state of an axis changes
                _gamepadController.AxisChanged += (object sender, AxisEventArgs e) =>
                {
                    var speed = _command.Speed;

                    switch(e.Axis)
                    {
                        case 1:
                            speed.X  = scale(e.Value);
                            break;
                        case 0:
                            speed.Y  = scale(e.Value);
                            break;
                        case 3:
                            speed.Z  = scale(e.Value);
                            break;
                        case 2:
                            _command.Yaw  = scale(e.Value);
                            break;
                        default:
                            break;
                    }
                    _command.Speed = speed;

                    Update();
                };

        }

        private int scale(short i)
        {
             var o = ((double)i/   32767) *100;
             return (int)Math.Round( o,0);

        }
    }
}
