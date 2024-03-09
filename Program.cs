public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        var webHostTask = RunWebHostAsync(app);

        var view = new ConsoleView();
        var service = new EndpointService();
        var controller = new EndpointController(view, service);
        controller.Run();

        webHostTask.Wait();
    }

    private static async Task RunWebHostAsync(IHost app)
    {
        await app.RunAsync();
    }
}
