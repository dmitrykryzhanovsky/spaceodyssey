using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class MassTests
    {
        [TestMethod ()]
        public void MassTest_Copying ()
        {
            Mass other  = Mass.CreateByMass (10.0);
            Mass actual = new Mass (other);

            Assert.AreEqual (10.0, actual.M);
            Assert.AreEqual (6.6743e-10, actual.GM, 1.0e-24);
            Assert.AreEqual (2.58346666322598403e-5, actual.SqrtGM, 1.0e-20);
        }

        [TestMethod ()]
        public void CloneTest ()
        {
            Mass other  = Mass.CreateByMass (10.0);
            Mass actual = (Mass)other.Clone ();

            Assert.AreEqual (10.0, actual.M);
            Assert.AreEqual (6.6743e-10, actual.GM, 1.0e-24);
            Assert.AreEqual (2.58346666322598403e-5, actual.SqrtGM, 1.0e-20);
        }

        [TestMethod ()]
        public void CreateByMassTest_Positive ()
        {
            Mass body = Mass.CreateByMass (10.0);

            Assert.AreEqual (10.0, body.M);
            Assert.AreEqual (6.6743e-10, body.GM, 1.0e-24);
            Assert.AreEqual (2.58346666322598403e-5, body.SqrtGM, 1.0e-20);
        }

        [TestMethod ()]
        public void CreateByMassTest_Zero ()
        {
            Mass body = Mass.CreateByMass (0.0);

            Assert.AreEqual (0.0, body.M);
            Assert.AreEqual (0.0, body.GM);
            Assert.AreEqual (0.0, body.SqrtGM);
        }

        [TestMethod ()]
        public void CreateByMassTest_Exception_Negative ()
        {
            bool argumentOutOfRangeException = false;

            try
            {
                Mass body = Mass.CreateByMass (-10.0);
            }
            
            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByGMTest_Positive ()
        {
            Mass body = Mass.CreateByGM (6.6743e-10);

            Assert.AreEqual (10.0, body.M, 1.0e-14);
            Assert.AreEqual (6.6743e-10, body.GM);
            Assert.AreEqual (2.58346666322598403e-5, body.SqrtGM);
        }

        [TestMethod ()]
        public void CreateByGMTest_Zero ()
        {
            Mass body = Mass.CreateByGM (0.0);

            Assert.AreEqual (0.0, body.M);
            Assert.AreEqual (0.0, body.GM);
            Assert.AreEqual (0.0, body.SqrtGM);
        }

        [TestMethod ()]
        public void CreateByGMTest_Exception_Negative ()
        {
            bool argumentOutOfRangeException = false;

            try
            {
                Mass body = Mass.CreateByGM (-10.0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySqrtGMTest_Positive ()
        {
            Mass body = Mass.CreateBySqrtGM (2.58346666322598403e-5);

            Assert.AreEqual (10.0, body.M, 1.0e-14);
            Assert.AreEqual (6.6743e-10, body.GM);
            Assert.AreEqual (2.58346666322598403e-5, body.SqrtGM);
        }

        [TestMethod ()]
        public void CreateBySqrtGMTest_Zero ()
        {
            Mass body = Mass.CreateBySqrtGM (0.0);

            Assert.AreEqual (0.0, body.M);
            Assert.AreEqual (0.0, body.GM);
            Assert.AreEqual (0.0, body.SqrtGM);
        }

        [TestMethod ()]
        public void CreateBySqrtGMTest_Exception_Negative ()
        {
            bool argumentOutOfRangeException = false;

            try
            {
                Mass body = Mass.CreateBySqrtGM (-10.0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }
    }
}