﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
             
            var options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors-spki-list");
            options.AddArgument("--ignore-ssl-errors");
            options.AddArgument("test-type");
            options.AddArguments("-incognito");
            options.AddArgument("no-sandbox");
            options.AddArgument("--start-maximized");
            options.AddArgument("headless");
            var driver = new ChromeDriver(options); 
            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.wired.com"); 
            Thread.Sleep(5000);
            // gets Most Recent items a tags 
            var recentElements = driver.FindElements(By.XPath("//*[@id=\"app-root\"]/div/div[3]/div/div/div[2]/div[3]/div[1]/div[1]/div/ul/li/a"));  
            Thread.Sleep(2000);
            //enter the value in the google search text box  
            var hrefs = recentElements.Select(x => x.GetAttribute("href"));
            Thread.Sleep(2000);
            var urls = hrefs.ToList();

            foreach (var url in urls)
            {
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(5000);
                var description =
                    driver.FindElement(By.XPath("//*[@id=\"main-content\"]/article/div[1]/header/div/div[1]/h1"));
                
                Console.WriteLine(description.Text);
            }
            
            
            driver.Close();  
        }
    }
}