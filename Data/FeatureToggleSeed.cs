using featuretoggledemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Data
{
    public class FeatureToggleSeed
    {
    
        public async Task SeedAsync(featuretoggledemoContext context, IWebHostEnvironment env)
        {
           
            using (context)
            {
                context.Database.Migrate();
                if (!context.Features.Any())
                {
                    context.Features.AddRange(
                        GetPreconfiguredFeatures());
                    await context.SaveChangesAsync();
                }

            }
        }

        static IEnumerable<Feature> GetPreconfiguredFeatures()
        {
            return new List<Feature>()
            {
                new Feature(){Id=new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"),Enabled=true,Name="FeatureA"},
                new Feature(){Id=new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"),Enabled=false,Name="FeatureB"},
                new Feature(){Id=new Guid("42164028-e54d-4f1c-9558-5a38bd1a5e00"),Enabled=false,Name="FeatureC"},
                new Feature(){ Id=new Guid("9fa9658b-f8ab-4a54-9b22-f93b7f75a807"),Enabled=false,Name= "FeatureD" }

            };
        }

       
    }
}
