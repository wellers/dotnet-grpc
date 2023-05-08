using Grpc.Core;
using MyPackage;

Server server = new()
{
    Services = { MyService.BindService(new MyServiceImplementation()) },
    Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
};
server.Start();

Console.WriteLine("Server listening on port 50051");

Console.WriteLine("Press any key to stop the server...");
Console.ReadKey();

server.ShutdownAsync().Wait();

public class MyServiceImplementation : MyService.MyServiceBase
{
    public override Task<HelloResponse> Hello(HelloRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Request received from {request.Name}...");

        return Task.FromResult(new HelloResponse
        {
            Message = "Hello, " + request.Name
        });
    }
}