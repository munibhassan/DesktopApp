using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System;

namespace DesktopApp
{
    [TestClass]
    public class CalculatorRunner
    {
        [TestMethod]
        public void TestMethod1()
        {
            WindowsDriver<WindowsElement> sessionCalc = null;
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            //options.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");


            sessionCalc = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            sessionCalc.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var btnOne = sessionCalc.FindElementByName("One");
            var btnTwo = sessionCalc.FindElementByName("Two");
            var btnPlus = sessionCalc.FindElementByName("Plus");
            var btnEquals = sessionCalc.FindElementByName("Equals");
            var txtResult = sessionCalc.FindElementByAccessibilityId("CalculatorResults");
            btnOne.Click();
            btnPlus.Click();
            btnTwo.Click();
            btnEquals.Click();
            Assert.IsTrue(txtResult.Text.Contains("3"), "The result is not correct.");

            txtResult.SendKeys(Keys.Escape);
            txtResult.SendKeys("2");
            txtResult.SendKeys("+");
            txtResult.SendKeys("1");
            txtResult.SendKeys("=");
            txtResult.SendKeys("3");
            Assert.IsTrue(txtResult.Text.Contains("3"), "The result is not correct.");
            sessionCalc.Quit();
        }
    }
}
