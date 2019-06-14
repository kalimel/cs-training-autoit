using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count == 1)
            {
                Random r = new Random();
                GroupData newGroup = new GroupData()
                {
                    Name = "newwgrouppp" + r.Next(1, 9999)
                };

                app.Groups.Add(newGroup);
                oldGroups.Add(newGroup);
            }

            GroupData groupToRemove = oldGroups.First();
            app.Groups.Remove(groupToRemove);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(groupToRemove);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
