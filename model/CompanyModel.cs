public class Company
{
    public string SerialNumber { get; set; }
    public int MeterModelId { get; set; }
    public int MeterNumber { get; set; }
    public string MeterFirmwareVersion { get; set; }
    public int SwitchState { get; set; }

    public Company(string serialNumber, string meterFirmwareVersion)
    {
        if (string.IsNullOrEmpty(serialNumber))
        {
            throw new ArgumentNullException(nameof(serialNumber), "Serial number cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(meterFirmwareVersion))
        {
            throw new ArgumentNullException(nameof(meterFirmwareVersion), "Meter firmware version cannot be null or empty.");
        }

        SerialNumber = serialNumber;
        MeterFirmwareVersion = meterFirmwareVersion;
    }
}
