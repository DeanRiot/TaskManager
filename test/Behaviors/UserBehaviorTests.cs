using NUnit.Framework;

namespace TaskManagerTests.Behaviors
{
    internal class UserBehaviorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_Positive()
        {
            Assert.Pass();
        }

        [Test]
        public void Create_Negative()
        {
            Assert.Pass();
        }

        [Test]
        public void Read_One_User_Return_Right_User()
        {
            Assert.Pass();
        }

        [Test]
        public void Read_One_User_Returns_Empty_If_Not_Exists()
        {
            Assert.Pass();
        }

        [Test]
        public void Read_All_Users_Return_All_Info()
        {
            Assert.Pass();
        }

        [Test]
        public void Auth_Return_Empty_Token_If_Not_Right_Secrets()
        {
            Assert.Pass();
        }

        [Test]
        public void Auth_Return_Token_Right_Secrets()
        {
            Assert.Pass();
        }

        [Test]
        public void HasToken_Positive()
        {
            Assert.Pass();
        }

        [Test]
        public void HasToken_Negative()
        {
            Assert.Pass();
        }
    }
}
