using System;
using System.Linq;
using Selenium;

namespace ThoughtWorks.Selenium.Silvernium
{
    public class Silvernium
    {
        private readonly string _scriptKey = "";
        private readonly ISelenium _selenium;
        private readonly string _silverLightJsStringPrefix;

        public Silvernium(ISelenium selenium, string silverlightObjectId, string scriptKey)
        {
            if (!string.IsNullOrEmpty(scriptKey))
            {
                _scriptKey = scriptKey + ".";
            }
            _selenium = selenium;
            _silverLightJsStringPrefix = GetSilverLightJsStringPrefix(silverlightObjectId);
        }

        public Silvernium(ISelenium selenium, string silverlightObjectId)
        {
            _selenium = selenium;
            _silverLightJsStringPrefix = GetSilverLightJsStringPrefix(silverlightObjectId);
        }

        public string SilverLightJSStringPrefix
        {
            get { return _silverLightJsStringPrefix; }
        }

        private string GetSilverLightJsStringPrefix(string silverlightObjectId)
        {
            string appName = _selenium.GetEval("navigator.userAgent");
            if (appName.Contains(BrowserConstants.Firefox2))
            {
                return CreateJsPrefixDocument(silverlightObjectId);
            }
            if (appName.Contains(BrowserConstants.Firefox) || appName.Contains(BrowserConstants.InternetExplorer))
            {
                return CreateJsPrefixWindowDocument(silverlightObjectId);
            }
            return string.Empty;
        }

        public string CreateJsPrefixWindowDocument(string silverlightObjectId)
        {
            return "window.document['" + silverlightObjectId + "'].";
        }

        public string CreateJsPrefixDocument(string silverlightObjectId)
        {
            return "document['" + silverlightObjectId + "'].";
        }

        public string JsForDirectMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Any())
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return _silverLightJsStringPrefix + functionName + "(" + functionArgs + ");";
        }

        public string JsForContentScriptMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Any())
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return _silverLightJsStringPrefix + "content." + _scriptKey + functionName + "(" + functionArgs + ");";
        }

        public string JsForContentMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Any())
            {
                for (int i=0; i<parameters.Length; i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                //remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return _silverLightJsStringPrefix + "content." + functionName + "(" + functionArgs + ");";
        }

        private string JsForContentProperty(string propertyName)
        {
            return _silverLightJsStringPrefix + "content." + propertyName + ";";
        }

        private string JsForDirectProperty(string propertyName)
        {
            return _silverLightJsStringPrefix + propertyName + ";";
        }

        private string JsForSettingsProperty(string propertyName)
        {
            return _silverLightJsStringPrefix + "settings." + propertyName + ";";
        }

        private string JsForContentScriptGetProperty(string propertyName)
        {
            return _silverLightJsStringPrefix + "content." + _scriptKey + propertyName + ";";
        }

        private string JsForContentScriptSetProperty(string propertyName, string parameters)
        {
            return _silverLightJsStringPrefix + "content." + _scriptKey + propertyName + "='" + parameters + "';";
        }

        public void Start()
        {
            _selenium.Start();
        }

        public void Stop()
        {
            _selenium.Stop();
        }

        public void Open(string url)
        {
            _selenium.Open(url);
        }

        public string DirectMethod(string functionName, params string[] parameters)
        {
            return _selenium.GetEval(JsForDirectMethod(functionName, parameters));
        }

        public string ContentMethod(string functionName, params string[] parameters)
        {
            return _selenium.GetEval(JsForContentMethod(functionName, parameters));
        }

        private string ContentProperty(string propertyName)
        {
            return _selenium.GetEval(JsForContentProperty(propertyName));
        }

        private string DirectProperty(string propertyName)
        {
            return _selenium.GetEval(JsForDirectProperty(propertyName));
        }

        private string SettingsProperty(string propertyName)
        {
            return _selenium.GetEval(JsForSettingsProperty(propertyName));
        }

        public string GetPropertyValue(string propertyName)
        {
            return _selenium.GetEval(JsForContentScriptGetProperty(propertyName));
        }

        public string SetPropertyValue(string propertyName, string parameters)
        {
            return _selenium.GetEval(JsForContentScriptSetProperty(propertyName, parameters));
        }

        public string Call(string functionName, params string[] parameters)
        {
            return _selenium.GetEval(JsForContentScriptMethod(functionName, parameters));
        }

        //Silverlight Methods
        public bool IsVersionSupported(string versionString)
        {
            return Convert.ToBoolean(DirectMethod("isVersionSupported", versionString));
        }

        public int ActualHeight()
        {
            return Convert.ToInt32(ContentProperty("actualHeight"));
        }

        public int ActualWidth()
        {
            return Convert.ToInt32(ContentProperty("actualWidth"));
        }

        public string Accessibility()
        {
            return ContentProperty("accessibility");
        }

        public void CreateFromXaml(string xamlContent, string namescope)
        {
            ContentMethod("createFromXaml", xamlContent, namescope);
        }

        public string FindName(string objectName)
        {
            return ContentMethod("findName", objectName);
        }

        public bool FullScreen()
        {
            return Convert.ToBoolean(ContentProperty("fullScreen"));
        }

        public string InitParams()
        {
            return DirectProperty("initParams");
        }

        public bool IsLoaded()
        {
            return Convert.ToBoolean(DirectProperty("isLoaded"));
        }

        public string Root()
        {
            return DirectProperty("root");
        }

        public string Background()
        {
            return SettingsProperty("background");
        }

        public bool EnabledFrameRateCounter()
        {
            return Convert.ToBoolean(SettingsProperty("enabledFramerateCounter"));
        }

        public bool EnableRedrawRegions()
        {
            return Convert.ToBoolean(SettingsProperty("enableRedrawRegions"));
        }

        public bool EnableHtmlAccess()
        {
            return Convert.ToBoolean(SettingsProperty("enableHtmlAccess"));
        }

        public int MaxFrameRate()
        {
            return Convert.ToInt32(SettingsProperty("maxFrameRate"));
        }

        public bool WindowLess()
        {
            return Convert.ToBoolean(SettingsProperty("windowless"));
        }

        public string Source()
        {
            return DirectProperty("source");
        }	
    }
}