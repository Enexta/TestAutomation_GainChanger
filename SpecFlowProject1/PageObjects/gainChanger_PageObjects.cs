using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.PageObjects
{
    public class gainChanger_PageObjects
    {
        private readonly IWebDriver driver;
        private const String GainChangerUrl = "https://www.gainchanger.com/resources/";

        public gainChanger_PageObjects(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement BlogButton => driver.FindElement(By.XPath("(//a[@class='elementor-post__thumbnail__link'])[1]"));
        private IWebElement H1Element => driver.FindElement(By.CssSelector(" h1[class='elementor-heading-title elementor-size-default']"));
        private IWebElement MetaTitle => driver.FindElement(By.CssSelector("meta[property='og:title']"));
        private IWebElement MetaDescription => driver.FindElement(By.CssSelector("meta[property='og:description']"));
        


    }
}
