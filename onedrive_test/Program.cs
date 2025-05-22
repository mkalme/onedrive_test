using Microsoft.Graph;
using Azure.Identity;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Microsoft.Graph.Models.Security;

namespace onedrive_test
{
    internal class Program
    {
        private static string Secret = "";
        private static string ClientId = "";
        private static string TenantId = "";

        private static string[] Scopes = { "" };

        private static string FilePath = "RenderedMap.png";

        static void Main(string[] args)
        {
            var confidentialClientApplication = ConfidentialClientApplicationBuilder
            .Create(ClientId)
            .WithTenantId(TenantId)
            .WithClientSecret(Secret)
            .Build();

            var authProvider = new ClientCredentialProvider(confidentialClientApplication);
            var graphClient = new GraphServiceClient(authProvider);

            using var stream = new FileStream(filePath, FileMode.Open);
            var driveItem = graphClient.Me.Drive.Root.ItemWithPath(Path.GetFileName(filePath)).Content.Request().PutAsync<DriveItem>(stream);

            Console.ReadLine();
        }
    }
}