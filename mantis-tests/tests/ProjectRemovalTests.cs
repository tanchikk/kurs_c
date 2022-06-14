using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            if (app.Projects.GetProjectList().Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = GenerateRandomString(10),
                    Description = GenerateRandomString(10)
                };
                app.Projects.Create(project);
            }

            List<ProjectData> oldProgects = app.Projects.GetProjectList();

            ProjectData toBeRemoved = oldProgects[0];

            app.Projects.Remove(toBeRemoved);

            List<ProjectData> newProgects = app.Projects.GetProjectList();

            oldProgects.RemoveAt(0);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);
        }
    }
}