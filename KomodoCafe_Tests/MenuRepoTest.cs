using GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuRepoTest
    {
        public MenuRepo _menuRepo;
        public Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepo();
            _menu = new Menu("John's Big Burger", "This burger is a great choice for meat lovers", new List<string> { "Bacon", "Angus Beef", "Turkey", "Sauage" }, 12.50m);
            _menuRepo.AddContentToList(_menu);
        }

        // Create Mehtod
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            _menu.Name = "Komodo Cafe";
            MenuRepo repository = new MenuRepo();

            repository.AddContentToList(_menu);
            //   Menu contentFromDirectory = repository.GetMenuByList("Kodomo Cafe");

            Assert.IsNotNull(repository);
        }

        //Read Method
        [TestMethod]
        public void ReturnMenuList_ShouldReturnNotNull()
        {
            //Act
            _menuRepo.GetMenuByList();

            //Assert
            Assert.IsNotNull(_menuRepo);
        }
        /// Update
        [TestMethod]
        public void UpdateExistingMenu_ShouldReturnTrue()
        {
            //Arrange
            Menu newContent = new Menu("Komodo Special", "A burger with Komodo Special Sauce", new List<string> { "swiss bun", "bacon", "Angus Beef", "tomatoes" }, 15.50m);

            //Act
            bool updatedResult = _menuRepo.UpdateExisitingMenu("John's Big Burger", newContent);

            //Assert
            Assert.IsTrue(updatedResult);

        }
        // Delete
        [TestMethod]
        public void RemoveMenuFromList_ShouldReturnTrue()
        {
            //Arrange


            //Act
            bool removeItem = _menuRepo.RemoveMenuFromList("John's Big Burger");

            //Assert
            Assert.IsTrue(removeItem);
        }
    }
}
