using System.Collections.Generic;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }

    public Place(string cityName = "")
    {
      CityName = cityName;
    }

    public static void GetAll()
    {

    }
  }
}