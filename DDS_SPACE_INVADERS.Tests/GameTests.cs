using Microsoft.VisualStudio.TestTools.UnitTesting;
using Invaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Invaders.Factory;


namespace Invaders.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod]
        public void Resultado_Metodo_AddAdittionalScore()
        {
            const int esperado1 = 58;


            Invader example = new Bug(ShipType.Bug, new Point(1, 1), 0);

            var actual = example.AddAditionalScore(53);


            Assert.AreEqual(esperado1, actual);
        }


        [TestMethod]
        public void Comprobar_Instancia_Unica_Singleton()
        {
            PlayerShip ps1 = PlayerShip.Instance;
            PlayerShip ps2 = PlayerShip.Instance;

            Assert.AreEqual(ps1, ps2);
        }

    }
}