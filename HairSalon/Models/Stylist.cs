using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Phone {get; private set;}
    // public string HireDate {get; private set;}

    public Stylist (string name, string phone, int id = 0)
    {
      Name = name;
      Phone = phone;
      Id = id;
      // HireDate = hireDate; string hireDate,
    }

    public static List<Stylist> SearchByName(string input)
    {
        //search for stylist by name
        List<Stylist> matchedStylists = new List<Stylist>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists WHERE name LIKE @searchInput;";

        MySqlParameter searchInput = new MySqlParameter();
        searchInput.ParameterName = "@searchInput";
        // searchInput.Value = input;
        // cmd.Parameters.Add(searchInput);
        cmd.Parameters.AddWithValue("@searchInput", input + "%");

        int stylistId = 0;
        string stylistName = "";
        string stylistPhone = "";

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            stylistId = rdr.GetInt32(0);
            stylistName = rdr.GetString(1);
            stylistPhone = rdr.GetString(2);
            Stylist matchedStylist = new Stylist(stylistName, stylistPhone, stylistId);
            matchedStylists.Add(matchedStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return matchedStylists;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM stylists WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.Id;
      cmd.Parameters.Add(searchId);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Update(string newName, string newPhone)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @newName, phone = @newPhone where id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.Id;
      cmd.Parameters.Add(searchId);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);

      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@newPhone";
      phone.Value = newPhone;
      cmd.Parameters.Add(phone);

      cmd.ExecuteNonQuery();
      this.Name = newName;
      this.Phone = newPhone;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Stylist Find(int inputId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM stylists WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = inputId;
      cmd.Parameters.Add(searchId);

      int stylistId = 0;
      string stylistName = "";
      string stylistPhone = "";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
        stylistPhone = rdr.GetString(2);
      }

      Stylist foundStylist = new Stylist(stylistName, stylistPhone, stylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT into stylists (name, phone) Values (@stylistName, @stylistPhone);";

      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@stylistName";
      stylistName.Value = Name;
      cmd.Parameters.Add(stylistName);

      MySqlParameter stylistPhone = new MySqlParameter();
      stylistPhone.ParameterName = "@stylistPhone";
      stylistPhone.Value = Phone;
      cmd.Parameters.Add(stylistPhone);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
       int stylistId = rdr.GetInt32(0);
       string stylistName = rdr.GetString(1);
       string stylistPhone = rdr.GetString(2);
      //  string stylistHireDate = rdr.GetString(3); stylistHireDate,
       Stylist newStylist = new Stylist(stylistName, stylistPhone, stylistId);
       allStylists.Add(newStylist);
    }
    conn.Close();
    if (conn !=null)
    {
     conn.Dispose();
    }
    return allStylists;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.Id == newStylist.Id);
        bool phoneEquality = (this.Phone == newStylist.Phone);
        bool nameEquality = (this.Name == newStylist.Name);
        return (idEquality && phoneEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.Id.GetHashCode();
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
