using Microsoft.Extensions.DependencyInjection;
using ProgettoEnterprise;
using ProgettoEnterprise.CLI.Interfaces;
using ProgettoEnterprise.Persistency.Interfaces;
using ProgettoEnterprise.FileManager.Interfaces;


var serviceProvider = new ServiceCollection()
                .AddTransient<DbReadWrite,DBmanager>()
                .AddTransient<ICommands, Commands>()
                .AddTransient<Downloader,FileDownloader>()
                .AddTransient<Searcher,FileSearcher>()
                .BuildServiceProvider();
            

            var service = serviceProvider.GetService<ICommands>();
            service.readData(1);


/*
Commands commands = new Commands(new DBmanager(), new FileDownloader(new DBmanager()), new FileSearcher(new DBmanager()) );
commands.readData(2);
*/
