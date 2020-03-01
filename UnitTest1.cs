using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeTest;
namespace GameOfLifeTest
{


    /// <summary>
    ///This is a test class for GameOfLifeTest and is intended
    ///to contain all GameOfLifeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Play
        ///</summary>
        [TestMethod()]
        public void PlayTest()
        {
            UnitTest.Game target = new UnitTest.Game(); // TODO: Initialize to an appropriate value
            bool[,] board = new bool[20, 20];
            bool[,] boardAfterPlay = target.Play(board);
            Assert.AreNotSame(board, boardAfterPlay);
            Assert.AreEqual(board.GetLength(0), boardAfterPlay.GetLength(0));
            Assert.AreEqual(board.GetLength(1), boardAfterPlay.GetLength(1));
        }

        [TestMethod()]
        public void DeadBoardReminsDeadTest()
        {
            UnitTest.Game target = new UnitTest.Game();
            bool[,] board = new bool[20, 20];
            bool[,] populatedBoard = new bool[20, 20];
            populatedBoard = target.PopulateBoard(board, ref populatedBoard);
            CollectionAssert.AreEqual(populatedBoard, board);
        }

        [TestMethod()]
        public void BoardChangedTest()
        {
            UnitTest.Game target = new UnitTest.Game();
            bool[,] board = new bool[20, 20];
            board[0, 0] = true;
            bool[,] populatedBoard = new bool[20, 20];
            populatedBoard = target.PopulateBoard(board, ref populatedBoard);
            CollectionAssert.AreNotEqual(populatedBoard, board);
        }

        [TestMethod()]
        public void CheckLivenessTest()
        {
            UnitTest.Game target = new UnitTest.Game();
            bool[,] board = { { false, false, false }, { false, false, false }, { true, true, true } };
            Assert.IsFalse(target.CheckLiveness(board, 0, 0));
            Assert.IsFalse(target.CheckLiveness(board, 0, 1));
            Assert.IsFalse(target.CheckLiveness(board, 0, 2));
            Assert.IsFalse(target.CheckLiveness(board, 1, 0));
            Assert.IsFalse(target.CheckLiveness(board, 1, 2));
            Assert.IsFalse(target.CheckLiveness(board, 2, 0));
            Assert.IsFalse(target.CheckLiveness(board, 2, 2));
            Assert.IsTrue(target.CheckLiveness(board, 1, 1));
            Assert.IsTrue(target.CheckLiveness(board, 2, 1));
        }

        [TestMethod()]
        public void ApplyRulesTest()
        {
            UnitTest.Game target = new UnitTest.Game();


            Assert.IsFalse(target.ApplyRules(false, 0));

            Assert.IsFalse(target.ApplyRules(false, 1));

            Assert.IsFalse(target.ApplyRules(false, 2));

            Assert.IsTrue(target.ApplyRules(false, 3));


            Assert.IsFalse(target.ApplyRules(true, 0));

            Assert.IsFalse(target.ApplyRules(true, 1));

            Assert.IsTrue(target.ApplyRules(true, 2));

            Assert.IsTrue(target.ApplyRules(true, 3));

            for (int i = 4; i < 9; i++)
            {
                Assert.IsFalse(target.ApplyRules(true, i));
                Assert.IsFalse(target.ApplyRules(false, i));
            }
        }

        [TestMethod()]
        public void CheckCountLiveNeighbours()
        {
            UnitTest.Game target = new UnitTest.Game();
            bool[,] board = { { false, false, false }, { false, false, false }, { true, true, true } };
            int liveNeighbours = target.CountLiveNeighbours(board, 1, 1);
            Assert.AreEqual(3, liveNeighbours);

            liveNeighbours = target.CountLiveNeighbours(board, 0, 1);
            Assert.AreEqual(0, liveNeighbours);
            Assert.AreEqual(0, target.CountLiveNeighbours(board, 0, 0));
            Assert.AreEqual(2, target.CountLiveNeighbours(board, 1, 0));
            Assert.AreEqual(2, target.CountLiveNeighbours(board, 1, 2));
            Assert.AreEqual(1, target.CountLiveNeighbours(board, 2, 0));
            Assert.AreEqual(1, target.CountLiveNeighbours(board, 2, 2));
            Assert.AreEqual(3, target.CountLiveNeighbours(board, 1, 1));
            Assert.AreEqual(2, target.CountLiveNeighbours(board, 2, 1));

            Assert.IsTrue(target.IsLiving(board, 2, 0));
            Assert.IsTrue(target.IsLiving(board, 2, 1));
            Assert.IsTrue(target.IsLiving(board, 2, 2));
            Assert.IsFalse(target.IsLiving(board, 1, 0));
            Assert.IsFalse(target.IsLiving(board, 1, 2));
            Assert.IsFalse(target.IsLiving(board, 0, 0));
            Assert.IsFalse(target.IsLiving(board, 0, 1));
            Assert.IsFalse(target.IsLiving(board, 2, 3));
            Assert.IsFalse(target.IsLiving(board, -1, 0));
        }
    }
}
