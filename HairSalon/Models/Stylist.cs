using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int Id {get; private set}
    public string Name {get; private set;}
    private string Phone {get; private set;}
    private string HireDate {get; private set;}

    public Stylist (string name, string phone, string hireDate, int id = 0)
    {
      Name = name;
      phone = phone;
      Id = id;
      HireDate = hireDate;
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
       string stylistHireDate = rdr.GetString(3);
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


  }
}
