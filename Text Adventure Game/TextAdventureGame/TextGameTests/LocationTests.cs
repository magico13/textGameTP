using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;

namespace TextGameTests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void CanCreateMap()
        {
            //Arrange
            Room Map = new Room();

            //Act
            List<Room> result = Map.CreateMap();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanConvertLocationToString()
        {
            //Arrange
            Room Map = new Room();
            string location = "bathroom";

            //Act
            Map.MapList = Map.CreateMap();
            Room result = Map.CheckInput(location);

            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.AreEqual("Bathroom", result.Name);
        }

        [TestMethod]
        [DataRow(10.0, true)]
        [DataRow(0.0, false)]
        public void EncounterChecksCorrectly(double num, bool expected)
        {
            //Arrange
            Room Map = new Room { EncounterChance = num };

            //Act
            Map.MapList = Map.CreateMap();
            bool result = Map.RollEncounter(Map);

            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CurrentLocationChanges()
        {
            //Arrange
            Room Map = new Room();
            Map.MapList = Map.CreateMap();
            string location = "bathroom";
            Room place = null;
            foreach (Room item in Map.MapList)
            {
                if (item.Name == "Master Bedroom")
                {
                    place = item;
                }
            }

            //Act
            Room result = Map.CheckInput(location);

            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.IsTrue(result.CurrentLocation);
            Assert.IsFalse(place.CurrentLocation);
        }

        [TestMethod]
        public void CurrentLocationStartsinMB()
        {
            //Arrange
            Room Map = new Room();
            Room place = null;

            //Act
            Map.MapList = Map.CreateMap();

            foreach (Room item in Map.MapList)
            {
                if (item.CurrentLocation == true)
                {
                    place = item;
                }
            }


            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.AreEqual("Master Bedroom", place.Name);
        }
    }
}
