using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using featuretoggledemo.Models;

namespace featuretoggledemo.Data
{
    public class featuretoggledemoContext : DbContext
    {
        public featuretoggledemoContext (DbContextOptions<featuretoggledemoContext> options)
            : base(options)
        {
        }

   
        public DbSet<Feature> Features { get; set; }
    }
}
