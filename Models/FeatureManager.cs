using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models
{
    public class FeatureManager : IFeatureManager
    {
        public FeatureManager(List<Feature> features)
        {
            Features = features;
        }
        public FeatureManager()
        {
            Features = new List<Feature>();
        }
        public List<Feature> Features { get; private set; }

        public bool Enabled(string feature)
        {
            return Features.Exists(f => f.Name.Equals(feature));
        }
    }
}
