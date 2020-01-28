using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models
{
    public class FeatureManager : IFeatureManager
    {
        public List<Feature> Features => throw new NotImplementedException();
    }
}
