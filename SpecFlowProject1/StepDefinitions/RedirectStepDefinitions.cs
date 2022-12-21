using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class RedirectStepDefinitions
    {
        private readonly IWebDriver driver = new ChromeDriver();
        private string? H1_element;
        private string? Metatitle_element;
        private string? Metadesc_element;
        private List<string> Hlist;
        private List<string> Plist;
        

        [Given(@"\[I naviagate to resources page]")]
        public void GivenINaviagateToResourcesPage()
        {
           
                driver.Navigate().GoToUrl("https://www.gainchanger.com/resources/");
                driver.Manage().Window.Maximize();
            Console.WriteLine("The page has been navigated to successfully");
        }

        [When(@"\[Access the first blog]")]
        public void WhenAccessTheFirstBlog()

        {
            var blog_btn = driver.FindElement(By.XPath("(//a[@class='elementor-post__thumbnail__link'])[1]"));
            blog_btn.SendKeys(Keys.Enter);

            Assert.IsTrue(driver.Url.ToLower().Contains("https://www.gainchanger.com/seo-without-link-building-the-best-on-page-strategies/"));
           
            Console.WriteLine("The first blog was foundand has been clicked");
        }

        [Then(@"\[I should be able to extract its web elements]")]
        public void ThenIShouldBeAbleToExtractItsWebElements()
        {
            // Retrieving h1 element            
            H1_element = driver.FindElement(By.CssSelector(" h1[class='elementor-heading-title elementor-size-default']")).Text;
            Console.WriteLine("H1 "+H1_element);  
           
            // Get Meta title
            Metatitle_element = driver.FindElement(By.CssSelector("meta[property='og:title']")).GetAttribute("content");
            Console.WriteLine("MT "+ Metatitle_element);
            
            //Get Meta Description
            Metadesc_element = driver.FindElement(By.CssSelector("meta[property='og:description']")).GetAttribute("content");
            Console.WriteLine("MD "+ Metadesc_element);


            //Get h2 Elements
            Hlist = new List<string>();
            IList<IWebElement> h2_tags = driver.FindElements(By.TagName("h2"));
            // extracting h2 tags text
            Console.WriteLine("total number of h2 =" + h2_tags.Count);
            foreach (IWebElement H2_element in h2_tags)
            {
              Console.WriteLine(H2_element.Text);
                Hlist.Add(H2_element.Text);
                
            }



            //Get Paragraph elements
            Plist = new List<string>();
            IList<IWebElement> p_tags = driver.FindElements(By.TagName("p"));
            // extracting paragraph tags text         
            foreach (IWebElement P_element in p_tags)
            {
             
            Console.WriteLine(P_element.Text);
             Plist.Add(P_element.Text);
            }

            driver.Quit();


        }
        [Then(@"\[Export the fields in json format]")]
        public void ThenExportTheFieldsToJSONFormat()
        {
          

            string jsonresult = JsonConvert.SerializeObject(new
            {
                H1 = H1_element,
                Meta_title = Metatitle_element,
                Meta_description = Metadesc_element,
                H2 = Hlist,
                Paragraph = Plist,               
            }) ;
            

            Console.WriteLine(jsonresult);
            var dir =Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Console.WriteLine(dir);
            File.WriteAllText(dir+"\\source\\repos\\TestAutomation_GainChanger\\SpecFlowProject1\\newone.json", jsonresult);
        
         
        }
        
       
    }
             

        

}
