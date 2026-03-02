using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void CalcIncrement_FinalIncrementOnEdge_ReturnsMay()
        {
            // Arrange
            var deposit = 12000.35d;
            var finalIncrement = 249.70d;

            // Action
            var result = Logic.CalcIncrement(deposit, finalIncrement);

            // Assert
            Assert.AreEqual("июнь", result);
        }

        [TestMethod()]
        public void CalcDeposit_DepositIsOnEdge_ReturnsTwo()
        {
            // Arrange
            var deposit = 12000.35d;
            var finalDeposit = 12485.16d;

            // Action
            var result = Logic.CalcDeposit(deposit, finalDeposit);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void CalcDeposit_StartGreaterFinal_ReturnsZero()
        {
            // Arrange
            var deposit = 12000.35d;
            var finalDeposit = 9000d;

            // Action
            var result = Logic.CalcDeposit(deposit, finalDeposit);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}