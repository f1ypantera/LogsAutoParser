using System.Collections.Generic;
using System.Configuration;
using System.Xml;


namespace LogsAutoParser
{
    public class BackupDirectoriesSection : IConfigurationSectionHandler
    {
        public string location { get; set; }
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<string> myConfigObject = new List<string>();

            foreach (XmlNode childNode in section.ChildNodes)
            {
                foreach (XmlAttribute attrib in childNode.Attributes)
                {
                    myConfigObject.Add(location = attrib.Value);
                }
            }
            return myConfigObject;
        }
    }
}
