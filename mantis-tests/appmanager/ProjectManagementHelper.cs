using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            manager.Menu.OpenManagmentMenu();
            manager.Menu.GoToProgectTab();
            InitProjectCreate();
            FillProjectForm(project);
            SubmitProjectCreate();
            driver.FindElement(By.LinkText("Продолжить")).Click();
        }

        public void Remove(ProjectData project)
        {
            manager.Menu.GoToProgectTab();
            OpenEditPage(project.Name);
            RemoveProgect();
            SubmitProgectRemove();
        }

        public void OpenEditPage(String name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        public void RemoveProgect()
        {
            driver.FindElement(By.CssSelector("form#project-delete-form input.btn")).Click();
        }

        public void SubmitProgectRemove()
        {
            driver.FindElement(By.CssSelector("div.alert-warning .btn")).Click();
        }

        public void SubmitProjectCreate()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        public void InitProjectCreate()
        {
            driver.FindElement(By.XPath("//form[@action=\"manage_proj_create_page.php\"]//button[@type=\"submit\"]")).Click();
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> list = new List<ProjectData>();
            manager.Menu.OpenManagmentMenu();
            manager.Menu.GoToProgectTab();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//table/tbody)[1]/tr"));
            foreach (IWebElement element in elements)
            {
                list.Add(new ProjectData()
                {
                    Name = element.FindElements(By.CssSelector("td"))[0].Text,
                    Description = element.FindElements(By.CssSelector("td"))[4].Text
                });
            }
            return list;
        }
    }
}