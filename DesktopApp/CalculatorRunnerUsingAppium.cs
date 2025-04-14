using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using OpenQA.Selenium;

namespace DesktopApp
{
    [TestClass]
    public class CalculatorRunnerUsingAppium
    {
        [TestMethod]
        public void LaunchCalculator()
        {
            var options = new AppiumOptions();
            options.PlatformName = "Windows";
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            var sessionCalc = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723/wd/hub"), options);

            Assert.IsNotNull(sessionCalc);
            Console.WriteLine("✅ Calculator launched using Appium server.");

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
        }

    }
}
