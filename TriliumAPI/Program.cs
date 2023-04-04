using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace TriliumQido
{
    public class Program
    {
        private const string _logName = "TriliumAgentServer";
        public static void Main(string[] args)
        {
            try
            {
                HttpSelfHostServer server = CreateHost("http://localhost:7787");
                Console.WriteLine("Please Do not close this window...");
                Console.WriteLine("This program listens to api call from portal...");
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception at Main.Message: " + ex.Message);
                ////StaticLogger.LogError("Exception at Main. Message: " + ex.Message, _logName);
            }
        }

        static HttpSelfHostServer CreateHost(string address)
        {
            try
            {
                // Create normal config
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(address);

                // Set our own assembly resolver where we add the assemblies we need
                AssembliesResolver assemblyResolver = new AssembliesResolver();
                config.Services.Replace(typeof(IAssembliesResolver), assemblyResolver);

                // Add a route
                config.Routes.MapHttpRoute(
                  name: "default",
                  routeTemplate: "api/{controller}/{action}/{param1}/{param2}/{param3}/{param4}",
                    defaults: new
                    {
                        action = RouteParameter.Optional,
                        param1 = RouteParameter.Optional,
                        param2 = RouteParameter.Optional,
                        param3 = RouteParameter.Optional,
                        param4 = RouteParameter.Optional
                    }
                );

                config.EnableCors(new EnableCorsAttribute("*", headers: "*", methods: "*"));


                HttpSelfHostServer server = new HttpSelfHostServer(config);
                server.OpenAsync().Wait();
                //string filepath = "";
                //Console.WriteLine("Listening on " + address);
                //string str1 = @"C:\Program Files (x86)\SmartRxHub\TriliumAgent\Scannerapplication.exe";
                //string str2 = @"C:\Program Files\SmartRxHub\TriliumAgent\Scannerapplication.exe";
                //if (File.Exists(str1))
                //{
                //    filepath = str1;
                //}
                //else
                //{
                //    filepath = str2;
                //}
                ////StaticLogger.LogInfo("At Servicedoc filepath: " + filepath, _logName);
                return server;
            }catch (Exception ex)
            {
                ////StaticLogger.LogError("Exception at CreateHost. Message: " + ex.Message, _logName);
                return null;
            }
        }
    }

    class AssembliesResolver : DefaultAssembliesResolver
    {
        private const string _logName = "TriliumAgentServer";
        public override ICollection<Assembly> GetAssemblies()
        {
            try
            {
                ICollection<Assembly> baseAssemblies = base.GetAssemblies();
                List<Assembly> assemblies = new List<Assembly>(baseAssemblies);

                // Add whatever additional assemblies you wish

                return assemblies;
            }catch(Exception ex)
            {
                ////StaticLogger.LogError("Exception at GetAssemblies. Message: " + ex.Message, _logName);
                return null;
            }
        }
    }
}
