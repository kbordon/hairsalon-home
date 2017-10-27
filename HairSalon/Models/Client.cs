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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
        {
        Client newClient = (Client) otherClient;
        bool idEqaulity = (this.Id == newClient.Id);
        bool nameEquality = (this.Name == newClient.Name);
        bool phoneEquality = (this.Phone == newClient.Phone);
        bool stylistEquality = (this.StylistId == newClient.StylistId);
        return (idEqaulity && nameEquality && phoneEquality && stylistEquality);
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
      cmd.CommandText = @"DELETE FROM clients; ALTER TABLE clients AUTO_INCREMENT = 1";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientPhone = rdr.GetString(2);
        int stylistId = rdr.GetInt32(4);

        Client newClient = new Client(clientName, clientPhone, stylistId, clientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

  }
}
