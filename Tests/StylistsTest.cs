using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void StylistTest_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void StylistTest_ReturnsTrueIfDescrtptionsAreTheSame()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Kirby");
      Stylist secondStylist = new Stylist("Kirby");

      //Assert
      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void StylistTest_Save_SavesToDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Kirby");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void StylistTest_Save_AssignsIdToObject()
    {
        //Arrange
        Stylist testStylist = new Stylist("Kirby");

        //Act
        testStylist.Save();
        Stylist savedStylist = Stylist.GetAll()[0];

        int result = savedStylist.GetId();
        int testId = testStylist.GetId();

        //Assert
        Assert.Equal(testId, result);
    }

  [Fact]
   public void StylistTest_Find_FindsStylistInDatabase()
   {
     //Arrange
     Stylist testStylist = new Stylist("Kirby");
     testStylist.Save();

     //Act
     Stylist foundStylist = Stylist.Find(testStylist.GetId());

     //Assert
     Assert.Equal(testStylist, foundStylist);
   }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
