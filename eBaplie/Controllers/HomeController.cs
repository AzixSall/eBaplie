using eBaplie.Data;
using eBaplie.Helpers;
using eBaplie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace eBaplie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(UploadBaplie));
        }

        public IActionResult UploadBaplie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertBaplie(IFormFile baplieFile)
        {
            if (baplieFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    try
                    {
                        baplieFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();

                        string text = Encoding.UTF8.GetString(fileBytes);
                        var baplieData = Parser.ProcessFileSegments(text);

                        List<PortColor> portColors = new List<PortColor>();

                        foreach (var port in baplieData.Ports.ToList())
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

                        if(baplieData != null)
                        {
                            Log newLog = new Log
                            {
                                Date = DateTime.Now
                            };

                            _context.Logs.Add(newLog);
                            _context.SaveChanges();
                        }

                        return View(baplieData);
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(LogLevel.Error, ex, "Error occured during parsing");
                        return View(nameof(UploadBaplie));
                    }
                }
            }

            return View(nameof(UploadBaplie));
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}