using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    
    private static List<Place> _allPlaces = new List<Place> (){};

    public Place(string cityName = "")
    {
      CityName = cityName;
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