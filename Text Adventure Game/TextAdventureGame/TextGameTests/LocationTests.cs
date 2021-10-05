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
            Location Map = new Location();

            //Act
            List<Location> result = Map.CreateMap();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanConvertLocationToString()
        {
            //Arrange
            Location Map = new Location();
            string location = "bathroom";

            //Act
            Map.MapList = Map.CreateMap();
            Location result = Map.Move(location);

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
            Location Map = new Location { EncounterChance = num };

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
            Location Map = new Location();
            Map.MapList = Map.CreateMap();
            string location = "bathroom";
            Location place = null;
            foreach (Location item in Map.MapList)
            {
                if (item.Name == "Master Bedroom")
                {
                    place = item;
                }
            }

            //Act
            Location result = Map.Move(location);

            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.IsTrue(result.CurrentLocation);
            Assert.IsFalse(place.CurrentLocation);
        }

        [TestMethod]
        public void CurrentLocationStartsinMB()
        {
            //Arrange
            Location Map = new Location();
            Location place = null;

            //Act
            Map.MapList = Map.CreateMap();

            foreach (Location item in Map.MapList)
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
