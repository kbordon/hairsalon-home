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
    public ActionResult StylistAdd()
    {
      // double validNumber;
      // bool correctPhone = double.TryParse(Request.Form["stylist-phone"], out validNumber);
      // if (correctPhone)
      // {
      Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-phone"]);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Stylists", allStylists);
      // }
      // else
      // {
        // string error = "error";
        // return View("StylistForm", error);
      // }
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult StylistDetail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};
      model.Add("selected-client", null);
      Stylist selectedStylist = Stylist.Find(id);
      model.Add("selected-stylist", selectedStylist);
      List<Client> stylistClients = Client.GetAllClientsByStylist(selectedStylist.Id);
      model.Add("stylist-clients", stylistClients);
      return View(model);
    }

    [HttpGet("/stylists/{id}/clients/new")]
    public ActionResult ClientForm(int id)
    {
      Stylist selectedStylist = Stylist.Find(id);
      return View(selectedStylist);
    }


    [HttpPost("/stylists/{id}/clients/new")]
    public ActionResult ClientAdd(int id)
    {
      Client newClient = new Client(Request.Form["client-name"], Request.Form["client-phone"], id);
      newClient.Save();

      Dictionary<string, object> model = new Dictionary<string, object> {};
      model.Add("selected-client", newClient);
      Stylist selectedStylist = Stylist.Find(id);
      model.Add("selected-stylist", selectedStylist);
      List<Client> allClients = Client.GetAllClientsByStylist(id);
      model.Add("stylist-clients", allClients);
      return View("StylistDetail", model);
    }

    [HttpGet("/stylists/{id}/clients/{clientId}")]
    public ActionResult ClientDetails(int id, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object> {};
      List<Client> allClients = Client.GetAllClientsByStylist(id);
      Stylist selectedStylist = Stylist.Find(id);
      Client selectedClient = Client.Find(clientId);
      model.Add("stylist-clients", allClients);
      model.Add("selected-stylist", selectedStylist);
      model.Add("selected-client", selectedClient);
      return View("StylistDetail", model);
    }

  }
}
