using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesYouveBeen.Models;
using System;
using System.Collections.Generic;

namespace PlacesYouveBeen.Tests
{
  [TestClass]
  public class PlaceTest : IDisposable
  {

    public void Dispose()
    {
      Place.DeleteAll();
    }
    
    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place();
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }

    [TestMethod]
    public void PlaceConstructor_CityNameParamater_Added()
    {
      Place newPlace = new Place("Hong Kong");
      Assert.AreEqual("Hong Kong", newPlace.CityName);
    }

    [TestMethod]
    public void DeleteAll_EmptyTheListOfPlaces_EmptyList()
    {
      Place newPlace = new Place("Timbuktu");
      Place.DeleteAll();
      List<Place> _expectedResults = new List<Place>(0);
      CollectionAssert.AreEqual(_expectedResults, Place.GetAll());
    }

    [TestMethod]
    public void GetAll_ShowsListOfAllPlaceObjects_ListMatches()
    {
      Place newPlace1 = new Place("Hong Kong");
      Place newPlace2 = new Place("Ulan Baatar");
      Place newPlace3 = new Place("St Petersburg");
      List<Place> _expectedResults = new List<Place> {newPlace1, newPlace2, newPlace3};
      CollectionAssert.AreEqual(_expectedResults, Place.GetAll());
    }

    [TestMethod]
    public void GetId_InstantiatePlaceObjectsWithId_Int()
    {
      Place newPlace = new Place("Portland");
      Assert.AreEqual(1, newPlace.ID);
    }

    [TestMethod]
    public void FindId_FindObjectUsingUniqueId_Obj()
    {
      Place newPlace1 = new Place("Portland");
      Place newPlace2 = new Place("Seattle");
      Place newPlace3 = new Place("Boise");
      Assert.AreEqual(newPlace1, Place.Find(1));
    }

    [TestMethod]
    public void EditPlace_ChangeTheValueOfAPlace_NewCityName()
    {
      Place newPlace = new Place("Portland");
      Place.EditPlace(1, "Vancouver");
      Assert.AreEqual("Vancouver", newPlace.CityName);
    }

    [TestMethod]
    public void DeletePlace_RemovePlaceObjectFromList_DoesNotContain()
    {
      Place newPlace1 = new Place("Portland");
      Place newPlace2 = new Place("Seattle");
      Place newPlace3 = new Place("Boise");
      Place.Remove(2);
      CollectionAssert.DoesNotContain(Place.GetAll(), newPlace2);
    }
  }
}