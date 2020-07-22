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

    [HttpGet("/place/{ID}")]
    public ActionResult Show(int ID)
    {
      Place foundPlace = Place.Find(ID);
      if (foundPlace != null)
      {
        return View(foundPlace);
      }
      else
      {
        return RedirectToAction("Index");
      }
    }

    [HttpGet("/place/{ID}/edit")]
    public ActionResult Edit(int ID)
    {
      return View(Place.Find(ID));
    }

    [HttpPost("/place/{ID}")]
    public ActionResult Update(string ID, string location)
    {
      int intID = int.Parse(ID);
      Place.EditPlace(intID, location);
      return RedirectToAction("Index");
    }
  }
}