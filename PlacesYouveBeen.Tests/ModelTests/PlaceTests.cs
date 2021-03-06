using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesYouveBeen.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PlacesYouveBeen.Tests
{
  [TestClass]
  public class PlaceTest : IDisposable
  {

    public void Dispose()
    {
      Place.ClearAll();
    }

    public PlaceTest()
    {
      DBConfiguration.ConnectionString = "server=localhost; user id=root;password=epicodus;port=3306;database=places_youve_been_test;";
    }
    
    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place("name", "description");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }

    [TestMethod]
    public void PlaceConstructor_CityNameParamater_String()
    {
      Place newPlace = new Place("Hong Kong", "description");
      Assert.AreEqual("Hong Kong", newPlace.CityName);
    }

    [TestMethod]
    public void PlaceConstructor_DescriptionParamater_String()
    {
      Place newPlace = new Place("Hong Kong", "Revolution of our time!");
      Assert.AreEqual("Revolution of our time!", newPlace.Description);
    }

    [TestMethod]
    public void DeleteAll_EmptyTheListOfPlaces_EmptyList()
    {
      Place newPlace = new Place("Timbuktu", "Great Food!");
      newPlace.Save();
      Place.ClearAll();
      List<Place> expectedResults = new List<Place>{};
      List<Place> databaseContents = Place.GetAll();
      CollectionAssert.AreEqual(expectedResults, databaseContents);
    }

    [TestMethod]
    public void GetAll_ShowsListOfAllPlaceObjects_ListMatches()
    {
      Place newPlace1 = new Place("Hong Kong", "Former British Colony");
      newPlace1.Save();
      Place newPlace2 = new Place("Ulan Baatar", "Great Butter Producers");
      newPlace2.Save();
      Place newPlace3 = new Place("St Petersburg", "St Peter's Cathedral");
      newPlace3.Save();
      List<Place> _expectedResults = new List<Place> {newPlace1, newPlace2, newPlace3};
      CollectionAssert.AreEqual(_expectedResults, Place.GetAll());
    }

    [TestMethod]
    public void GetId_InstantiatePlaceObjectsWithId_Int()
    {
      Place newPlace = new Place("Portland", "Rainy City");
      newPlace.Save();
      int Id = newPlace.Id;
      Assert.AreEqual(Id, newPlace.Id);
    }

    [TestMethod]
    public void Find_ReturnsCorrectPlace_Place()
    {
      Place newPlace1 = new Place("Portland", "Rainy City");
      newPlace1.Save();
      int Id1 = newPlace1.Id;
      Place newPlace2 = new Place("Seattle", "Another Rainy City");
      newPlace2.Save();
      Place newPlace3 = new Place("Boise", "Mildy Rainy");
      newPlace3.Save();

      Assert.AreEqual(newPlace1, Place.Find(Id1));
    }

    [TestMethod]
    public void EditPlace_ChangeTheValueOfAPlace_NewCityName()
    {
      Place newPlace = new Place("Portland", "Rainy Sity");
      newPlace.Save();
      int id = newPlace.Id;

      Place.EditPlace(id, "Vancouver", "Rainy City");
      newPlace = Place.Find(id);
      Assert.AreEqual("Vancouver", newPlace.CityName);
    }

    // [TestMethod]
    // public void DeletePlace_RemovePlaceObjectFromList_DoesNotContain()
    // {
    //   Place newPlace1 = new Place("Portland");
    //   Place newPlace2 = new Place("Seattle");
    //   Place newPlace3 = new Place("Boise");
    //   Place.Remove(2);
    //   CollectionAssert.DoesNotContain(Place.GetAll(), newPlace2);
    // }

    // [TestMethod]
    // public void GetID_IDsShouldAlwaysBeUnique_NotEqual()
    // {
    //   Place newPlace1 = new Place("Portland");
    //   Place newPlace2 =  new Place("Seattle");
    //   Place.Remove(1);
    //   Place newPlace3 = new Place("Boise");
    //   Assert.AreNotEqual(newPlace2.ID, newPlace3.ID);
    // }

    // [TestMethod]
    // public void FindID_StillFindsCorrectObjectAfterDeletion_ObjMatch()
    // {
    //   Place newPlace1 = new Place("Portland");
    //   Place newPlace2 =  new Place("Seattle");
    //   Place.Remove(1);
    //   Place newPlace3 = new Place("Boise");
    //   Place findPlace = Place.Find(3);
    //   Assert.AreEqual(findPlace, newPlace3);
    // }

    // [TestMethod]
    // public void FindID_ReturnsNullIfSearchigANonExistant_Null()
    // {
    //   Place newPlace1 = new Place("Portland");
    //   Place newPlace2 = new Place("Seattle");
    //   Assert.IsNull(Place.Find(5));
    // }

    // [TestMethod]
    // public void EditPlace_DoesNothingIfNoPlaceFound_Nothing()
    // {
    //   Place newPlace1 = new Place("Portland");
    //   Place.EditPlace(59, "Seattle");
    //   List<Place> _expectedResults = new List<Place> {newPlace1};
    //   CollectionAssert.AreEqual(_expectedResults, Place.GetAll());
    // }

    // [TestMethod]
    // public void Remove_DoesNothingIfNotFound_Nothing()
    // {
    //   Place newPlace = new Place("Portland");
    //   Place.Remove(5);
    //   List<Place> _expectedResults = new List<Place> {newPlace};
    //   CollectionAssert.AreEqual(_expectedResults, Place.GetAll());
    // }
  }
}