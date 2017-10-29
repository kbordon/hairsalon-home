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

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM clients WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.Id;
      cmd.Parameters.Add(searchId);

      cmd.ExecuteNonQuery();
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void UpdateClient(string updateName, string updatePhone)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newName, phone = @newPhone WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.Id;
      cmd.Parameters.Add(searchId);

      //name
      MySqlParameter newName = new MySqlParameter();
      newName.ParameterName = "@newName";
      newName.Value = updateName;
      cmd.Parameters.Add(newName);
      //favorite dish
      MySqlParameter newPhone = new MySqlParameter();
      newPhone.ParameterName = "@newPhone";
      newPhone.Value = updatePhone;
      cmd.Parameters.Add(newPhone);

      cmd.ExecuteNonQuery();
      this.Name = updateName;
      this.Phone = updatePhone;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int inputId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = inputId;

      cmd.Parameters.Add(thisId);

      int clientId = 0;
      string clientName = "";
      string clientPhone = "";
      int clientStylistId = 0;

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        clientPhone = rdr.GetString(2);
        clientStylistId = rdr.GetInt32(3);
      }

      Client foundClient = new Client(clientName, clientPhone, clientStylistId, clientId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phone, stylist_id) VALUES (@clientName, @clientPhone, @stylistId);";
      //name
      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@clientName";
      clientName.Value = this.Name;
      cmd.Parameters.Add(clientName);
      //phone
      MySqlParameter clientPhone = new MySqlParameter();
      clientPhone.ParameterName = "@clientPhone";
      clientPhone.Value = this.Phone;
      cmd.Parameters.Add(clientPhone);
      //stylist id
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = this.StylistId;
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
        int stylistId = rdr.GetInt32(3);

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

    public static List<Client> GetAllClientsByStylist(int inputId)
    {
      List<Client> allClients = new List<Client>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylistId";
      stylistId.Value = inputId;
      cmd.Parameters.Add(stylistId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int returnId = rdr.GetInt32(0);
        string returnName = rdr.GetString(1);
        string returnPhone = rdr.GetString(2);
        int returnStylistId = rdr.GetInt32(3);
        Client returnClient = new Client(returnName, returnPhone, returnStylistId, returnId);
        allClients.Add(returnClient);
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
