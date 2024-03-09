public class EndpointController
{
    private readonly ConsoleView view;
    private readonly EndpointService service;

    public EndpointController(ConsoleView view, EndpointService service)
    {
        this.view = view;
        this.service = service;
    }
    //Lembrar de usar constantes e refatorar caso de tempo por conta do switch do Program.cs
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            int option = view.ShowMainMenu();
            switch (option)
            {
                case 1: // Insert a new endpoint
                    InsertEndpoint();
                    break;
                case 2: // Edit an existing endpoint
                    EditEndpoint();
                    break;
                case 3: // Delete an existing endpoint
                    DeleteEndpoint();
                    break;
                case 4: // List all endpoints
                    ListEndpoints();
                    break;
                case 5: // Find an endpoint by Serial Number
                    FindEndpointBySerialNumber();
                    break;
                case 6: // Exit
                    Environment.Exit(0);
                    break;

            }
        }
    }

    private void InsertEndpoint()
    {
        Company newEndpoint = view.GetNewEndpointData();
        try
        {
            service.AddEndpoint(newEndpoint);
            view.DisplayMessage("Endpoint added successfully.");
        }
        catch (Exception e) 
        {
            view.DisplayMessage($"Error: {e.Message}");
        }
    }

    private void EditEndpoint()
    {
        string serialNumber = view.AskForSerialNumber();
        Company endpoint = service.FindEndpointBySerialNumber(serialNumber);
        if (endpoint == null)
        {
            view.DisplayMessage("Endpoint not found.");
        }
        else
        {
            int newSwitchState = view.AskForSwitchState();
            endpoint.SwitchState = newSwitchState;
            service.UpdateEndpoint(endpoint);
            view.DisplayMessage("Endpoint updated successfully.");
        }
    }

    private void DeleteEndpoint()
    {
        string serialNumber = view.AskForSerialNumber();
        Company endpoint = service.FindEndpointBySerialNumber(serialNumber);
        if (endpoint == null)
        {
            view.DisplayMessage("Endpoint not found.");
            return;
        }

        if (view.ConfirmAction())
        {
            service.RemoveEndpoint(serialNumber);
            view.DisplayMessage("Endpoint removed successfully.");
        }
    }

    private void ListEndpoints()
    {
        IEnumerable<Company> endpoints = service.GetAllEndpoints();
        foreach (var endpoint in endpoints)
        {
            view.DisplayEndpoint(endpoint);
        }
    }

    private void FindEndpointBySerialNumber()
    {
        string serialNumber = view.AskForSerialNumber();
        Company endpoint = service.FindEndpointBySerialNumber(serialNumber);
        if (endpoint == null)
        {
            view.DisplayMessage("Endpoint not found.");
        }
        else
        {
            view.DisplayEndpoint(endpoint);
        }
    }

}
