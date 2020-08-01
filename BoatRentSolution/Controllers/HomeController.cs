using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BoatRentSolution.Models;
using BoatRentSolution.Data.Models;
using BoatRentSolution.Service.IService;

namespace BoatRentSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBoatDetailsService boatDetailsService;
        public HomeController(ILogger<HomeController> logger, IBoatDetailsService _boatDetailsService)
        {
            _logger = logger;
            boatDetailsService = _boatDetailsService;
        }

        public IActionResult Index()
        {
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
        public IActionResult RegisterBoat()
        {
            return View("RegisterBoat");
        }
        public async Task<string> SaveBoatDetails(string boatname, double boatrate)
        {
            try
            {
                IEnumerable<BoatDetails> boatDetails1 = await boatDetailsService.GetAllAsyn();
                List<BoatDetails> boats = boatDetails1.ToList();
                int uniqueboatno = 1;
                if (boats != null)
                {
                    var lastBoatDEtails = boats[boats.Count - 1];
                    uniqueboatno = Convert.ToInt32(lastBoatDEtails.BoatName.Split("Boat")[1]) + 1;
                }
                BoatDetails boatDetails = new BoatDetails();
                if (boatname != "" && boatrate != 0) //validation on server side
                {
                    boatDetails.CreatedDate = DateTime.Now;
                    boatDetails.BoatName = boatname;
                    boatDetails.HourlyRate = boatrate;
                    boatDetails.Rowstatus = 1;
                    boatDetails.BoatName = "Boat" + uniqueboatno;
                }
                await boatDetailsService.AddItemAsync(boatDetails);
                return boatDetails.BoatName;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
