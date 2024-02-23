using Microsoft.Extensions.DependencyInjection;
using ProgettoEnterprise;
using ProgettoEnterprise.CLI.Interfaces;
using ProgettoEnterprise.Persistency.Interfaces;
using ProgettoEnterprise.FileManager.Interfaces;
using Microsoft.Extensions.Configuration;


                Console.ForegroundColor = ConsoleColor.Green;

                IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();




                 var serviceProvider = new ServiceCollection()
                .AddTransient<DbReadWrite,DBmanager>()
                .AddTransient<ICommands, Commands>()
                .AddTransient<Downloader,FileDownloader>()
                .AddTransient<Searcher,FileSearcher>()
                .AddTransient<MyApp>()
                .BuildServiceProvider();
            

                 var service = serviceProvider.GetService<MyApp>();
                 service.execute();



