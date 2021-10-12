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
            string name = "Steve";

            //Act
            Player player = new Player(name);
            string result = player.Name;

            //Assert
            Assert.AreEqual("Steve", result, "Player does not take inputted name");
        }

        [TestMethod]
        public void SugarLevelIncrements()
        {
            //Arrange
            string name = "Steve";
            Player player = new Player(name);

            //Act
            player.GainSugar();
            int result = player.SugarLevel;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EatCandyReturnsCorrectString()
        {
            //Arrange
            string name = "Steve";
            Player player = new Player(name);
            

            //Act
            string result = player.EatCandy();

            //Assert
            Assert.AreEqual("You now have 1 lolipop sticks!", result);
        }
    }
}
