namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }

    public Place(string cityName = "")
    {
      CityName = cityName;
    }
  }
}