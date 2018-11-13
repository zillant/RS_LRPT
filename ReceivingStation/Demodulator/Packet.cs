using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceivingStation.Demodulator
{
    class Packet
    {
        public sbyte[] SyncMarker = new sbyte[48];
        public sbyte[] PacketBody = new sbyte[16336];
    }

    class BitPacket
    {
        public sbyte[] SyncMarker = new sbyte[48];
        public sbyte[] PacketBody = new sbyte[16336];
    }
}
