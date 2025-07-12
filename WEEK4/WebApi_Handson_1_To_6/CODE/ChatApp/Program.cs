using ChatApp.Forms;
using ChatApp.Services;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ChatApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var kafkaService = new KafkaService(configuration);

            Application.Run(new ChatForm(kafkaService));
        }
    }
}