using Domain.GameDesign.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignTestUnit
{
    [TestClass]
    public class UnitTestWorld
    {
        private Random rand = new Random();

        public UnitTestWorld()
        {

        }

        [TestMethod]
        public void TestAccess()
        {
            int width = 3 + rand.Next(10);
            int height = 3 + rand.Next(10);
            World world = new World(width, height);
            Assert.AreEqual(world.GetWidth(), width);
            Assert.AreEqual(world.GetHeight(), height);

            for (int repeat = 0; repeat < 10; repeat++)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);
                world.Set(x, y, new Space(SpaceTypeId.GUM));
                StaticElement se = world.Get(x, y, Direction.NONE);
                Assert.IsTrue(typeof(Space).IsInstanceOfType(se));
                Space space = (Space)se;
                Assert.AreEqual(SpaceTypeId.GUM, space.SpaceTypeId);
            }
        }
    }
}
