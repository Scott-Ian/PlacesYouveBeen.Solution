using Microsoft.AspNetCore.Mvc;
using PlacesYouveBeen.Models;
using System.Collections.Generic;

namespace PlacesYouveBeen.Controllers
{
  public class PlacesController : Controller
  {
    [HttpGet("/place")]
    public ActionResult Index()
    {
      List<Place> placeList = Place.GetAll();
      return View(placeList);
    }

    [HttpGet("/place/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/place")]
    public ActionResult Create(string location)
    {
      Place newPlace = new Place(location);
      return RedirectToAction("Index");
    }
  }
}