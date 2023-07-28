using blazor.signalr.Shared;

namespace DroneCommands;

public readonly record struct RemoteCommand(Speed Speed, int Yaw);
