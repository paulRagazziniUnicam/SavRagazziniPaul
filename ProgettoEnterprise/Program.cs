using Enterprise;
using Microsoft.Extensions.Configuration;
using ProgettoEnterprise;

/*
MyApp app = new MyApp();
app.execute();
*/

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var batchSize = config["AutoNumberOptions:BatchSize"];

Console.WriteLine($"Batch Size {batchSize}");







