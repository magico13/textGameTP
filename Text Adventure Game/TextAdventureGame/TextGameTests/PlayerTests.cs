using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;

namespace TextGameTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void CreatePlayerHasName()
        {
            //Arrange
            Player player = new Player();
            string name = "Steve";

            //Act
            player = player.CreatePlayer(name);
            string result = player.Name;

            //Assert
            Assert.AreEqual("Steve", result, "Player does not take inputted name");
        }

        [TestMethod]
        public void SugarLevelIncrements()
        {
            //Arrange
            Player player = new Player();

            //Act
            player.Execute(2);
            int result = player.SugarLevel;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EatCandyReturnsCorrectString()
        {
            //Arrange
            Player player = new Player();
            

            //Act
            string result = player.EatCandy();

            //Assert
            Assert.AreEqual("You now have 1 lolipop sticks!", result);
        }
    }
}
