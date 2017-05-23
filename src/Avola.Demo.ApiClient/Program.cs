using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using IdentityModel;
using Newtonsoft.Json;

namespace Avola.Demo.ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var exitCode = Parser.Default.ParseArguments<SettingsOptions, ListOptions, ExecuteOptions>(args)
                    .MapResult(
                        (SettingsOptions opts) => RunGetSettings(opts),
                        (ListOptions opts) => RunDecisionList(opts),
                        (ExecuteOptions opts) => RunExecuteDecision(opts),
                        errs => 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
        }

        [Verb("settings", HelpText = "Get the settings for the organisation.")]
        private class SettingsOptions : BaseOptions
        {
        }

        [Verb("list", HelpText = "Show a list of executable decisions.")]
        private class ListOptions : BaseOptions
        {
        }

        [Verb("execute", HelpText = "Execute a specific decision service.")]
        private class ExecuteOptions : BaseOptions
        {
        }

        abstract class BaseOptions
        {
            [Option('v', "verbose", Default = false, HelpText = "Show me what happens.")]
            public bool Verbose { get; set; }
        }

        private static string BaseUrl() => $"https://{AppSettings.Environment.Organisation}.api.execution.{AppSettings.Environment.Name}.avo.la/api/";

        private static int RunGetSettings(SettingsOptions opts)
        {
            Task.Run(async () =>
            {
                var apiClient = new AvolaApiClient(BaseUrl(), AppSettings.Authentication.ClientId, AppSettings.Authentication.Secret);
                var settings = await apiClient.GetApiDescription();
                Console.WriteLine($"Here are the execution api settings for {AppSettings.Environment.Organisation}");
                Console.WriteLine(JsonConvert.SerializeObject(settings, Formatting.Indented));
            })
            .Wait();

            return 1;
        }

        private static int RunDecisionList(ListOptions opts)
        {
            Task.Run(async () =>
            {
                var apiClient = new AvolaApiClient(BaseUrl(), AppSettings.Authentication.ClientId, AppSettings.Authentication.Secret);

                var list = await apiClient.ListAvailableDecisionServices();
                Console.WriteLine($"There are {list.Count} decision services available to execute.");

                foreach (var decision in list)
                {
                    Console.WriteLine(decision.Name);
                }
            }).Wait();

            return 1;
        }

        private static int RunExecuteDecision(ExecuteOptions opts)
        {
            throw new NotImplementedException();
        }
    }
}
