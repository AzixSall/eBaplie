using eBaplie.Helpers;
using eBaplie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eBaplie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty("D:\\BAPLIE To 3D\\DKR FINAL EDI  HLC KONRAD VGE 2240S.edi"))
            {
                return null;
            }

            string text = System.IO.File.ReadAllText("D:\\BAPLIE To 3D\\DKR FINAL EDI  HLC KONRAD VGE 2240S.edi");

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            var baplieData = Parser.ProcessFileSegments(text);

            List<PortColor> portColors = new List<PortColor>();

            foreach (var port in baplieData.Ports)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                PortColor portColor = new PortColor
                {
                    Color = color,
                    Name = port.Name
                };

                portColors.Add(portColor);
            }

            ViewBag.PortColor = portColors;
            ViewBag.Containers = baplieData.Containers.ToArray();
            return View(baplieData);
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