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


    // TODO: consider adding these if there is time;
    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = "DELETE FROM cuisines WHERE id = @searchId;";
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = this.Id;
    //   cmd.Parameters.Add(searchId);
    //
    //   cmd.ExecuteNonQuery();
    //
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
    //
    // public void UpdateName(string newName)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"UPDATE cuisines SET name = @newName where id = @searchId;";
    //
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = this.Id;
    //   cmd.Parameters.Add(searchId);
    //
    //   MySqlParameter name = new MySqlParameter();
    //   name.ParameterName = "@newName";
    //   name.Value = newName;
    //   cmd.Parameters.Add(name);
    //
    //   cmd.ExecuteNonQuery();
    //   this.Name = newName;
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

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
