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

namespace Avola.Demo.ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var exitCode = Parser.Default.ParseArguments<SettingsOptions, ListOptions>(args)
                    .MapResult(
                        (SettingsOptions opts) => RunGetSettings(opts),
                        (ListOptions opts) => RunDecisionList(opts),
                        errs => 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        [Verb("settings", HelpText = "Get the settings for the organisation.")]
        private class SettingsOptions : BaseOptions
        {
        }

        [Verb("list", HelpText = "Show a list of executable decisions.")]
        private class ListOptions : BaseOptions
        {
        }

        abstract class BaseOptions
        {
            [Option('o', "organisation", Default = "set-your-default-here", HelpText = "Provide organisation name.")]
            public string OrganisationName { get; set; }
            [Option('c', "clientid", Default = "set-your-default-here", HelpText = "Provide client id.")]
            public string ClientId { get; set; }
            [Option('s', "clientsecret", Default = "set-your-default-here", HelpText = "Provide client secret.")]
            public string ClientSecret { get; set; }
            [Option('t', "thumbprint", Default = "set-your-default-here", HelpText = "Provide certificate thumbprint.")]
            public string Thumbprint { get; set; }
        }

        private static int RunGetSettings(SettingsOptions opts)
        {
            Task.Run(async () =>
            {
                var apiClient = new AvolaApiClient($"https://{opts.OrganisationName}.api.execution.test.avo.la/api/", opts.ClientId, opts.ClientSecret);
                var settings = await apiClient.GetApiDescription();
                Console.WriteLine(settings);
            })
            .Wait();

            return 1;
        }

        private static int RunDecisionList(ListOptions opts)
        {

            Task.Run(async () =>
            {
                var apiClient = new AvolaApiClient($"https://{opts.OrganisationName}.api.execution.test.avo.la/api/", opts.ClientId, opts.ClientSecret);

                var list = await apiClient.ListAvailableDecisionServices();
                Console.WriteLine(list.Count);

            }).Wait();

            return 1;
        }
    }
}
