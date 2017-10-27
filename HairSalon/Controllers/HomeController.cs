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
      public ActionResult StylistsView()
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View("Stylists", allStylists);
      }

      [HttpGet("/stylists/new")]
      public ActionResult StylistForm()
      {
        // string error = "";
        return View();
      }

      [HttpPost("/stylists/new")]
      public ActionResult StylistsAdd()
      {
        double validNumber;
        bool correctPhone = double.TryParse(Request.Form["stylist-phone"], out validNumber);
        if (correctPhone)
        {
          Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-phone"]);
          newStylist.Save();
          List<Stylist> allStylists = Stylist.GetAll();
          return View("Stylists", allStylists);
        }
        else
        {
          string error = "error";
          return View("StylistForm", error);
        }
      }

    }
}
