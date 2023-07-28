using blazor.signalr.Shared;

namespace DroneCommands;

public record struct RemoteCommand(Speed Speed, int Yaw);
