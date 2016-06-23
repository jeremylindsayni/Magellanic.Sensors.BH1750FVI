namespace Magellanic.Sensors.BH1750FVI
{
    public enum MeasurementMode
    {
        ContinuouslyHighResolutionMode = 0x10,
        ContinuouslyHighResolutionMode2 = 0x11,
        ContinuouslyLowResolutionMode = 0x13,
        OneTimeHighResolutionMode = 0x20,
        OneTimeHighResolutionMode2 = 0x21,
        OneTimeLowResolutionMode = 0x23
    }
}
