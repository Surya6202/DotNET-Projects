using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using WebApp1.MVC.DataAccess;

namespace WebApp1.MVC.App_Start
{
    public static class DIConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register In-Memory DbContext with default data
            var options = new DbContextOptionsBuilder<WebAppDbContext>()
                              .UseInMemoryDatabase("MyMemoryDb")
                              .Options;

            builder.Register(c => new WebAppDbContext(options))
                   .AsSelf()
                   .SingleInstance(); // Persists throughout the app's lifetime

            // Build and set resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}