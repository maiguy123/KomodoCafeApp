using KomodoBadge_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badge_Tests
{
    [TestClass]
    public class BadgeTests
    {
        public BadgeRepo _badgeRepo;
        public Badges _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _badge = new Badges("BadgeID", new List<string> { "Door Acess" });
            _badgeRepo.CreateNewBadges(_badge);
        }
        // create method
        [TestMethod]
        public void AddToList_shouldGetNotNull()
        {
            _badge.BadgeID = "Badge Name";
            BadgeRepo repository = new BadgeRepo();

            repository.CreateNewBadges(_badge);
        }

        // read method
        [TestMethod]
        public void ReturnMenuList_ShouldReturnNotNull()
        {
            // Act
            _badgeRepo.GetBadgesByList();

            // Assert
            Assert.IsNotNull(_badgeRepo);
        }

        //Update 
        [TestMethod]
        public void UpdateExistingDoors_ShouldReturnTrue()
        {
            //arrange
            Badges newContent = new Badges("BadgeID", new List<string> { "Doors" });

            //Act 
            bool updatedResult = _badgeRepo.UpdateExistingDoors("BadgeID", newContent);

            //Assert
            Assert.IsTrue(updatedResult);
        }

        //Delete 
        [TestMethod]
        public void DeleteDoorFromExisitingBadges_ShouldReturnTrue()
        {
            // Act 
            bool removeItem = _badgeRepo.DeleteDoorFromExisitingBadges("BadgeID");

            //Assert
            Assert.IsTrue(removeItem);
        }

    }
}





