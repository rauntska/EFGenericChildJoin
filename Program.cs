using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EFGenericChildJoin.Data;
using EFGenericChildJoin.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFGenericChildJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                // Create service collection and configure our services
                var services = ConfigureServices();
                // Generate a provider
                var serviceProvider = services.BuildServiceProvider();

                using (var dataContext = serviceProvider.GetService<DataContext>())
                {
                    var contracts = dataContext.Contract.Where(x => true).IncludeResourceAttachment(serviceProvider).ToList();
                    var customers = dataContext.Customer.Where(x => true).IncludeResourceAttachment(serviceProvider).ToList();
                }

                Console.WriteLine("Finished");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }
         private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "DataDB"));

            return services;
        }
    }
}