using Autofac;
using AutoMapper;
using BusinessLogicLibrary.Application;
using BusinessLogicLibrary.DataAccess;
using BusinessLogicLibrary.Model;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;

// Create custom config file to store connection strings
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Create automapper config
var mapConfig = new MapperConfiguration(cfg =>
{
    // Scan the assembly for classes that implement IMapFrom<>
    cfg.AddProfile<MapperProfiles>();
});

//Register database client
var builder = new ContainerBuilder();
builder.RegisterType<SqlDatabase>().As<IDatabase>()
    .WithParameter("connectionString", config.GetConnectionString("SqlConnection"));

//Register parser
builder.RegisterType<OrderParser>().As<IOrderParser>();

// Create the mapper using the configuration
var mapper = mapConfig.CreateMapper();

// Register the mapper with Autofac
builder.RegisterInstance(mapper).As<IMapper>();

using (var container = builder.Build())
{
    using var scope = container.BeginLifetimeScope();
    var parser = scope.Resolve<IOrderParser>();
    var db = scope.Resolve<IDatabase>();

    //Get data and parse to xml string
    var model = db.GetOrder("RASO000001");
    var xml = parser.GetXmlString<OrderWrapperXmlDto>(parser.FromModelToDto(model));

    Console.WriteLine(xml);
    Console.WriteLine();
    Console.WriteLine();

    while (true)
    {
        Console.WriteLine("Enter Y to send this XML to the web api and get total ShippingQty or EXIT to exit: ");
        string input = Console.ReadLine().Trim().ToUpper();

        if (input == "Y")
        {
            var uri = "https://localhost:7209/api/Order/CalculateTotalShippedQty";

            using (var client = new HttpClient())
            {
                using (var content = new StringContent(xml, Encoding.UTF8, "application/xml"))
                {
                    using (var response = await client.PostAsync(uri, content))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseContent = await response.Content.ReadAsStringAsync();

                        Console.WriteLine();
                        Console.WriteLine($"Return result is : {responseContent}");
                    }
                }
            }
        }
        else if (input == "EXIT")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
}

