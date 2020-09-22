using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using featuretoggledemo.Models;
using featuretoggledemo.Models.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;

namespace featuretoggledemo.Data
{
    public class featuretoggledemoContext : DbContext
    {
        public featuretoggledemoContext (DbContextOptions<featuretoggledemoContext> options)
            : base(options)
        {
        }

   
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeatureManagerConfiguration());
        }
    }
    public static class Extensions
    {
        public static IWebHost MigrateDbContext<TContext>(
        this IWebHost host,
        Action<TContext,
        IServiceProvider> seeder)
          where TContext : featuretoggledemoContext
        {

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<TContext>();
                var connection = @"Server=db;Database=master;User=sa;Password=Your_password123;";
                try
                {
                    
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(new TimeSpan[]
                        {
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(8),
                        });

                    //if the sql server container is not created on run docker compose this
                    //migration can't fail for network related exception. The retry options for DbContext only
                    //apply to transient exceptions
                    // Note that this is NOT applied when running some orchestrators (let the orchestrator to recreate the failing service)
                    retry.Execute(() => InvokeSeeder(seeder, context, services));


                }
                catch (Exception ex)
                {
                    
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : featuretoggledemoContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }

        
    }
}
