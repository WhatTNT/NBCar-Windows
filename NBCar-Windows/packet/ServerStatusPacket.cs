using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBCar_Windows.packet
{
    class ServerStatusPacket : Packet
    {

        private readonly short leftPower;
        private readonly short rightPower;

        public ServerStatusPacket(Int16 leftPower, Int16 rightPower)
        {
            this.leftPower = leftPower;
            this.rightPower = rightPower;
        }

        public override byte[] GetData()
        {
            byte[] bs = new byte[4];
            bs[0] = (byte)(leftPower / 256);
            bs[1] = (byte)(leftPower % 256);
            bs[2] = (byte)(rightPower / 256);
            bs[3] = (byte)(rightPower % 256);
            return bs;
        }

        public override PacketType GetPacketType()
        {
            return PacketType.SERVER_STATUS;
        }
    }
}
