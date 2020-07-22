using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesYouveBeen.Models;

namespace PlacesYouveBeen.Tests
{
  [TestClass]
  public class PlaceTests
  {
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
  }
}