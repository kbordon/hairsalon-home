using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }

    public ClientTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=kimberly_bordon_test;";
    }

    [TestMethod]
    public void GetAll_GetClientsEmptyAtFirst_0()
    {
      int result = Client.GetAll().Count;

      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamePhoneAndIdAreTheSame_Client()
    {
      Client firstClient = new Client("Charles Edeau", "619-883-0092", 1);
      Client secondClient = new Client("Charles Edeau", "619-883-0092", 1);

      Assert.AreEqual(firstClient, secondClient);
    }
    // Above tests ensure following tests, equals method, and database connection are properly setup.

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      CollectionAssert.AreEqual(testList, result);
    }
    // Fulfills specs to add client, and view all clients.

    [TestMethod]
    public void GetClientsByStylist_GetsAllClientsInDatabaseByStylist_List()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();
      Client testClient2 = new Client("Rosali Gueverra", "334-781-1119", 2);
      testClient2.Save();
      Client testClient3 = new Client("Dinan Johannsen", "305-225-2267", 1);
      testClient3.Save();

      List<Client> testList = Client.GetAllClientsByStylist(1);
      List<Client> expectedList = new List<Client>{testClient, testClient3};

      CollectionAssert.AreEqual(testList, expectedList);
    }
    // Fulfills spec to view all clients of a specific stylist


    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.Id);

      Assert.AreEqual(testClient, foundClient);
    }
    // Fulfills spec to select a specific client.

    [TestMethod]
    public void UpdateClient_UpdatesClientInDatabase_String()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();
      testClient.UpdateClient("Maya Concepcion", "619-888-0092");

      Assert.AreEqual(testClient.Name, "Maya Concepcion");
      Assert.AreEqual(testClient.Phone, "619-888-0092");
    }
    // Fulfills spec to update a specific client's information.

    [TestMethod]
    public void Delete_DeletesClientInDatabase_ClientList()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();
      Client testClient2 = new Client("Rosali Gueverra", "334-781-1119", 2);
      testClient2.Save();
      Client testClient3 = new Client("Dinan Johannsen", "305-225-2267", 1);
      testClient3.Save();

      List<Client> testList = new List<Client>{testClient2, testClient3};
      testClient.Delete();

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(testList, result);
    }
    // Fulfills spec to delete a specific client.


  }
}
