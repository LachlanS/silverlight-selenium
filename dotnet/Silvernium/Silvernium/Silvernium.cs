using System;
using System.Linq;
using OpenQA.Selenium;

namespace ThoughtWorks.Selenium.Silvernium
{
    public class Silvernium
    {
        private readonly string _scriptKey = "";
        private readonly IJavaScriptExecutor _javaScriptExecutor;
        private readonly string _silverLightJsStringPrefix;

        public Silvernium(IJavaScriptExecutor javaScriptExecutor, string silverlightObjectId, string scriptKey)
        {
            if (!string.IsNullOrEmpty(scriptKey))
            {
                _scriptKey = scriptKey + ".";
            }
            _javaScriptExecutor = javaScriptExecutor;
            _silverLightJsStringPrefix = GetSilverLightJsStringPrefix(silverlightObjectId);
        }

        public Silvernium(IJavaScriptExecutor javaScriptExecutor, string silverlightObjectId)
        {
            _javaScriptExecutor = javaScriptExecutor;
            _silverLightJsStringPrefix = GetSilverLightJsStringPrefix(silverlightObjectId);
        }

        public string SilverLightJSStringPrefix => _silverLightJsStringPrefix;

        private string GetSilverLightJsStringPrefix(string silverlightObjectId)
        {
            string appName = (string)_javaScriptExecutor.ExecuteScript("return navigator.userAgent");

            return appName.Contains(BrowserConstants.Firefox2)
                ? CreateJsPrefixDocument(silverlightObjectId)
                : CreateJsPrefixWindowDocument(silverlightObjectId);
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
                foreach (var p in parameters)
                {
                    functionArgs = functionArgs + "'" + p + "',";
                }

                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return "return " + _silverLightJsStringPrefix + functionName + "(" + functionArgs + ");";
        }

        public string JsForContentScriptMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Any())
            {
                foreach (var p in parameters)
                {
                    functionArgs = functionArgs + "'" + p + "',";
                }

                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return "return " + _silverLightJsStringPrefix + "content." + _scriptKey + functionName + "(" + functionArgs + ");";
        }

        public string JsForContentMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Any())
            {
                foreach (var p in parameters)
                {
                    functionArgs = functionArgs + "'" + p + "',";
                }

                //remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return "return " + _silverLightJsStringPrefix + "content." + functionName + "(" + functionArgs + ");";
        }

        private string JsForContentProperty(string propertyName)
        {
            return "return " + _silverLightJsStringPrefix + "content." + propertyName + ";";
        }

        private string JsForDirectProperty(string propertyName)
        {
            return "return " + _silverLightJsStringPrefix + propertyName + ";";
        }

        private string JsForSettingsProperty(string propertyName)
        {
            return "return " + _silverLightJsStringPrefix + "settings." + propertyName + ";";
        }

        private string JsForContentScriptGetProperty(string propertyName)
        {
            return "return " + _silverLightJsStringPrefix + "content." + _scriptKey + propertyName + ";";
        }

        private string JsForContentScriptSetProperty(string propertyName, string parameters)
        {
            return "return " + _silverLightJsStringPrefix + "content." + _scriptKey + propertyName + "='" + parameters + "';";
        }

        public object DirectMethod(string functionName, params string[] parameters)
        {
            return _javaScriptExecutor.ExecuteScript(JsForDirectMethod(functionName, parameters));
        }

        public object ContentMethod(string functionName, params string[] parameters)
        {
            return _javaScriptExecutor.ExecuteScript(JsForContentMethod(functionName, parameters));
        }

        private object ContentProperty(string propertyName)
        {
            return _javaScriptExecutor.ExecuteScript(JsForContentProperty(propertyName));
        }

        private object DirectProperty(string propertyName)
        {
            return _javaScriptExecutor.ExecuteScript(JsForDirectProperty(propertyName));
        }

        private object SettingsProperty(string propertyName)
        {
            return _javaScriptExecutor.ExecuteScript(JsForSettingsProperty(propertyName));
        }

        public object GetPropertyValue(string propertyName)
        {
            return _javaScriptExecutor.ExecuteScript(JsForContentScriptGetProperty(propertyName));
        }

        public object SetPropertyValue(string propertyName, string parameters)
        {
            return _javaScriptExecutor.ExecuteScript(JsForContentScriptSetProperty(propertyName, parameters));
        }

        public object Call(string functionName, params string[] parameters)
        {
            return _javaScriptExecutor.ExecuteScript(JsForContentScriptMethod(functionName, parameters));
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
            return (string)ContentProperty("accessibility");
        }

        public void CreateFromXaml(string xamlContent, string namescope)
        {
            ContentMethod("createFromXaml", xamlContent, namescope);
        }

        public string FindName(string objectName)
        {
            return (string)ContentMethod("findName", objectName);
        }

        public bool FullScreen()
        {
            return Convert.ToBoolean(ContentProperty("fullScreen"));
        }

        public string InitParams()
        {
            return (string)DirectProperty("initParams");
        }

        public bool IsLoaded()
        {
            return Convert.ToBoolean(DirectProperty("isLoaded"));
        }

        public string Root()
        {
            return (string)DirectProperty("root");
        }

        public string Background()
        {
            return (string)SettingsProperty("background");
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
            return (string)DirectProperty("source");
        }
    }
}