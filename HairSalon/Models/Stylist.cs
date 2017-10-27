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


  }
}
