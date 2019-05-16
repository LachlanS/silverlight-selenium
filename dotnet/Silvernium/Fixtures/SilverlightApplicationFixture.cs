using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class SilverlightApplicationFixture
    {
        private const string ObjectId = "silverlight";
        private const string Scriptkey = "SilverlightFixture";

        private readonly ThoughtWorks.Selenium.Silvernium.Silvernium _silvernium;

        public SilverlightApplicationFixture(string host, int port, Browser browser, string url)
        {
            var uriBuilder = new UriBuilder { Host = host, Port = port };

            IWebDriver driver;
            switch (browser)
            {
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browser.InternetExplorer:
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    throw new Exception("Browser is not implemented");
            }

            var selenium = new WebDriverBackedSelenium(driver, uriBuilder.Uri);

            selenium.Start();
            selenium.Open(url);
            selenium.SetSpeed("100");
            _silvernium = new ThoughtWorks.Selenium.Silvernium.Silvernium(selenium, ObjectId, Scriptkey);
            while (!_silvernium.IsLoaded())
            {
                Thread.Sleep(100);
            }
        }

        public ButtonFixture Button(string path)
        {
            return new ButtonFixture(_silvernium, path);
        }

        public TextBoxFixture TextBox(string path)
        {
            return new TextBoxFixture(_silvernium, path);
        }

        public CheckBoxFixture CheckBox(string path)
        {
            return new CheckBoxFixture(_silvernium, path);
        }

        public TextBlockFixture TextBlock(string path)
        {
            return new TextBlockFixture(_silvernium, path);
        }

        public RadioButtonFixture RadioButton(string path)
        {
            return new RadioButtonFixture(_silvernium, path);
        }

        public ComboBoxFixture ComboBox(string path)
        {
            return new ComboBoxFixture(_silvernium, path);
        }

        public DataGridFixture DataGrid(string path)
        {
            return new DataGridFixture(_silvernium, path);
        }

        public DataGridFixture DataGrid(string path, string pagerPath)
        {
            return new DataGridFixture(_silvernium, path, pagerPath);
        }

    }
}
