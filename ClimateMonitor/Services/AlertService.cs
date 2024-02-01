using ClimateMonitor.Services.Models;

namespace ClimateMonitor.Services;

public class AlertService
{
    /// <summary>
    /// A set of sensor validators that check if the device readings are within the acceptable range.
    /// </summary>
    private static readonly HashSet<Func<DeviceReadingRequest, Alert?>> SensorValidators = new()
                {
                    deviceReading =>
                        deviceReading.Humidity is < 0 or > 100
                        ? new Alert(AlertType.HumiditySensorOutOfRange, "Humidity sensor is out of range.")
                        : default,

                    deviceReading =>
                        deviceReading.Temperature is < -10 or > 50
                        ? new Alert(AlertType.TemperatureSensorOutOfRange, "Temperature sensor is out of range.")
                        : default,
                };

    /// <summary>
    /// Retrieves the alerts for the given device reading request.
    /// </summary>
    /// <param name="deviceReadingRequest">The device reading request.</param>
    /// <returns>The alerts generated based on the device readings.</returns>
    public IEnumerable<Alert> GetAlerts(DeviceReadingRequest deviceReadingRequest)
    {
        return SensorValidators
            .Select(validator => validator(deviceReadingRequest))
            .OfType<Alert>();
    }
}
