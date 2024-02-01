namespace ClimateMonitor.Services;

public class DeviceSecretValidatorService
{
    private static readonly ISet<string> ValidSecrets = new HashSet<string>
        {
            "secret-ABC-123-XYZ-001",
            "secret-ABC-123-XYZ-002",
            "secret-ABC-123-XYZ-003"
        };

    /// <summary>
    /// Validates the device secret.
    /// </summary>
    /// <param name="deviceSecret">The device secret to validate.</param>
    /// <returns>True if the device secret is valid; otherwise, false.</returns>
    public bool ValidateDeviceSecret(string deviceSecret)
        => ValidSecrets.Contains(deviceSecret);
}
