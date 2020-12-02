using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBCar_Windows.packet
{
    class ServerStatusPacket : Packet
    {

        private readonly byte leftPower;
        private readonly byte rightPower;

        public ServerStatusPacket(byte leftPower, byte rightPower)
        {
            this.leftPower = leftPower;
            this.rightPower = rightPower;
        }

        public override byte[] GetData()
        {
            byte[] bs = new byte[2];
            bs[0] = leftPower;
            bs[1] = rightPower;
            return bs;
        }

        public override PacketType GetPacketType()
        {
            return PacketType.SERVER_STATUS;
        }
    }
}
