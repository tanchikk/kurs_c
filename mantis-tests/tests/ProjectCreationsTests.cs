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
                Name = "Project",
                Description = ""
            };

            app.Projects.Create(project);

            List<ProjectData> newProgects = app.Projects.GetProjectList();

            oldProgects.Add(project);
            oldProgects.Sort();
            newProgects.Sort();

            Assert.AreEqual(oldProgects, newProgects);

        }
    }
}
