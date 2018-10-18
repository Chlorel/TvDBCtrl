using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApp
{
    public static class CParams
    {
        public static string    AppPath     = "";

        public static string    TV_ApiKey   = "";
        public static string    TV_Langue   = "";

        public static void Load ()
        {
            string ParamFile = $"{AppPath}\\Params.xml";

            TV_ApiKey = GetXmlInfoString(ParamFile, "APIKey");
            TV_Langue = GetXmlInfoString(ParamFile, "Langue");
        }

        public static void Save ()
        {
            string ParamFile = $"{AppPath}\\Params.xml";

            XmlDocument XmlDoc      = new XmlDocument();
            XmlNode     XmlRootNode = XmlDoc.CreateElement("Params");
            XmlDoc.AppendChild(XmlRootNode);
            XmlNode XmlAPIKey = XmlDoc.CreateElement("APIKey");
            XmlAPIKey.InnerText = TV_ApiKey;
            XmlRootNode.AppendChild(XmlAPIKey);
            XmlNode XmlLangue = XmlDoc.CreateElement("Langue");
            XmlLangue.InnerText = TV_Langue;
            XmlRootNode.AppendChild(XmlLangue);

            XmlDoc.Save(ParamFile);
        }

        private static string GetXmlInfoString(string sXmlFile, string sXmlNode)
        {
            string sInfo = "";

            XmlDocument XmlDoc = new XmlDocument();
            XmlNodeList noeuds = null;

            try
            {
                // Ouverture du fichier xml
                XmlDoc.Load(sXmlFile);
                // Recherche de la liste de noeuds
                noeuds = XmlDoc.DocumentElement.GetElementsByTagName(sXmlNode);

                try
                {
                    if (noeuds.Count == 1)
                    {
                        sInfo = noeuds[0].InnerText;
                    }
                    else
                    {
                        sInfo = "";
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

            }
            catch (Exception)
            {
            }

            return sInfo;
        }

    }
}
