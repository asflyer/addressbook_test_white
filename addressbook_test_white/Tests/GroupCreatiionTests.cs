﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace addressbook_test_white
{
    [TestFixture]
    public class GroupCreatiionTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups =  app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "White"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups =  app.Groups.GetGroupList();

            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
