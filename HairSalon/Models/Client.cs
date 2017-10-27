using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    public string Name {get; private set;}
    public string Phone {get; private set;}
    public int Id {get; private set;}
    public int StylistId {get; private set;}

    public Client(string name, string phone, int stylistId, int id = 0)
    {
      Name = name;
      Phone = phone;
      Id = id;
      StylistId = stylistId;
    }
  }
}
