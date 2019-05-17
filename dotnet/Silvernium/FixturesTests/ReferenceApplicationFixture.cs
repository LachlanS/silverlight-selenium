namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    class ReferenceApplicationFixture : SilverlightApplicationFixture
    {
        private const Browser Browser = Fixtures.Browser.InternetExplorer;
        private const string Url = "http://localhost:1981/ReferenceApplication.aspx?testMode=true";

        private static ReferenceApplicationFixture _instance;

        public static ReferenceApplicationFixture Instance()
        {
            return _instance ?? (_instance = new ReferenceApplicationFixture());
        }

        private ReferenceApplicationFixture() : base(Browser, Url) { }

    }
}
