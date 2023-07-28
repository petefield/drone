namespace blazor.signalr.Server
{
    public interface IInputController {

        event EventHandler<ControllerEventArgs> ControllerInputReceived;


    }
}