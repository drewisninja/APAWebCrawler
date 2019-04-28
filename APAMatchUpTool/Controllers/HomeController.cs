using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APAMatchUpTool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using APAMatchUpTool.Interfaces;
using APAMatchUpTool.Repository;
using APAMatchUpTool.BLL;

namespace APAMatchUpTool.Controllers
{
    public class HomeController : Controller
    {
        APA_DB_Processor _TeamsViewManager;

        #region Constructors

        public HomeController()
        {
            _TeamsViewManager = new APA_DB_Processor(new TeamsRepository());
        }

        #endregion

        #region HomePage

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Privacy

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

        #region Teams

        public IActionResult Teams()
        {                    

            ViewBag.Teams = _TeamsViewManager.GetTeams_SelectListItem().Result;

            return View();
        }

        #endregion

        #region Settings

        public IActionResult Settings()
        {
            return View();
        }

        #endregion

        #region Error

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
