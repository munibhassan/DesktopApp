using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;

namespace DesktopApp
{
    [TestClass]
    public class LaunchSplashScreenApp
    {
        [TestMethod]
        public void TestMethod1()
        {
            var options = new AppiumOptions();
            options.PlatformName = "Windows";
            //options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", "Outlook");


            var sessionCalc = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723/wd/hub"), options);

            Assert.IsNotNull(sessionCalc);
            Console.WriteLine("✅ Calculator launched using Appium server.");
        }
    }
}
