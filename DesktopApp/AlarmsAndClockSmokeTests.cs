using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace DesktopApp
{
    [TestClass]
    public class AlarmsAndClockSmokeTests
    {
        static WindowsDriver<WindowsElement> sessionAlarms = null;
        [ClassInitialize]

        public static void PrepareForTestingAlarms(TestContext context)
        {
            Debug.WriteLine("Preparing for testing Alarms and Clock app...");
            var options = new AppiumOptions();
            options.PlatformName = "Windows";
            //options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            sessionAlarms = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
        }

        [TestMethod]
        public void TestAlarmsAndClockLaunchingSuccessfully()
        {
            
 

            Assert.AreEqual("Alarms & Clock", sessionAlarms.Title, false, $"Actual Title doestn't match with expected title: {sessionAlarms.Title}");
        }

        [ClassCleanup]
        public static void CleanupAfterTestingAlarms()
        {
            Debug.WriteLine("Cleaning up after testing Alarms and Clock app...");
            if (sessionAlarms != null)
            {
                sessionAlarms.Quit();
                sessionAlarms = null;
            }
        }

        [TestInitialize]
        public void BeforeAtTest()
        {
            Debug.WriteLine("Initializing test...");
            // You can add any setup code here if needed
        }
        [TestMethod]
        public void TestAlarmsAndClockAppIsResponsive()
        {
            Debug.WriteLine("Testing if Alarms and Clock app is responsive...");
            //// Add your test logic here
            //Assert.IsTrue(sessionAlarms != null, "Alarms and Clock app session is not initialized.");
            //// You can add more checks to ensure the app is responsive
        }
        [TestCleanup]
        public void AfterAtTest()
        {
            Debug.WriteLine("Cleaning up after test...");
            // You can add any cleanup code here if needed
        }
    }
}
