using System.Collections;

namespace BitViewer
{
    class Packet
    {
        public BitArray data;
        public int index;

        public Packet(byte[] bytesFromFile,int packetIndex)
        {
            this.data = new BitArray(bytesFromFile);
            this.index = packetIndex;
        }
    }
}
