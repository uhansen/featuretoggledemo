using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace featuretoggledemo.Models.Configuration
{
    public interface IFeatureManager
    {
        List<Feature> Features { get; }
        bool Enabled(string feature);

    }
}
