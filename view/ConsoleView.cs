

public class ConsoleView
{
    public int ShowMainMenu()
    {
        Console.WriteLine("Energy Company Endpoint Management");
        Console.WriteLine("1) Insert a new endpoint");
        Console.WriteLine("2) Edit an existing endpoint");
        Console.WriteLine("3) Delete an existing endpoint");
        Console.WriteLine("4) List all endpoints");
        Console.WriteLine("5) Find an endpoint by Serial Number");
        Console.WriteLine("6) Exit");
        Console.Write("Select an option: ");

        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
        {
            Console.WriteLine("Invalid input, please enter a number between 1 and 6.");
            Console.Write("Select an option: ");
        }

        return option;
    }

        public string AskForSerialNumber()
        {
            Console.Write("Enter the Endpoint Serial Number: ");
            string? input = Console.ReadLine();
            return input ?? string.Empty; // Substitui null por string vazia se input for null
        }

    public Company GetNewEndpointData()
    {
        Console.Write("Enter Endpoint Serial Number: ");
        string serialNumber = Console.ReadLine() ?? string.Empty; // Garante que não seja nulo

        Console.Write("Enter Meter Firmware Version: ");
        string meterFirmwareVersion = Console.ReadLine() ?? string.Empty; // Garante que não seja nulo

        int meterModelId;
        while (true)
        {
            Console.Write("Enter Meter Model Id (16, 17, 18, 19 for respective models): ");
            if (int.TryParse(Console.ReadLine(), out meterModelId) && (meterModelId >= 16 && meterModelId <= 19))
            {
                break;
            }
            Console.WriteLine("Invalid input, please enter a valid number between 16 and 19.");
        }

        int meterNumber;
        while (true)
        {
            Console.Write("Enter Meter Number: ");
            if (int.TryParse(Console.ReadLine(), out meterNumber))
            {
                break; 
            }
            Console.WriteLine("Invalid input, please enter a valid number.");
        }

        int switchState;
        while (true)
        {
            Console.Write("Enter Switch State (0 for Disconnected, 1 for Connected, 2 for Armed): ");
            if (int.TryParse(Console.ReadLine(), out switchState) && (switchState >= 0 && switchState <= 2))
            {
                break;
            }
            Console.WriteLine("Invalid input, please enter a number between 0 and 2.");
        }

        return new Company(serialNumber, meterFirmwareVersion)
        {
            MeterModelId = meterModelId,
            MeterNumber = meterNumber,
            SwitchState = switchState
        };
    }


    public int AskForSwitchState()
    {
        Console.WriteLine("Select the new Switch State:");
        Console.WriteLine("0) Disconnected");
        Console.WriteLine("1) Connected");
        Console.WriteLine("2) Armed");
        Console.Write("Select an option: ");

        int state;
        while (!int.TryParse(Console.ReadLine(), out state) || state < 0 || state > 2)
        {
            Console.WriteLine("Invalid input, please enter a number between 0 and 2.");
            Console.Write("Select an option: ");
        }

        return state;
    }

    public bool ConfirmAction()
    {
        Console.Write("Are you sure you want to proceed? (Y/N): ");
        string? confirmation = Console.ReadLine()?.ToUpper(); // Adiciona ? para evitar a desreferência nula
        return confirmation == "Y";
    }


    public void DisplayEndpoint(Company endpoint)
    {
        Console.WriteLine("Endpoint Serial Number: " + endpoint.SerialNumber);
        Console.WriteLine("Meter Model Id: " + endpoint.MeterModelId);
        Console.WriteLine("Meter Number: " + endpoint.MeterNumber);
        Console.WriteLine("Meter Firmware Version: " + endpoint.MeterFirmwareVersion);
        Console.WriteLine("Switch State: " + endpoint.SwitchState);
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
