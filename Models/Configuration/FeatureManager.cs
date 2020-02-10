using featuretoggledemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models.Configuration
{
    public class FeatureManager : IFeatureManager
    {
        private featuretoggledemoContext _ctx;
        
        public FeatureManager(featuretoggledemoContext ctx)
        {
            _ctx = ctx;
            Features = _ctx.Features.ToList();
        }
        public List<Feature> Features { get; private set; }

        public bool Enabled(string feature)
        {
            return Features.Exists(f => f.Name.Equals(feature) && f.Enabled);
        }
    }
}
