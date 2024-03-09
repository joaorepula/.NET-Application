using System;
using System.Collections.Generic;
using System.Linq;

public class EndpointService
{
    private List<Company> endpoints = new List<Company>();

    public void AddEndpoint(Company newEndpoint)
    {
        if (newEndpoint == null)
            throw new ArgumentNullException(nameof(newEndpoint));

        if (endpoints.Any(ep => ep.SerialNumber == newEndpoint.SerialNumber))
            throw new ArgumentException("An endpoint with the same serial number already exists.");

        endpoints.Add(newEndpoint);
    }

    public void UpdateEndpoint(Company updatedEndpoint)
    {
        if (updatedEndpoint == null)
            throw new ArgumentNullException(nameof(updatedEndpoint));

        var existingEndpoint = endpoints.FirstOrDefault(ep => ep.SerialNumber == updatedEndpoint.SerialNumber);
        if (existingEndpoint == null)
            throw new ArgumentException("Endpoint not found.");

        existingEndpoint.SwitchState = updatedEndpoint.SwitchState;
    }

    public void RemoveEndpoint(string serialNumber)
    {
        var endpoint = endpoints.FirstOrDefault(ep => ep.SerialNumber == serialNumber);
        if (endpoint != null)
        {
            endpoints.Remove(endpoint);
        }
        else
        {
            throw new ArgumentException("Endpoint not found.");
        }
    }

    public IEnumerable<Company> GetAllEndpoints()
    {
        return endpoints;
    }
    public Company FindEndpointBySerialNumber(string serialNumber)
    {
        var endpoint = endpoints.FirstOrDefault(ep => ep.SerialNumber == serialNumber) ?? throw new InvalidOperationException("Endpoint not found for the provided serial number.");
        return endpoint;
    }

}
