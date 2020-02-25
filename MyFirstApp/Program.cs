using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MyFirstApp
{

    class Program
    {

        static public string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";
        static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } =
            new Dictionary<string, string>()
            {
                ["Profile:Username"] =  Environment.UserName,
                ["AppConfiguration:ConnectionString"] = DefaultConnectionString,
            };
        static public IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            configurationBuilder.AddJsonFile("appsettings.json");

            int inMemWidth = 70;
            int inMemHeight = 50;

            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                ["Custom:Width"] = inMemWidth.ToString(),
                ["Custom:Height"] = inMemHeight.ToString()
            });

            Configuration = configurationBuilder.Build();

 

            Console.SetWindowSize(Int32.Parse(Configuration["Custom:Width"]), Int32.Parse(Configuration["Custom:Height"]));
            Console.WriteLine($"Hello {Configuration.GetValue<string>("Profile:Username")}");
            //Console.WriteLine($"{}");
            Console.ReadKey();
        }
    }
}
