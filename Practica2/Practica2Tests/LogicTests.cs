using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void DivisionTest()
        {
            // arrange
            decimal dividendo = 50;
            decimal divisor = 2;
            decimal resultado_esperado = 25;

            //act
            decimal resultado_obtenido = Logic.Division(dividendo, divisor);

            //assert
            Assert.AreEqual(resultado_obtenido, resultado_esperado);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest_LanzaError()
        {
            // arrange
            decimal dividendo = 50;
            decimal divisor = 0;

            //act
            decimal resultado_obtenido = Logic.Division(dividendo, divisor);

            //assert
        }



    }
}