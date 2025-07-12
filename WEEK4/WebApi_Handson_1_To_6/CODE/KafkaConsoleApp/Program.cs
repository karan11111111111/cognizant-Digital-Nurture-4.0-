using KafkaConsoleApp.Consumers;
using KafkaConsoleApp.Producers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<KafkaChatProducer>();
        services.AddHostedService<KafkaChatConsumer>();
    })
    .Build();

Console.WriteLine("Kafka Console Application");
Console.WriteLine("1. Start Producer (Type messages)");
Console.WriteLine("2. Start Consumer (Read messages)");
Console.WriteLine("3. Run Both");
Console.Write("Choose an option: ");

var option = Console.ReadLine();

switch (option)
{
    case "1":
        await RunProducer(host.Services);
        break;
    case "2":
        await host.RunAsync();
        break;
    case "3":
        var producerTask = RunProducer(host.Services);
        var consumerTask = host.RunAsync();
        await Task.WhenAll(producerTask, consumerTask);
        break;
    default:
        Console.WriteLine("Invalid option");
        break;
}

async Task RunProducer(IServiceProvider services)
{
    using var producer = services.GetRequiredService<KafkaChatProducer>();
    Console.WriteLine("Producer started. Type messages (or 'exit' to quit):");

    while (true)
    {
        var message = Console.ReadLine();
        if (message?.ToLower() == "exit") break;

        if (!string.IsNullOrWhiteSpace(message))
        {
            await producer.ProduceAsync(message);
            Console.WriteLine($"Message sent: {message}");
        }
    }
}