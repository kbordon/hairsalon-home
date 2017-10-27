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
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kimberly_bordon_test;";
    }

    [TestMethod]
    public void GetAll_GetClientsEmptyAtFirst_0()
    {
      int result = Client.GetAll().Count;

      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamePhoneAndIdAreTheSame_Restaurant()
    {
      Client firstClient = new Client("Charles Edeau", "619-883-0092", 1);
      Client secondClient = new Client("Charles Edeau", "619-883-0092", 1);

      Assert.AreEqual(firstClient, secondClient);
    }
    // Above tests ensure following tests, equals method, and database connection are properly setup.

    [TestMethod]
    public void Save_SavesToDatabase_RestaurantList()
    {
      Client testClient = new Client("Charles Edeau", "619-883-0092", 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      CollectionAssert.AreEqual(testList, result);
    }
    // Fulfills specs to add client, and view all clients.



  }
}
