using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace EmpireAutoWithdraw
{
    class AutoWithdrawTool
    {

        static public void FindMyItem(IWebDriver driver, String itemName)
        {
            try
            {
                IWebElement findItem = driver.FindElement(By.XPath($"//img[@alt='{itemName}']"));
                if (findItem.Displayed)
                {
                    Console.WriteLine("Item: Inscribed Wings of the Fireflight Scion Found!");
                    for (int i = 0; i < 2; i++)
                        Console.Beep();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find item... Will try again in 2 minutes!");
            }

        }

        static void Main(string[] args)
        {

            String tradeURL = "https://steamcommunity.com/tradeoffer/new/?partner=61634773&token=msvftOMK";
            String passCode = "0727";


            // Creates WebDriver and goes to target website
            IWebDriver ChromeDriver = new ChromeDriver();
            ChromeDriver.Navigate().GoToUrl("https://csgoempire.com/");

            Console.WriteLine("Welcome to CSGOEmpire Auto-Withdraw tool!");
            Console.WriteLine("Please login with Steam credentials then press Enter to continue.");
            Console.ReadLine();


            //Finds withdraw button on website
            IWebElement withdraw = ChromeDriver.FindElement(By.XPath("//a[contains(@href, '/withdraw')]"));


            //Checks if button is shown on site.
            if (withdraw.Displayed)
            {
                Console.WriteLine("Withdraw button found!");
                withdraw.Click();
            }
            else
            {
                Console.WriteLine("Oh no! Element not found");
            }

            Thread.Sleep(1000);

            //Finds DotA 2 on Withdraw
            IWebElement dotaButton = ChromeDriver.FindElement(By.XPath("//*[contains(text(), ' Dota 2 ')]"));


            if (dotaButton.Displayed)
            {
                Console.WriteLine("DotA 2 Button found!");
                dotaButton.Click();
            }
            else
            {
                Console.WriteLine("Oh no! Element not found");
            }

            Thread.Sleep(2000);

            bool loop = true;

            String itemName = "Inscribed Wings of the Fireflight Scion";

            while (loop)
            {

                // Code for waiting until item exists: https://stackoverflow.com/questions/19573943/webdriverwait-how-to-wait-until-an-item-exists-or-doesnt-exist

                FindMyItem(ChromeDriver, itemName);

                ChromeDriver.Navigate().Refresh();

                ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            }

            


            // Clicks next page
            IWebElement pageTwo = ChromeDriver.FindElement(By.XPath("//a[text()='2']"));
            pageTwo.Click();

            /* Finds item and clicks on it.
            IWebElement itemButton = ChromeDriver.FindElement(By.XPath("//*[contains(text(), ' Genuine Golden Gravelmaw ')]"));
            itemButton.Click();
            */



            //Thread.Sleep(15000);
            //ChromeDriver.Quit();
        }
    }


}

