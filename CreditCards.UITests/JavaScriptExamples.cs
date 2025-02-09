﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.UITests
{
    public class JavaScriptExamples
    {
        [Fact]
        public void ClickOverlayedLink()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/JSOverlay.html");

                DemoHelper.Pause();

                string script = "document.getElementById('HiddenLink').click();";

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(script);


                //driver.FindElement(By.Id("HiddenLink")).Click();

                DemoHelper.Pause();

                Assert.Equal("https://www.google.com/", driver.Url);
            }
        }

        [Fact]
        public void GetOverlayedLinkText()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/jsoverlay.html");

                DemoHelper.Pause();

                string script = "return document.getElementById('HiddenLink').innerHTML;";

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string linkText = (string)js.ExecuteScript(script);

                Assert.Equal("Go to A4Q", linkText);
            }
        }
    }
}
