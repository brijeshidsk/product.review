using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RestFullWebAPI.Tests.MoqDemo;

namespace RestFullWebAPI.Tests
{
    public class MoqDemoTest
    {
        [Fact]
        public void TestUsingMoqDependency()
        {
            //Arrange
            //Create a mock version of interface first
            var MockDep = new Mock<IThingDependency>();

            MockDep.Setup(t => t.Join(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("John Smith");

            MockDep.Setup(t => t.Age)
                .Returns(32);

            var card = new Card { Name = "John Smith", Number = 123456789, CVV = 123 };

            //MockDep.Setup(t => t.Charge(123, card))
            //  .Returns(true);

            MockDep.Setup(t => t.Charge(It.IsAny<int>(), card))
               .Returns(true);

            var classToBeTested = new ThingToBeTested(MockDep.Object);

            var expected = "John Smith is 32 years old";

            //Act
            var result = classToBeTested.doTheThing();

            var result2 = classToBeTested.chargeTheCard(40,card);

            //Assert
            Assert.Equal(expected, result);



        }
    }
}
