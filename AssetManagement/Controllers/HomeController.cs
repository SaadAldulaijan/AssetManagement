using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AssetManagement.Models;
using AssetManagement.Data;
using Microsoft.EntityFrameworkCore;
using AssetManagement.ViewModels;
using static AssetManagement.Models.Extension;
using AssetManagement.Models.Abstraction.Enums;

namespace AssetManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _ctx;

        public HomeController(ILogger<HomeController> logger, DataContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // get all devices with cisco.
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult<Dashboard> GetAll()
        {
            Dashboard vm = new Dashboard
            {
                NoOfPhones = GetTelephones(),
                NoOfEricsson = GetEricssonPhones(),
                NoOfCisco = GetCiscoPhones(),
                NoOfAvailableExtension = GetAvailableExtension(),
                NoOfUsedExtension = GetUsedExtension()
            };

            return vm;
        }

        #region Phones
        private int GetTelephones() => _ctx.Telephone.ToList().Count();
        private int GetCiscoPhones()
        {
            var cat = _ctx.Category.Where(x => x.Name == "Cisco").FirstOrDefault();
            var telephones = _ctx.Telephone.Where(x => x.SubCategory.Category == cat).ToList();
            return telephones.Count();
        }

        private int GetEricssonPhones()
        {
            var cat = _ctx.Category.Where(x => x.Name == "Ericsson").FirstOrDefault();
            var telephones = _ctx.Telephone.Where(x => x.SubCategory.Category == cat).ToList();
            return telephones.Count();
        }
        #endregion

        #region Extensions
        public int GetTotalExtension() => _ctx.Extension.Count();

        public int GetUsedExtension() => _ctx.Extension.Where(x => x.Usage != ExtensionUsage.Available).Count();

        public int GetAvailableExtension() => _ctx.Extension.Where(x => x.Usage == ExtensionUsage.Available).Count();

        #endregion
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
