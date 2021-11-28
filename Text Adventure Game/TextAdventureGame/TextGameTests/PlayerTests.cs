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
        public void SugarLevelIncrements()
        {
            //Arrange
            Player player = new Player();

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
            Player player = new Player();
            

            //Act
            string result = player.EatCandy();

            //Assert
            Assert.AreEqual("You now have 1 lolipop sticks!", result);
        }
    }
}
