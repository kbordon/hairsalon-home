using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/stylists")]
      public ActionResult ViewStylists()
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View("Stylists", allStylists);
      }

      [HttpGet("/stylists/new")]
      public ActionResult StylistForm()
      {
        return View();
      }
    }
}
