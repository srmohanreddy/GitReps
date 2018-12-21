using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestStack.White.UIItems.Finders;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NDATask
{
    public static class Utilities
    {
        public static string GetXMLData(string filePath, string xPath, string childNode)
        {
            string value = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                XmlElement rootNode = xmlDocument.DocumentElement;
                XmlNodeList xmlNodeList = rootNode.SelectNodes(xPath);

                foreach (XmlNode node in xmlNodeList)
                {
                    value = node[childNode].InnerText;
                }

            }
            catch
            {
                throw;
            }
            return value;
        }
        public static void UploadFile(string wndTiltle, string filePath)
        {
            var addwindow = TestStack.White.Desktop.Instance.Windows();
            for (int i = 0; i <= addwindow.Count - 1; i++)
            {
                if (addwindow[i].Name.Contains(wndTiltle))
                {
                    addwindow[i].Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByText("File name:")).Enter(filePath);
                    addwindow[i].Get<TestStack.White.UIItems.Panel>(SearchCriteria.ByText("Open")).Click();
                }
            }

        }
        public static void SaveScreenshot(IWebDriver driver, string filePath)
        {
           // Screenshot imageFile = ((ITakesScreenshot)driver).GetScreenshot();
           // imageFile.SaveAsFile(@"c:\image.jpeg", ScreenshotImageFormat.Jpeg);
           //// DefaultWait < IWebElement > dw= new DefaultWait<IWebElement>(element);

           // dw.Timeout = TimeSpan.FromSeconds(10);
           // dw.PollingInterval = TimeSpan.FromSeconds(5);

        }


        public static void VerifyOnFrame(string verificationText)
        {
            //IWebDriver driver;
            //driver.SwitchTo().Frame(0);
            //driver.SwitchTo().DefaultContent();
            
        }
    }
}
