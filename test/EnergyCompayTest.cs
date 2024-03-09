using NUnit.Framework;
using Moq;


[TestFixture]
public class EnergyCompayTest
{
    [Test]
    public void AddEndpoint_NewEndpoint_SuccessfullyAdded()
    {
        var mockCompany = new Company("12345", "v1.0") { MeterModelId = 16, MeterNumber = 123, SwitchState = 1 };
        var mockService = new Mock<EndpointService>();
        mockService.Setup(s => s.AddEndpoint(It.IsAny<Company>())).Verifiable();

        mockService.Object.AddEndpoint(mockCompany);

        mockService.Verify(s => s.AddEndpoint(It.IsAny<Company>()), Times.Once);
    }

    [Test]
    public void AddEndpoint_NullEndpoint_ThrowsArgumentNullException()
    {
        var mockService = new EndpointService();

        Assert.Throws<ArgumentNullException>(() => mockService.AddEndpoint(new Company("12345", "v1.0")));
    }

    [Test]
    public void GetAllEndpoints_ReturnsAllEndpoints()
    {
        var mockEndpoints = new List<Company>
        {
            new Company("12345", "v1.0") { MeterModelId = 16, MeterNumber = 123, SwitchState = 1 },
            new Company("54321", "v2.0") { MeterModelId = 17, MeterNumber = 456, SwitchState = 2 }
        };
        var mockService = new EndpointService();
        mockEndpoints.ForEach(ep => mockService.AddEndpoint(ep));

        var result = mockService.GetAllEndpoints();

        Assert.AreEqual(mockEndpoints.Count, result.Count());
    }

    [Test]
    public void FindEndpointBySerialNumber_ExistingEndpoint_ReturnsEndpoint()
    {
        var mockEndpoint = new Company("12345", "v1.0") { MeterModelId = 16, MeterNumber = 123, SwitchState = 1 };
        var mockService = new EndpointService();
        mockService.AddEndpoint(mockEndpoint);

        var result = mockService.FindEndpointBySerialNumber("12345");

        Assert.IsNotNull(result);
        Assert.AreEqual(mockEndpoint.SerialNumber, result.SerialNumber);
    }

    [Test]
    public void FindEndpointBySerialNumber_NonExistingEndpoint_ThrowsInvalidOperationException()
    {
        var mockService = new EndpointService();

        Assert.Throws<InvalidOperationException>(() => mockService.FindEndpointBySerialNumber("12345"));
    }
}
