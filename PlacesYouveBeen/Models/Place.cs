using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    public int ID { get; }
    private static List<Place> _allPlaces = new List<Place>(0);
    public static int _nextID = 1;

    public Place(string cityName = "")
    {
      CityName = cityName;
      ID = _nextID;
      _nextID++;
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

    public static Place Find(int searchId)
    {
      for (int i = 0; i < _allPlaces.Count; i++)
      {
        if (_allPlaces[i].ID == searchId)
        {
          return _allPlaces[i];
        }
      }
      return null;
    }

    public static void EditPlace(int id, string newCityName)
    {
      Place editPlace = Find(id);
      editPlace.CityName = newCityName;
    }

    public static void Remove(int id)
    {
      Place.GetAll().Remove(Place.Find(id));
    }
  }
}