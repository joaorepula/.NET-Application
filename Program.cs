public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adicione os serviços necessários
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure o pipeline de solicitação HTTP.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Inicie o servidor web em paralelo com a execução da lógica do console
        var webHostTask = RunWebHostAsync(app);

        // Executar a lógica do console
        var view = new ConsoleView();
        var service = new EndpointService();
        var controller = new EndpointController(view, service);
        controller.Run();

        // Aguardar a conclusão do servidor web
        webHostTask.Wait();
    }

    // Método para iniciar o servidor web
    private static async Task RunWebHostAsync(IHost app)
    {
        await app.RunAsync();
    }
}
