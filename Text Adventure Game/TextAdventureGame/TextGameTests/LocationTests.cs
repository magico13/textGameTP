using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Commands;
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
            RoomCommand rc = new RoomCommand();

            //Act
            List<Room> result = rc.Map.MapList;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanConvertLocationToString()
        {
            //Arrange
            RoomCommand rc = new RoomCommand();
            string location = "bathroom";

            //Act
            //Map.MapList = Map.CreateMap();
            Room result = rc.CheckInput(location);

            //Assert
            Assert.IsNotNull(rc.Map.MapList);
            Assert.AreEqual("Bathroom", result.Name);
        }

        [TestMethod]
        [DataRow(10.0, true)]
        [DataRow(0.0, false)]
        public void EncounterChecksCorrectly(double num, bool expected)
        {
            //Arrange
            RoomCommand rc = new RoomCommand { CurrentLocation = new Room { EncounterChance = num } };
            Room Map = new Room();

            //Act
            bool result = Map.RollEncounter(rc.CurrentLocation);

            //Assert
            Assert.IsNotNull(Map.MapList);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CurrentLocationChanges()
        {
            //Arrange
            RoomCommand rc = new RoomCommand();
            string location = "bathroom";

            //Act
            rc.CurrentLocation = rc.CheckInput(location);

            //Assert
            Assert.IsNotNull(rc.Map.MapList);
            Assert.AreEqual("Bathroom", rc.CurrentLocation.Name);
            Assert.AreNotEqual("Master Bedroom", rc.CurrentLocation.Name);
        }

        [TestMethod]
        public void CurrentLocationStartsinMB()
        {
            //Arrange
            RoomCommand rc = new RoomCommand();
            Room place = null;

            //Act
            foreach (Room item in rc.Map.MapList)
            {
                if (item.Name == rc.CurrentLocation.Name)
                {
                    place = item;
                }
            }


            //Assert
            Assert.IsNotNull(rc.Map.MapList);
            Assert.AreEqual("Master Bedroom", place.Name);
        }
    }
}
