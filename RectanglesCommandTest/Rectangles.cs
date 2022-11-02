using NUnit.Framework;
using RectanglesCommands;
using System.Collections.Generic;

namespace RectanglesCommandTest
{
    [TestFixture]
    public class RectanglesTest
    {
        Rectangles rectangle;
        List<int> X;
        List<int> Y;

        [SetUp]
        public void Setup()
        {
            rectangle = new Rectangles();
            X = new List<int>();
            Y = new List<int>();
        }

        [TestCase("PLACE", "4,6")]
        [TestCase("FIND", "4,6")]
        [TestCase("REMOVE", "4,6")]
        public void ExecuteCommand(string commond, string parameter)
        {
            rectangle.ExecuteCommand(commond, parameter);
        }

        [TestCase("4,6")]
        public void Test_PlaceRectangles_Placed(string parameters)
        {
            bool res = rectangle.PlaceRectangles(parameters);
            X.Add(4);
            Y.Add(6);
            Assert.AreEqual(res, true);
        }

        [TestCase("4,6")]
        public void Test_FindRectangles_Found(string parameters)
        {
            rectangle.FindRectangle(parameters);
            Assert.IsTrue(X.Count > 0);
            Assert.IsTrue(Y.Count > 0);
        }

        [TestCase("4,6")]
        public void Test_RemoveRectangles_Removed(string parameters)
        {
            rectangle.RemoveRectangle(parameters);
        }
    }
}