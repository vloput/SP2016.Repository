﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SP2016.Repository.Tests.Repository
{
    [TestClass]
    public class EntityCreationTests : BaseRepoTest
    {
        [TestMethod]
        public void CreateEntity_FromListItem_EntityFilledWithRightData()
        {
            Perform(web =>
            {
                try
                {
                    UsersRepository.Add(web, MockUsers.User1);
                    var item = UsersRepository.GetEntitiesByTitle(web, MockUsers.User1.DisplayName)[0].ListItem;

                    var entity = UsersRepository.CreateEntity(web, item);

                    Assert.IsNotNull(entity);
                    Assert.AreEqual(MockUsers.User1.DisplayName, entity.DisplayName);
                }
                finally
                {
                    UsersRepository.DeleteAll(web);
                }
            });
        }
    }
}
