using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using featuretoggledemo.Models;

namespace featuretoggledemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureManager _features;

        public HomeController(ILogger<HomeController> logger,IFeatureManager features)
        {
            _logger = logger;
            _features = features;
        }

        public IActionResult Index()
        {
            ViewBag.FeatureA = _features.Enabled(nameof(FeatureFlags.FeatureA));
            ViewBag.FeatureB = _features.Enabled(nameof(FeatureFlags.FeatureB));
            ViewBag.FeatureC = _features.Enabled(nameof(FeatureFlags.FeatureC));
            ViewBag.FeatureD = _features.Enabled(nameof(FeatureFlags.FeatureD));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
