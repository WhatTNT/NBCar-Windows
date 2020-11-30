using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBCar_Windows.packet
{
    abstract class Packet
    {
        abstract public byte[] GetData();

        abstract public PacketType GetPacketType();

        public byte[] Build()
        {
            byte[] data = GetData();
            byte[] bs = new byte[data.Length + 4];
            bs[0] = 0x0f;
            bs[1] = (byte)(data.Length + 4);
            bs[2] = (byte)GetPacketType();
            for (int i = 0;i < data.Length; i++)
            {
                bs[3 + i] = data[i];
            }
            bs[data.Length + 3] = 0x10;
            return bs;
        }

    }
}
