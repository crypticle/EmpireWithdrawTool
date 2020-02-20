using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EmpireAutoWithdraw
{
    class AutoWithdrawTool
    {
        static void Main(string[] args)
        {
            IWebDriver ChromeDriver = new ChromeDriver();

            ChromeDriver.Navigate().GoToUrl("https://csgoempire.com/");

            IWebElement withdraw = ChromeDriver.FindElement(By.XPath("//a[contains(@href, '/withdraw')]"));

            if(withdraw.Displayed)
            {
                Console.WriteLine("Awesome the element was found!");
            }
            else
            {
                Console.WriteLine("Oh no! Element not found");
            }

            withdraw.Click();

            Thread.Sleep(1000);

            // IWebElement dotaButton = ChromeDriver.FindElement(By.XPath("//*[@class='pl-2']")); // Works for first button

            IWebElement dotaButton = ChromeDriver.FindElement(By.XPath("//*[contains(text(), ' Dota 2 ')]"));


            if (dotaButton.Displayed)
            {
                Console.WriteLine("Awesome the element was found!");
            }
            else
            {
                Console.WriteLine("Oh no! Element not found");
            }

            dotaButton.Click();

            Thread.Sleep(1000);

            IWebElement itemButton = ChromeDriver.FindElement(By.XPath("//*[contains(text(), ' Genuine Golden Gravelmaw ')]"));
            itemButton.Click();

            IWebElement itemButton2 = ChromeDriver.FindElement(By.XPath("//*[contains(text(), ' Genuine Golden Gravelmaw ')] [2]"));
            itemButton2.Click();
            //Thread.Sleep(15000);
            //ChromeDriver.Quit();
        }
    }
}

/*
do
{
IList<IWebElement> Test= SeleniumDriver.WebDriver.FindElements(By.Xpath(""));

//HERE YOU CHECK IF BUTTON EXIST
if(isElementPresented(By.Id("")))
{
driver.FindElement(By.Id("")).Click;
}
else
{
//if button not exists
buttonExist = false;
}
}while(buttonExist);
*/
