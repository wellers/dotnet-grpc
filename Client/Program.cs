using Grpc.Core;
using MyPackage;

Channel channel = new Channel("localhost", 50051, ChannelCredentials.Insecure);
var client = new MyService.MyServiceClient(channel);

HelloRequest request = new HelloRequest { Name = "Alice" };
HelloResponse response = client.Hello(request);

Console.WriteLine(response.Message);

channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();