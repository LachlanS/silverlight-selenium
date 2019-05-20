using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public static class Setup
    {
        /// <summary>
        ///     Check that the registry key required for WebDriver fixtures to consistently work with Internet Explorer 11 is set.
        /// </summary>
        [AssemblyInitialize]
        public static void Registry_Key_For_Internet_Explorer_11_Is_Set(TestContext testContext)
        {
            AssertRegistryKeyForInternetExplorer11(RegistryView.Registry32);
            AssertRegistryKeyForInternetExplorer11(RegistryView.Registry64);
        }

        private static void AssertRegistryKeyForInternetExplorer11(RegistryView registryView)
        {
            /*
             * The instructions on what registry value needs to be set should include the WOW64 registry redirect path,
             * in the case of 32-bit Internet Explorer running on 64-bit Windows
             */
            var failMessage =
@"A registry value is required for WebDriver fixtures to consistently work with Internet Explorer 11:

Windows Registry Editor Version 5.00
[HKEY_LOCAL_MACHINE\SOFTWARE\" + (registryView == RegistryView.Registry32 ? "WOW6432Node\\" : "") + @"Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BFCACHE]
""iexplore.exe""=dword:00000000";

            var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView);
            var subKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BFCACHE");
            var value = subKey?.GetValue("iexplore.exe");

            Assert.IsNotNull(value, failMessage);
            Assert.IsInstanceOfType(value, typeof(int), failMessage);
            Assert.AreEqual(0, (int)value, failMessage);
        }
    }
}
