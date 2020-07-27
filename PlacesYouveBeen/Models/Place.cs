using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PlacesYouveBeen.Models
{
  public class Place
  {
    public string CityName { get; set; }
    public string Description { get; set; }
    public int Id { get; set;}

    public Place (string cityName = "", string description = "")
    {
      CityName = cityName;
      Description = description;
    }

    public Place(string cityName, string description, int id)
    {
      CityName = cityName;
      Description = description;
      Id = id;
    }

    public override bool Equals(System.Object otherPlace)
    {
      if(!(otherPlace is Place))
      {
        return false;
      }
      else
      {
        Place newPlace = (Place) otherPlace;
        bool idEquality = (this.Id == newPlace.Id);
        bool cityNameEquality = (this.CityName == newPlace.CityName);
        return (idEquality && cityNameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO places (CityName, Description) VALUES (@PlacesCityName, @PlacesDescription);";
      MySqlParameter cityName = new MySqlParameter();
      MySqlParameter description = new MySqlParameter();
      cityName.ParameterName = "@CityName";
      description.ParameterName = "@Description";
      cityName.Value = this.CityName;
      description.Value = this.Description;
      cmd.Parameters.Add(cityName);
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();

      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Place> GetAll()
    {
      List<Place> allPlaces = new List<Place>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM places;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        string placeCityName = rdr.GetString(1);
        string placeDescription = rdr.GetString(2);
        int placeId = rdr.GetInt32(0);
        Place newPlace = new Place (placeCityName, placeDescription, placeId);
        allPlaces.Add(newPlace);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPlaces;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Place Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      // should be var cmd?
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM places WHERE id = @this.Id;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int placeId = 0;
      string placeCityName = "";
      string placeDescription = "";
      while (rdr.Read())
      {
        placeId = rdr.GetInt32(0);
        placeCityName = rdr.GetString(1);
        placeDescription = rdr.GetString(2);
      }
      Place foundPlace = new Place (placeCityName, placeDescription, placeId);

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return foundPlace;
    }

// Update places SET column = value, column = value WHERE Id = X;
    public static void EditPlace(int searchId, string newCityName, string newDescription)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE places SET CityName = @newCityName, Description = @newDescription WHERE Id = @this.id";
      
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);

      MySqlParameter thisDescription = new MySqlParameter();
      thisDescription.ParameterName = "@newDescription";
      thisDescription.Value = newDescription;
      cmd.Parameters.Add(thisDescription);

      MySqlParameter thisCityName = new MySqlParameter();
      thisCityName.ParameterName = "@newCityName";
      thisCityName.Value = newCityName;
      cmd.Parameters.Add(thisCityName);
      
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void Remove(int id)
    {
      Place placeToDelete = Find(id);
      if (placeToDelete != null)
      {
        Place.GetAll().Remove(placeToDelete);
      }
    }
  }
}