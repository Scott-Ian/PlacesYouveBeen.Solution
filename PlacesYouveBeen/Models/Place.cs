using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    public int ID { get; }
    private static List<Place> _allPlaces = new List<Place>(0);

    public Place(string cityName = "")
    {
      CityName = cityName;
      ID = Place.GetAll().Count + 1;
      _allPlaces.Add(this);
    }

    public static List<Place> GetAll()
    {
      return _allPlaces;
    }

    public static void DeleteAll()
    {
      _allPlaces.Clear();
    }
  }
}