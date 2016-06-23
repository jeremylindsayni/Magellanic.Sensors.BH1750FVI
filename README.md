# Magellanic.Sensors.BH1750FVI
This is a C# implementation of code which integrates the BH1750FVI digital light sensor with Windows 10 IoT Core on the Raspberry Pi 3.

## Getting started
To build this project, you'll need the Magellanic.I2C project also (this is a NuGet package which is referenced in the project, so you may need to restore NuGet packages in your solution).

You should reference the Magellanic.Sensors.BH1750FVI in your Visual Studio solution. The BH1750FVI can be used with the following sample code from a blank Windows 10 UWP app:

```C#
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
 
        Loaded += MainPage_Loaded;
    }
 
    private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        try
        {
          var lightSensitivityMeter = new BH1750FVI(AddPinConnection.PIN_LOW);

          await lightSensitivityMeter.Initialize();

          lightSensitivityMeter.PowerOn();
          lightSensitivityMeter.Reset();

          lightSensitivityMeter.SetMode(MeasurementMode.ContinuouslyHighResolutionMode);

          while (true)
          {
              var lux = lightSensitivityMeter.GetLightLevel();

              Debug.WriteLine("Lux = " + lux);

              Task.Delay(1000).Wait();
          }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
```
