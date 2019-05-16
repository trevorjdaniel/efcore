using System;
using System.IO;
using System.Reflection.Metadata;
using ICMASync.Data;
using ICMASync.Data.Context;
using ICMASync.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject;

namespace DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //builder for BaseContext
            var builder = new DbContextOptionsBuilder<BaseContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            
            //Use with DI
            ExampleWithNinjectDIContainer(builder.Options);

            //Manual creation
            ExampleWithManual(builder.Options);

            //For asp.net it should be done in Startup.ConfigureServices()
        }

        private static void ExampleWithManual(DbContextOptions<BaseContext> dbContextOptions)
        {
            var factory = new BaseContextFactory(dbContextOptions);
            var engine = new Engine(factory);
            //engine.Sync()
        }

        private static void ExampleWithNinjectDIContainer(DbContextOptions<BaseContext> dbContextOptions)
        {
            //use your favorite DI container for composition, I prefer Ninject
            var kernel = new StandardKernel();

            kernel.Bind<IBaseContextFactory>().ToConstant(new BaseContextFactory(dbContextOptions)).InSingletonScope(); //as singleton
            kernel.Bind<Engine>().ToSelf().InSingletonScope(); //as singleton too
            kernel.Bind<SomeUsefulClass>().ToSelf(); //new on each request
            
            var engine = kernel.Get<Engine>();
            //engine.Sync(new EngineSyncParams()) invoke

            var someUsefulClass = kernel.Get<SomeUsefulClass>();
            someUsefulClass.DoSome();
        }
    }

    class BaseContextFactory : IBaseContextFactory
    {
        private readonly DbContextOptions<BaseContext> _dbContextOptions;

        public BaseContextFactory(DbContextOptions<BaseContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public BaseContext Create()
        {
            return new BaseContext(_dbContextOptions);
        }
    }

    class SomeUsefulClass 
    {
        private readonly IBaseContextFactory _baseContextFactory;

        public SomeUsefulClass(IBaseContextFactory baseContextFactory)
        {
            _baseContextFactory = baseContextFactory;
        }

        public void DoSome()
        {
            using (var baseContext = _baseContextFactory.Create())
            {
                foreach (var test in baseContext.Test)
                {
                    Console.WriteLine($"{test.Id} - {test.Trev}");
                }
            }
        }
    }
}
