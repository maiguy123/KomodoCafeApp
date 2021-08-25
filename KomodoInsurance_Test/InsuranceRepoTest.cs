using KomodoInsurance_Re;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsurance_Test
{
    [TestClass]
    public class InsuranceRepoTest
    {
        public ClaimsRepo _claimsRepo;
        public Claims _claims;

        [TestMethod]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepo();
            _claims = new Claims("John Mai",
                "Full Coverage", "Insures both sides", 1200m, new DateTime(9 / 10 / 2020), new DateTime(9/15/2020));
            _claimsRepo.AddClaimsToQueue(_claims);
        }
        //Create Method
        [TestMethod]
        public void AddtoQueue_ShouldGetNotNull()
        {
            //Arrange
            Claims newClaim = new Claims();
            ClaimsRepo repo = new ClaimsRepo();

            newClaim.ID = "one";
            //Act

            repo.AddClaimsToQueue(newClaim);
            //Assert
            Assert.IsNotNull(repo);
        }
        //Read Method
        [TestMethod]
        public void ReturnClaimsQueue_ShouldReturnNotNull()
        {
            //Arrange
            Arrange();
            // Act
            _claimsRepo.GetClaimsByQueue();

            //Assert 
            Assert.IsNotNull(_claimsRepo);
        }

   

        //Delete
        [TestMethod]
        public void RemoveClaimsFromQueue_ShouldReturnTrue()
        {
            //Arrange
            Arrange();
            //Act
            bool removeItem = _claimsRepo.RemoveClaimsFromQueue();
            //Assert
            Assert.IsTrue(removeItem);
        }
    }
}
