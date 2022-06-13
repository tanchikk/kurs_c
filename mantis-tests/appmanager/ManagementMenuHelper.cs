using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests 
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void OpenManagmentMenu()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_overview_page.php']")).Click();
        }

        public void GoToProgectTab()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_proj_page.php']")).Click();
        }
    }
}
