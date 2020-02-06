using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models.Configuration
{
    public class FeatureManagerConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features");
            
            builder.Property(s => s.Name)
                .IsRequired(true);
            builder.Property(s => s.Enabled)
                .HasDefaultValue(false);
            builder.HasData
                (
                    new Feature
                    { Id=Guid.NewGuid(),Name=nameof(FeatureFlags.FeatureA),Enabled=false},
                    new Feature 
                    { Id = Guid.NewGuid(), Name = nameof(FeatureFlags.FeatureB), Enabled = false },
                    new Feature
                    {Id=Guid.NewGuid(),Name=nameof(FeatureFlags.FeatureC),Enabled=false},
                    new Feature
                    { Id = Guid.NewGuid(), Name = nameof(FeatureFlags.FeatureD), Enabled = false }
                );
        }
    }
}
