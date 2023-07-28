using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blazor.signalr.Shared
{
    public record struct DroneState(int pitch, int roll, int yaw, Speed speed, int tempMin, int tempMax, int ToF, int height, int bat, int bar, TimeSpan time, int agx, int agy, int agz)
    {
    }
}
