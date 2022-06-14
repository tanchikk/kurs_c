using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationsTests : AuthTestBase
    {
        [Test]
        public void ProjectCreateonTest()
        {
            List<ProjectData> oldProgects = app.Projects.GetProjectList();

            ProjectData project = new ProjectData()
            {
                //Name = "Project",
                Name = GenerateRandomString(10),
                Description = GenerateRandomString(10)
            };

            app.Projects.Create(project);

            List<ProjectData> newProgects = app.Projects.GetProjectList();

            oldProgects.Add(project);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);

        }

        [Test]
        public void ProgectCreateonAPITest()
        {
            List<ProjectData> oldProgects = app.Projects.GetProjectList(account);

            ProjectData project = new ProjectData()
            {
                //Name = "Project",
                Name = GenerateRandomString(10),
                Description = GenerateRandomString(10)
            };

            app.Projects.Create(project);

            List<ProjectData> newProgects = app.Projects.GetProjectList(account);

            oldProgects.Add(project);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);

        }
    }
}
