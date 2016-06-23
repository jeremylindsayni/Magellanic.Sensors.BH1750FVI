using Magellanic.I2C;
using System;
using System.Threading.Tasks;

namespace Magellanic.Sensors.BH1750FVI
{
    public class BH1750FVI : AbstractI2CDevice
    {
        private byte I2C_ADDRESS = 0x23;

        public override byte[] GetDeviceId()
        {
            throw new NotImplementedException();
        }

        public override byte GetI2cAddress()
        {
            return I2C_ADDRESS;
        }

        public void PowerOn()
        {
            this.Slave.Write(new byte[] { 0x01 });
        }

        public void PowerOff()
        {
            this.Slave.Write(new byte[] { 0x00 });
        }

        public void Reset()
        {
            this.Slave.Write(new byte[] { 0x07 });
        }

        public void SetMode(MeasurementMode measurementMode)
        {
            this.Slave.Write(new byte[] { (byte)measurementMode });
            Task.Delay(10).Wait();
        }

        public int GetLightLevel()
        {
            var readBuffer = new byte[2];

            this.Slave.WriteRead(new byte[] { I2C_ADDRESS }, readBuffer);

            var lightLevel = readBuffer[0] << 8 | readBuffer[1];

            return (int)(((float)lightLevel) / 1.2f);
        }
    }
}
