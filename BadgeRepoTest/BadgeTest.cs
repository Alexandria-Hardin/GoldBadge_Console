using System;
using Badge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeRepoTest
{
    [TestClass]
    public class BadgeTest
    {
            [TestMethod]
            public void AddBadgeToDirectory_ShouldGetCorrectBoolean()
            {
                Badges newContent = new Badges();
                BadgeRepository repository = new BadgeRepository();
                bool addResult = repository.AddBadgeToDirectory(newContent);
                Assert.IsTrue(addResult);
            }
            [TestMethod]
            public void GetContents_ShouldReturnCorrectCollection()
            {
                Badges testContent = new Badges(12345, "A7");
                BadgeRepository repo = new BadgeRepository();
                repo.AddBadgeToDirectory(testContent);
                Dictionary contents = repo.GetBadges();
                bool directoryHasContent = contents.Contains(testContent);
                Assert.IsTrue(directoryHasContent);
            }
        private Badges _content;
        private BadgeRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _content = new Badges(12345, "A7");
            _repo = new BadgeRepository();
            _repo.AddBadgeToDirectory(_content);
        }
        [TestMethod]
        public void GetBadgeByID_ShouldReturnCorrectClaim()
        {
            Badges searchResult = _repo.GetBadgeByID(1);
            Assert.AreEqual(_content.BadgeID, searchResult.BadgeID);
        }
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            Badges updatedInfo = new Badges(12345, "A7");
            bool updateResult = _repo.UpdateExistingBadge(12345, updatedInfo);
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingBadge_ShouldReturnTrue()
        {
            Badges foundContent = _repo.GetBadgeByID(1);
            bool removeResult = _repo.DeleteExistingBadge(foundContent);
            Assert.IsTrue(removeResult);
        }
    }
}